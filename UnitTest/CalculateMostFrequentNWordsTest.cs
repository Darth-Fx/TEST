using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class CalculateMostFrequentNWordsTest : CalculateFrequencyForWordTestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateMostFrequentNWords_Given_Null_Text_Should_Throw()
        {
            //arrange
            string text = null;
            int n = 3;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            wordFrequencyAnalyser.CalculateMostFrequentNWords(text, n);

            // Assert
            Assert.Fail("Expected exception was not thrown.");
        }

        [TestMethod]
        public void CalculateMostFrequentNWords_Given_N_is_Zero_Should_Return_EmptySet()
        {
            //arrange
            string text = "The sun shines over the lake";
            int n = 0;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var listOfWordFrequencies = wordFrequencyAnalyser.CalculateMostFrequentNWords(text, n);

            // Assert
            Assert.AreEqual(0, listOfWordFrequencies.Count);
        }

        [TestMethod]
        public void CalculateMostFrequentNWords_Given_EmptyText_and_Positive_N__Should_Return_EmptySet()
        {
            //arrange
            string text = string.Empty;
            int n = 5;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var listOfWordFrequencies = wordFrequencyAnalyser.CalculateMostFrequentNWords(text, n);

            // Assert
            Assert.AreEqual(0, listOfWordFrequencies.Count);
        }

        [TestMethod]
        public void CalculateMostFrequentNWords_Given_N_is_Three_Should_Return_Description()
        {
            /*
             * DESCRIPTION
             * If several words have the same frequency, this method should return them in ascendant alphabetical order 
             * (for input text “The sun shines over the lake” and n = 3, it should return 
             * the list { (“the”, 2), (“lake”, 1), (“over”, 1) }
             */

            //arrange
            string text = "The sun shines over the lake";

            int n = 3;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var listOfWordFrequencies = wordFrequencyAnalyser.CalculateMostFrequentNWords(text, n);

            // Assert
            Assert.AreEqual("the", listOfWordFrequencies[0].Word);
            Assert.AreEqual(2, listOfWordFrequencies[0].Frequency);

            Assert.AreEqual("lake", listOfWordFrequencies[1].Word);
            Assert.AreEqual(1, listOfWordFrequencies[1].Frequency);

            Assert.AreEqual("over", listOfWordFrequencies[2].Word);
            Assert.AreEqual(1, listOfWordFrequencies[2].Frequency);
        }
    }
}
