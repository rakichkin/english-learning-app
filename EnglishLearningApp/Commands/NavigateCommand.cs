using EnglishLearningApp.Stores;
using EnglishLearningApp.ViewModels;

namespace EnglishLearningApp.Commands
{
	public class NavigateCommand : CommandBase
	{
		private readonly StartupViewModel _startupViewModel;
		private readonly NavigationStore _navigationStore;

		public NavigateCommand(StartupViewModel startupViewModel, NavigationStore navigationStore)
		{
			_startupViewModel = startupViewModel;
			_navigationStore = navigationStore;
		}

		public override void Execute(object? parameter)
		{
			_navigationStore.CurrentViewModel = new TestViewModel(_startupViewModel);
		}
	}
}
