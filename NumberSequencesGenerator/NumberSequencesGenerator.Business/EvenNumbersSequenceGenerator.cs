﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business
{
    using Interfaces.Generator;
    public class EvenNumbersSequenceGenerator:INumberSequencesGenerator
    {
        public List<string> GenerateSequence(int UpperLimit)
        {
            var result = new List<string>();

            for (int iCtr = 1; iCtr <= UpperLimit; iCtr++)
            {
                 if (iCtr%2==0) result.Add(iCtr.ToString());
            }

            if (UpperLimit > 1 && UpperLimit % 2 == 1)  //including upper limit when it is odd number
            {
                result.Add(UpperLimit.ToString());
            }

            return result;
        }
    }
}
