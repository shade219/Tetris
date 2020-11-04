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
            GameState GS = new GameState();
            Assert.IsNotNull(GS);
        }
        [TestMethod]
        public void FullInitializeTest()
        {
            GameState Var = new GameState();
            int a = Var.currentLevel;
            int b = Var.currentScore;
            int c = Var.totalLinesCleared;
            Assert.IsNotNull(Var.getGrid());
            //Assert.IsNotNull(Var.getNextShape()); won't work until full code works
            //Assert.IsNotNull(Var.getActiveShape()); won't work until full code works

            Assert.AreEqual(a, 0);
            Assert.AreEqual(b, 0);
            Assert.AreEqual(c, 0);
        }
        [TestMethod]
        public void typeErr()
        {
            GameState Var = new GameState();

            int s = 0;
            int a = Var.currentLevel;
            Assert.IsInstanceOfType(a, typeof(int));
            Assert.IsInstanceOfType(Var.currentScore, typeof(int));
            Assert.IsInstanceOfType(Var.totalLinesCleared, typeof(int));

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