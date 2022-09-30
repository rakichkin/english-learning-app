using EnglishLearningApp.Stores;
using EnglishLearningApp.ViewModels;

namespace EnglishLearningApp.Commands
{
	public class GoToNextStepCommand : CommandBase
	{
		private readonly TestViewModel _testViewModel;
		private readonly NavigationStore _navigationStore;

		public GoToNextStepCommand(TestViewModel testViewModel, NavigationStore navigationStore)
		{
			_testViewModel = testViewModel;
			_navigationStore = navigationStore;
		}

		public override void Execute(object? parameter)
		{
			if(++_testViewModel.CurrentIndexInList < _testViewModel.WordTranslationPairs.Count)
			{
				var nextPair = _testViewModel.WordTranslationPairs[_testViewModel.CurrentIndexInList];
				_testViewModel.Word = nextPair.Word;

				_testViewModel.Progress = $"Word {_testViewModel.CurrentIndexInList + 1}/{_testViewModel.WordTranslationPairs.Count}";
				_testViewModel.InputTranslation = string.Empty;
				_testViewModel.Result = string.Empty;
			}
			else
			{
				_navigationStore.CurrentViewModel = new FinalViewModel(_testViewModel, _navigationStore);
			}
		}
	}
}
