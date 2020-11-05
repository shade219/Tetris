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
            Assert.AreEqual(0, tester.score);
            
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScore1LineTest()
        {
            ScoreManager tester = new ScoreManager();
            Assert.AreEqual(80, tester.UpdateScore(1, 2));
            Assert.AreEqual(280, tester.UpdateScore(1, 5));
        }

        [TestMethod()]
        // Author: Eoin Stanley, Jessica Wilson
        public void UpdateScore2LineTest()
        {
            ScoreManager tester = new ScoreManager();
            Assert.AreEqual(200, tester.UpdateScore(2, 2));
            Assert.AreEqual(700, tester.UpdateScore(2, 5));
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScore3LineTest()
        {
            ScoreManager tester = new ScoreManager();
            Assert.AreEqual(600, tester.UpdateScore(3, 2));
            Assert.AreEqual(2100, tester.UpdateScore(3, 5));
        }

        //Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScore4LineTest()
        {
            ScoreManager tester = new ScoreManager();
            Assert.AreEqual(2400, tester.UpdateScore(4, 2));
            Assert.AreEqual(8400, tester.UpdateScore(4, 5));
        }


        //Author: Eoin Stanley
        //Expect print statements for bad inputs
        [TestMethod()]
        public void UpdateScoreBadInputTest()
        {
            ScoreManager tester = new ScoreManager();

            Assert.AreEqual(0, tester.UpdateScore(-1, 1)); //lines cleared > 0
            Assert.AreEqual(0, tester.UpdateScore(5, 1)); // lines cleared < 4
            Assert.AreEqual(0, tester.UpdateScore(3, -1)); // level is negative

            Assert.AreEqual(0, tester.UpdateScore(-1)); // lines dropped is negative
        }

        // Author: Eoin Stanley
        [TestMethod()]
        public void UpdateScoreDroppedLinesTest()
        {
            ScoreManager tester = new ScoreManager();
            Assert.AreEqual(8, tester.UpdateScore(8));
        }
    }
}