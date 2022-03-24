using System.Diagnostics;
using static System.Console;
using static System.Diagnostics.Process;

namespace MonitoringLib
{
    public static class Recorder
    {
        private static Stopwatch timer = new();
        private static long bytesPhysicalBefore = 0;
        private static long bytesVirtualBefore = 0;

        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }

        public static void stop()
        {
            timer.Stop();
            long bytesPhysicalUsed = GetCurrentProcess().WorkingSet64 - bytesPhysicalBefore;
            long bytesVirtualUsed = GetCurrentProcess().VirtualMemorySize64 - bytesVirtualBefore;

            WriteLine($"{bytesPhysicalUsed:N0} physical bytes used.");
            WriteLine($"{bytesVirtualUsed:N0} virtual bytes used.");
            WriteLine($"{timer.Elapsed} time span ellapsed.");
            WriteLine($"{timer.ElapsedMilliseconds:N0} total milliseconds ellapsed.");
        }
    }
}
