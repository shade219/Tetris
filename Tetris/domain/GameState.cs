using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.services;

namespace Tetris.domain
{
// Authors: <Brian and Morgan>
    public class GameState
    {
        private BlockGrid grid;
        private GameShape activeShape;
        private GameShape nextShape;
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

        public BlockGrid getGrid()
        {
            return this.grid;
        }

        public GameShape getActiveShape()
        {
            return this.activeShape;
        }

        public GameShape getNextShape()
        {
            return this.nextShape;
        }

        public void activateNext()
        {
            this.activeShape = this.nextShape;
            this.nextShape = ShapeGenerator.GenerateShape(this.currentLevel);
        }


    }
}
