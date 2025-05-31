using System;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Clock MyClock = new Clock();
        for (int i = 0; i < 50000; i++)
        {
            MyClock.Tick();
            //Console.WriteLine(MyClock.Display());
        }
        stopwatch.Stop();

        //extract the timelapse

        Console.WriteLine(MyClock.Display());
        MyClock.Restart();
        Console.WriteLine(MyClock.Display());
        Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
        // Get the current process
        Process proc = Process.GetCurrentProcess();

        // Display memory usage
        Console.WriteLine($"Current process: {proc.ProcessName}");
        Console.WriteLine($"Physical memory usage: {proc.WorkingSet64 / 1024.0:F2} KB");
        Console.WriteLine($"Peak physical memory usage: {proc.PeakWorkingSet64 / 1024.0:F2} KB");
    }

}
