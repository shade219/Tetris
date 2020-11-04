using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;

namespace Tetris.ui
{
    // Authors: Nathan Hester, Tom Zdanowski

    /* Description:
        Uses GameState, GameManager, and UI classes like ShapeRenderer, 
        Constants, and DrawColor (maybe SpriteObjectManager) to convert the 
        logical GameState into a visual represenatition of Tetris.
        EX: StateRenderer draw() should fill in the grid, update the level, score, and etc..
    */
    public static class StateRenderer
    {

        // Author: Tom Zdanowski
        public static void Draw(GameState state)
        {
            //DrawColor drawColor = new DrawColor();

            // 1. Sets up the so called background which involves the container and preview window
  
            SOM.drawBackground();

            // 2. add activeShape and nextShape either via external method or...
            
            // GameShape activeShape =
            // GameShape nextShape = 

            // 3. fill in grid for tetris board
            // Should call a BlockGrid method or gameState info for this

            // BlockGrid bg = 

            // 4. add strings to showcase the currentLevel, currentScore, and totalLinesCleared

            // state.currentLevel
            // state.currentScore
            // state.TotalLinesCleared

            // 5. To Be Continued


        }
    }
}
