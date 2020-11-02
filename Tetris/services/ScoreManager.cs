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
        int score;

        // Author: Eoin Stanley
        public ScoreManager()
        {
            this.score = 0;
        }

        // Author: Eoin Stanley
        public int UpdateScore(int linesCleared, int level)
        {
            if (linesCleared > 4 || linesCleared < 0)
            {
                Console.WriteLine("Illegal Arguement, linesCleared");
                return -1;
            }

            if (level < 0)
            {
                Console.WriteLine("Illegal Arguement, level");
                return -1;
            }

            if (linesCleared == 1) { score += (40 * level); }
            else if (linesCleared == 2) { score += (100 * level); }
            else if (linesCleared == 3) { score += (300 * level); }
            else { score += (1200 * level); }

            return score;
        }

        // Author: Eoin Stanley
        public int UpdateScore(int linesDropped)
        {
            if(linesDropped < 0) { Console.WriteLine("Illegal Arguement, linesDropped"); return -1; }
            score += linesDropped;
            return score;
        }
    }
}
