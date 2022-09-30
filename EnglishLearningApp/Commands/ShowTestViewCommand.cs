using EnglishLearningApp.Stores;
using EnglishLearningApp.ViewModels;

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
		}

		public override void Execute(object? parameter)
		{
			_navigationStore.CurrentViewModel = new TestViewModel(_startupViewModel, _navigationStore);
		}
	}
}
