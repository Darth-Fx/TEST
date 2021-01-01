using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
	{
		private readonly Func<string, List<string>> textPrepareForFrpcessingFunction;

		public WordFrequencyAnalyzer(string text, Func<string, List<string>> textSeperateFunction)
		{
			this.textPrepareForFrpcessingFunction = textSeperateFunction;
		}

		public int CalculateHighestFrequency(string text)//
		{
			var seperatedText = textPrepareForFrpcessingFunction(text);

			return seperatedText.GroupBy(v => v)
					  .OrderByDescending(g => g.Count())
					  .First()
					  .Count();
		}

		public int CalculateFrequencyForWord(string text, string word)
		{
			var seperatedText = textPrepareForFrpcessingFunction(text);

			return seperatedText.GroupBy(v => v)
						  .OrderByDescending(g => g.Count())
						  .Where(g => g.Key == word)
						  .Select(g => g.Count())
						  .First();
		}

		public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
		{
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
