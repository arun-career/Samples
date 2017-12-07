using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business.Interfaces.Generator
{
    public interface INumberSequencesGenerator
    {
        List<string> GenerateSequence(int UpperLimit);
    }
}
