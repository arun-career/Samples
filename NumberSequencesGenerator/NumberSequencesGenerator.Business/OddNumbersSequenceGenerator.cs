using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business
{
    using Interfaces.Generator;
    public class OddNumbersSequenceGenerator:INumberSequencesGenerator
    {
        public List<string> GenerateSequence(int UpperLimit)
        {
            var result = new List<string>();

            for (int iCtr = 1; iCtr <= UpperLimit; iCtr++)
            {
                if (iCtr % 2 == 1) result.Add(iCtr.ToString());
            }

            if (UpperLimit > 1 && UpperLimit % 2 == 0)  //including upper limit when it is even number
            {
                result.Add(UpperLimit.ToString());
            }

            return result;
        }
    }
}
