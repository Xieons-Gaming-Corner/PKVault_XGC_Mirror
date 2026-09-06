using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.StaticFiles;
using Photino.NET;
using Photino.NET.Server;
using PKVault.Backend;
using Serilog;

namespace PKVault.Desktop;

internal class Program
{
	private static readonly bool WindowsOS = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

	private static readonly bool LinuxOS = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

	private static readonly Assembly Assembly = System.Reflection.Assembly.GetExecutingAssembly();

	private static readonly string AssemblyStaticPrefix = "PKVault.Desktop.Resources.wwwroot.";

	private static readonly DesktopMessageJsonContext messageJsonContext = new DesktopMessageJsonContext(new JsonSerializerOptions
	{
		Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	});

	private static IFileChooser fileChooser = new DefaultFileChooser();

	[STAThread]
	private static void Main(string[] args)
	{
		LogUtil.Initialize();
		Log.Logger.Debug("ARGS: " + string.Join(' ', args));
		Log.Logger.Debug("OS : " + RuntimeInformation.OSDescription);
		Log.Logger.Debug("OS LANGUAGE : " + CultureInfo.CurrentUICulture.Name);
		Log.Logger.Debug("RID runtime : " + RuntimeInformation.RuntimeIdentifier);
		Log.Logger.Debug($"LinuxOS : {LinuxOS}");
		Log.Logger.Debug($"WindowsOS : {WindowsOS}");
		Log.Logger.Debug("Current directory : " + Directory.GetCurrentDirectory());
		Directory.SetCurrentDirectory(SettingsService.GetAppDirectory());
		Log.Logger.Debug("Current directory (fixed) : " + Directory.GetCurrentDirectory());
		if (LinuxOS)
		{
			fileChooser = new LinuxFileChooser();
			Environment.SetEnvironmentVariable("__NV_DISABLE_EXPLICIT_SYNC", "1");
		}
		try
		{
			PKVault.Backend.Program.Copyright();
			SettingsService.FlatpakMigrateIfAny();
			PhotinoWindow window = new PhotinoWindow();
			SetupStaticAssetsServer(out string baseUrl)();
			LocalWebServer server = new LocalWebServer();
			window.RegisterWindowCreatedHandler(async delegate
			{
				Log.Logger.Debug("CREATED");
				try
				{
					await (await SetupBackendServer(server, args))();
				}
				catch (Exception exception2)
				{
					Log.Fatal(exception2, "An unhandled exception occurred post window created");
					throw;
				}
			});
			window.RegisterWindowClosingHandler(delegate
			{
				if (!server.HasEmptyActionList() && window.ShowMessage("PKVault", "You have unsaved changes. Are you sure ?", PhotinoDialogButtons.OkCancel) == PhotinoDialogResult.Cancel)
				{
					return true;
				}
				server.Stop();
				return false;
			});
			SetupWindow(window, baseUrl);
			InjectIntoFrontend(window);
			window.WaitForClose();
		}
		catch (Exception exception)
		{
			Log.Fatal(exception, "An unhandled exception occurred during startup");
		}
		finally
		{
			LogUtil.Dispose();
		}
	}

	private static async Task<Func<Task>> SetupBackendServer(LocalWebServer server, string[] args)
	{
		return (await server.Start(args)) ?? ((Func<Task>)async delegate
		{
		});
	}

	private static Func<Task> SetupStaticAssetsServer(out string baseUrl)
	{
		WebApplication server = PhotinoServer.CreateStaticFileServer(Array.Empty<string>(), out baseUrl);
		FileExtensionContentTypeProvider contentTypeProvider = new FileExtensionContentTypeProvider();
		server.Map("{**catchAll}", async delegate(HttpContext context)
		{
			try
			{
				string displayUrl = context.Request.GetDisplayUrl();
				if (displayUrl.EndsWith("/.well-known/appspecific/com.chrome.devtools.json"))
				{
					context.Response.StatusCode = 404;
					return;
				}
				IEnumerable<string> source = displayUrl.Split('?')[0].Split('/').Skip(3);
				source.First();
				IEnumerable<string> source2 = source.SkipLast(1);
				string text = source.Last();
				string extension = Path.GetExtension(text);
				List<string> list = new List<string>();
				list.AddRange(source2.Select((string part) => part.Replace('-', '_')));
				list.Add(text);
				string text2 = string.Join('.', new ReadOnlySpan<string>(list.ToArray()));
				string text3 = AssemblyStaticPrefix + text2;
				Stream? obj = Assembly.GetManifestResourceStream(text3) ?? throw new ArgumentException("Stream not found for key " + text3 + ", uri " + displayUrl);
				contentTypeProvider.Mappings.TryGetValue(extension, out string value);
				context.Response.ContentType = value;
				await obj.CopyToAsync(context.Response.Body);
			}
			catch (Exception ex)
			{
				await ExceptionHandlingMiddleware.WriteExceptionResponse(context, ex);
			}
		});
		return () => server.RunAsync();
	}

	private static void SetupWindow(PhotinoWindow window, string baseUrl)
	{
		using Stream stream = Assembly.GetManifestResourceStream(AssemblyStaticPrefix + "icon.png");
		string tmpIconFilepath = Path.Combine(Path.GetTempPath(), "pkvault-icon.png");
		using FileStream destination = File.Create(tmpIconFilepath);
		stream.CopyTo(destination);
		window.SetTitle("PKVault").SetUseOsDefaultSize(WindowsOS).SetSize(1280, 755)
			.Center()
			.SetResizable(resizable: true)
			.SetIconFile(tmpIconFilepath)
			.RegisterWindowCreatedHandler(delegate
			{
				if (File.Exists(tmpIconFilepath))
				{
					File.Delete(tmpIconFilepath);
				}
			})
			.Load(baseUrl + "/index.html?server=" + LocalWebServer.HOST_URL);
	}

	private static void InjectIntoFrontend(PhotinoWindow window)
	{
		window.RegisterWebMessageReceivedHandler(async delegate(object? sender, string message)
		{
			Log.Logger.Debug("Message received: " + message);
			if (string.IsNullOrEmpty(message))
			{
				return;
			}
			try
			{
				DesktopRequestMessage? desktopRequestMessage = JsonSerializer.Deserialize(message, messageJsonContext.DesktopRequestMessage);
				string text = "";
				switch (desktopRequestMessage.type)
				{
				case "file-explore":
				{
					FileExploreRequestMessage fileExploreRequest = JsonSerializer.Deserialize(message, messageJsonContext.FileExploreRequestMessage);
					string appBasePath = MatcherUtil.NormalizePath(SettingsService.GetAppDirectory()).Replace('/', '\\');
					text = JsonSerializer.Serialize(await GetDialogResponse(), messageJsonContext.FileExploreResponseMessage);
					break;
				}
				case "open-folder":
				{
					OpenFolderRequestMessage openFolderRequestMessage = JsonSerializer.Deserialize(message, messageJsonContext.OpenFolderRequestMessage);
					string text2 = MatcherUtil.NormalizePath(Path.Combine(SettingsService.GetAppDirectory(), openFolderRequestMessage.path)).Replace('/', '\\');
					if (WindowsOS)
					{
						string text3 = (openFolderRequestMessage.isDirectory ? text2 : $"/e, /select, \"{text2}\"");
						ProcessStartInfo startInfo = new ProcessStartInfo
						{
							FileName = "explorer.exe",
							Arguments = text3,
							UseShellExecute = false
						};
						Log.Logger.Debug("RUN explorer.exe " + text3);
						Process.Start(startInfo)?.WaitForInputIdle();
					}
					else
					{
						if (!LinuxOS)
						{
							throw new PlatformNotSupportedException("OS not supported: " + RuntimeInformation.OSDescription);
						}
						string text4 = "\"" + (openFolderRequestMessage.isDirectory ? MatcherUtil.NormalizePath(text2) : Path.GetDirectoryName(MatcherUtil.NormalizePath(text2))) + "\"";
						ProcessStartInfo startInfo2 = new ProcessStartInfo
						{
							FileName = "xdg-open",
							Arguments = text4,
							UseShellExecute = false
						};
						Log.Logger.Debug("RUN xdg-open " + text4);
						try
						{
							Process.Start(startInfo2);
						}
						catch
						{
							Process.Start(new ProcessStartInfo
							{
								FileName = openFolderRequestMessage.path,
								UseShellExecute = true
							});
						}
					}
					break;
				}
				}
				if (!(text == ""))
				{
					if (WindowsOS)
					{
						text = text.Replace("\\", "\\\\");
					}
					string data = "{ \"detail\": " + text + " }";
					await window.SendWebMessageAsync(data);
					Log.Logger.Debug("Response = " + data);
				}
			}
			catch (JsonException exception)
			{
				Log.Error(exception, "JsonException during frontend message recept");
			}
		});
	}
}
