using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequencesGenerator.Business
{
    using Interfaces.Generator;
    using Interfaces.GeneratorService;
    using System.Reflection;

    public class NumberSequencesGeneratorService:INumberSequencesGeneratorService
    {
        public Dictionary<string, List<string>> GenerateSequence(int UpperLimit)
        {

            var classes = (from type in Assembly.GetExecutingAssembly().GetTypes()
                          where typeof(INumberSequencesGenerator).IsAssignableFrom(type)
                          select type).ToList();

            var resultDict = new Dictionary<string, List<string>>();

            foreach (Type nsGenerator in classes)
            {
                if (!nsGenerator.IsInterface)
                {
                    var objNSGenerator = Activator.CreateInstance(nsGenerator) as INumberSequencesGenerator;
                    var typeName = objNSGenerator.GetType().ToString();
                    resultDict.Add(typeName.Substring(typeName.LastIndexOf(".") + 1), objNSGenerator.GenerateSequence(UpperLimit));
                }
            }                        
            
            return resultDict;
        }
    }
}
