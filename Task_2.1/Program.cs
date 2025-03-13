
using System;

internal class Program
{
    private static void PrintCounters(Counter[] counters)
    {
        foreach (Counter c in counters)
        {
            Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
        }
    }

    static void Main(string[] args)
    {


        Clock MyClock = new Clock();
        Console.WriteLine("Time at the begining is:");
        MyClock.Display();
        for (int i = 1; i <= 100; i++)
        {
            MyClock.Tick();
        }
        Console.WriteLine("Time at the end is:");
        MyClock.Display();

        Counter[] myCounters = new Counter[3];
        myCounters[0] = new Counter("Counter 1");
        myCounters[1] = new Counter("Counter 2");
        myCounters[2] = myCounters[0];

        for (int i = 1; i <= 9; i++)
        {
            myCounters[0].Increment();
        }

        for (int i = 1; i <= 14; i++)
        {
            myCounters[1].Increment();
        }

        PrintCounters(myCounters);

        myCounters[2].ResetByDefault();

        PrintCounters(myCounters);

        myCounters[0].IncrementByFive();
        myCounters[1].IncrementByFive();

        PrintCounters(myCounters);
    }
}
