using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: DeAngelo, Name2
    // Description:
    public class Block
    {
        readonly DrawColor.Shade color;

        //private Vector<int> coordinates;
        private int x;
        private int y;

        // Author: Your Name Here
        public Block(DrawColor.Shade color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public Block(Block block)
        {
            x = block.GetX();
            y = block.GetY();
            color = block.color;
        }


        // Author: DeAngelo
        public Block Copy()
        {
            return new Block(this);
        }

        public void Draw()
        {
            SOM.drawBox(x, y, color);
        }

        public void ApplyOffset(Vector2 offset)
        {
            x += (int) offset.X;
            y += (int) offset.Y;
        }


        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }
    }
}
