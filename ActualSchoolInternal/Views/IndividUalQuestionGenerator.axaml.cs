using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ActualSchoolInternal.Views;

public partial class IndividualQuestionGenerator : Window
{
	
	public IndividualQuestionGenerator()
	{
		InitializeComponent();
	}
	/*Opens the url in the browser*/
	public void UrlGoTo(object? sender, RoutedEventArgs e)
	{
		/*checks that the args aren't null*/
		if (sender is not HyperlinkButton hyperlinkButton || hyperlinkButton.NavigateUri == null) return;
		/*Set url to string*/
		string url = hyperlinkButton.NavigateUri.ToString();
		/*Tries to open the url in the browser*/
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = url,
				UseShellExecute = true
			});
		}
		catch (Exception exception)
		{
			Console.WriteLine(exception);
			throw;
		}
	}
}