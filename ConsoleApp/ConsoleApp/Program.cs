using System;
using System.Threading.Tasks;
using ConsoleApp.Directives;
using ConsoleApp.Exceptions;
using ConsoleApp.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TestLineDirectives();
            //TestTryCatchAtCustomeException();

            await TestTasksExceptions();

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

        static async Task TestTasksExceptions()
        {
            await new TestTasks().RunTasksWithExceptionAsync();
        }
    }
}
