using System;
using ConsoleApp.Directives;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLineDirectives();

            Console.WriteLine();
            Console.WriteLine("ended!!!");
        }

        static void TestLineDirectives()
        {
            var lineDirective = new LineDirective();
            lineDirective.WriteLines();
        }
    }
}
