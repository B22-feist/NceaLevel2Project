﻿using System.Windows.Input;
using DynamicData;
using ReactiveUI;

namespace ActualSchoolInternal.ViewModels;

/*This is the class that the view uses to access the view model*/
public class MainWindowViewModel : ReactiveObject
{
	private readonly PageViewModelBase[] _pages =
	{
		new IndividualQuestionGeneratorViewModel(),
		new AddQuestionViewModel()
	};
	
	private PageViewModelBase _selectedPage;

	public PageViewModelBase SelectedPage
	{
		get => _selectedPage;
		set => this.RaiseAndSetIfChanged(ref _selectedPage, value);
	}
	
	public ICommand NavigateNextCommand { get; }

	private void NavigateNext()
	{
		int index = _pages.IndexOf(SelectedPage) + 1;
		
		SelectedPage = _pages[index];
	}
	
	public ICommand NavigatePreviousCommand { get; }

	private void NavigatePrevious()
	{
		int index = _pages.IndexOf(SelectedPage) - 1;
		SelectedPage = _pages[index];
	}

	public MainWindowViewModel()
	{
		_selectedPage = _pages[0];
		IObservable<bool> canNavNext = this.WhenAnyValue(x => x.SelectedPage.CanNavigateNext);
		IObservable<bool> canNavPrevious = this.WhenAnyValue(x => x.SelectedPage.CanNavigatePrevious);
		
		NavigateNextCommand = ReactiveCommand.Create(NavigateNext, canNavNext);
		NavigatePreviousCommand = ReactiveCommand.Create(NavigatePrevious, canNavPrevious);
	}
}