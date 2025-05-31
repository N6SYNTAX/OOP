using System;
namespace ClockApp
{
    public class Clock
    {
        private Counter _hour;
        private Counter _min;
        private Counter _sec;

        public Clock()
        {
            _hour = new Counter("Hours");
            _min = new Counter("Minutes");
            _sec = new Counter("Seconds");
        }

        public string GetTime()
        {
            string h = _hour.Ticks.ToString("D2");
            string m = _min.Ticks.ToString("D2");
            string s = _sec.Ticks.ToString("D2");
            string time = h + ":" + m + ":" + s;

            return time;
        }

        public void Restart()
        {
            _hour.Reset();
            _min.Reset();
            _sec.Reset();
        }

        public void Tick()
        {
          //develop your logic here
        }
    }
}
