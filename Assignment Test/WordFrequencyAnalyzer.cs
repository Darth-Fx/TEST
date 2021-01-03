using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
	{
		private readonly Func<string, List<string>> textPrepareForFrpcessingFunction;
			
		public WordFrequencyAnalyzer(Func<string, List<string>> textSeperateFunction)
		{
			//caller kan hier andere split seperators meegeven via de constructor. Voor nu hard-coded op 'spaces'
			this.textPrepareForFrpcessingFunction =
				(text) => text.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
		}

		public int CalculateHighestFrequency(string text)
		{
			if (text == null) throw new ArgumentNullException(nameof(text));

			var seperatedText = textPrepareForFrpcessingFunction(text);

			return seperatedText.GroupBy(v => v)
					  .OrderByDescending(g => g.Count())
					  .FirstOrEmpty()
					  .Count();
		}

		public int CalculateFrequencyForWord(string text, string word)
		{
			if (text == null) throw new ArgumentNullException(nameof(text));
			if (word == null) throw new ArgumentNullException(nameof(word));

			var seperatedText = textPrepareForFrpcessingFunction(text);

			return seperatedText.GroupBy(v => v)
						  .OrderByDescending(g => g.Count())
						  .Where(g => g.Key == word)
						  .Select(g => g.Count())
						  .FirstOrDefault();						  
		}

		public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
		{
			if (text == null) throw new ArgumentNullException(nameof(text));

			var seperatedText = textPrepareForFrpcessingFunction(text);

			return seperatedText.OrderBy(w => w)
						.GroupBy(v => v)
						.OrderByDescending(g => g.Count())
						.Take(n)
						.Select(g => WordFrequency.Create(g.Key, g.Count()))
						.ToList();
		}
	}

}
