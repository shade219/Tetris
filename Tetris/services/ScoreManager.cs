using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.services
{
    // Authors: Eoin Stanley
    // Description: A class for keeping track of the score and updating it.
    public class ScoreManager
    {
        public int score;

        // Author: Eoin Stanley

        //constructor
        public ScoreManager()
        {
            this.score = 0;
        }

        // Author: Eoin Stanley

        //adds to score and returns, points are increased if multiple lines are cleared at the same time. points are multiplied by level.
        public int UpdateScore(int linesCleared, int level)
        {
            if (linesCleared > 4 || linesCleared < 0)
            {
                //check for valid inputs
                Console.WriteLine("Illegal Arguement, linesCleared");
                return score;
            }

            if (level < 0)
            {
                //check for valid inputs
                Console.WriteLine("Illegal Arguement, level");
                return score;
            }

            switch (linesCleared)
            {
                case 1:
                    score += (40 * level);
                    break;
                case 2:
                    score += (100 * level);
                    break;
                case 3:
                    score += (300 * level);
                    break;
                case 4:
                    score += (1200 * level);
                    break;
            }
            
            return score;
        }

        // Author: Eoin Stanley

        // adds to score when player uses PlaceDown option. Points added based on how many lines are skipped when the block is dropped.
        public int UpdateScore(int linesDropped)
        {
            if(linesDropped < 0) { Console.WriteLine("Illegal Arguement, linesDropped"); return score; }
            score += linesDropped;
            return score;
        }
    }
}
