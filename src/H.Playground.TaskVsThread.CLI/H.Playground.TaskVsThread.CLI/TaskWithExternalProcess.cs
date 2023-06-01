using H.Necessaire;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H.Playground.TaskVsThread.CLI
{
    internal class TaskWithExternalProcess : ImATaskExample
    {
        public Task ExecuteTaskExample()
        {
            TaskCompletionSource taskCompletionSource = new TaskCompletionSource();

            Process.Start(new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = "/c echo I'm the standard output of the external process",
                CreateNoWindow = true,
                FileName = "cmd.exe",
            })
            .And(process =>
            {
                process.EnableRaisingEvents = true;
                process.Exited += (s, e) => {
                    Console.WriteLine(process.StandardOutput.ReadToEnd());
                    Console.WriteLine($"I'm a piece of code running on thread {Thread.CurrentThread.ManagedThreadId}");
                    taskCompletionSource.SetResult();
                };
            });

            return taskCompletionSource.Task;
        }
    }
}
