using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberSequencesGenerator.Business.Tests
{
    [TestClass]
    public class AllNumbersSequenceGeneratorTest
    {
        [TestMethod]
        public void Test_AllSequence_Standard_Number_10()
        {
            var expectedResult = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            var objAllNumbersSequenceGenerator = new AllNumbersSequenceGenerator();
            var actualResult = objAllNumbersSequenceGenerator.GenerateSequence(10);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_AllSequence_An_Odd_Number_15()
        {
            var expectedResult = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
            var objAllNumbersSequenceGenerator = new AllNumbersSequenceGenerator();
            var actualResult = objAllNumbersSequenceGenerator.GenerateSequence(15);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_AllSequence_A_Prime_Number_23()
        {
            var expectedResult = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            var objAllNumbersSequenceGenerator = new AllNumbersSequenceGenerator();
            var actualResult = objAllNumbersSequenceGenerator.GenerateSequence(23);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
