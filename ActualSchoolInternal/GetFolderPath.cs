using System.Text;

namespace ActualSchoolInternal.Models.Utilities;

public static class GetFolderPath
{
	/*Gets the folder path to sln root*/
	public static string FolderPath()
	{
		/*Gets the folder path to sln root, as binary starts in
		 bin folder lots of get parents are added*/
		StringBuilder slnLocation = new( Directory.GetParent(
			Directory.GetParent(
				Directory.GetParent(
					Directory.GetParent(
						Directory.GetCurrentDirectory())?.ToString() ?? string.Empty)?.ToString() ?? string.Empty)?.ToString() ?? string.Empty)+"/");

		/*Changes all \\ to / to keep file deliminators consistenient accross program*/
		for (int currentLocation = 0; currentLocation < slnLocation.Length; currentLocation++)
		{
			if (slnLocation[currentLocation] != '\\') continue;
			slnLocation[currentLocation] = '/';
		}
		
		string fixLocation = slnLocation.ToString();
		
		return fixLocation;
	}
}