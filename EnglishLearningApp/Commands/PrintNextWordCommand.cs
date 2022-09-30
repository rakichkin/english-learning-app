using EnglishLearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishLearningApp.Commands
{
	public class PrintNextWordCommand : CommandBase
	{
		private readonly TestViewModel _testViewModel;

		public PrintNextWordCommand(TestViewModel testViewModel)
		{
			_testViewModel = testViewModel;
		}

		public override void Execute(object? parameter)
		{
			if(++_testViewModel.CurrentIndexInList < _testViewModel.WordTranslationPairs.Count)
			{
				var nextPair = _testViewModel.WordTranslationPairs[_testViewModel.CurrentIndexInList];
				_testViewModel.Word = nextPair.Word;
				_testViewModel.InputTranslation = string.Empty;
			}
		}
	}
}
