using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.shapes
{
    // Authors: Dillon Gould
    // Description: Implementation of the T shape, drawing the shape and setting the orientation of the shape. 
    public class L1Shape : GameShape
    {
        // Author: Your Name Here
        public L1Shape(Block anchor, ShapeRenderer.Orientation orientation) : base (anchor, orientation)
        {
            //this.anchor = anchor;

            // Check ShapeRenderer.draw___ which will tell you the color of the shape
            this.color = ShapeRenderer.GetL1Color();

            // Draw a grid and determine what the shape looks like when it is at 0, 90, 180, and 270 degrees.
            // Then determine the other block offsets. The anchor is (x, y), the block immediately on the right is (x+1, y), the block immediately below is (x, y-1), etc.
            // Handle adding/creating the other blocks for each potential orientation
            this.blocks.Add(anchor);
            //NOTE:: Swapped ordering of anchors <==> Orientations ---> matching ShapeRenderer*
            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // 0 - Anchor is on the top left
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // Block the the left 2
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // Block to the right 3
                    this.blocks.Add(anchor.Copy(new Vector2(2, 0))); // Block below 4
                    break;
                case ShapeRenderer.Orientation.ORIENT_1: // 90 - anchor is on the top right
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // Block above 2
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // Block below 3
                    this.blocks.Add(anchor.Copy(new Vector2(0, 2))); // Block to the left 4
                    break;
                case ShapeRenderer.Orientation.ORIENT_2: // 180 - anchor is on the bottom right
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // Block to the right 2
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // Block to the left 3
                    this.blocks.Add(anchor.Copy(new Vector2(-2, 0))); // Block above 4
                    break;
                case ShapeRenderer.Orientation.ORIENT_3: // 270 - anchor is on the bottom left
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // Block  below 2
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // Block above 3
                    this.blocks.Add(anchor.Copy(new Vector2(0, -2))); // Block to the right 4
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation in SquareShape constructor: " + orientation);
            }

            //rotation offset dictionary
            this.nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();

            // Note: Set the first Vector2 to (0, 0) to not move the anchor
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0, new[] { new Vector2(0, 0), new Vector2(1, -1), new Vector2(1, 1), new Vector2(2, 2) }.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, new[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(-1, 1), new Vector2(-2, 2) }.ToList());
            // 90 -> 180
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, new[] { new Vector2(0, 0), new Vector2(-1, 1), new Vector2(-1, -1), new Vector2(-2, -2) }.ToList());
            // 180 -> 270
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, new[] { new Vector2(0, 0), new Vector2(-1, -1), new Vector2(1, -1), new Vector2(2, -2) }.ToList());
        }

        // Authors: Dillon Gould
        public override void Draw()
        {
            ShapeRenderer.drawL1(anchor.GetX(), anchor.GetY(), orientation);
        }
    }
}
