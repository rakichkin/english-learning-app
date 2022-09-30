using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using GemBox.Document;

using EnglishLearningApp.Models;


namespace EnglishLearningApp.Services
{
	public static class ParsingTextFileService
	{
		public static List<WordTranslationModel> ParseDocxFile(string path)
		{
			ComponentInfo.SetLicense("FREE-LIMITED-KEY");
			var document = DocumentModel.Load(path);
			string text = document.Content.ToString();

			var wordsAndTranslations = SplitText(text);
			return wordsAndTranslations;
		}

		public static List<WordTranslationModel> ParseTxtFile(string path)
		{
			var sr = new StreamReader(path);
			var text = sr.ReadToEnd();
			sr.Close();

			var wordsAndTranslations = SplitText(text);
			return wordsAndTranslations;
		}

		private static List<WordTranslationModel> SplitText(string text)
		{
			string[] lineSeparators = new[] { "\r\n", "\n" };
			string[] wordSeparators = new[] { " - ", " – " };

			var splittedText = text.Split(lineSeparators, StringSplitOptions.None).Where(x => x != "").ToArray();
			var wordsAndTranslations = new List<WordTranslationModel>();

			foreach(var line in splittedText)
			{
				string word = line.Split(wordSeparators, StringSplitOptions.None)[0].ToLower();
				string translation = line.Split(wordSeparators, StringSplitOptions.None)[1].ToLower();
				wordsAndTranslations.Add(new WordTranslationModel(word, translation));
			}

			return wordsAndTranslations;
		}
	}
}
