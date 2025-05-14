using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

public class ReactiveViewModel : ReactiveObject
{
	private Bitmap _CurrentQuestion;

	public Bitmap CurrentQuestion
	{
		get => _CurrentQuestion;

		set => this.RaiseAndSetIfChanged(ref _CurrentQuestion, value );
	}
	
	
}