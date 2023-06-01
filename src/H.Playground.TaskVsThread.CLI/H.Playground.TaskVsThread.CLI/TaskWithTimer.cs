using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace H.Playground.TaskVsThread.CLI
{
    internal class TaskWithTimer : ImATaskExample
    {
        public Task ExecuteTaskExample()
        {
            TaskCompletionSource taskCompletionSource = new TaskCompletionSource();
            new Timer(x => {

                Console.WriteLine("I'm timer-triggered task that ended 3 seconds after it started");
                Console.WriteLine($"I'm a piece of code running on thread {Thread.CurrentThread.ManagedThreadId}");
                taskCompletionSource.SetResult();

            }, null, TimeSpan.FromSeconds(3), Timeout.InfiniteTimeSpan);

            return taskCompletionSource.Task;
        }
    }
}
