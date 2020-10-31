using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.shapes
{
    // Authors: Greg Kulasik
    // Description: Implementation of the square shape, covering all the special logic to handle the shape's methods
    public class SquareShape : GameShape
    {

        // Author: Greg Kulasik
        public SquareShape(Block anchor, ShapeRenderer.Orientation orientation) : base (anchor, orientation)
        {
            this.anchor = anchor;

            // Check ShapeRenderer.draw___ which will tell you the color of the shape
            this.color = DrawColor.Shade.COLOR_RED;

            // Draw a grid and determine what the shape looks like when it is at 0, 90, 180, and 270 degrees.
            // Then determine the other block offsets. The anchor is (x, y), the block immediately on the right is (x+1, y), the block immediately below is (x, y-1), etc.
            // Handle adding/creating the other blocks for each potential orientation
            this.blocks.Add(anchor);
            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // 0 - anchor is on the top right
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // Block down
                    this.blocks.Add(anchor.Copy(new Vector2(-1, -1))); // Block down and left
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // Block to the left
                    break;
                case ShapeRenderer.Orientation.ORIENT_1: // 90 - anchor is on the bottom right
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // Block to the left
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 1))); // Block up and to the left
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // Block above
                    break;
                case ShapeRenderer.Orientation.ORIENT_2: // 180 - anchor is on the bottom left
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // Block above
                    this.blocks.Add(anchor.Copy(new Vector2(1, 1))); // Block above and to the right 
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // Block to the right
                    break;
                case ShapeRenderer.Orientation.ORIENT_3: // 270 - Anchor is on the top left
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // Block to the right
                    this.blocks.Add(anchor.Copy(new Vector2(1, -1))); // Block below and to the right
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // Block below
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation in SquareShape constructor: " + orientation);
            }

        }

        // Author: Greg Kulasik
        public override void ApplyAction(InputAction action)
        {
            ApplyActionToBlocks(action, blocks);
        }

        // Author: Greg Kulasik
        public override List<Block> CalcBlocksPostAction(InputAction action)
        {
            List<Block> newBlocks = CopyBlocks();
            ApplyActionToBlocks(action, newBlocks);
            return newBlocks;
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
        // Moves blocks in a certain direction by applying a vector offset.
        protected void Move(InputAction action, List<Block> blocksToMove)
        {
            Vector2 offset = new Vector2(0, 0);

            switch (action)
            {
                case InputAction.MoveDown:
                    offset = new Vector2(0, -1);
                    break;
                case InputAction.MoveLeft:
                    offset = new Vector2(-1, 0);
                    break;
                case InputAction.MoveRight:
                    offset = new Vector2(1, 0);
                    break;
                default:
                    throw new ArgumentException("Unexpected InputAction applied: " + action);
            }

            foreach (Block b in blocksToMove)
                b.ApplyOffset(offset);
        }

        // Author: Greg Kulasik
        // Rotates the shape in place (Square is special since rotate does not change the shape but we need to show it rotating - so the anchor will rotate around)
        // New offsets are calculated for each 90 degree rotation
        // For each block apply the roation for that block (both lists are ordered - blocks move clockwise)
        protected void Rotate(List<Block> blocksToRotate)
        {
            ShapeRenderer.Orientation nextOri = GetNextOrientation();
            Dictionary<ShapeRenderer.Orientation, List<Vector2>> nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();

            // Note: Set the first Vector2 to (0, 0) to not move the anchor
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0,  new[] { new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0), new Vector2(0, 1) }.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, new[] { new Vector2(0, -1), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0) }.ToList());
            // 90 -> 180
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, new[] { new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1) }.ToList());
            // 180 -> 270
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, new[] { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) }.ToList());

            List<Vector2> rotationOffsets;
            if(nextOriToOffsets.TryGetValue(nextOri, out rotationOffsets))
            {
                for(int i = 0; i < blocksToRotate.Count(); i++)
                {
                    blocksToRotate.ElementAt(i).ApplyOffset(rotationOffsets.ElementAt(i));
                }
            }
        }

        // Author: Greg Kulasik
        public override void Draw()
        {
            ShapeRenderer.drawSquare(anchor.GetX(), anchor.GetY(), orientation);
        }
    }
}
