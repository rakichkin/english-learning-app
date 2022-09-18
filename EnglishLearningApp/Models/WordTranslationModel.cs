namespace EnglishLearningApp.Models
{
	public class WordTranslationModel
	{
		public string Word { get; }
		public string Translation { get; }

		public WordTranslationModel(string word, string translation)
		{
			Word = word;
			Translation = translation;
		}

		public override bool Equals(object? obj)
		{
			return obj is WordTranslationModel wtl &&
				wtl.Word.Equals(Word) &&
				wtl.Translation.Equals(Translation);
		}
	}
}
