using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    public abstract class GameShape
    {
        Block anchor;
        List<Block> blocks;
        Shape.Orientation orientation;
        DrawColor.Shade color;
        bool isAboutToPlace;
        bool isPlaced;

        public abstract void draw();

        public abstract void applyAction();

        public abstract List<Block> calcBlocksPostAction();


    }
}
