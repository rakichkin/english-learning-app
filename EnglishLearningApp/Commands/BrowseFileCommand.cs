using System.IO;
using System.Linq;

using EnglishLearningApp.Services;
using EnglishLearningApp.ViewModels;

namespace EnglishLearningApp.Commands
{
	public class BrowseFileCommand : CommandBase
	{
		private readonly StartupViewModel _startupViewModel;
		public BrowseFileCommand(StartupViewModel startupViewModel)
		{
			_startupViewModel = startupViewModel;
		}

		public override void Execute(object? parameter)
		{
			DefaultDialogService defaultDialogService = new DefaultDialogService();

			if(defaultDialogService.OpenFileDialog())
			{
				_startupViewModel.WordTranslationPairs = Path.GetExtension(defaultDialogService.PathToFile) == ".docx"
					? ParsingTextFileService.ParseDocxFile(defaultDialogService.PathToFile)
					: ParsingTextFileService.ParseTxtFile(defaultDialogService.PathToFile);

				_startupViewModel.CountOfWords = _startupViewModel.WordTranslationPairs.Count();

				_startupViewModel.IsFileLoaded = true;
			}
		}

		public override bool CanExecute(object? parameter)
		{
			return base.CanExecute(parameter);
		}
	}
}
