using System;
using System.Diagnostics;

namespace ClockApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            Clock MyClock = new Clock();
            for (int i = 0; i < 10000; i++)
            {
                MyClock.Tick();
            }
            //stopwatch.Stop();
            //extract the timelapse

            Console.WriteLine(MyClock.GetTime());
            MyClock.Restart();
            Console.WriteLine(MyClock.GetTime());

            //Process process = Process.GetCurrentProcess();
            //extract memory
        }
    }
}
