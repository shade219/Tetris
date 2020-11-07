using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;

namespace Tetris.services
{
    // Authors: Brian Moore
    // Description: Checks to see if a key has been pressed, and returns as an InputAction.
    public class InputReader
    {

        // Greg change
        // Store last action seen for retrieval later once the timer runs out

        InputAction lastAction;

        public InputReader()
        {
            this.lastAction = InputAction.Null;
        }

        public InputAction GetLastAction()
        {
            InputAction toReturn = lastAction;
            lastAction = InputAction.Null;

            return toReturn;
        }

        // Author: Brian Moore
        public void GetInputs()
        {
            //Returning value from within checks, so keeping all as If checks. 

            //First check for Pause
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ESCAPE))
            {
                lastAction = InputAction.Pause;
            }

            //Check drop and speed down
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE))
            {
                lastAction = InputAction.PlaceDown;
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_DOWN))
            {
                lastAction = InputAction.MoveDown;
            }

            //Check for rotate
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_UP))
            {
                lastAction = InputAction.Rotate;
            }

            //Check direction movement
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT))
            {
                lastAction = InputAction.MoveLeft;
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT))
            {
                lastAction = InputAction.MoveRight;
            }
        }
    }
}
