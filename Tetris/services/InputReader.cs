using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;

namespace Tetris.services
{
    public static class InputReader
    {

        public static InputAction GetInputs()
        {
            return InputAction.Rotate;
        }

    }
}
