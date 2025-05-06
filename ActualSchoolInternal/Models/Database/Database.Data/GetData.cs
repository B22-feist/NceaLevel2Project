using Avalonia.Media.Imaging;

namespace ActualSchoolInternal.Models.Database.Database.Data;

public class GetData
{
	public List<Bitmap> DataBaseOutput(string? difficultly, string? operation)
	{
		using QuestionContext context = new();

		IQueryable<Questions>? databaseOutput = null;
		switch (difficultly)
		{
			case null when operation == null:
				databaseOutput = context.Questions;
				break;
			case null:
				if (context.Questions != null) databaseOutput = context.Questions
						.Where(o => o.Operation == operation);
				break;
			default:
			{
				if (operation == null)
				{
					if (context.Questions != null) databaseOutput = context.Questions
							.Where(o => o.Difficulty == difficultly);
				}

				else if (operation != null && difficultly != null)
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(o => o.Difficulty == difficultly && o.Operation == operation);
				}

				break;
			}
		}
		
		List<Bitmap> output = new();

		string PathToFolder = GetFolderPath.FolderPath();

		if (databaseOutput == null) return output;
		foreach (Questions Bitmap in databaseOutput)
		{
			output.Add(new Bitmap(PathToFolder+Bitmap.Location));
		}

		return output;
	}
}