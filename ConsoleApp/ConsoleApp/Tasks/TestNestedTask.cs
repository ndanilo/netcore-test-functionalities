using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tasks
{
    public class TestNestedTask
    {
        public async Task CallTestClassAsync()
        {
            var test = new Test();

            await test.ChangeSomeThing1().ChangeSomeThing2().ChangeSomeThing3();

            test.CloseTests();
        }
    }

    public static class TestExtensions
    {
        private const int DefaultWaitTime = 1000;
        public static async Task<Test> ChangeSomeThing1(this Test obj)
        {
            await DelayTaskAsync(nameof(ChangeSomeThing1), 5);
            return obj;
        }

        public static async Task<Test> ChangeSomeThing2(this Task<Test> obj)
        {
            //await obj;
            await DelayTaskAsync(nameof(ChangeSomeThing2), 5);
            return await obj;
        }

        public static async Task<Test> ChangeSomeThing3(this Task<Test> obj)
        {
            //await obj;
            await DelayTaskAsync(nameof(ChangeSomeThing3), 5);
            return await obj;
        }

        private static async Task DelayTaskAsync(string taskName, int maxCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                await Task.Delay(DefaultWaitTime);
                Console.WriteLine($"{taskName} processing task no: {i}");
            }
        }
    }

    public class Test
    {
        public Test()
        {
            Console.WriteLine($"{nameof(Test)} class was instatiated!");
        }

        public void CloseTests()
        {
            Console.WriteLine("all tasks of this class were finalized...");
        }
    }
}
