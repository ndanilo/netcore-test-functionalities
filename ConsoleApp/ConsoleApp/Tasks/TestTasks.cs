using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Tasks
{
    public class TestTasks
    {
        public async Task RunTasksWithExceptionAsync()
        {
            try
            {
                using (var cancellationTokenSource = new CancellationTokenSource())
                {
                    var lockObj = new object();

                    var task1 = CustomTaskAsync("taskA", 500, throwException: false, 20, cancellationTokenSource, lockObj);
                    var task2 = CustomTaskAsync("taskB", 500, throwException: false, 15, cancellationTokenSource, lockObj);
                    var task3 = CustomTaskAsync("taskC", 500, throwException: false, 10, cancellationTokenSource, lockObj);

                    await Task.WhenAll(task1, task2, task3);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task CustomTaskAsync(string taskName, int time, bool throwException, int at, CancellationTokenSource cancellationTokenSource = default, object lockObj = null)
        {
            await Task.Yield();

            while (!Monitor.TryEnter(lockObj))
            {
                await Task.Delay(1000);
                Console.WriteLine("{0} waiting for access", taskName);
            }

            lock(lockObj)
            {
                int count = 0;
                Task.Delay(1000).Wait();

                while (count <= at)
                {
                    cancellationTokenSource
                        ?.Token.ThrowIfCancellationRequested();

                    Task.Delay(1000).Wait();
                    Console.WriteLine("{0}: interval {1}", taskName, count);
                    count++;
                }
                if (throwException)
                {
                    cancellationTokenSource?.Cancel();
                    throw new Exception($"forced exception was throw at: {taskName}");
                }
            }

            Monitor.Exit(lockObj);
        }
    }
}
