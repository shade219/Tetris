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
            this.color = ShapeRenderer.GetSquareColor();
            anchor.SetColor(this.color);

            // Draw a grid and determine what the shape looks like when it is at 0, 90, 180, and 270 degrees.
            // Then determine the other block offsets. The anchor is (x, y), the block immediately on the right is (x+1, y), the block immediately below is (x, y-1), etc.
            // Handle adding/creating the other blocks for each potential orientation
            this.blocks.Add(anchor);
            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // 0 - Anchor is on the top left
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // Block to the right
                    this.blocks.Add(anchor.Copy(new Vector2(1, -1))); // Block below and to the right
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // Block below 
                    break;
                case ShapeRenderer.Orientation.ORIENT_1: // 90 - anchor is on the top right
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // Block down
                    this.blocks.Add(anchor.Copy(new Vector2(-1, -1))); // Block down and left
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // Block to the left 
                    break;
                case ShapeRenderer.Orientation.ORIENT_2: // 180 - anchor is on the bottom right
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // Block to the left
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 1))); // Block up and to the left
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // Block above
                    break;
                case ShapeRenderer.Orientation.ORIENT_3: // 270 - anchor is on the bottom left
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // Block above
                    this.blocks.Add(anchor.Copy(new Vector2(1, 1))); // Block above and to the right 
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // Block to the right
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation in SquareShape constructor: " + orientation);
            }

            //rotation offset dictionary
            this.nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();

            // Note: Set the first Vector2 to (0, 0) to not move the anchor
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0, new[] { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) }.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, new[] { new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0), new Vector2(0, 1) }.ToList());
            // 90 -> 180
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, new[] { new Vector2(0, -1), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0) }.ToList());
            // 180 -> 270
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, new[] { new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1) }.ToList());
        }


        // Author: Greg Kulasik
        public override void Draw()
        {
            ShapeRenderer.drawSquare(anchor.GetX(), anchor.GetY(), orientation);
        }
    }
}
