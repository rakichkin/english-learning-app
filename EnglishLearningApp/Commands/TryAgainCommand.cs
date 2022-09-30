using EnglishLearningApp.Stores;
using EnglishLearningApp.ViewModels;

namespace EnglishLearningApp.Commands
{
	public class TryAgainCommand : CommandBase
	{
		private readonly NavigationStore _navigationStore;

		public TryAgainCommand(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
		}

		public override void Execute(object? parameter)
		{
			_navigationStore.CurrentViewModel = new StartupViewModel(_navigationStore);
		}
	}
}
