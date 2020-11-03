using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public int duration; //duration is calculated in miliseconds
        public Stopwatch stopwatch = new Stopwatch();

        // Author: Ana Maria Anghel
        public Timer(int duration)
        {
            this.duration = duration;
            this.start = -1;
            this.end = -1;
        }

        // Author: Ana Maria Anghel
        public void ResetTimer()
        {
            stopwatch.Reset();
            stopwatch.Restart();
            stopwatch.Start();
            this.start = stopwatch.ElapsedMilliseconds;
            this.end = stopwatch.ElapsedMilliseconds + this.duration;
        }

        // Author: Ana Maria Anghel
        public bool IsExpired()
        {
            if (stopwatch.ElapsedMilliseconds < this.end)
                return false;
            else
                return true;
        }

    }
}
