using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.domain;
using Tetris.services;
/*
Assert
GameState can be initialized on creation
variables are not null and are properly initialized on one class creation call
Seek bugs like invalid variables are caught (type errors)
*/
//Authors: <Marco Vergara>
namespace TetrisTest
{
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
            Assert.IsNotNull(Var.grid);
          Assert.IsNotNull(Var.nextShape);
           Assert.IsNotNull(Var.activeShape);

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
