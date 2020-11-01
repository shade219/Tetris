using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.services.Tests
{
    // Authors: Jessica Wilson
    // Description: Testing the functionality of creating a LevelManager and updating the level itself
    [TestClass()]
    public class LevelManagerTests
    {
        // Author: Jessica Wilson
        [TestMethod()]
        public void LevelManagerTest()
        {
            int expected = 1;
            LevelManager manager = new LevelManager(expected);

            Assert.AreEqual(expected, manager.currentLevel);
            Assert.AreEqual(expected, manager.startLevel);
            Assert.AreEqual(10, manager.maxLevel);
        }

        // Author: Jessica Wilson
        [TestMethod()]
        public void UpdateLevelStartingAtLevelOneTest()
        {
            //starting at level one, first ten lines take you to level 2, next ten are level 3.
            LevelManager manager = new LevelManager(1);
            int levelReturned = manager.UpdateLevel(24);
            Assert.AreEqual(3, manager.currentLevel);
            Assert.AreEqual(1, manager.startLevel);
            Assert.AreEqual(3, levelReturned);

        }

        // Author: Jessica Wilson
        [TestMethod()]
        public void UpdateLevelStillAtLevelOneTest()
        {
            //only cleared 7 lines have not moved on to the next level, still at level one.
            LevelManager manager = new LevelManager(1);
            int levelReturned = manager.UpdateLevel(7);
            Assert.AreEqual(1, manager.currentLevel);
            Assert.AreEqual(1, manager.startLevel);
            Assert.AreEqual(1, levelReturned);

        }

        // Author: Jessica Wilson
        [TestMethod()]
        public void UpdateLevelNegativeInputTest()
        {
            //bad input from user 
            LevelManager manager = new LevelManager(1);
            int levelReturned = manager.UpdateLevel(-27);
            Assert.AreEqual(1, manager.currentLevel);
            Assert.AreEqual(1, manager.startLevel);
            Assert.AreEqual(1, levelReturned);

        }

        // Author: Jessica Wilson
        [TestMethod()]
        public void UpdateLevelStartingAtLevelFiveTest()
        {
            //User started at level 5, only 1 additional level is added
            LevelManager manager = new LevelManager(5);
            int levelReturned = manager.UpdateLevel(11);
            Assert.AreEqual(6, manager.currentLevel);
            Assert.AreEqual(5, manager.startLevel);
            Assert.AreEqual(6, levelReturned);

        }



        // Author: Jessica Wilson
        [TestMethod()]
        public void UpdateToMaxLevelLevelTest()
        {
            //can only go up to level ten, will not go above
            LevelManager manager = new LevelManager(1);
            int levelReturned = manager.UpdateLevel(110);
            Assert.AreEqual(10, manager.currentLevel);
            Assert.AreEqual(10, levelReturned);
        }
    }
}