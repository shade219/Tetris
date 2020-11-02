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
            Assert.AreNotEqual(timer.time.TotalMilliseconds, timer.start);
            Assert.AreNotEqual(timer.time.TotalMilliseconds + 10, timer.end);
            timer.ResetTimer();
            Assert.AreEqual(timer.time.TotalMilliseconds, timer.start);
            Assert.AreEqual(timer.time.TotalMilliseconds + 10, timer.end);
        }

        // Author: Ana Maria Anghel
        [TestMethod()]
        public void IsExpiredTest()
        {
            Timer timer = new Timer(1);
            timer.ResetTimer();
            Assert.IsFalse(timer.IsExpired());
            timer.end = (long)timer.time.TotalMilliseconds - 1;
            Assert.IsTrue(timer.IsExpired());
        }
    }
}