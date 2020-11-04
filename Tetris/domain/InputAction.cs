using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{

    // Authors: Greg Kulasik
    // Description: Represents valid inputs as an enum
    public enum InputAction
    {
        PlaceDown,
        MoveDown,
        MoveLeft,
        MoveRight,
        Rotate,
        Pause,
        Null
    }
}
