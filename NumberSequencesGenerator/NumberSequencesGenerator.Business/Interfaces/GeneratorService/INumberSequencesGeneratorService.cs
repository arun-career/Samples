using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business.Interfaces.GeneratorService
{
    public interface INumberSequencesGeneratorService
    {
        Dictionary<string, List<string>> GenerateSequence(int UpperLimit);
    }
}
