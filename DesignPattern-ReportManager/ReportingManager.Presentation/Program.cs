using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ReportingManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //PHASE 1: Basic Steps
            //Console.WriteLine("....................");
            //Console.WriteLine("... " + DateTime.Now);
            //ReportManagerService service = new ReportManagerService(1,"My Report","andre");
            //Console.WriteLine(service.GenerateReport());
            //Console.WriteLine("....................");


            //PHASE 2:  DI Steps
            // Set up the dependency injection container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IReportManagerService, ReportManagerService>() // Registering the service
                .BuildServiceProvider();

            // Resolving the ReportManager instance
            var reportManager = serviceProvider.GetService<IReportManagerService>();
            var result = reportManager.GenerateReport(); // Calling the method to generate the report
            Console.WriteLine(result);


            Console.WriteLine(".........Full END...........");
        }
    }
}
