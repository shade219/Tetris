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
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScore1LineTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(1, 2), 80);
            Assert.AreEqual(tester.score, 80);

            Assert.AreEqual(tester.UpdateScore(1, 5), 200);
            Assert.AreEqual(tester.score, 200);
        }

        [TestMethod()]
        public void UpdateScore2LineTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(2, 2), 280);
            Assert.AreEqual(tester.score, 280);

            Assert.AreEqual(tester.UpdateScore(2, 5), 700);
            Assert.AreEqual(tester.score, 700);
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScore3LineTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(3, 2), 600);
            Assert.AreEqual(tester.score, 600);

            Assert.AreEqual(tester.UpdateScore(3, 5), 2100);
            Assert.AreEqual(tester.score, 2100);
        }

        //Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScore4LineTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(4, 2), 2400);
            Assert.AreEqual(tester.score, 2400);

            Assert.AreEqual(tester.UpdateScore(4, 5), 8400);
            Assert.AreEqual(tester.score, 8400);
        }


        //Author: Eoin Stanley
        //Expect print statements for bad inputs
        [TestMethod()]
        public void UpdateScoreBadInputTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(-1, 1), 0); //lines cleared > 0
            Assert.AreEqual(tester.UpdateScore(5, 1), 0); // lines cleared < 4
            Assert.AreEqual(tester.UpdateScore(3, -1), 0); // level is negative

            Assert.AreEqual(tester.UpdateScore(-1), 0); // lines dropped is negative
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScoreDroppedLinesTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(tester.UpdateScore(8),8);
            Assert.AreEqual(tester.score, 8);
        }
    }
}