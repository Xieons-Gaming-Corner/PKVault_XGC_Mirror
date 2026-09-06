using System.Threading.Tasks;
using Photino.NET;

public interface IFileChooser
{
	Task<string[]> ShowChooserAsync(PhotinoWindow window, bool directoryOnly, bool multiSelect, string? defaultPath);
}
