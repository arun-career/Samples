using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberSequencesGenerator.Business.Tests
{
    [TestClass]
    public class EvenNumbersSequenceGeneratorTest
    {
        [TestMethod]
        public void Test_EvenSequence_Standard_Number_10()
        {
            var expectedResult = new List<string>{"2", "4", "6", "8", "10" };
            var objEvenNumbersSequenceGenerator = new EvenNumbersSequenceGenerator();
            var actualResult = objEvenNumbersSequenceGenerator.GenerateSequence(10);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_EvenSequence_An_Odd_Number_15()
        {
            var expectedResult = new List<string> { "2", "4", "6", "8", "10", "12", "14", "15" };
            var objEvenNumbersSequenceGenerator = new EvenNumbersSequenceGenerator();
            var actualResult = objEvenNumbersSequenceGenerator.GenerateSequence(15);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_EvenSequence_A_Prime_Number_23()
        {
            var expectedResult = new List<string> { "2", "4", "6", "8", "10", "12", "14", "16", "18", "20", "22", "23" };
            var objEvenNumbersSequenceGenerator = new EvenNumbersSequenceGenerator();
            var actualResult = objEvenNumbersSequenceGenerator.GenerateSequence(23);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_EvenSequence_Lowest_Odd_Number_1()
        {
            var expectedResult = new List<string> { };
            var objEvenNumbersSequenceGenerator = new EvenNumbersSequenceGenerator();
            var actualResult = objEvenNumbersSequenceGenerator.GenerateSequence(1);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_EvenSequence_Lowest_Even_Number_2()
        {
            var expectedResult = new List<string> { "2" };
            var objEvenNumbersSequenceGenerator = new EvenNumbersSequenceGenerator();
            var actualResult = objEvenNumbersSequenceGenerator.GenerateSequence(2);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_EvenSequence_Lowest_2nd_Odd_Number_3()
        {
            var expectedResult = new List<string> { "2", "3" };
            var objEvenNumbersSequenceGenerator = new EvenNumbersSequenceGenerator();
            var actualResult = objEvenNumbersSequenceGenerator.GenerateSequence(3);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_EvenSequence_Lowest_Even_Number_4()
        {
            var expectedResult = new List<string> { "2", "4" };
            var objEvenNumbersSequenceGenerator = new EvenNumbersSequenceGenerator();
            var actualResult = objEvenNumbersSequenceGenerator.GenerateSequence(4);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
