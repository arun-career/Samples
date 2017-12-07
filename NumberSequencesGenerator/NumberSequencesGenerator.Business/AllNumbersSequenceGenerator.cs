using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business
{
    using Interfaces.Generator;
    public class AllNumbersSequenceGenerator: INumberSequencesGenerator
    {
        public List<string> GenerateSequence(int UpperLimit)
        {
            var result = new List<string>();

            for (int iCtr = 1; iCtr <= UpperLimit; iCtr++)
            {
                result.Add(iCtr.ToString());
            }

            return result;
        }
    }
}
