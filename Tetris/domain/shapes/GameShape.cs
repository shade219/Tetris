using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: Name1, Name2
    // Description:
    public abstract class GameShape
    {
        Block anchor;
        List<Block> blocks;
        ShapeRenderer.Orientation orientation;
        DrawColor.Shade color;
        public bool isAboutToPlace;
        public bool isPlaced;

        public GameShape(Block anchor)
        {
            this.anchor = anchor;
        }

        public abstract void Draw();

        public abstract void ApplyAction(InputAction action);

        public abstract List<Block> CalcBlocksPostAction(InputAction action);


    }
}
