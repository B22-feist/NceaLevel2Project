using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

/*This is the class that the view uses to access the view model*/
public partial class MainWindowViewModel : ReactiveObject
{
	public ReactiveViewModel ReactiveViewModel { get; } = new();
}