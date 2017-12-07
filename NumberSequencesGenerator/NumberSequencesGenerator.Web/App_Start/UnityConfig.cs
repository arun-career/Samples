using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace NumberSequencesGenerator.Web
{
    using NumberSequencesGenerator.Business;
    using NumberSequencesGenerator.Business.Interfaces.GeneratorService;
    using NumberSequencesGenerator.Business.Interfaces.Generator;
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<INumberSequencesGeneratorService, NumberSequencesGeneratorService>();
            container.RegisterType<INumberSequencesGenerator, AllNumbersConsidering3and5SequenceGenerator>();
            container.RegisterType<INumberSequencesGenerator, AllNumbersSequenceGenerator>();
            container.RegisterType<INumberSequencesGenerator, EvenNumbersSequenceGenerator>();
            container.RegisterType<INumberSequencesGenerator, OddNumbersSequenceGenerator>();
            container.RegisterType<INumberSequencesGenerator, FibonacciNumbersSequenceGenerator>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}