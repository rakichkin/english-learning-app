using EnglishLearningApp.Models;
using EnglishLearningApp.Services;

namespace EnglishLearningApp.tests
{
	public class ParsingTextFileServiceTest
	{
		private string _pathToTestFilesFolder;
		[SetUp]
		public void Setup()
		{
			_pathToTestFilesFolder = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "EnglishLearningApp.tests\\testFiles\\");
			
		}

		[Test]
		public void DocxFileParse()
		{
			var list = ParsingTextFileService.ParseDocxFile($"{_pathToTestFilesFolder}test.docx");
			Assert.AreEqual(new WordTranslationModel("hello", "привет"), list[0]);
			Assert.AreEqual(new WordTranslationModel("how are you", "как дела"), list[1]);
		}

		[Test]
		public void TxtFileParse()
		{
			var list = ParsingTextFileService.ParseTxtFile($"{_pathToTestFilesFolder}test.txt");
			Assert.AreEqual(new WordTranslationModel("hello", "привет"), list[0]);
			Assert.AreEqual(new WordTranslationModel("how are you", "как дела"), list[1]);
		}
	}
}
