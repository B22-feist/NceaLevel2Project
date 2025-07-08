using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

public class RemoveQuestionViewModel : PageViewModelBase
{
	private List<string> _possibleRemoves;
	public List<string> PossibleRemoves
	{
		get => _possibleRemoves;

		set => this.RaiseAndSetIfChanged(ref _possibleRemoves, value);
	}

	public override bool CanNavigateNext
	{
		get => false; 
		protected set => throw new NotSupportedException();
		
	}
	public override bool CanNavigatePrevious { 
		get => true; 
		protected set => throw new NotSupportedException(); 
	}
}