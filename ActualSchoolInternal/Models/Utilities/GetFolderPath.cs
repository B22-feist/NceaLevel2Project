namespace ActualSchoolInternal.Models.Utilities;

public static class GetFolderPath
{
	public static string FolderPath()
	{
		return Directory.GetCurrentDirectory();
	}
}