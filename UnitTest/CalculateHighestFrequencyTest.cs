using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class CalculateHighestFrequencyTest : CalculateFrequencyForWordTestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateHighestFrequency_Given_Null_Text_Should_Throw()
        {
            //arrange
            string text = null;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            wordFrequencyAnalyser.CalculateHighestFrequency(text);

            // Assert
            Assert.Fail("Expected exception was not thrown.");
        }

        [TestMethod]
        public void CalculateHighestFrequency_Given_EmptyString_Text_Should_Return_Zero()
        {
            //arrange
            string text = string.Empty;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            int frequency = wordFrequencyAnalyser.CalculateHighestFrequency(text);

            // Assert
            Assert.AreEqual(0, frequency);
        }

        [TestMethod]
        public void CalculateHighestFrequency_Given_Regular_Text_Should_Return()
        {
            //arrange
            string text = "The lake in the lake was the lake's best the thing";
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            int frequency = wordFrequencyAnalyser.CalculateHighestFrequency(text);

            // Assert
            Assert.AreEqual(4, frequency);
        }
    }
}
