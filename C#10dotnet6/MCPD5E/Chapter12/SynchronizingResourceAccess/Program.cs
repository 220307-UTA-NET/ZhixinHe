using System.Diagnostics;
using static System.Console;
using System.Threading.Tasks;

WriteLine("Please wait for the tasks to complete.");
Stopwatch watch = Stopwatch.StartNew();
Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);
Task.WaitAll(new Task[] {a, b});
WriteLine();
WriteLine($"Results: {SharedObjects.Message}.");
WriteLine($"{watch.ElapsedMilliseconds} elapsed milliseconds.");

static void MethodA()
{
    lock (SharedObjects.Conch)
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(SharedObjects.Random.Next(2000));
        SharedObjects.Message += "A";
        Write(".");
    }
}

static void MethodB()
{
    lock (SharedObjects.Conch)
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(SharedObjects.Random.Next(2000));
        SharedObjects.Message += "B";
        Write(".");
    }
}

static class SharedObjects
{
    public static Random Random = new();
    public static string? Message;
    public static object Conch = new();
}