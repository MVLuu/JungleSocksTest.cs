using System;
using Testing.JungleSocks.UITests;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new MainPageTest();
            Console.WriteLine("Executing test OneOrder.");
            test.TestInitialize();
            test.OneOrder();
            test.TestCleanup();
            Console.WriteLine("Test completed succefully, press 'Enter' to exit test.");
            
        }
    }
}
