
using EnglishLearningApp.Stores;
using EnglishLearningApp.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace EnglishLearningApp.Commands
{
	public class ShowTestViewCommand : CommandBase
	{
		private readonly StartupViewModel _startupViewModel;
		private readonly NavigationStore _navigationStore;

		public ShowTestViewCommand(StartupViewModel startupViewModel, NavigationStore navigationStore)
		{
			_startupViewModel = startupViewModel;
			_navigationStore = navigationStore;

			_startupViewModel.PropertyChanged += OnViewModelPropertyChanged;
		}

		public override void Execute(object? parameter)
		{
			_navigationStore.CurrentViewModel = new TestViewModel(_startupViewModel, _navigationStore);
		}

		private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if(e.PropertyName == nameof(_startupViewModel.IsFileLoaded))
			{
				OnCanExectuteChanged();
			}
		}

		public override bool CanExecute(object? parameter)
		{
			return _startupViewModel.IsFileLoaded && base.CanExecute(parameter);
		}
	}
}
