using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: DeAngelo, Greg Kulasik
    // Description: A class which implements all shared functionality of derived shapes
                        //Used for active GameShapes prior to being store onto the BlockGrid
    public abstract class GameShape
    {
        //used for drawing GameShape
        protected Block anchor;
        private Boolean canMutateOrientation = false;

        //used for placing GameShape onto Game-BlockGrid
        public List<Block> blocks
        {
            get;
        }

        //NOTE:: rotation offset dictionary -- initialized by derived shape
        protected Dictionary<ShapeRenderer.Orientation, List<Vector2>> nextOriToOffsets;

        protected ShapeRenderer.Orientation orientation;
        protected DrawColor.Shade color;

        //NOTE:: Maintained by MovementManager
        public bool isAboutToPlace
        {
            get;
            private set;
        }
        //NOTE:: set by BlockGrid
        public bool isPlaced
        {
            get;
            private set;
        }

        // Author: DeAngelo Wilson
        protected GameShape(Block anchor, ShapeRenderer.Orientation orientation = ShapeRenderer.Orientation.ORIENT_0)
        {
            this.anchor = anchor;
            this.blocks = new List<Block>();
            this.orientation = orientation;
            this.isAboutToPlace = false;
            this.isPlaced = false;
        }

        // Author: Greg Kulasik
        public void MoveShapeToSpawn()
        {
            this.ApplyMoveOffset(new Vector2(-12, 3), blocks);
        }

        //************************************************************************
        // Abstract Functions (MUST be implemented)
        //************************************************************************

        //************************************************************************
        //
        //************************************************************************


        // Author: Greg Kulasik
        //apply rotation or movement offset to GameShape ('anchor' + 'blocks')
        public void ApplyAction(InputAction action)
        {
            canMutateOrientation = true;
            ApplyActionToBlocks(action, blocks);
            canMutateOrientation = false;
        }

        // Author: Greg Kulasik
        // Detects the type of action and calls Rotate or Move as appropriate
        protected void ApplyActionToBlocks(InputAction action, List<Block> blocksToApply)
        {
            switch (action)
            {
                case InputAction.Rotate:
                    Rotate(blocksToApply);
                    break;
                case InputAction.MoveDown:
                case InputAction.MoveLeft:
                case InputAction.MoveRight:
                    Move(action, blocksToApply);
                    break;
                default:
                    throw new ArgumentException("Unexpected InputAction applied: " + action);
            }
        }


        // Author: Greg Kulasik
        public List<Block> CalcBlocksPostAction(InputAction action)
        {
            List<Block> newBlocks = CopyBlocks();
            ApplyActionToBlocks(action, newBlocks);
            return newBlocks;
        }


        //Author: DeAngelo Wilson
        protected List<Block> CopyBlocks()
        {
            List<Block> newBlocks = new List<Block>();
            foreach (Block b in blocks)
            {
                newBlocks.Add(b.Copy());
            }
            return newBlocks;
        }

        //Author: DeAngelo Wilson
        private List<Block> CreateCopyOfBlocksArray()
        {
            Block[] blocksArray = new Block[blocks.Count];
            blocks.CopyTo(blocksArray);

            return new List<Block>(blocksArray);
        }

        //Author: DeAngelo Wilson
        //used to apply uniform offset to 'anchor' Block and 'blocks' Block array (anchor is includes in blocks list)
        private void ApplyMoveOffset(Vector2 offset, List<Block> blocksToMove)
        {
            foreach (Block b in blocksToMove)
            {
                b.ApplyOffset(offset);
            }
        }

        // Author: Greg Kulasik
        // Moves blocks in a certain direction by applying a vector offset.
            //Uniform for all derived GameShape's
        protected void Move(InputAction action, List<Block> blocksToMove)
        {
            switch (action)
            {
                case InputAction.MoveDown:
                    ApplyMoveOffset(Constants.DOWN_OFFSET, blocksToMove);
                    break;
                case InputAction.MoveLeft:
                    ApplyMoveOffset(Constants.LEFT_OFFSET, blocksToMove);
                    break;
                case InputAction.MoveRight:
                    ApplyMoveOffset(Constants.RIGHT_OFFSET, blocksToMove);
                    break;
                default:
                    throw new ArgumentException("Unexpected InputAction applied: " + action);
            }
        }


        // Author: Greg Kulasik
        // Rotates the shape in place (Square is special since rotate does not change the shape but we need to show it rotating - so the anchor will rotate around)
        // New offsets are calculated for each 90 degree rotation
        // For each block apply the roation for that block (both lists are ordered - blocks move clockwise)
        protected void Rotate(List<Block> blocksToRotate)
        {
            ShapeRenderer.Orientation nextOri = GetNextOrientation();

            List<Vector2> rotationOffsets;
            if (nextOriToOffsets.TryGetValue(nextOri, out rotationOffsets))
            {
                for (int i = 0; i < blocksToRotate.Count(); i++)
                {
                    blocksToRotate.ElementAt(i).ApplyOffset(rotationOffsets.ElementAt(i));
                }
                if(canMutateOrientation)
                    //set new orientation
                    this.orientation = nextOri;
            }

        }
        // Author: DeAngelo Wilson
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
        // Author: DeAngelo Wilson
        public IReadOnlyCollection<Block> GetBlocks()
        {
            return blocks.AsReadOnly();
        }

        // Author: DeAngelo Wilson
        public IReadOnlyCollection<Vector2> GetOrientationOffsets(ShapeRenderer.Orientation ori)
        {
            List<Vector2> offsets;
            nextOriToOffsets.TryGetValue(ori, out offsets);

            return offsets;
        }
        // Author: DeAngelo Wilson
        public ShapeRenderer.Orientation GetOrientation()
        {
            return orientation;
        }
        // Author: DeAngelo Wilson
        public DrawColor.Shade GetColor()
        {
            return color;
        }
        // Author: DeAngelo Wilson
        public void GameShapePlaced()
        {
            this.isPlaced = true;
        }
        // Author: DeAngelo Wilson
        public void AboutToPlaceGameShape()
        {
            this.isAboutToPlace = true;
        }
        // Author: DeAngelo Wilson
        public void ResetAboutToPlaceFlag()
        {
            this.isAboutToPlace = false;
        }

        // Author: Greg Kulasik
        public void Draw()
        {
            foreach(Block b in blocks)
            {
                SOM.drawBox(b.GetX(), b.GetY(), b.color);
            }
        }

        // Author: Greg Kulasik
        // Print helper for debugging
        override public String ToString()
        {
            String blockString = "";
            foreach (Block b in blocks)
            {
                blockString += $"({b.GetX()}, {b.GetY()})";
            }
            return $"{this.GetType().Name}: {blockString}";
        }

    }
}