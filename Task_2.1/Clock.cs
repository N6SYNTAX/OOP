using System.Security.Cryptography.X509Certificates;

public class Clock
{
    private Counter MinuteCounter;
    private Counter SecondCounter;


    public Clock()
    {
        MinuteCounter = new Counter("Minute Counter");
        SecondCounter = new Counter("Seconds Counter");
    }

    public void Tick()
    {
        SecondCounter.Increment();

        if (SecondCounter.Ticks == 60)
        {
            MinuteCounter.Increment();
            SecondCounter.Reset();
        }
    }
    public void Display()
    {
        Console.WriteLine($"The time is {MinuteCounter.Ticks} minutes {SecondCounter.Ticks} seconds");
    }
}




