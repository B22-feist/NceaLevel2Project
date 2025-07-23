using System.ComponentModel;

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

	public bool Logarithm { get; }
	public bool Exponential { get; }
	public bool Quadratic { get; }
	public bool Linear { get; }
	public bool Excellence { get; }
	public bool Merit { get; }
	public bool Achieved { get; }
	public bool Simplify { get; }
	public bool Expand { get; }
	public bool Factorise { get; }
	public bool Solve { get; }
}