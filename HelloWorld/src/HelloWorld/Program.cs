using Pets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

/*
  Following the dotnet CLI tutorials:

  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
 */
namespace HelloWorld
{
    class Program
    {
        delegate Task DeleFunc();  // Used by: `StopWatchDelegate()`.
        static Stopwatch watch = new Stopwatch();

        static void Main(string[] args)
        {
            // Reading CLI args example.
            if (args.Length > 0)
            {
                // Run via: `dotnet run -- <arg>`.
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }

            // Multiple files in same directory example.
            Console.WriteLine("Fibonacci Numbers 1-15:");
            var generator = new FibonacciGenerator();
            foreach (var digit in generator.Generate(15))
            {
                Console.WriteLine(digit);
            }

            // Multiple files in sub-folders example.
            List<IPet> pets = new List<IPet>
            {
                new Dog(),
                new Cat(),
                new Bird()
            };

            foreach (var pet in pets)
            {
                Console.WriteLine(pet.TalkToOwner());
            }


            SumPageExample sumPageExample = new SumPageExample();
            // Synchronous call to get HTTP pages.
            watch.Start();
            sumPageExample.SumPageSizes();
            watch.Stop();
            Console.WriteLine($"Synchronous call took: {watch.ElapsedMilliseconds}ms");

            // Asynchronous call to get HTTP pages.
            StopWatchDelegateAsync(sumPageExample.SumPageSizesAsync).GetAwaiter().GetResult();

            // Asynchronous & Parallel calls to get HTTP pages.
            StopWatchDelegateAsync(sumPageExample.SumPageSizesInParallelAndAsync).GetAwaiter().GetResult();

            // Multiple asynchronous calls created and then awaited at a later
            // date, to provide a parallel call.
            StopWatchDelegateAsync(sumPageExample.CreateMultipleTasksAsync).GetAwaiter().GetResult();
        }

        /**
           Delegate Method to wrap my functions to get elapsed time for the
           method.

           NOTE: Implicitly uses the class global `StopWatch` called `watch`.
           FIXME: pass in `StopWatch`, or create within the delegate if I
           factor this out of the main class.

           @param DeleFunc task - Get timing of any `DeleFunc` (`Task`) based
                   methods.
           */
        static async Task StopWatchDelegateAsync(DeleFunc task)
        {
            Console.WriteLine($"\n-- Starting timing of: {task.Method.Name}()...");
            watch.Reset();
            watch.Start();
            await task();
            watch.Stop();
            Console.WriteLine($"-- {task.Method.Name}(), took: {watch.ElapsedMilliseconds}ms");
        }

        static int FibonacciNumber(int n)
        {
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }
    }
}
