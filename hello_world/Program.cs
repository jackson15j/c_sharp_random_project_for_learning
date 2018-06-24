/*
  Following the dotnet CLI tutorials:

  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
 */

using System;

namespace hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Run via: `dotnet run -- <arg>`.
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }

            Console.WriteLine("Fibonacci Numbers 1-15:");

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"{i + 1}: {FibonacciNumber(i)}");
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
