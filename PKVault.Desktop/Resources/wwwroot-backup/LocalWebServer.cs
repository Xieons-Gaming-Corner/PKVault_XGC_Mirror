using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PKVault.Backend;
using Serilog;

public class LocalWebServer
{
	public static readonly string HOST_URL = $"http://localhost:{Program.GetAvailablePort()}";

	private readonly IHost? webHost;

	public LocalWebServer()
	{
		try
		{
			Log.Logger.Information("LocalWebServer build for " + HOST_URL);
			webHost = Host.CreateDefaultBuilder().ConfigureWebHostDefaults(delegate(IWebHostBuilder webBuilder)
			{
				webBuilder.UseUrls(HOST_URL).UseStartup<Startup>();
			}).Build();
		}
		catch (Exception exception)
		{
			Log.Logger.Error(exception, "");
		}
	}

	public async Task<Func<Task>?> Start(string[] args)
	{
		if (webHost == null)
		{
			return null;
		}
		Log.Logger.Information("LocalWebServer start for " + HOST_URL);
		Task.Run(delegate
		{
			webHost.Run();
		});
		return await Program.SetupData(webHost, args);
	}

	public async Task Stop()
	{
		if (webHost != null)
		{
			await webHost.StopAsync();
			webHost.Dispose();
		}
	}

	public bool HasEmptyActionList()
	{
		if (webHost == null)
		{
			return true;
		}
		return Program.HasEmptyActionList(webHost);
	}
}
