using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: Name1, Name2
    // Description:
    public class GameState
    {

        BlockGrid grid;
        GameShape activeShape;
        GameShape nextShape;
        int totalLinesCleared;
        int currentLevel;
        int currentScore;

        // Author: Your Name Here
        public GameState()
        {

        }

    }
}
