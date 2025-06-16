using System.Diagnostics;
using System.Reactive;
using ActualSchoolInternal.Models.Database.Database.Data;
using ActualSchoolInternal.Models.Utilities;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

public class ReactiveViewModel : ReactiveObject
{
	/*Get data object  to be used in class*/
	private readonly GetData _checkQuestion = new();
	
	/*Backing field of current question*/
	private Bitmap? _currentQuestion;

	/*Image displayed to user*/
	public Bitmap? CurrentQuestion
	{
		get => _currentQuestion;

		set => this.RaiseAndSetIfChanged(ref _currentQuestion, value );
	}

	/*hyperlink to tutorial url*/
	private string? _tutorialUrl;
	public string? TutorialUrl
	{
		get => _tutorialUrl;
		
		set => this.RaiseAndSetIfChanged(ref _tutorialUrl, value);
	}

	/*Type of question*/		
	public bool Logarithm { get; set; }
	public bool Exponential { get; set; }
	public bool Quadratic { get; set; }
	public bool Linear { get; set; }

	/*Difficultly of question*/
	public bool Excellence { get; set; }
	public bool Merit { get; set; }
	public bool Achieved { get; set; }

	/*Operating of question*/
	public bool Simplify { get; set; }
	public bool Expand { get; set; }
	public bool Factorise { get; set; }
	public bool Solve { get; set; }

	/*This is a variable that is used to operate on the current question path
	 without effect the current question*/
	private string? CurrentStringPath { get; set; }
	
	/*This holds the current answers location*/
	private string? AnswerLocation { get; set; }

	public ReactiveViewModel()
	{
		/*Adds button commands*/
		QuestionGenerateCommand = ReactiveCommand.Create(QuestionGenerator);
		
		DisplayAnswerCommand = ReactiveCommand.Create(DisplayAnswer);
		
	}
	
	/*Buttons command bindings*/
	public ReactiveCommand<Unit, Unit> QuestionGenerateCommand { get; }
	
	public ReactiveCommand<Unit, Unit> DisplayAnswerCommand { get; }

	private void QuestionGenerator()
	{
		/*Set current string path to a question, can be Questions don't match settings*/
		CurrentStringPath  = _checkQuestion.DataBaseOutput(QuestionGeneratorSettings.QuestionDifficutly(Achieved, Merit, Excellence),
			QuestionGeneratorSettings.Operation(Logarithm, Exponential, Quadratic, Linear),
			QuestionGeneratorSettings.TypeOfQuestion(Simplify, Expand, Factorise, Solve), CurrentStringPath);

		/*Checks if the current string path is No questions match your settings*/
		if (CurrentStringPath == (GetFolderPath.FolderPath() + "ActualSchoolInternal/Assets/NoQuestionsMatchYourSettings.png"))
		{
			CurrentQuestion = new Bitmap(GetFolderPath.FolderPath() +
			                             "ActualSchoolInternal/Assets/NoQuestionsMatchYourSettings.png");
		}
		
		/*Updates current question*/
		else
		{
			CurrentQuestion = new Bitmap(CurrentStringPath);
			TutorialUrl = _checkQuestion.UrlLocation(CurrentStringPath);
		}
	}

	/*Gets answer location and sets Current question to Answer location*/
	private  void DisplayAnswer()
	{
		if (CurrentStringPath != null) AnswerLocation = _checkQuestion.GetAnswersLocation(CurrentStringPath);

		if (AnswerLocation != null)
			CurrentQuestion = new Bitmap(AnswerLocation);
	}

	
}