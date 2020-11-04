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
    Uses GameState and UI classes like ShapeRenderer, 
    Constants, and DrawColor to convert the logical GameState into a
    visual represenatition of Tetris.

    EX: StateRenderer draw() should fill in the grid, update the level, score, and etc..
    */
    public static class StateRenderer
    {

        // Author: Your Name Here
        public static void Draw(GameState state)
        {
            //DrawColor drawColor = new DrawColor();
            SOM.drawBackground();
        
        }
    }
}
