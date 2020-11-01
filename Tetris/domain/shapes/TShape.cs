using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.shapes
{
    // Authors: Name1, Name2
    // Description:
    public class TShape : GameShape
    {

        // Author: Your Name Here
        public TShape(Block anchor, ShapeRenderer.Orientation orientation) : base(anchor, orientation)
        {

        }

        // Author: Your Name Here
        protected override void ApplyActionToBlocks(InputAction action, List<Block> blocksToApply)
        {
            throw new NotImplementedException();
        }

        // Author: Your Name Here
        public override List<Block> CalcBlocksPostAction(InputAction action)
        {
            throw new NotImplementedException();
        }

        // Author: Your Name Here
        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
