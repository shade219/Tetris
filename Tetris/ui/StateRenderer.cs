using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;

namespace Tetris.ui
{
    // Authors: Nathan Hester, Tom Zdanowski

    /* Description: StateRenderer should fill in the grid, update the level, score, and etc..
     * Uses GameState, GameManager, and UI classes like ShapeRenderer, 
     * Constants, (maybe SpriteObjectManager) to convert the 
     * logical GameState into a visual represenatition of Tetris.
    */
    public static class StateRenderer
    {

        // Author: Tom Zdanowski and Nathan Hester
        public static void Draw(GameState state)
        {

            // 1. Sets up the so called background which involves the container and preview window
  
            SOM.drawBackground();

            // 2. add activeShape and nextShape via getter and setter from GameState

            // GameShape activeShape;  = state.getActiveShape(); 
            // GameShape nextShape; = state.getNextShape(); 

            // activeShape.Draw(); // uncomment if getters in gamestate are there
            // nextShape.Draw(); // uncomment if getters in gamestate are there

            // 3. fill in grid for tetris board

            // BlockGrid bg = state.getGrid(); // uncomment if getters in gamestate are there

            // bg.Draw(); uncomment if getters in gamestate are there

            // 4. add strings to showcase the currentLevel, currentScore, and totalLinesCleared

            

            // state.currentLevel
            // state.currentScore
            // state.TotalLinesCleared


        }
    }
}
