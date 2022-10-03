using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using EnglishLearningApp.Models;


namespace EnglishLearningApp.Services
{
	public static class ParsingTextFileService
	{
		public static List<WordTranslationModel> ParseDocxFile(string path) // https://learn.microsoft.com/en-us/answers/questions/340644/what39s-the-fastest-way-to-read-a-docx-file-line-b.html
		{
			string text = string.Empty;
			using(WordprocessingDocument wordDocument = WordprocessingDocument.Open(path, false))
			{
				var body = wordDocument.MainDocumentPart.Document.Body;
				foreach(Paragraph p in wordDocument.MainDocumentPart.Document.Body.Descendants<Paragraph>())
				{
					text += p.InnerText.ToString() + '\n';
				}
			}

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
