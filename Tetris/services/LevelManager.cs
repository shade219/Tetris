using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.services
{
    // Authors: Jessica Wilson
    // Description: Determine the current level based off the total number of lines cleared
    public class LevelManager
    {

        public int maxLevel = 10;
        public int startLevel;
        public int currentLevel;

        // Author: Jessica Wilson
        public LevelManager(int overrideStartLevel)
        {
            this.startLevel = overrideStartLevel;
            this.currentLevel = overrideStartLevel;
            
        }

        // Author: Jessica Wilson
        public int UpdateLevel(int totalLinesCleared)
        {
            //Each new level increases every 10 lines
            currentLevel = totalLinesCleared / 10;

            //can only get up to level ten (or whatever the max level is defaulted to)
            if (currentLevel >= maxLevel)
            {
                return maxLevel;
            }
            return currentLevel;

        }

    }
}
