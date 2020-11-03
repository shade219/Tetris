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
            activeShape = ShapeGenerator::GenerateShape(this.currentLevel);
            this.grid = new BlockGrid(maxX, maxY);
            nextShape = ShapeGenerator::GenerateShape(this.currentLevel);
            totalLinesCleared = 0;
            currentLevel = 0;
            currentScore = 0;
        }
    }

}
