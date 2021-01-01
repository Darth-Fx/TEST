namespace Test
{
	public class WordFrequency : IWordFrequency
	{
		private readonly string word;
		private readonly int frequenty;

		public string Word => word;
		public int Frequency => frequenty;

		private WordFrequency(string word, int frequenty)
		{
			this.word = word;
			this.frequenty = frequenty;
		}

		public static IWordFrequency Create(string word, int frequenty) => new WordFrequency(word, frequenty);
	}
}