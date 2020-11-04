using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.services;
using Tetris.domain;

namespace Tetris
{ // Authors: <Brian and Morgan>
    class GameState
    {
        BlockGrid grid;
        GameShape activeShape;
        GameShape nextShape;
        public int totalLinesCleared;
        public int currentLevel;
        public int currentScore;

        //Authors: <Brian and Morgan>
        public GameState()
        {
            this.currentLevel = 0;
            this.currentScore = 0;
            this.totalLinesCleared = 0;
            this.activeShape = ShapeGenerator.GenerateShape(this.currentLevel);
            this.nextShape = ShapeGenerator.GenerateShape(this.currentLevel);
            this.grid = new BlockGrid(Constants.GAME_MAX_X, Constants.GAME_MAX_Y);
        }
    }

}
