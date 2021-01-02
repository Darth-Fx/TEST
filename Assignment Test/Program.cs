using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
			const string exampleText = @"The pipo sun sun sun sun sunsun sun shines over the lake zeta ypsolon xavi wawa vuut tipo sien rara quentin pipo open";
					  
			Func<string, List<string>> textSeperateFunction = (text) => text.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();


			var wordprocessor = new WordFrequencyAnalyzer(textSeperateFunction);

            Console.WriteLine($"{wordprocessor.CalculateHighestFrequency(exampleText)}");
			Console.WriteLine($"{wordprocessor.CalculateFrequencyForWord(exampleText, "lake")}");
			var mostFrequent = wordprocessor.CalculateMostFrequentNWords(exampleText, 7);

            mostFrequent.ToList().ForEach(word => Console.WriteLine($"{word.Word}, freq: {word.Frequency}"));
		}
    }
}
