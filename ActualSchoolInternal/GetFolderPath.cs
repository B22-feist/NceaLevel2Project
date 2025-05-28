namespace ActualSchoolInternal.Models.Utilities;

public static class GetFolderPath
{
	public static string? FolderPath()
	{
		return Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())?.ToString() ?? string.Empty)?.ToString() ?? string.Empty)?.ToString() ?? string.Empty)+"/";
	}
}