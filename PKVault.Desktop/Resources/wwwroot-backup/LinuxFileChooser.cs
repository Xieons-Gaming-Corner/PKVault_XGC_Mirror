using System;
using System.Linq;
using System.Threading.Tasks;
using Gtk;
using Photino.NET;
using Serilog;

public class LinuxFileChooser : IFileChooser
{
	public async Task<string[]> ShowChooserAsync(PhotinoWindow window, bool directoryOnly, bool multiSelect, string? defaultPath)
	{
		FileChooserAction action = (directoryOnly ? FileChooserAction.SelectFolder : FileChooserAction.Open);
		string title = (directoryOnly ? "Select a directory" : "Select a file");
		Window parent = null;
		try
		{
			parent = Window.ListToplevels().OfType<Window>().FirstOrDefault((Window w) => w.Visible);
		}
		catch (Exception exception)
		{
			Log.Logger.Warning(exception, "Failed to get parent window, dialog won't be modal");
		}
		FileChooserNative fileChooserNative = new FileChooserNative(title, parent, action, "_Open", "_Cancel");
		try
		{
			fileChooserNative.SelectMultiple = multiSelect;
			if (!string.IsNullOrEmpty(defaultPath))
			{
				fileChooserNative.SetCurrentFolder(defaultPath);
			}
			ResponseType responseType = (ResponseType)fileChooserNative.Run();
			Log.Logger.Debug($"GTK file chooser response = {responseType} / filenames = {string.Join(',', fileChooserNative.Filenames)}");
			return (responseType == ResponseType.Accept) ? fileChooserNative.Filenames : Array.Empty<string>();
		}
		finally
		{
			((IDisposable)fileChooserNative)?.Dispose();
		}
	}
}
