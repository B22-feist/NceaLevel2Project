using ActualSchoolInternal.Models.Utilities;
using Avalonia.Media.Imaging;

namespace ActualSchoolInternal.Models.Database.Database.Data;

public class GetData
{
	public Bitmap? DataBaseOutput(string? difficultly, string? operation, string? typeOfQuestion, Bitmap? currentQuestion)
	{
		using QuestionContext context = new();

		IQueryable<Questions>? databaseOutput = null;

		 switch (difficultly)
		{
			case "" when typeOfQuestion == "" && operation == "":
				
				databaseOutput = context.Questions;
				break;
			case "" when typeOfQuestion == "" && operation != "":

				if (context.Questions != null)
					databaseOutput = context.Questions
						.Where(q => q.Operation == operation);
				break;
			case "" when typeOfQuestion != "" && operation == "":
				
				if (context.Questions != null)
					databaseOutput = context.Questions
						.Where(q => q.TypeOfQuestion == typeOfQuestion);
				break;
			default:
			{
				if (difficultly != "" && typeOfQuestion == "" && operation == "")
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.Difficulty == difficultly);
				}
		
				else if (difficultly == "" && typeOfQuestion != "" && operation != "")
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.TypeOfQuestion == typeOfQuestion)
							.Where(q => q.Operation == operation);
				}
		
				else if (difficultly != "" && typeOfQuestion == "" && operation != "")
				{
					if (context.Questions != null)
						databaseOutput = context.Questions
							.Where(q => q.Difficulty == typeOfQuestion)
							.Where(q => q.Operation == operation);
				}

				else switch (difficultly != "" && typeOfQuestion != "")
				{
					case true when operation == "":
					{
						if (context.Questions != null)
							databaseOutput = context.Questions
								.Where(q => q.TypeOfQuestion == typeOfQuestion)
								.Where(q => q.Operation == difficultly);
						break;
					}
					case true when true:
					{
						if (context.Questions != null)
							databaseOutput = context.Questions
								.Where(q => q.Operation == typeOfQuestion)
								.Where(q => q.TypeOfQuestion == operation)
								.Where(q => q.Difficulty == difficultly);
						break;
					}
				}

				break;
			}
		}
	

		List<Bitmap?> possibleAnswer = [];

		string? pathToFolder = GetFolderPath.FolderPath();

		if (databaseOutput != null && !databaseOutput.Any() && pathToFolder is not null or "") return new Bitmap(pathToFolder + "ActualSchoolInternal/Assets/BlankScreen.png");
		
        if (databaseOutput != null)
			foreach (Questions bitmap in databaseOutput)
			{
				possibleAnswer.Add(new Bitmap(pathToFolder + bitmap.Location));
			}
        
        

		Random generateBitmap = new();

		try
		{
			Bitmap? outPut;
			while (true)
			{
				outPut = possibleAnswer[generateBitmap.Next(0, possibleAnswer.Count)];
				
				if (outPut != currentQuestion) break;
			}

			return outPut;
		}
		catch (Exception e)
		{
			Bitmap outPut = new(pathToFolder+"ActualSchoolInternal/Assets/BlankScreen.png");
			
			Console.WriteLine(e);
			
			return outPut;
		}
		
	}
}