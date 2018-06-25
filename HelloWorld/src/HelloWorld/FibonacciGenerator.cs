/*
  Working through the dotnet tutorials. Now on multiple files:

  * https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli#working-with-multiple-files
 */
using System.Collections.Generic;

namespace HelloWorld
{
    public class FibonacciGenerator
    {
        private Dictionary<int, int> _cache = new Dictionary<int, int>();

        /*
          Lambda expression:

          * if `n < 2` return n.
          * else return the latter added results of the 2xFibValue calls.
        */
        private int Fib(int n) => n < 2 ? n : FibValue(n - 1) + FibValue(n - 2);

        /*
          The `_cache` checks and recursive loop, means that the cache is
          back-filled with all required numbers, to return the current value of
          `n`.
        */
        private int FibValue(int n)
        {
            if (!_cache.ContainsKey(n))
            {
                _cache.Add(n, Fib(n));
            }

            return _cache[n];
        }

        public IEnumerable<int> Generate(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return FibValue(i);
            }
        }
    }
}
