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
        public void UpdateLevelTest()
        {
            int expectedLevel = 2;

            LevelManager manager = new LevelManager(1);
            int levelReturned = manager.UpdateLevel(24);
            Assert.AreEqual(expectedLevel, manager.currentLevel);
            Assert.AreEqual(1, manager.startLevel);
            Assert.AreEqual(10, manager.maxLevel);
            Assert.AreEqual(expectedLevel, levelReturned);

            //make sure the current level is updated again at an even 10 number
            levelReturned = manager.UpdateLevel(30);
            Assert.AreEqual(levelReturned, manager.currentLevel);

        }

        // Author: Jessica Wilson
        [TestMethod()]
        public void UpdateToMaxLevelLevelTest()
        {
            LevelManager manager = new LevelManager(1);
            int levelReturned = manager.UpdateLevel(110);
            Assert.AreEqual(11, manager.currentLevel);
            Assert.AreEqual(10, manager.maxLevel);
            Assert.AreEqual(10, levelReturned);
        }
    }
}