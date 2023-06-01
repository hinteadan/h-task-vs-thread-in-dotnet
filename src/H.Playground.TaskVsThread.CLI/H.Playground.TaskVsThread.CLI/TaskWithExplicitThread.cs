using System;
using System.Threading;
using System.Threading.Tasks;

namespace H.Playground.TaskVsThread.CLI
{
    internal class TaskWithExplicitThread : ImATaskExample
    {
        public Task ExecuteTaskExample()
        {
            TaskCompletionSource taskCompletionSource = new TaskCompletionSource();

            Thread explicitThread = new Thread(() =>
            {
                Thread.CurrentThread.Name = "[new Thread generated Thread]";
                Console.WriteLine($"I'm a piece of code running on thread {Thread.CurrentThread.ManagedThreadId} - {Thread.CurrentThread.Name}");
                taskCompletionSource.SetResult();
            });

            explicitThread.Start();

            return taskCompletionSource.Task;
        }
    }
}
