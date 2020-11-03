using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tetris.services.Tests
{
    // Authors: Ana Maria Anghel
    // Description: Testing timer class and its methods (constructor, ResetTimer() and isExpired())
    [TestClass()]
    public class TimerTests
    {
        // Author: Ana Maria Anghel
        [TestMethod()]
        public void TimerTest()
        {
            Timer timer = new Timer(5);
            Assert.AreEqual(5, timer.duration);
        }

        // Author: Ana Maria Anghel
        [TestMethod()]
        public void ResetTimerTest()
        {
            Timer timer = new Timer(10);
            timer.start = 2;
            timer.end = 12;
            Assert.AreNotEqual(timer.stopwatch.ElapsedMilliseconds, timer.start);
            Assert.AreNotEqual(timer.stopwatch.ElapsedMilliseconds + 10, timer.end);
            timer.ResetTimer();
            Assert.IsTrue(timer.stopwatch.ElapsedMilliseconds - timer.start < 3);
            Assert.IsTrue(timer.stopwatch.ElapsedMilliseconds - timer.end < 3);
        }

        // Author: Ana Maria Anghel
        [TestMethod()]
        public void IsExpiredTest()
        {
            int duration = 1000;
            Timer timer = new Timer(duration);
            timer.ResetTimer();
            Assert.IsFalse(timer.IsExpired());
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while(watch.ElapsedMilliseconds <= duration+1)
            {
                continue;
            }
            Assert.IsTrue(timer.IsExpired());
        }
    }
}