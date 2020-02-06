using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Tasks
{
    public class TestMultithread
    {
        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(10000, 10000);
        private IList<int> ThreadCount = new List<int>();
        private object lockObj = new object();
        public async Task RunMultithreadTasksAsync()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var workers = 0;
            var completions = 0;

            ThreadPool.GetMaxThreads(out workers, out completions);
            Console.WriteLine("Processors: {0}. Workers: {0}. Completions: {0}\n", Environment.ProcessorCount, workers, completions);

            var operations = new ConcurrentBag<Task>();

            for (int i = 0; i < 1000000; i++)
            {
                var number = i;
                operations.Add(RunCommonTask(number));
            }

            await Task.WhenAll(operations).ConfigureAwait(false);

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds * 1.0 / 1000}");
        }

        private async Task RunCommonTask(int taskId)
        {
            semaphoreSlim.Wait();
            var threadId = Thread.CurrentThread.ManagedThreadId;
            await Task.Delay(10000);
            //Console.WriteLine($"Thread {threadId}. TaskId: {taskId}.");

            //var t = new Thread(c => Console.WriteLine("my thread: {0}", Thread.CurrentThread.ManagedThreadId));
            //t.Start();
            //t.Join();
            semaphoreSlim.Release();

            //lock (lockObj)
            //{
            //    if (!ThreadCount.Contains(threadId))
            //        ThreadCount.Add(threadId);
            //}
        }
    }
}
