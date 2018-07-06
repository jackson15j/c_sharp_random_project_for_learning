using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class Timers
{
    public delegate void DeleFuncVoid();
    public delegate Task DeleFuncTask();  // Used by: `StopWatchDelegateAsync()`.
    static Stopwatch watch = new Stopwatch();

    /**
       Delegate Method to wrap my synchronous methods to get elapsed time for
       them.

       NOTE: Implicitly uses the class global `StopWatch` called `watch`.
       FIXME: pass in `StopWatch`, or create within the delegate if I
       factor this out of the main class.

       @param DeleFuncVoid task - Get timing of any `DeleFuncVoid` (`Void`)
               based methods.
    */
    public static void StopWatchDelegate(DeleFuncVoid task)
    {
        Console.WriteLine($"\n-- Starting timing of: {task.Method.Name}()...");
        watch.Reset();
        watch.Start();
        task();
        watch.Stop();
        Console.WriteLine($"-- {task.Method.Name}(), took: {watch.ElapsedMilliseconds}ms");
    }

    /**
       Delegate Method to wrap my asynchronous methods to get elapsed time for
       them.

       NOTE: Implicitly uses the class global `StopWatch` called `watch`.
       FIXME: pass in `StopWatch`, or create within the delegate if I
       factor this out of the main class.

       @param DeleFunc task - Get timing of any `DeleFuncTask` (`Task`) based
               methods.
    */
    public static async Task StopWatchDelegateAsync(DeleFuncTask task)
    {
        Console.WriteLine($"\n-- Starting timing of: {task.Method.Name}()...");
        watch.Reset();
        watch.Start();
        await task();
        watch.Stop();
        Console.WriteLine($"-- {task.Method.Name}(), took: {watch.ElapsedMilliseconds}ms");
    }
}
