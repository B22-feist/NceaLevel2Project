using System.Diagnostics;
using ActualSchoolInternal.Models.Utilities;

namespace ActualSchoolInternal.Models.Database.Database.Data;

/*This class is used to accessing the database
 from the view model*/
public class GetData
{
	/*This method is used to get the questions from the database
	 depending on the difficultly, operation, type of question(i.e. quadratic, linear)
	 Current question is used to make sure that the same setting don't generate the same answer*/
	public string DataBaseOutput(string? difficultly, string? operation, string? typeOfQuestion, string? currentQuestion)
	{
		using QuestionContext context = new();

		IQueryable<Questions>? databaseOutput = null;

		/*This switch block performs a query based on if
		 difficultly, operating or type of question are null
		 and puts the return value into database output*/
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

		 /*This get the path to the solution root to add an image*/
		string pathToFolder = GetFolderPath.FolderPath();

		/*If the request comes back */
		if (databaseOutput == null || !databaseOutput.Any())
		{
			return pathToFolder + "ActualSchoolInternal/Assets/NoQuestionsMatchYourSettings.png";
		}

		Random generateBitmap = new();
		List<string>? possibleString= [];

		foreach (Questions questionStringLocation in databaseOutput)
		{
			possibleString?.Add(questionStringLocation.Location);
		}
		
		string outPutLocation;
		try
		{
			
			while (true)
			{
				outPutLocation = pathToFolder+possibleString?[generateBitmap.Next(0, possibleString.Count)];

				if (outPutLocation == currentQuestion) continue;
				Console.WriteLine(outPutLocation);
				return outPutLocation;
			}
			
		}
		catch (Exception e)
		{
			outPutLocation = pathToFolder+"ActualSchoolInternal/Assets/NoQuestionsMatchYourSettings.png";
			
			Console.WriteLine(e);
			
			return outPutLocation;
		}
		
	}
	
	public string? UrlLocation(string currentQuestionString)
	{
		string currentQuestionStringAppend = currentQuestionString[GetFolderPath.FolderPath().Length..];
		using QuestionContext context = new();

		IQueryable<Questions> currentDbSetQuestions = context.Questions!
			.Where(x => x.Location == currentQuestionStringAppend);

		Questions dbQuestion = currentDbSetQuestions.ToArray()[0];

		int questionId = dbQuestion.Id;

		IQueryable<Answers> answerDb = context.Answers
			.Where(x => x.Id == questionId);

		Answers urlAnswer = answerDb.ToArray()[0];

		string? url = urlAnswer.TutorialUrl;
		return url;
	}

	public string GetAnswersLocation(string currentQuestionString)
	{
		string currentQuestionStringAppend = currentQuestionString[GetFolderPath.FolderPath().Length..];

		using QuestionContext context = new();

		Debug.Assert(context.Questions != null);
		IQueryable<Questions> questionsDb = context.Questions;
		IQueryable<Answers> answerDb = context.Answers;

		Questions fileId = questionsDb
				.Where(x => x.Location == currentQuestionStringAppend)
				.ToArray()[0];
		
			Answers answerLocation = answerDb
				.Where(x => x.Id == fileId.Id)
				.ToArray()[0];
			
		return GetFolderPath.FolderPath() + answerLocation.LocationOfFile;
	}
}