using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitAnalysisCommon;

namespace ConsoleNet461
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCase.Logger = new ConsoleLogger();
            TestCase.RunTestTaskAsync().GetAwaiter().GetResult();
            Console.WriteLine("All Finished");
            Console.ReadLine();
        }
    }
}
