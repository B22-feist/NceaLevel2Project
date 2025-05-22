using ActualSchoolInternal.Models.Utilities;
using Avalonia.Media.Imaging;

namespace ActualSchoolInternal.Models.Database.Database.Data;

public class GetData
{
	public Bitmap? DataBaseOutput(string? difficultly, string? operation, string? typeOfQuestion)
	{
		using QuestionContext context = new();

		IQueryable<Questions>? databaseOutput = null;

		switch (difficultly)
		{
			case null when typeOfQuestion == null && operation == null:
				
				databaseOutput = context.Questions;
				break;
			case null when typeOfQuestion == null && operation != null:

				if (context.Questions != null)
					databaseOutput = context.Questions
						.Where(q => q.Operation == operation);
				break;
			case null when typeOfQuestion != null && operation == null:
				
				if (context.Questions != null)
					databaseOutput = context.Questions
						.Where(q => q.TypeOfQuestion == typeOfQuestion);
				break;
			default:
			{
				if (difficultly != null && typeOfQuestion == null && operation == null)
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.Difficulty == difficultly);
				}
		
				else if (difficultly == null && typeOfQuestion != null && operation != null)
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.TypeOfQuestion == typeOfQuestion)
							.Where(q => q.Operation == operation);
				}
		
				else if (difficultly != null && typeOfQuestion == null && operation != null)
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.Difficulty == typeOfQuestion)
							.Where(q => q.Operation == operation);
				}

				else if (difficultly != null & typeOfQuestion != null && operation == null)
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.TypeOfQuestion == typeOfQuestion)
							.Where(q => q.Operation == difficultly);
				}

				else if (difficultly != null & typeOfQuestion != null && operation != null)
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.TypeOfQuestion == typeOfQuestion)
							.Where(q => q.Operation == operation)
							.Where(q => q.Difficulty == difficultly);
				}

				break;
			}
		}
	

		List<Bitmap?> possibleAnswer = [];

		string pathToFolder = GetFolderPath.FolderPath();

		if (databaseOutput == null) return new Bitmap("ActualSchoolInternal/Assets/BlankScreen.png");
		foreach (Questions bitmap in databaseOutput)
		{
			possibleAnswer.Add(new Bitmap(pathToFolder+bitmap.Location));
		}

		Random generateBitmap = new();
		
		Bitmap? outPut = possibleAnswer[generateBitmap.Next(0,possibleAnswer.Count-1)];

		return outPut;
	}
}