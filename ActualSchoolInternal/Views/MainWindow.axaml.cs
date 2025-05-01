using ActualSchoolInternal.Models.Database.Database.Data;
using Avalonia.Controls;

namespace ActualSchoolInternal.Views;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		
		QuestionContext context = new QuestionContext();
		
		Console.WriteLine(context);
	}
}