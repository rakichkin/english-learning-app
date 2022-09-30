using System;
using System.Collections.Generic;
using System.Windows.Input;

using EnglishLearningApp.Commands;
using EnglishLearningApp.Models;
using EnglishLearningApp.Stores;

namespace EnglishLearningApp.ViewModels
{
	public class TestViewModel : ViewModelBase
	{
		private readonly NavigationStore _navigationStore;
		private readonly bool _isTranslationToWordChecked;

		public List<WordTranslationModel> WordTranslationPairs { get; }
		public int CountOfCorrectAnswers { get; set; } = 0;
		public int CurrentIndexInList { get; set; } = 0;

		private string _progress;
		public string Progress
		{
			get
			{
				return _progress;
			}
			set
			{
				_progress = value;
				OnPropertyChanged(nameof(Progress));
			}
		}

		private string _word;
		public string Word
		{
			get
			{
				return _word;
			}
			set
			{
				_word = value;
				OnPropertyChanged(nameof(Word));
			}
		}

		private string _inputTranslation;
		public string InputTranslation
		{
			get
			{
				return _inputTranslation;
			}
			set
			{
				_inputTranslation = value;
				OnPropertyChanged(nameof(InputTranslation));
			}
		}

		private string _result;
		public string Result
		{
			get
			{
				return _result;
			}
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		public ICommand CheckAnswerCommand { get; }
		public ICommand PrintNextWordCommand { get; }

		public TestViewModel(StartupViewModel startupViewModel, NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;

			WordTranslationPairs = startupViewModel.WordTranslationPairs;
			_isTranslationToWordChecked = startupViewModel.IsTranslationToWordChecked;

			CheckAnswerCommand = new CheckAnswerCommand(this);
			PrintNextWordCommand = new GoToNextStepCommand(this, _navigationStore);

			if(startupViewModel.ShuffleElements)
			{
				ShuffleElementsInList();
			}

			if(startupViewModel.CountOfWords < WordTranslationPairs.Count)
			{
				WordTranslationPairs.RemoveRange(startupViewModel.CountOfWords, WordTranslationPairs.Count - startupViewModel.CountOfWords);
			}

			Progress = $"Word {CurrentIndexInList + 1}/{WordTranslationPairs.Count}";
			Word = WordTranslationPairs[CurrentIndexInList].Word;
		}

		private void ShuffleElementsInList()
		{
			var random = new Random();

			for(int i = WordTranslationPairs.Count - 1; i >= 1; i--)
			{
				int j = random.Next(i + 1);

				var temp = WordTranslationPairs[j];
				WordTranslationPairs[j] = WordTranslationPairs[i];
				WordTranslationPairs[i] = temp;
			}
		}
	}
}
