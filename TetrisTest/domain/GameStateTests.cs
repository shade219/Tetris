using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;
using Tetris.services;

namespace Tetris.domain.Tests
{
    /*
    Assert
    GameState can be initialized on creation
    variables are not null and are properly initialized on one class creation call
    Seek bugs like invalid variables are caught (type errors)
    */
    //Authors: <Marco Vergara>
    [TestClass]
    public class GameStateTest
    {
        [TestMethod]
        public void BaseInitializeTest()
        {
            GameState gameState = new GameState();
            Assert.IsNotNull(gameState);
        }
        [TestMethod]
        public void FullInitializeTest()
        {
            GameState gameState = new GameState();
            int currLevel = gameState.currentLevel;
            int currScore = gameState.currentScore;
            int totLinesCleared = gameState.totalLinesCleared;
            Assert.IsNotNull(gameState.getGrid());
            //Assert.IsNotNull(Var.getNextShape()); won't work until full code works
            //Assert.IsNotNull(Var.getActiveShape()); won't work until full code works

            Assert.AreEqual(currLevel, 0);
            Assert.AreEqual(currScore, 0);
            Assert.AreEqual(totLinesCleared, 0);
        }
        [TestMethod]
        public void IncorrectTypeInitializeTest()
        {
            // no logic in GameState has been implemented to support catching bad types being passed in
            GameState gameState = new GameState();
            int a = gameState.currentLevel;
            Assert.IsInstanceOfType(a, typeof(int));
            Assert.IsInstanceOfType(gameState.currentScore, typeof(int));
            Assert.IsInstanceOfType(gameState.totalLinesCleared, typeof(int));

        }

        [TestMethod]
        public void getGridTest()
        {
            // testing getGrid
        }

        [TestMethod]
        public void getActiveShapeTest()
        {
            // testing getActiveShape
        }

        [TestMethod]
        public void getNextShapeTest()
        {
            // testing getNextShape
        }

        [TestMethod]
        public void getActivateNextTest()
        {
            // testing getActivateNext
        }
    }
}