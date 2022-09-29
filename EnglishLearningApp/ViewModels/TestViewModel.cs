using EnglishLearningApp.Commands;
using EnglishLearningApp.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using System.Windows.Markup;

namespace EnglishLearningApp.ViewModels
{
	public class TestViewModel : ViewModelBase
	{
		private readonly List<WordTranslationModel> _wordTranslationPairs;
		private readonly bool _isRandomChecked;

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

		private string _translation;
		public string Translation
		{
			get
			{
				return _translation;
			}
			set
			{
				_translation = value;
				OnPropertyChanged(nameof(Translation));
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
		public ICommand NextWordCommand { get; }

		public TestViewModel(StartupViewModel startupViewModel)
		{
			_wordTranslationPairs = startupViewModel.WordTranslationPairs;
			_isRandomChecked = startupViewModel.IsRandomChecked;

			CheckAnswerCommand = new CheckAnswerCommand(this);
			NextWordCommand = new NextWordCommand();

			if(startupViewModel.IsRandomChecked)
			{
				ShuffleElementsInList();
			}

			if(startupViewModel.CountOfWords < _wordTranslationPairs.Count)
			{
				_wordTranslationPairs.RemoveRange(startupViewModel.CountOfWords, _wordTranslationPairs.Count - startupViewModel.CountOfWords);
			}

			StartTest();
		}

		private void StartTest()
		{
			foreach(var pair in _wordTranslationPairs)
			{
				
			}
		}

		private void ShuffleElementsInList()
		{
			var random = new Random();

			for(int i = _wordTranslationPairs.Count - 1; i >= 1; i--)
			{
				int j = random.Next(i + 1);

				var temp = _wordTranslationPairs[j];
				_wordTranslationPairs[j] = _wordTranslationPairs[i];
				_wordTranslationPairs[i] = temp;
			}
		}
	}
}
