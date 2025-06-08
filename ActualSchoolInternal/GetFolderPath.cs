using System.Text;

namespace ActualSchoolInternal.Models.Utilities;

public static class GetFolderPath
{
	public static string FolderPath()
	{
		StringBuilder slnLocation = new( Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())?.ToString() ?? string.Empty)?.ToString() ?? string.Empty)?.ToString() ?? string.Empty)+"/");

		for (int currentLocation = 0; currentLocation < slnLocation.Length; currentLocation++)
		{
			if (slnLocation[currentLocation] != '\\') continue;
			slnLocation[currentLocation] = '/';
		}
		
		string fixLocation = slnLocation.ToString();
		
		return fixLocation;
	}
}