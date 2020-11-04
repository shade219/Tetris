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
    public static class InputReader
    {

        // Author: Brian Moore
        public static InputAction GetInputs()
        {
            //Returning value from within checks, so keeping all as If checks. 

            //First check for Pause
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ESCAPE))
            {
                return InputAction.Pause;
            }

            //Check drop and speed down
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE))
            {
                return InputAction.PlaceDown;
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_DOWN))
            {
                return InputAction.MoveDown;
            }

            //Check for rotate
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_UP))
            {
                return InputAction.Rotate;
            }

            //Check direction movement
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT))
            {
                return InputAction.MoveLeft;
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT))
            {
                return InputAction.MoveRight;
            }

            //Return NULL if no key is pressed.
            return InputAction.Null;
        }

    }
}
