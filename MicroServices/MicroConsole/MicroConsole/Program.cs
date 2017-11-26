using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Threading;
namespace MicroConsole
{
    class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:8080/";

            //start OWIN host
            using (WebApp.Start<StartUp>(url: baseAddress))
            {
                Console.WriteLine("Service is listening at " + baseAddress);
                Thread.Sleep(-1);
            }
        }
    }
}
