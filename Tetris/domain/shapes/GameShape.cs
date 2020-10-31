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
    public abstract class GameShape
    {
        //used for drawing GameShape
        protected Block anchor;

        //used for placing GameShape onto Game-BlockGrid
        public List<Block> blocks
        {
            get;
        }

        protected ShapeRenderer.Orientation orientation;
        protected DrawColor.Shade color;
        protected bool isAboutToPlace;
        protected bool isPlaced;

        //MOVED TO Tetris.Constants
        //public Vector2 downOffset;
        //public Vector2 upOffset;
        //public Vector2 leftOffset;
        //public Vector2 rightOffset;


        protected GameShape(Block anchor, ShapeRenderer.Orientation orientation = ShapeRenderer.Orientation.ORIENT_0)
        {
            this.anchor = anchor;
            blocks = new List<Block>();
            isAboutToPlace = false;
            isPlaced = false;
            this.orientation = orientation;
        }

        //Draw GameShape at 'anchor' in 'orientation'
        public abstract void Draw();

        //apply rotation or movement offset to GameShape ('anchor' + 'blocks')
        public abstract void ApplyAction(InputAction action);

        public abstract List<Block> CalcBlocksPostAction(InputAction action);


        protected List<Block> CopyBlocks()
        {
            List<Block> newBlocks = new List<Block>();
            foreach (Block b in blocks)
            {
                newBlocks.Add(b.Copy());
            }
            return newBlocks;
        }

        //DeAngelo Wilson
        private List<Block> CreateCopyOfBlocksArray()
        {
            Block[] blocksArray = new Block[blocks.Count];
            blocks.CopyTo(blocksArray);

            return new List<Block>(blocksArray);
        }

        //used to apply uniform offset to 'anchor' Block and 'blocks' Block array (anchor is includes in blocks list)
        protected void ApplyMovementCoordinateOffset(Vector2 offset)
        {
            foreach (Block b in blocks)
            {
                b.ApplyOffset(offset);
            }
        }

        //public abstract void RotateGameShape();

        public ShapeRenderer.Orientation GetNextOrientation()
        {
            ShapeRenderer.Orientation ori;

            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0:
                    ori = ShapeRenderer.Orientation.ORIENT_1;
                    break;
                case ShapeRenderer.Orientation.ORIENT_1:
                    ori = ShapeRenderer.Orientation.ORIENT_2;
                    break;
                case ShapeRenderer.Orientation.ORIENT_2:
                    ori = ShapeRenderer.Orientation.ORIENT_3;
                    break;
                case ShapeRenderer.Orientation.ORIENT_3:
                    ori = ShapeRenderer.Orientation.ORIENT_0;
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation: " + orientation);
            }

            return ori;
        }
    }
}