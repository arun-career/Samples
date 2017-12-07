using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberSequencesGenerator.Business.Tests
{
    [TestClass]
    public class AllNumbersConsidering3and5SequenceGeneratorTest
    {
        [TestMethod]
        public void Test_Considering3and5Sequence_Standard_Number_10()
        {
            var expectedResult = new List<string>{"1", "2", "C", "4", "E", "C", "7", "8", "C", "E" };
            var objConsidering3and5NumbersSequenceGenerator = new AllNumbersConsidering3and5SequenceGenerator();
            var actualResult = objConsidering3and5NumbersSequenceGenerator.GenerateSequence(10);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_Considering3and5Sequence_An_Odd_Number_15()
        {
            var expectedResult = new List<string> { "1", "2", "C", "4", "E", "C", "7", "8", "C", "E", "11", "C", "13", "14", "Z" };
            var objConsidering3and5NumbersSequenceGenerator = new AllNumbersConsidering3and5SequenceGenerator();
            var actualResult = objConsidering3and5NumbersSequenceGenerator.GenerateSequence(15);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_Considering3and5Sequence_A_Prime_Number_23()
        {
            var expectedResult = new List<string> { "1", "2", "C", "4", "E", "C", "7", "8", "C", "E", "11", "C", "13", "14", "Z", "16", "17", "C", "19", "E", "C", "22", "23" };
            var objConsidering3and5NumbersSequenceGenerator = new AllNumbersConsidering3and5SequenceGenerator();
            var actualResult = objConsidering3and5NumbersSequenceGenerator.GenerateSequence(23);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
