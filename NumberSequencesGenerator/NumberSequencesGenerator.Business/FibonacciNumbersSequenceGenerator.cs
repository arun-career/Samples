using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business
{
    using Interfaces.Generator;
    public class FibonacciNumbersSequenceGenerator:INumberSequencesGenerator
    {
        public List<string> GenerateSequence(int UpperLimit)
        {
            var result = new List<string>();

            var firstNumber = 0;
            var secondNumber = 1;

            result.Add(firstNumber.ToString());
            result.Add(secondNumber.ToString());

            var thirdNumber = firstNumber + secondNumber;

            for (int iCtr = 3; thirdNumber <= UpperLimit; iCtr++)
            {                
                result.Add(thirdNumber.ToString());

                firstNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = firstNumber + secondNumber;

            }

            if (UpperLimit > Convert.ToInt64(result[result.Count - 1]))  //including upper limit when it is not included in the series
            {
                result.Add(UpperLimit.ToString());
            }

            return result;
        }
    }
}
