﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
//
//
// THIS WILL BE DELETED - LEAVING FOR COMPATIBILITY WITH EXISTING GAMEMANAGER CODE
//
//
//
namespace Tetris.services
{

        class GameStats
        {
            // data
            private int levelNum;
            private int lineCount;
            private int gameScore;

            public GameStats()
            {
                this.levelNum = 5;
                this.lineCount = 7;
                this.gameScore = 5;
            }

            public int getLevelNum()
            {
                return this.levelNum;
            }

            public void setLevelNum(int level)
            {
                this.levelNum = level;
            }

            public int getLineCount()
            {
                return this.lineCount;
            }

            public void setLineCount(int line)
            {
                this.lineCount = line;
            }

            public int getScore()
            {
                return this.gameScore;
            }

            public void setScore(int score)
            {
                this.gameScore = score;
            }


        }
}
