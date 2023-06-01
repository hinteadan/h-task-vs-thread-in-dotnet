using System;
using System.Threading;
using System.Threading.Tasks;

namespace H.Playground.TaskVsThread.CLI
{
    internal class TaskWithUserInput : ImATaskExample
    {
        public Task ExecuteTaskExample()
        {
            TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();

            Console.WriteLine("Waiting for some user input, type something and press [ENTER]:");
            string userInput = Console.ReadLine();

            Console.WriteLine($"User typed: {userInput}");
            Console.WriteLine($"I'm a piece of code running on thread {Thread.CurrentThread.ManagedThreadId}");
            taskCompletionSource.SetResult(userInput);

            return taskCompletionSource.Task;
        }
    }
}
