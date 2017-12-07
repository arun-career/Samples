using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberSequencesGenerator.Business.Tests
{
    [TestClass]
    public class OddNumbersSequenceGeneratorTest
    {
        [TestMethod]
        public void Test_OddSequence_Standard_Number_10()
        {
            var expectedResult = new List<string>{"1", "3", "5", "7", "9", "10" };
            var objOddNumbersSequenceGenerator = new OddNumbersSequenceGenerator();
            var actualResult = objOddNumbersSequenceGenerator.GenerateSequence(10);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_OddSequence_An_Odd_Number_15()
        {
            var expectedResult = new List<string> { "1", "3", "5", "7", "9", "11", "13", "15" };
            var objOddNumbersSequenceGenerator = new OddNumbersSequenceGenerator();
            var actualResult = objOddNumbersSequenceGenerator.GenerateSequence(15);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_OddSequence_A_Prime_Number_23()
        {
            var expectedResult = new List<string> { "1", "3", "5", "7", "9", "11", "13", "15", "17", "19", "21", "23" };
            var objOddNumbersSequenceGenerator = new OddNumbersSequenceGenerator();
            var actualResult = objOddNumbersSequenceGenerator.GenerateSequence(23);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_OddSequence_Lowest_Odd_Number_1()
        {
            var expectedResult = new List<string> {"1" };
            var objOddNumbersSequenceGenerator = new OddNumbersSequenceGenerator();
            var actualResult = objOddNumbersSequenceGenerator.GenerateSequence(1);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_OddSequence_Lowest_Even_Number_2()
        {
            var expectedResult = new List<string> { "1", "2" };
            var objOddNumbersSequenceGenerator = new OddNumbersSequenceGenerator();
            var actualResult = objOddNumbersSequenceGenerator.GenerateSequence(2);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_OddSequence_Lowest_2nd_Odd_Number_3()
        {
            var expectedResult = new List<string> { "1", "3" };
            var objOddNumbersSequenceGenerator = new OddNumbersSequenceGenerator();
            var actualResult = objOddNumbersSequenceGenerator.GenerateSequence(3);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_OddSequence_Lowest_2nd_Even_Number_4()
        {
            var expectedResult = new List<string> { "1", "3", "4" };
            var objOddNumbersSequenceGenerator = new OddNumbersSequenceGenerator();
            var actualResult = objOddNumbersSequenceGenerator.GenerateSequence(4);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
