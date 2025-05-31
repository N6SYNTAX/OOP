using System.Security.Cryptography.X509Certificates;

public class Clock
{
    private Counter HourCounter;
    private Counter MinuteCounter;
    private Counter SecondCounter;


    public Clock()
    {
        HourCounter = new Counter("Hour Counter");
        MinuteCounter = new Counter("Minute Counter");
        SecondCounter = new Counter("Seconds Counter");
    }


    public void Restart()
    {
        HourCounter.Reset();
        MinuteCounter.Reset();
        SecondCounter.Reset();

    }

    public void Tick()
    {
        SecondCounter.Increment();

        if (SecondCounter.Ticks == 60)
        {
            MinuteCounter.Increment();
            SecondCounter.Reset();
            if (MinuteCounter.Ticks == 60)
            {
                MinuteCounter.Reset();
                if (HourCounter.Ticks < 24)
                {
                    HourCounter.Increment();
                }
                else
                {
                    HourCounter.Reset();
                }

            }

        }
    }
    public string Display()
    {
        string h = HourCounter.Ticks.ToString("D2");
        string m = MinuteCounter.Ticks.ToString("D2");
        string s = SecondCounter.Ticks.ToString("D2");
        string time = h + ":" + m + ":" + s;

        return time;
    }
}




