using EnglishLearningApp.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishLearningApp.Services
{
	public class DefaultDialogService
	{
		//private readonly StartupViewModel _startupViewModel;
		public string PathToFile { get; set; }

		//public DefaultDialogService(StartupViewModel startupViewModel)
		//{
		//	_startupViewModel = startupViewModel;
		//}

		public bool OpenFileDialog()
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Text files|*.txt;*.docx";

			if(openFileDialog.ShowDialog() == true)
			{
				PathToFile = openFileDialog.FileName;
				return true;
			}
			return false;
		}
	}
}
