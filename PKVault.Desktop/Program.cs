using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Photino.NET;
using Photino.NET.Server;
using PKVault.Core;
using Serilog;

namespace PKVault.Desktop;

class Program
{
    private static readonly bool WindowsOS =
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    private static readonly bool LinuxOS =
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    private static readonly bool MacOS =
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    private static readonly Assembly Assembly =
        Assembly.GetExecutingAssembly();

    private static readonly string AssemblyStaticPrefix =
        "PKVault.Desktop.Resources.wwwroot.";

    private static readonly DesktopMessageJsonContext messageJsonContext = new(new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    });

    private static IFileChooser fileChooser =
        new DefaultFileChooser();

    private static Task<IServiceProvider>? SetupTask;

    [DllImport("kernel32.dll")]
    private static extern bool AttachConsole(uint dwProcessId);

    private const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;

    [STAThread]
    private static void Main(string[] args)
    {
        AttachConsole(ATTACH_PARENT_PROCESS);

        Core.Program.Initialize();

        if (LinuxOS)
        {
            fileChooser = new LinuxFileChooser();

            Environment.SetEnvironmentVariable(
                "__NV_DISABLE_EXPLICIT_SYNC",
                "1");
        }

        try
        {
            SettingsService.FlatpakMigrateIfAny();

            var window = new PhotinoWindow();

            var staticServerRun = SetupServer(out var baseUrl);

            _ = StartStaticServerAsync(staticServerRun);

            window.RegisterWindowCreatedHandler((sender, e) =>
            {
                Log.Debug("CREATED");
            });

            window.RegisterWindowClosingHandler((sender, e) =>
            {
                if (SetupTask is null || !SetupTask.IsCompletedSuccessfully)
                {
                    return false;
                }

                var emptyActionList =
                    Core.Program.HasEmptyActionList(SetupTask.Result);

                if (!emptyActionList)
                {
                    var result = window.ShowMessage(
                        "PKVault",
                        "You have unsaved changes. Are you sure ?",
                        PhotinoDialogButtons.OkCancel);

                    if (result == PhotinoDialogResult.Cancel)
                    {
                        return true;
                    }
                }

                return false;
            });

            SetupWindow(window, baseUrl);

            SetupTask = SetupCore();

            InjectIntoFrontend(window);

            window.WaitForClose();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An unhandled exception occurred during startup");
        }
        finally
        {
            LogUtil.Dispose();
        }
    }

    private static async Task StartStaticServerAsync(
        Func<Task> staticServerRun)
    {
        try
        {
            Log.Information("Starting PKVault local static web server...");

            await staticServerRun();

            Log.Warning("PKVault local static web server stopped.");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "PKVault local static web server failed.");
        }
    }

    private static async Task<IServiceProvider> SetupCore()
    {
        var services = new ServiceCollection();

        Core.Program.ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        await Core.Program.SetupData(serviceProvider);

        return serviceProvider;
    }

    private static void LogEmbeddedResourceNames()
    {
        var resources = Assembly.GetManifestResourceNames();

        Log.Information(
            "Embedded resource count: {ResourceCount}",
            resources.Length);

        var staticResources = resources
            .Where(resourceName => resourceName.StartsWith(
                AssemblyStaticPrefix,
                StringComparison.OrdinalIgnoreCase))
            .OrderBy(resourceName => resourceName)
            .ToArray();

        Log.Information(
            "Embedded wwwroot resource count: {ResourceCount}",
            staticResources.Length);

        foreach (var resourceName in staticResources)
        {
            Log.Debug(
                "Embedded web resource: {ResourceName}",
                resourceName);
        }
    }

    private static Func<Task> SetupServer(out string baseUrl)
    {
        LogEmbeddedResourceNames();

        var server = PhotinoServer.CreateStaticFileServer(
            [],
            49152,
            16000,
            "wwwroot",
            out baseUrl);

        Log.Information(
            "Local static web server prepared for {BaseUrl}",
            baseUrl);

        var contentTypeProvider = new FileExtensionContentTypeProvider();

        server.Map("{**catchAll}", async context =>
        {
            var requestPath = context.Request.Path.Value ?? "";

            try
            {
                if (requestPath.StartsWith(
                    "/api/",
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (SetupTask is null)
                    {
                        Log.Error(
                            "API request received before PKVault core setup began: {RequestPath}",
                            requestPath);

                        context.Response.StatusCode =
                            StatusCodes.Status503ServiceUnavailable;

                        context.Response.ContentType = "text/plain";

                        await context.Response.WriteAsync(
                            "PKVault is still starting.");

                        return;
                    }

                    var serviceProvider = await SetupTask;

                    using var scope = serviceProvider.CreateScope();

                    var coreRouter = scope.ServiceProvider
                        .GetRequiredService<CoreRouter>();

                    var request = context.Request;
                    var response = context.Response;

                    var queryString = request.QueryString.HasValue
                        ? request.QueryString.Value ?? ""
                        : "";

                    var result = await coreRouter.Dispatch(
                        scope.ServiceProvider,
                        request.Method,
                        request.Path,
                        queryString,
                        request.Body);

                    response.StatusCode =
                        result.StatusCode ?? StatusCodes.Status200OK;

                    if (result.Header is not null)
                    {
                        foreach (var (key, values) in result.Header)
                        {
                            response.Headers[key] = values;
                        }
                    }

                    if (result is CoreFileResponse fileResponse)
                    {
                        response.ContentType =
                            fileResponse.ContentType ??
                            "application/octet-stream";

                        var contentDispositionHeader =
                            new System.Net.Mime.ContentDisposition
                            {
                                FileName = fileResponse.File.FileName,
                                DispositionType = "attachment"
                            };

                        response.Headers.Append(
                            "Content-Disposition",
                            contentDispositionHeader.ToString());

                        if (fileResponse.LastModified is not null)
                        {
                            response.GetTypedHeaders().LastModified =
                                fileResponse.LastModified;
                        }

                        await using var fileResponseStream =
                            fileResponse.File.Stream;

                        await fileResponseStream.CopyToAsync(
                            response.Body);

                        return;
                    }

                    if (result is CoreJSONResponse jsonResponse)
                    {
                        response.ContentType =
                            jsonResponse.ContentType ??
                            "application/json";

                        if (jsonResponse.Data is not null)
                        {
                            var typeInfo =
                                RouteJsonContext.DefaultWithOptions
                                    .GetTypeInfo(jsonResponse.Data.GetType())
                                ?? throw new InvalidOperationException(
                                    $"Missing TypeInfo for type " +
                                    $"{jsonResponse.Data.GetType()}");

                            await JsonSerializer.SerializeAsync(
                                response.Body,
                                jsonResponse.Data,
                                typeInfo);
                        }

                        return;
                    }

                    return;
                }

                if (requestPath.Equals(
                    "/.well-known/appspecific/com.chrome.devtools.json",
                    StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.StatusCode =
                        StatusCodes.Status404NotFound;

                    return;
                }

                var requestedPath = requestPath.TrimStart('/');

                if (string.IsNullOrWhiteSpace(requestedPath))
                {
                    requestedPath = "index.html";
                }

                var pathSegments = requestedPath.Split(
                    '/',
                    StringSplitOptions.RemoveEmptyEntries);

                if (pathSegments.Length == 0)
                {
                    context.Response.StatusCode =
                        StatusCodes.Status404NotFound;

                    return;
                }

                var fileName = pathSegments[^1];

                var directories = pathSegments.SkipLast(1);

                var resourcePath = string.Join(
                    '.',
                    directories
                        .Select(directory => directory.Replace('-', '_'))
                        .Append(fileName));

                var streamKey =
                    $"{AssemblyStaticPrefix}{resourcePath}";

                Log.Debug(
                    "Static request {RequestPath}; looking for embedded resource {ResourceKey}",
                    requestPath,
                    streamKey);

                using var resourceStream =
                    Assembly.GetManifestResourceStream(streamKey);

                if (resourceStream is null)
                {
                    Log.Error(
                        "Embedded static resource not found. Request: {RequestPath}; key: {ResourceKey}",
                        requestPath,
                        streamKey);

                    context.Response.StatusCode =
                        StatusCodes.Status404NotFound;

                    context.Response.ContentType = "text/plain";

                    await context.Response.WriteAsync(
                        $"Missing embedded resource: {streamKey}");

                    return;
                }

                var extension = Path.GetExtension(fileName);

                if (!contentTypeProvider.Mappings.TryGetValue(
                    extension,
                    out var contentType))
                {
                    contentType = "application/octet-stream";
                }

                context.Response.ContentType = contentType;

                await resourceStream.CopyToAsync(context.Response.Body);
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to process HTTP request {RequestPath}",
                    requestPath);

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode =
                        StatusCodes.Status500InternalServerError;

                    context.Response.ContentType = "text/plain";

                    await context.Response.WriteAsync(
                        "PKVault encountered an error while processing this request. " +
                        "Check the application log for details.");
                }
            }
        });

        return () => server.RunAsync();
    }

    private static void SetupWindow(
        PhotinoWindow window,
        string baseUrl)
    {
        string? temporaryIconPath = null;

        var iconResourceName =
            $"{AssemblyStaticPrefix}icon.ico";

        try
        {
            using Stream? iconStream =
                Assembly.GetManifestResourceStream(iconResourceName);

            if (iconStream is null)
            {
                Log.Warning(
                    "Embedded icon resource was not found: {ResourceName}. " +
                    "Starting PKVault with the default system icon.",
                    iconResourceName);
            }
            else
            {
                temporaryIconPath = Path.Combine(
                    Path.GetTempPath(),
                    $"pkvault-icon-{Guid.NewGuid():N}.ico");

                using var iconFileStream =
                    File.Create(temporaryIconPath);

                iconStream.CopyTo(iconFileStream);

                Log.Debug(
                    "Extracted embedded icon resource to {IconPath}",
                    temporaryIconPath);
            }
        }
        catch (Exception ex)
        {
            Log.Warning(
                ex,
                "Could not extract the embedded PKVault icon. " +
                "Starting with the default system icon.");
        }

        window
            .SetTitle("PKVault")
            .SetUseOsDefaultSize(WindowsOS)
            .SetSize(1280, 755)
            .Center()
            .SetResizable(true);

        if (!string.IsNullOrWhiteSpace(temporaryIconPath) &&
            File.Exists(temporaryIconPath))
        {
            window.SetIconFile(temporaryIconPath);
        }

        window
            .RegisterWindowCreatedHandler((sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(temporaryIconPath) &&
                    File.Exists(temporaryIconPath))
                {
                    try
                    {
                        File.Delete(temporaryIconPath);
                    }
                    catch (Exception ex)
                    {
                        Log.Debug(
                            ex,
                            "Unable to delete temporary icon file {IconPath}",
                            temporaryIconPath);
                    }
                }
            })
            .Load(baseUrl + "/index.html");
    }

    private static void InjectIntoFrontend(PhotinoWindow window)
    {
        window.RegisterWebMessageReceivedHandler(async (sender, message) =>
        {
            Log.Debug("Message received: {Message}", message);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            try
            {
                var desktopRequest = JsonSerializer.Deserialize(
                    message,
                    messageJsonContext.DesktopRequestMessage);

                if (desktopRequest is null)
                {
                    Log.Warning(
                        "Received an invalid or empty desktop request: {Message}",
                        message);

                    return;
                }

                string responseSerialized = "";

                switch (desktopRequest.type)
                {
                    case FileExploreRequestMessage.TYPE:
                    {
                        var fileExploreRequest = JsonSerializer.Deserialize(
                            message,
                            messageJsonContext.FileExploreRequestMessage);

                        if (fileExploreRequest is null)
                        {
                            Log.Warning(
                                "Could not deserialize FileExplore request.");

                            return;
                        }

                        var appBasePath = MatcherUtil
                            .NormalizePath(
                                SettingsService.GetAppDirectory())
                            .Replace('/', '\\');

                        string? GetDefaultPath()
                        {
                            if (fileExploreRequest.basePath == default)
                            {
                                return null;
                            }

                            return MatcherUtil
                                .NormalizePath(
                                    Path.Combine(
                                        appBasePath,
                                        fileExploreRequest.basePath))
                                .Replace('/', '\\');
                        }

                        string ToRelative(string path)
                        {
                            path = MatcherUtil
                                .NormalizePath(path)
                                .Replace('/', '\\');

                            if (path.StartsWith(
                                appBasePath,
                                StringComparison.OrdinalIgnoreCase))
                            {
                                var pathWithoutBase =
                                    MatcherUtil.NormalizePath(
                                        path[appBasePath.Length..]);

                                if (pathWithoutBase.Length > 0 &&
                                    pathWithoutBase[0] == '/')
                                {
                                    pathWithoutBase =
                                        pathWithoutBase[1..];
                                }

                                return MatcherUtil.NormalizePath(
                                    Path.Combine(
                                        ".",
                                        pathWithoutBase));
                            }

                            return MatcherUtil.NormalizePath(path);
                        }

                        var results = await fileChooser.ShowChooserAsync(
                            window,
                            directoryOnly: fileExploreRequest.directoryOnly,
                            multiSelect: fileExploreRequest.multiselect,
                            defaultPath: GetDefaultPath());

                        var response = new FileExploreResponseMessage(
                            type: fileExploreRequest.type,
                            id: fileExploreRequest.id,
                            directoryOnly: fileExploreRequest.directoryOnly,
                            values: [.. results.Select(ToRelative)]);

                        responseSerialized = JsonSerializer.Serialize(
                            response,
                            messageJsonContext.FileExploreResponseMessage);

                        break;
                    }

                    case OpenFolderRequestMessage.TYPE:
                    {
                        var openFolderRequest = JsonSerializer.Deserialize(
                            message,
                            messageJsonContext.OpenFolderRequestMessage);

                        if (openFolderRequest is null)
                        {
                            Log.Warning(
                                "Could not deserialize OpenFolder request.");

                            return;
                        }

                        var normalizedPath = MatcherUtil.NormalizePath(
                            Path.Combine(
                                SettingsService.GetAppDirectory(),
                                openFolderRequest.path));

                        var path = normalizedPath.Replace('/', '\\');

                        if (WindowsOS)
                        {
                            var arguments = openFolderRequest.isDirectory
                                ? path
                                : string.Format(
                                    "/e, /select, \"{0}\"",
                                    path);

                            var processStartInfo = new ProcessStartInfo
                            {
                                FileName = "explorer.exe",
                                Arguments = arguments,
                                UseShellExecute = false
                            };

                            Log.Debug(
                                "RUN explorer.exe {Arguments}",
                                arguments);

                            Process.Start(processStartInfo)
                                ?.WaitForInputIdle();
                        }
                        else if (LinuxOS)
                        {
                            var arguments = $"\"{(
                                openFolderRequest.isDirectory
                                    ? MatcherUtil.NormalizePath(path)
                                    : Path.GetDirectoryName(
                                        MatcherUtil.NormalizePath(path))!
                            )}\"";

                            var processStartInfo = new ProcessStartInfo
                            {
                                FileName = "xdg-open",
                                Arguments = arguments,
                                UseShellExecute = false
                            };

                            Log.Debug(
                                "RUN xdg-open {Arguments}",
                                arguments);

                            try
                            {
                                Process.Start(processStartInfo);
                            }
                            catch
                            {
                                var fallback = new ProcessStartInfo
                                {
                                    FileName = openFolderRequest.path,
                                    UseShellExecute = true
                                };

                                Process.Start(fallback);
                            }
                        }
                        else if (MacOS)
                        {
                            var arguments =
                                $"-R \"{MatcherUtil.NormalizePath(normalizedPath)}\"";

                            var processStartInfo = new ProcessStartInfo
                            {
                                FileName = "open",
                                Arguments = arguments,
                                UseShellExecute = false
                            };

                            Log.Debug(
                                "RUN open {Arguments}",
                                arguments);

                            Process.Start(processStartInfo);
                        }
                        else
                        {
                            throw new PlatformNotSupportedException(
                                $"OS not supported: " +
                                $"{RuntimeInformation.OSDescription}");
                        }

                        break;
                    }

                    case StartFinishRequestMessage.TYPE:
                        break;

                    default:
                        Log.Warning(
                            "Received unhandled desktop message type: {MessageType}",
                            desktopRequest.type);
                        break;
                }

                if (string.IsNullOrEmpty(responseSerialized))
                {
                    return;
                }

                if (WindowsOS)
                {
                    responseSerialized = responseSerialized.Replace(
                        "\\",
                        "\\\\");
                }

                var data = $"{{ \"detail\": {responseSerialized} }}";

                await window.SendWebMessageAsync(data);

                Log.Debug("Response = {Response}", data);
            }
            catch (JsonException ex)
            {
                Log.Error(
                    ex,
                    "JsonException during frontend message receipt.");
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Unhandled exception during frontend message processing.");
            }
        });
    }
}
