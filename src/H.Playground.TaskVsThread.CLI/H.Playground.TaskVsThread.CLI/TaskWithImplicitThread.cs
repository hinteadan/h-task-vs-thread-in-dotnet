using System;
using System.Threading;
using System.Threading.Tasks;

namespace H.Playground.TaskVsThread.CLI
{
    internal class TaskWithImplicitThread : ImATaskExample
    {
        public Task ExecuteTaskExample()
        {
            return
                Task.Run(() =>
                {
                    Thread.CurrentThread.Name = "[Task.Run generated Thread]";
                    Console.WriteLine($"I'm a piece of code running on thread {Thread.CurrentThread.ManagedThreadId} - {Thread.CurrentThread.Name}");
                });
        }
    }
}
