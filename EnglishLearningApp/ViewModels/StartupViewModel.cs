using EnglishLearningApp.Commands;
using EnglishLearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishLearningApp.ViewModels
{
	public class StartupViewModel : ViewModelBase
	{
		public string PathToFile { get; set; }
		public IEnumerable<WordTranslationModel> WordTranslationPairs { get; set; }

		public ICommand BrowseFileCommand { get; }
		public ICommand StartCommand { get; }

		public StartupViewModel()
		{
			BrowseFileCommand = new BrowseFileCommand(this);
			StartCommand = new StartCommand();
		}
	}
}
