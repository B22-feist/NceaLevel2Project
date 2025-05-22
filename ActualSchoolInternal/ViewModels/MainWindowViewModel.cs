using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
	public ReactiveViewModel ReactiveViewModel { get; } = new();
}