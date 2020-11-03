using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;

namespace Tetris
{
    class gameState
    { 
        GameShape activeShape;
        BlockGrid grid;
        GameShape nextShape;
        public int totalLinesCleared;
        public int currentLevel;
        public int currentScore;

        public gameState()
        {
            activeShape = new activeShape(); 
            this.grid = new BlockGrid(); 
            nextShape = new nextShape();
            totalLinesCleared = new totalLinesCleared();
            currentLevel = new currentLevel();
            currentScore = new currentScore();
        }
    }

}
