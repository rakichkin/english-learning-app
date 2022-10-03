using EnglishLearningApp.ViewModels;
using System.ComponentModel;

namespace EnglishLearningApp.Commands
{
	public class CheckAnswerCommand : CommandBase
	{
		private readonly TestViewModel _testViewModel;

		public CheckAnswerCommand(TestViewModel testViewModel)
		{
			_testViewModel = testViewModel;

			_testViewModel.PropertyChanged += OnViewModelPropertyChanged;
		}

		public override void Execute(object? parameter)
		{
			var currentPair = _testViewModel.WordTranslationPairs[_testViewModel.CurrentIndexInList];
			if(currentPair.Translation.Equals(_testViewModel.InputTranslation))
			{
				_testViewModel.Result = "The answer is correct!";
				_testViewModel.CountOfCorrectAnswers++;
			}
			else
			{
				_testViewModel.Result = $"Wrong. Correct translation is {currentPair.Translation}";
			}
			_testViewModel.IsTranslationChecked = true;
		}

		private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if(e.PropertyName == nameof(_testViewModel.InputTranslation))
			{
				OnCanExectuteChanged();
			}
		}

		public override bool CanExecute(object? parameter)
		{
			return !string.IsNullOrEmpty(_testViewModel.InputTranslation) && base.CanExecute(parameter);
		}
	}
}
