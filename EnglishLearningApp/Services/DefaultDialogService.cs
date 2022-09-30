using Microsoft.Win32;

namespace EnglishLearningApp.Services
{
	public class DefaultDialogService
	{
		public string PathToFile { get; set; }

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
