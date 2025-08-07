namespace ActualSchoolInternal.Models.Database.Database.Data;

public class AddData
{
	public int AddInfo(string? difficulty, string? equation, string? operation, string? fileLocation, string? tutorialUrl, string? answerLocation)
	{
		if (difficulty == null || equation == null || operation == null || fileLocation == null || answerLocation == null)
		{
			return -1;
		}
		
		using QuestionContext context = new();

		Questions addQuestion = new()
		{
			Difficulty = difficulty,
			Location = fileLocation,
			Operation = operation,
			TutorialUrl = tutorialUrl,
			Name = "UserDefined",
			TypeOfQuestion = equation
		};

		Answers addAnswer = new()
		{
			LocationOfFile = answerLocation,
			Name = "UserDefined",
			Question = addQuestion
		};
		
		addQuestion.Answer= addAnswer;
		context.Questions?.Add(addQuestion);
		return context.SaveChanges() > 0 ? 1 : 0;
	}
}