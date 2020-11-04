using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: Name1, Name2
    // Description:
    public class Block
    {
        public DrawColor.Shade color
        {
            get;
            private set;
        }
        Vector2 coordinates;
        private int x;
        private int y;
        // Author: Your Name Here
        public Block(Azul.Color color, Vector2 coordinates)
        {

        }

        // Author: Your Name Here
        public Block Copy()
        {
            return null;
        }

        public void Draw()
        {
            SOM.drawBox(x, y, color);
        }
    }
}
