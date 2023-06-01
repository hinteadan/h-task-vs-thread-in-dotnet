using System;
using System.Threading;
using System.Threading.Tasks;

namespace H.Playground.TaskVsThread.CLI
{
    internal class TaskDoingNothing : ImATaskExample
    {
        public Task ExecuteTaskExample()
        {
            Console.WriteLine($"I'm a piece of code running on thread {Thread.CurrentThread.ManagedThreadId}");
            return Task.CompletedTask;
        }
    }
}
