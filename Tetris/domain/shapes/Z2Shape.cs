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
        public Z2Shape(Block anchor, ShapeRenderer.Orientation orientation = ShapeRenderer.Orientation.ORIENT_0) : base(anchor, orientation)
        {
            

            // Check ShapeRenderer.draw___ which will tell you the color of the shape
            this.color = ShapeRenderer.GetZ2Color();
            anchor.SetColor(this.color);

            this.blocks.Add(anchor);
            
            switch (orientation)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // 0 - anchor is on the top of middle collumn
                case ShapeRenderer.Orientation.ORIENT_2:
                    this.blocks.Add(anchor.Copy(new Vector2(1, 0))); // 3 (block to right)
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 4 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, -1))); // 1 (block below and to left)
                    break;
                case ShapeRenderer.Orientation.ORIENT_1: // 90 - anchor is on the top of right collumn
                case ShapeRenderer.Orientation.ORIENT_3:
                    this.blocks.Add(anchor.Copy(new Vector2(0, -1))); // 3 (block below)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 0))); // 4 (block to left)
                    this.blocks.Add(anchor.Copy(new Vector2(-1, 1))); // 1 (block above and to left)
                    break;
                default:
                    throw new ArgumentException("Unexpected ShapeRenderer::Orientation in Z2Shape constructor: " + orientation);
            }

            //rotation offset dictionary
            this.nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();

            var vectorSetOne = new[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(1, -1), new Vector2(0, -2) };
            var vectorSetTwo = new[] { new Vector2(0, 0), new Vector2(-1, -1), new Vector2(-1, 1), new Vector2(0, 2) };
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0, vectorSetOne.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, vectorSetTwo.ToList());
            // 90 -> 180 (same as 270 -> 0)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, vectorSetOne.ToList());
            // 180 -> 270 (same as 0 -> 90)
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, vectorSetTwo.ToList());
        }


        // Author: Alex Schertler
        public override void Draw()
        {
        ShapeRenderer.drawZ2(anchor.GetX(), anchor.GetY(), orientation);
        }
    }
}
