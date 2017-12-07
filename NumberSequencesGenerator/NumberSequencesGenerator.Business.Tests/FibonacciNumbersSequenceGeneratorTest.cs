using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberSequencesGenerator.Business.Tests
{
    [TestClass]
    public class FibonacciNumbersSequenceGeneratorTest
    {
        [TestMethod]
        public void Test_FibonacciSequence_Standard_Number_10()
        {
            var expectedResult = new List<string>{"0", "1", "1", "2", "3", "5", "8", "10"};
            var objFibonacciNumbersSequenceGenerator = new FibonacciNumbersSequenceGenerator();
            var actualResult = objFibonacciNumbersSequenceGenerator.GenerateSequence(10);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_FibonacciSequence_An_Odd_Number_15()
        {
            var expectedResult = new List<string> { "0", "1", "1", "2", "3", "5", "8", "13", "15" };
            var objFibonacciNumbersSequenceGenerator = new FibonacciNumbersSequenceGenerator();
            var actualResult = objFibonacciNumbersSequenceGenerator.GenerateSequence(15);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test_FibonacciSequence_A_Prime_Number_23()
        {
            var expectedResult = new List<string> { "0", "1", "1", "2", "3", "5", "8", "13", "21", "23" };
            var objFibonacciNumbersSequenceGenerator = new FibonacciNumbersSequenceGenerator();
            var actualResult = objFibonacciNumbersSequenceGenerator.GenerateSequence(23);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
