using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

public abstract class PageViewModelBase : ReactiveObject
{
	public abstract bool CanNavigateNext { get; protected set; }
	
	public abstract bool CanNavigatePrevious { get; protected set; }

}