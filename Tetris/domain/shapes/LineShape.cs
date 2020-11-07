using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.shapes
{
    // Authors: Alex Schertler
    // Description: Rotates the Line shape around the anchor point
    public class LineShape : GameShape
    {

        // Author: Alex Schertler
        public LineShape(Block anchor, ShapeRenderer.Orientation orientation = ShapeRenderer.Orientation.ORIENT_0) : base(anchor, orientation)
        {
            

            // Check ShapeRenderer.draw___ which will tell you the color of the shape
            this.color = ShapeRenderer.GetLineColor();
            anchor.SetColor(this.color);

            this.blocks.Add(anchor);
            
            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // 0 - anchor is second to left
                case ShapeRenderer.Orientation.ORIENT_2:
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 1 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // 3 (block to close right)
                    this.blocks.Add(anchor.Copy(new Vector2(2, 0))); // 4 (block to far right)
                    break;
                case ShapeRenderer.Orientation.ORIENT_1: // 90 - anchor is second from top
                case ShapeRenderer.Orientation.ORIENT_3:
                    this.blocks.Add(anchor.Copy(new Vector2(0, 1))); // 1 (block above)
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 3 (block to close below)
                    this.blocks.Add(anchor.Copy(new Vector2(0, -2))); // 4 (block to far below)
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation in LineShape constructor: " + orientation);
            }

            anchor.SetColor(ShapeRenderer.GetLineAnchorColor());

            //rotation offset dictionary
            this.nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();

            var vectorSetOne = new[] { new Vector2(0, 0), new Vector2(-1, -1), new Vector2(1, 1), new Vector2(2, 2) };
            var vectorSetTwo = new[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(-1, -1), new Vector2(-2, -2) };
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0, vectorSetOne.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, vectorSetTwo.ToList());
            // 90 -> 180 (same as 270 -> 0)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, vectorSetOne.ToList());
            // 180 -> 270 (same as 0 -> 90)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, vectorSetTwo.ToList());
        }


    }
}
