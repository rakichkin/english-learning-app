using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			}
		}
	}
}
