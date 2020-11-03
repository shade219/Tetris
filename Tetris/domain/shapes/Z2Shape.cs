using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.shapes
{
    // Authors: Alex Schertler
    // Description: Rotates the Z2 shape around its anchor
    public class Z2Shape : GameShape
    {

        // Author: Alex Schertler
        public Z2Shape(Block anchor, ShapeRenderer.Orientation orientation) : base(anchor, orientation)
        {
            //this.anchor = anchor;

            // Check ShapeRenderer.draw___ which will tell you the color of the shape
            this.color = ShapeRenderer.GetZ2Color();

            // Draw a grid and determine what the shape looks like when it is at 0, 90, 180, and 270 degrees.
            // Then determine the other block offsets. The anchor is (x, y), the block immediately on the right is (x+1, y), the block immediately below is (x, y-1), etc.
            // Handle adding/creating the other blocks for each potential orientation
            this.blocks.Add(anchor);
            //NOTE:: Swapped ordering of anchors <==> Orientations ---> matching ShapeRenderer*
            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // 0 - anchor is on the top of middle collumn
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // 3 (block to right)
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 4 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, -1))); // 1 (block below and to left)
                    break;
                case ShapeRenderer.Orientation.ORIENT_1: // 90 - anchor is on the top of right collumn
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 3 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 4 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 1))); // 1 (block above and to left)
                    break;
                case ShapeRenderer.Orientation.ORIENT_2: // 180 - anchor is on the top of middle collumn
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // 3 (block to right)
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 4 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, -1))); // 1 (block below and to left)
                    break;
                case ShapeRenderer.Orientation.ORIENT_3: // 270 - anchor is on the top of right collumn
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 3 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 4 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 1))); // 1 (block above and to left)
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation in SquareShape constructor: " + orientation);
            }

            //rotation offset dictionary
            this.nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();

            // Note: Set the first Vector2 to (0, 0) to not move the anchor
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0, new[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(1, -1), new Vector2(0, -2) }.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, new[] { new Vector2(0, 0), new Vector2(-1, -1), new Vector2(-1, 1), new Vector2(0, 2) }.ToList());
            // 90 -> 180 (same as 270 -> 0)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, new[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(1, -1), new Vector2(0, -2) }.ToList());
            // 180 -> 270 (same as 0 -> 90)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, new[] { new Vector2(0, 0), new Vector2(-1, -1), new Vector2(-1, 1), new Vector2(0, 2) }.ToList());
        }


        // Author: Alex Schertler
        public override void Draw()
        {
        ShapeRenderer.drawZ2(anchor.GetX(), anchor.GetY(), orientation);
        }
    }
}
