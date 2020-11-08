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
        InputAction actionToAvoidRepeating;
        //Timer inputRepeatProtector;

        public InputReader()
        {
            this.lastAction = InputAction.Null;
            this.actionToAvoidRepeating = InputAction.Null;
            //this.inputRepeatProtector = new Timer(35);
            //this.inputRepeatProtector.ResetTimer();
        }

        public InputAction GetLastAction()
        {
            InputAction toReturn = lastAction;
            // Store the last action we recorded/will process
            // This way if the same input comes up immediately after (Null should show up)
            // then we know we captured a double input
            actionToAvoidRepeating = toReturn;
            lastAction = InputAction.Null;

            return toReturn;
        }

        //NOTE:: does not register multiple key presses (ignores the "2nd" keystroke)
        // Author: Brian Moore
        public void GetInputs()
        {
            // Don't record input too often
            //if (!inputRepeatProtector.IsExpired()) return;
            // Process lastAction recorded before getting new input
            if (lastAction != InputAction.Null) return;


            //First check for Pause
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_P))
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

            // If we register the same key twice in a row then the key 
            // is likely being held down so slow down the processing to accomodate 
            // longer key press wihtout double input
            // Set to Null so that we can accept the same input next time 
            // (max delay of input inputRepeatProtector * 2)
            if (lastAction == actionToAvoidRepeating)
                lastAction = InputAction.Null;

            //inputRepeatProtector.ResetTimer();

            if(lastAction != InputAction.Null)
                Console.WriteLine($"Input recorded: {lastAction}");
        }
    }
}
