using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test;

namespace UnitTest
{
    [TestClass]
    public class CalculateFrequencyForWordTest : CalculateFrequencyForWordTestBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateFrequencyForWord_Given_Null_Text_Should_Throw()
        {
            //arrange
            string text = null;
            string word = "test";
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var _ = wordFrequencyAnalyser.CalculateFrequencyForWord(text, word);

            // Assert
            Assert.Fail("Expected exception was not thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateFrequencyForWord_Given_Null_Word_Should_Throw()
        {
            //arrange
            string text = "test";
            string word = null;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var _ = wordFrequencyAnalyser.CalculateFrequencyForWord(text, word);

            // Assert
            Assert.Fail("Expected exception was not thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculateFrequencyForWord_Given_Null_Text_and_Null_Word_Should_Throw()
        {
            //arrange
            string text = null;
            string word = null;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var _ = wordFrequencyAnalyser.CalculateFrequencyForWord(text, word);

            // Assert
            Assert.Fail("Expected exception was not thrown.");
        }

        [TestMethod]
        public void CalculateFrequencyForWord_Given_EmptyString_Text_Should_Return_Zero()
        {
            //arrange
            string text = string.Empty;
            string word = string.Empty;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var frequency = wordFrequencyAnalyser.CalculateFrequencyForWord(text, word);

            // Assert
            Assert.AreEqual(0, frequency);
        }

        [TestMethod]
        public void CalculateFrequencyForWord_Given_Regular_Text_Should_Return_Zero()
        {
            //arrange
            string text = "The lake in the lake was the lake best the thing";
            string word = "lake";
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var frequency = wordFrequencyAnalyser.CalculateFrequencyForWord(text, word);

            // Assert
            Assert.AreEqual(3, frequency);
        }

        [TestMethod]
        public void CalculateFrequencyForWord_Given_Regular_Text_And_Search_Empty_String_Frequency()
        {
            //arrange
            string text = "The lake in the lake was the lake best the thing";
            string word = String.Empty;
            var wordFrequencyAnalyser = new WordFrequencyAnalyzer(textPrepareForFrpcessingFunction);

            //act
            var frequency = wordFrequencyAnalyser.CalculateFrequencyForWord(text, word);

            // Assert
            Assert.AreEqual(0, frequency);
        }
    }
}

