using DocumentFormat.OpenXml.Office.Drawing;
using EnglishLearningApp.Stores;
using EnglishLearningApp.ViewModels;
using EnglishLearningApp.Views;
using System.ComponentModel;

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

			_testViewModel.PropertyChanged += OnViewModelPropertyChanged;
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

				if(_testViewModel.CurrentIndexInList == _testViewModel.WordTranslationPairs.Count - 1)
				{
					_testViewModel.NextStepBtnContent = "Finish";
				}
			}
			else
			{
				_navigationStore.CurrentViewModel = new FinalViewModel(_testViewModel, _navigationStore);
			}

			_testViewModel.IsTranslationChecked = false;
		}
		
		private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if(e.PropertyName == nameof(_testViewModel.IsTranslationChecked))
			{
				OnCanExectuteChanged();
			}
		}

		public override bool CanExecute(object? parameter)
		{
			return _testViewModel.IsTranslationChecked && base.CanExecute(parameter);
		}
	}
}
