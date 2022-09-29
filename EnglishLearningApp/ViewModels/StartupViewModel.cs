using EnglishLearningApp.Commands;
using EnglishLearningApp.Models;
using EnglishLearningApp.Stores;
using System.Collections.Generic;
using System.Windows.Input;

namespace EnglishLearningApp.ViewModels
{
	public class StartupViewModel : ViewModelBase
	{
		public string PathToFile { get; set; }
		public List<WordTranslationModel> WordTranslationPairs { get; set; }

		private int _countOfWords;
		public int CountOfWords
		{
			get
			{
				return _countOfWords;
			}
			set
			{
				_countOfWords = value;
				OnPropertyChanged(nameof(CountOfWords));
			}
		}

		private bool _isSequentialChecked;
		public bool IsSequentialChecked
		{
			get
			{
				return _isSequentialChecked;
			}
			set
			{
				_isSequentialChecked = value;
				OnPropertyChanged(nameof(IsSequentialChecked));
			}
		}

		private bool _isRandomChecked;
		public bool IsRandomChecked
		{
			get
			{
				return _isRandomChecked;
			}
			set
			{
				_isRandomChecked = value;
				OnPropertyChanged(nameof(IsRandomChecked));
			}
		}

		private bool _isWordToTranslationChecked;
		public bool IsWordToTranslationChecked
		{
			get
			{
				return _isWordToTranslationChecked;
			}
			set
			{
				_isWordToTranslationChecked = value;
				OnPropertyChanged(nameof(IsWordToTranslationChecked));
			}
		}

		private bool _isTranslationToWordChecked;
		public bool IsTranslationToWordChecked
		{
			get
			{
				return _isTranslationToWordChecked;
			}
			set
			{
				_isTranslationToWordChecked = value;
				OnPropertyChanged(nameof(IsTranslationToWordChecked));
			}
		}

		public ICommand BrowseFileCommand { get; }
		public ICommand StartCommand { get; }

		public StartupViewModel(NavigationStore navigationStore)
		{
			BrowseFileCommand = new BrowseFileCommand(this);
			StartCommand = new NavigateCommand(this, navigationStore);

			IsSequentialChecked = true;
			IsWordToTranslationChecked = true;
		}
	}
}
