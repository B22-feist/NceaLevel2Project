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

		/*If the request comes back empty, returns No questions match image*/
		if (databaseOutput == null || !databaseOutput.Any())
		{
			return pathToFolder + "ActualSchoolInternal/Assets/NoQuestionsMatchYourSettings.png";
		}
		
		Random generateBitmap = new();
		List<string>? possibleString= [];

		/*Adds the different Questions to a list*/
		foreach (Questions questionStringLocation in databaseOutput)
		{
			possibleString?.Add(questionStringLocation.Location);
		}
		
		string outPutLocation;
		try
		{
			/*tries to generate a new question
			 if generate is equal to current question then generate a new question
			 if fails, displays no questions match settings
			 and writes error to stdin*/
			for(int numRepeats =0; numRepeats < 100; numRepeats++ )
			{
				 outPutLocation = pathToFolder+possibleString?[generateBitmap.Next(0, possibleString.Count)];
				

				if (outPutLocation == currentQuestion) continue;
				Console.WriteLine(outPutLocation);
				return outPutLocation;
			}
			
			Console.WriteLine();
		}
		catch (Exception e)
		{
			outPutLocation = pathToFolder+"ActualSchoolInternal/Assets/NoQuestionsMatchYourSettings.png";
			
			Console.WriteLine(e);
			
			return outPutLocation;
		}

		return pathToFolder + "ActualSchoolInternal/Assets/NoQuestionsMatchYourSettings.png";
	}
	
	/*Get tutorial location from question table*/
	public string? UrlLocation(string currentQuestionString)
	{
		/*gets the location of file from sln root*/
		string currentQuestionStringAppend = currentQuestionString[GetFolderPath.FolderPath().Length..];
		/*sets the db context*/
		using QuestionContext context = new();
		
		/*WON'T BE NULL AS ! IS USED, IF CHANGED, CHECK IF NULL
		 Gets the db record associated with the file*/
		IQueryable<Questions> currentDbSetQuestions = context.Questions!
			.Where(x => x.Location == currentQuestionStringAppend);

		/*Parses the db set into an array of question class and extracts the tutorial url*/
		string? urlLocation = currentDbSetQuestions.ToArray()[0].TutorialUrl;
		
		return urlLocation;
	}

	/*Gets the answer when show answer is pressed*/
	public string GetAnswersLocation(string currentQuestionString)
	{
		/*gets current question location*/
		string currentQuestionStringAppend = currentQuestionString[GetFolderPath.FolderPath().Length..];

		/*sets db context*/
		using QuestionContext context = new();

		/*check if context is null and if not creates question and answer
		 db sets*/
		Debug.Assert(context.Questions != null);
		IQueryable<Questions> questionsDb = context.Questions;
		IQueryable<Answers> answerDb = context.Answers;

		/*gets id of current question*/
		Questions fileId = questionsDb
				.Where(x => x.Location == currentQuestionStringAppend)
				.ToArray()[0];
		
		/*gets the answer location*/ 
        Answers answerLocation = answerDb 
            .Where(x => x.Id == fileId.Id) 
            .ToArray()[0];
        
        /*returns answer location*/
		return GetFolderPath.FolderPath() + answerLocation.LocationOfFile;
	}
}