using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.shapes
{
    // Authors: Alex Schertler
    // Description: Rotates the Z1 shape around its anchor
    public class Z1Shape : GameShape
    {

        // Author: Alex Schertler
        public Z1Shape(Block anchor, ShapeRenderer.Orientation orientation = ShapeRenderer.Orientation.ORIENT_0) : base(anchor, orientation)
        {
            

            // Check ShapeRenderer.draw___ which will tell you the color of the shape
            this.color = ShapeRenderer.GetZ1Color();
            anchor.SetColor(this.color);

            // Draw a grid and determine what the shape looks like when it is at 0, 90, 180, and 270 degrees.
            // Then determine the other block offsets. The anchor is (x, y), the block immediately on the right is (x+1, y), the block immediately below is (x, y-1), etc.
            // Handle adding/creating the other blocks for each potential orientation
            this.blocks.Add(anchor);
            //NOTE:: Swapped ordering of anchors <==> Orientations ---> matching ShapeRenderer*
            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // 0 - anchor is on the top middle collumn
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 1 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 4 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(1, -1))); // 3 (block below and to right)
                    break;
                case ShapeRenderer.Orientation.ORIENT_1: // 90 - anchor is on the bottom right collumn
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // 1 (block above)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 4 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, -1))); // 3 (block below and to left)
                    break;
                case ShapeRenderer.Orientation.ORIENT_2: // 180 - anchor is on the top middle collumn
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 1 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 4 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(1, -1))); // 3 (block below and to right)
                    break;
                case ShapeRenderer.Orientation.ORIENT_3: // 270 - anchor is on the bottom right collumn
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // 1 (block above)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 4 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, -1))); // 3 (block below and to left)
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation in SquareShape constructor: " + orientation);
            }

            //rotation offset dictionary
            this.nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();

            // Note: Set the first Vector2 to (0, 0) to not move the anchor
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0, new[] { new Vector2(0, 0), new Vector2(-1, -1), new Vector2(1, -1), new Vector2(2, 0) }.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, new[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(-1, 1), new Vector2(-2, 0) }.ToList());
            // 90 -> 180 (same as 270 -> 0)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, new[] { new Vector2(0, 0), new Vector2(-1, -1), new Vector2(1, -1), new Vector2(2, 0) }.ToList());
            // 180 -> 270 (same as 0 -> 90)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, new[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(-1, 1), new Vector2(-2, 0) }.ToList());
        }


        // Author: Alex Schertler
        public override void Draw()
        {
            ShapeRenderer.drawZ1(anchor.GetX(), anchor.GetY(), orientation);

        }
    }
}
