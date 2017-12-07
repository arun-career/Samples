using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business
{
    using Interfaces.Generator;
    public class AllNumbersConsidering3and5SequenceGenerator:INumberSequencesGenerator
    {
        public List<string> GenerateSequence(int UpperLimit)
        {
            var result = new List<string>();        

            for (int iCtr = 1; iCtr <= UpperLimit; iCtr++)
            {
                var isDivisibleBy3 = iCtr % 3 == 0;
                var isDivisibleBy5 = iCtr % 5 == 0;

                if (isDivisibleBy3 && isDivisibleBy5)
                {
                    result.Add("Z");
                }
                else if (isDivisibleBy5)
                {
                    result.Add("E");
                }
                else if (isDivisibleBy3)
                {
                    result.Add("C");
                }
                else
                {
                    result.Add(iCtr.ToString());
                }
            }
           
            return result;
        }
    }
}
