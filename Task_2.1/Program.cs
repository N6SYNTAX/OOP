using System;

internal class Program
{
    // Method to print all counters' names and values
    private static void PrintCounters(Counter[] counters)
    {
        foreach (Counter c in counters)
        {
            Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
        }
    }

    static void Main(string[] args)
    {
        // Create an array of three Counter objects
        Counter[] myCounters = new Counter[3];
        myCounters[0] = new Counter("Counter 1");
        myCounters[1] = new Counter("Counter 2");
        myCounters[2] = myCounters[0]; // myCounters[2] points to myCounters[0]

        // Increment Counter 1 nine times
        for (int i = 1; i <= 9; i++)
        {
            myCounters[0].Increment();
        }

        // Increment Counter 2 fourteen times
        for (int i = 1; i <= 14; i++)
        {
            myCounters[1].Increment();
        }

        // Print values
        Console.WriteLine("Before Reset:");
        PrintCounters(myCounters);

        // Reset Counter 1 (myCounters[2] is also reset because it's the same object as myCounters[0])
        myCounters[2].Reset();

        // Print values again after reset
        Console.WriteLine("\nAfter Reset:");
        PrintCounters(myCounters);

        // Testing ResetByDefault
        myCounters[1].ResetByDefault();
        Console.WriteLine("\nAfter ResetByDefault:");
        PrintCounters(myCounters);

        // Testing IncrementByFive
        myCounters[1].IncrementByFive();
        Console.WriteLine("\nAfter IncrementByFive:");
        PrintCounters(myCounters);
    }
}
