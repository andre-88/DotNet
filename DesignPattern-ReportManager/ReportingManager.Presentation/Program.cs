using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReportingManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".........");
            Console.WriteLine(">>> END");
            Console.WriteLine("......... Test 101");
            ReportManagerBO bo = new ReportManagerBO(1,"My Report","andre");
            Console.WriteLine(bo.GenerateReport());

            //var input = Console.ReadKey();
        }
    }
}
