using System.Reactive;
using ActualSchoolInternal.Models.Database.Database.Data;
using ActualSchoolInternal.Models.Utilities;
using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

public class AddQuestionViewModel : PageViewModelBase
{
	public override bool CanNavigateNext 
	{
		get => false;
		protected set => throw new NotSupportedException(); 
	}

	public override bool CanNavigatePrevious
	{
		get => true; 
		protected set => throw new NotSupportedException();
	}

	/*Answer File Location*/
	public string? AnswerLocation { get; set; }

	/*Question File Location*/
	public string? QuestionFileLocation { get; set; }
	
	/*Tutorial Url link*/
	public string? TutorialUrlLink
	{
		get => _tutorialUrlLink;
		set => this.RaiseAndSetIfChanged(ref _tutorialUrlLink, value);
	}

	private string? _tutorialUrlLink;

	/*equation*/
	public bool Log { get; set; }
	public bool Exponential { get; set; }
	public bool Quadratic { get; set; }
	public bool Linear { get; set; }
	
	/*Difficultly*/
	public bool Excellence { get; set; }
	public bool Merit { get; set; }
	public bool Achieved { get; set; }
	
	/*Operation*/
	public bool Simplify { get; set; }
	public bool Expand { get; set; }
	public bool Factorise { get; set; }
	public bool Solve { get; set; }
	
	public ReactiveCommand<Unit, Unit> AddQuestionCommand  { get; set; }
	/*Colour if action succeeds or fails*/
	public string Colour
	{
		get => _colour; 
		set => this.RaiseAndSetIfChanged(ref _colour, value);
	}
	
	private string _colour;

	private void AddQuestion()
	{
		AddData dataAdd = new();
		
		string difficulty = QuestionGeneratorSettings.QuestionDifficultly(Achieved, Merit, Excellence);

		string equation = QuestionGeneratorSettings.Equation(Log, Exponential, Quadratic, Linear);
		
		string operation = QuestionGeneratorSettings.Operation(Simplify, Expand, Factorise, Solve);

		if (difficulty != string.Empty || equation != string.Empty || operation != string.Empty)
		{
			int returnValue = dataAdd.AddInfo(difficulty, equation, operation, QuestionFileLocation, TutorialUrlLink,
				AnswerLocation);

			_colour = returnValue > 1 ? "Green" : "Red";
		}

		else
			_colour = "Red";
	}

	public AddQuestionViewModel()
	{
		_colour = "White";
		AddQuestionCommand = ReactiveCommand.Create(AddQuestion);
	}
}