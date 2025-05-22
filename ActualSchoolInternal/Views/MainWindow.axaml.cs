using ActualSchoolInternal.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ActualSchoolInternal.Views;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private readonly ReactiveViewModel _viewModel = new();
	private void GenerateQuestionButton(object? sender, RoutedEventArgs e)
	{
		_viewModel.GenerateQuestion ++;
	}

	public string? NotImplementedException { get; set; }
}