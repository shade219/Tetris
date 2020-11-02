using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.services
{
    // Authors: Ana Maria Anghel
    // Description: Timer keeps track of time on a single "cycle" and report if a piece should fall one more row.
    public class Timer
    {
        public long start;
        public long end;
        public int duration;
        public TimeSpan time = new TimeSpan();

        // Author: Ana Maria Anghel
        public Timer(int duration)
        {
            this.duration = duration;
        }

        // Author: Ana Maria Anghel
        public void ResetTimer()
        {
            this.start =(long) time.TotalMilliseconds;
            this.end = (long) time.TotalMilliseconds + this.duration;
        }

        // Author: Ana Maria Anghel
        public bool IsExpired()
        {
            if (time.TotalMilliseconds < this.end)
                return false;
            else
                return true;
        }

    }
}
