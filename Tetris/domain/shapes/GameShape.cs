<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: Name1, Name2
    // Description:
    public abstract class GameShape
    {
        //used for drawing GameShape
        Block anchor;

        //used for placing GameShape onto Game-BlockGrid
        public List<Block> blocks
        {
            get;
        }

        ShapeRenderer.Orientation orientation;
        DrawColor.Shade color;
        bool isAboutToPlace;
        bool isPlaced;

        //MOVED TO Tetris.Constants
        //public Vector2 downOffset;
        //public Vector2 upOffset;
        //public Vector2 leftOffset;
        //public Vector2 rightOffset;


        protected GameShape(Block anchor)
        {
            this.anchor = anchor;
            blocks = new List<Block>();
            isAboutToPlace = false;
            isPlaced = false;
        }

        //Draw GameShape at 'anchor' in 'orientation'
        public abstract void Draw();

        //apply rotation or movement offset to GameShape ('anchor' + 'blocks')
        public abstract void ApplyAction(InputAction action);

        public abstract List<Block> CalcBlocksPostAction(InputAction action);

        //DeAngelo Wilson
        private List<Block> CreateCopyOfBlocksArray()
        {
            Block[] blocksArray = new Block[blocks.Count];
            blocks.CopyTo(blocksArray);

            return new List<Block>(blocksArray);
        }

        //used to apply uniform offset to 'anchor' Block and 'blocks' Block array
        protected void ApplyMovementCoordinateOffset(Vector2 offset)
        {
            anchor.ApplyOffset(offset);

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
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation");
            }

            return ori;
        }
    }
}