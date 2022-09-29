using EnglishLearningApp.ViewModels;

namespace EnglishLearningApp.Commands
{
	public class CheckAnswerCommand : CommandBase
	{
		private readonly TestViewModel _testViewModel;

		public string Word { get; set; }
		public string Translation { get; set; }

		public CheckAnswerCommand(TestViewModel testViewModel)
		{
			_testViewModel = testViewModel;
		}

		public override void Execute(object? parameter)
		{
			if(Word.Equals(Translation))
			{
				_testViewModel.Result = "True";
			}
			else
			{
				_testViewModel.Result = $"False. {Translation}";
			}
		}
	}
}
