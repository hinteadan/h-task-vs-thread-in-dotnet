using H.Necessaire;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace H.Playground.TaskVsThread.CLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ImATaskExample[] allTaskExamples
                = typeof(ImATaskExample)
                .GetAllImplementations()
                .Select(type => Activator.CreateInstance(type) as ImATaskExample)
                .ToArray();

            Console.WriteLine($"Main Thread is {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine();

            foreach (ImATaskExample example in allTaskExamples)
            {
                Console.WriteLine($"Running example {example.GetType().Name}");

                await
                    new Func<Task>(example.ExecuteTaskExample)
                    .TryOrFailWithGrace(
                        onFail: ex => Console.WriteLine($"Failed to run example {example.GetType().Name} because {ex.Message}")
                    );

                Console.WriteLine($"DONE Running example {example.GetType().Name}");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine($"Done @ {DateTime.Now}. Press [ENTER] to exit.");
            Console.ReadLine();
        }
    }
}