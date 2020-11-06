using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: DeAngelo
    // Description: a basic class representing 1 element in block grid -- GameShapes converted to 'Block'
    public class Block 
    { 
        public DrawColor.Shade color
        {
            get;
            private set;
        }

        private int x;
        private int y;

        // Author: DeAngelo Wilson
        public Block(int x, int y)
        {
            //default color of blocks -- set when attached to a GameShape
            this.color = DrawColor.Shade.COLOR_GREY;
            this.x = x;
            this.y = y;
        }
        // Author: DeAngelo Wilson
        public Block(DrawColor.Shade color, int x, int y)
        {
            //default color of blocks -- set when attached to a GameShape
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public Block(Vector2 coordinates) : this((int)coordinates.X, (int)coordinates.Y){ }

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

        public Block Copy(Vector2 offset)
        {
            Block b = new Block(this);
            b.ApplyOffset(offset);
            return b;
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

        public Vector2 GetPosition()
        {
            return new Vector2(x, y);
        }

        public DrawColor.Shade GetColor()
        {
            return color;
        }

        public void SetColor(DrawColor.Shade c)
        {
            this.color = c;
        }


    }
}
