using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.services.Tests
{
    // Authors: Eoin Stanley
    // Description: Tests for Score Manager
    [TestClass()]
    public class ScoreManagerTests
    {
        // Author: Eoin Stanley

        

        [TestMethod()]
        public void ScoreManagerTest()
        {
            ScoreManager tester = new ScoreManager();
            Assert.AreEqual(tester.score, 0);
            tester.UpdateScore(2, 2);

            ScoreManager tester2 = new ScoreManager();
            Assert.AreEqual(tester2.score, 0);
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScoreTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(3, 2), 600);
            Assert.AreEqual(tester.score, 600);

            Assert.AreEqual(tester.UpdateScore(1, 1), 640);
            Assert.AreEqual(tester.score, 640);

            Assert.AreEqual(tester.UpdateScore(8, 4), -1); //expect print statement
            Assert.AreEqual(tester.UpdateScore(3, -1), -1); //expect print statement
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScoreTest1()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(8),8);
            Assert.AreEqual(tester.score, 8);
            Assert.AreEqual(tester.UpdateScore(-5), -1); //expect print statement
        }
    }
}