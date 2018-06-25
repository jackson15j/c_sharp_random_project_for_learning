/*
  Following the dotnet CLI tutorials:

  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
 */

using Pets;
using System;
using System.Collections.Generic;

namespace hello_world
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
                new Cat()
            };

            foreach (var pet in pets)
            {
                Console.WriteLine(pet.TalkToOwner());
            }
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
