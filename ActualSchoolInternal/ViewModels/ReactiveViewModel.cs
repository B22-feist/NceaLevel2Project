using System.Reactive;
using ActualSchoolInternal.Models.Database.Database.Data;
using ActualSchoolInternal.Models.Utilities;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

public class ReactiveViewModel : ReactiveObject
{
	private readonly GetData _checkQuestion = new();
	
	private Bitmap? _currentQuestion;

	public Bitmap? CurrentQuestion
	{
		get => _currentQuestion;

		set => this.RaiseAndSetIfChanged(ref _currentQuestion, value );
	}

	private string? _tutorialUrl;
	public string? TutorialUrl
	{
		get => _tutorialUrl;
		
		set => this.RaiseAndSetIfChanged(ref _tutorialUrl, value);
	}

	public bool Logarithm { get; set; }
	public bool Exponential { get; set; }
	public bool Quadratic { get; set; }
	public bool Linear { get; set; }

	public bool Excellence { get; set; }
	public bool Merit { get; set; }
	public bool Achieved { get; set; }


	public bool Simplify { get; set; }
	public bool Expand { get; set; }
	public bool Factorise { get; set; }
	public bool Solve { get; set; }

	private static string? CurrentStringPath { get; set; }
	
	private string AnswerLocation { get; set; }

	public ReactiveViewModel()
	{
		QuestionGenerateCommand = ReactiveCommand.Create(QuestionGenerator);
		
		DisplayAnswerCommand = ReactiveCommand.Create(DisplayAnswer);
	}
	
	public ReactiveCommand<Unit, Unit> QuestionGenerateCommand { get; }
	
	public ReactiveCommand<Unit, Unit> DisplayAnswerCommand { get; }

	private void QuestionGenerator()
	{
		CurrentStringPath =  _checkQuestion.DataBaseOutput(QuestionGeneratorSettings.QuestionDifficutly(Achieved, Merit, Excellence),
			QuestionGeneratorSettings.Operation(Logarithm, Exponential, Quadratic, Linear),
			QuestionGeneratorSettings.TypeOfQuestion(Simplify, Expand, Factorise, Solve), CurrentStringPath);


		if (CurrentStringPath == (GetFolderPath.FolderPath() + "ActualSchoolInternal/Assets/BlankScreen.png")) return;
		CurrentQuestion = new Bitmap(CurrentStringPath);
		TutorialUrl = _checkQuestion.UrlLocation(CurrentStringPath);
	}

	private void DisplayAnswer()
	{
		AnswerLocation = _checkQuestion.GetAnswersLocation(CurrentStringPath);

		CurrentQuestion = new Bitmap(AnswerLocation);
	}
}