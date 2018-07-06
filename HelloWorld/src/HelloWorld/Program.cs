using Pets;
using System;
using System.Collections.Generic;
using static Timers;

/*
  Following the dotnet CLI tutorials:

  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
 */
namespace HelloWorld
{
    class Program
    {
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
            StopWatchDelegate(sumPageExample.SumPageSizes);

            // Asynchronous call to get HTTP pages.
            StopWatchDelegateAsync(sumPageExample.SumPageSizesAsync).GetAwaiter().GetResult();

            // Asynchronous & Parallel calls to get HTTP pages.
            StopWatchDelegateAsync(sumPageExample.SumPageSizesInParallelAndAsync).GetAwaiter().GetResult();

            // Multiple asynchronous calls created and then awaited at a later
            // date, to provide a parallel call.
            StopWatchDelegateAsync(sumPageExample.CreateMultipleTasksAsync).GetAwaiter().GetResult();
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
