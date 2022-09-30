using EnglishLearningApp.ViewModels;

namespace EnglishLearningApp.Commands
{
	public class CheckAnswerCommand : CommandBase
	{
		private readonly TestViewModel _testViewModel;

		public CheckAnswerCommand(TestViewModel testViewModel)
		{
			_testViewModel = testViewModel;
		}

		public override void Execute(object? parameter)
		{
			var currentPair = _testViewModel.WordTranslationPairs[_testViewModel.CurrentIndexInList];
			if(currentPair.Translation.Equals(_testViewModel.InputTranslation))
			{
				_testViewModel.Result = "The answer is correct!";
			}
			else
			{
				_testViewModel.Result = $"Wrong. Correct translation is {currentPair.Translation}";
			}
		}
	}
}
