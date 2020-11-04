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
        public void initialized()
        {
            GameState GS = new GameState();
            Assert.IsNotNull(GS);
        }
        [TestMethod]
        public void VarNotNull()
        {
            GameState Var = new GameState();
            int a = Var.currentLevel;
            int b = Var.currentScore;
            int c = Var.totalLinesCleared;
            Assert.IsNotNull(Var.getGrid());
            Assert.IsNotNull(Var.getNextShape());
            Assert.IsNotNull(Var.getActiveShape());

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
    }
}