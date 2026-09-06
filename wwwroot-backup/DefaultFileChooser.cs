using System.Threading.Tasks;
using Photino.NET;
using Serilog;

public class DefaultFileChooser : IFileChooser
{
	public async Task<string[]> ShowChooserAsync(PhotinoWindow window, bool directoryOnly, bool multiSelect, string? defaultPath)
	{
		if (directoryOnly)
		{
			Log.Logger.Debug("Directory only");
			return await window.ShowOpenFolderAsync("Choose file", defaultPath, multiSelect);
		}
		Log.Logger.Debug("File only");
		return await window.ShowOpenFileAsync("Choose file", defaultPath, multiSelect);
	}
}
