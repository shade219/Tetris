using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    public class GameState
    {

        BlockGrid grid;
        GameShape activeShape;
        GameShape nextShape;
        int totalLinesCleared;
        int currentLevel;
        int currentScore;

        public GameState()
        {

        }

    }
}
