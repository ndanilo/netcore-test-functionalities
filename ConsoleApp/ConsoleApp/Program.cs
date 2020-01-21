using System;
using ConsoleApp.Directives;
using ConsoleApp.Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLineDirectives();
            TestTryCatchAtCustomeException();

            Console.WriteLine();
            Console.WriteLine("ended!!!");
        }

        static void TestLineDirectives()
        {
            new LineDirective().WriteLines();
        }

        static void TestTryCatchAtCustomeException()
        {
            new CustomException().ThrowException();
        }
    }
}
