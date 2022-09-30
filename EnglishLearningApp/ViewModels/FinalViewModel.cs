using System.Windows.Input;

using EnglishLearningApp.Commands;
using EnglishLearningApp.Stores;

namespace EnglishLearningApp.ViewModels
{
	public class FinalViewModel : ViewModelBase
	{
		private readonly TestViewModel _testViewModel;
		private readonly NavigationStore _navigationStore;

		private string _conclusion;
		public string Conclusion
		{
			get
			{
				return _conclusion;
			}
			set
			{
				_conclusion = value;
				OnPropertyChanged(nameof(Conclusion));
			}
		}

		public ICommand TryAgainCommand { get; }

		public FinalViewModel(TestViewModel testViewModel, NavigationStore navigationStore)
		{
			_testViewModel = testViewModel;
			_navigationStore = navigationStore;

			TryAgainCommand = new TryAgainCommand(_navigationStore);

			Conclusion = $"Done!\n {_testViewModel.CountOfCorrectAnswers} correct answers out of {_testViewModel.WordTranslationPairs.Count}";
		}
	}
}
