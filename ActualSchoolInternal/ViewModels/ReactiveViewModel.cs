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

	public int GenerateQuestion { get; set; }

	public ReactiveViewModel()
	{
		this.WhenAnyValue(x => GenerateQuestion)
			.Subscribe(_ =>
			{
				CurrentQuestion = _checkQuestion.DataBaseOutput(QuestionGeneratorSettings.QuestionDifficutly(Achieved, Merit, Excellence),
					QuestionGeneratorSettings.Operation(Logarithm, Exponential, Quadratic, Linear),
					QuestionGeneratorSettings.TypeOfQuestion(Simplify, Expand, Factorise, Solve));
			});
	}
}