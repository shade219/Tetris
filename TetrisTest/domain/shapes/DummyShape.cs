using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tetris;
using Tetris.domain;

namespace TetrisTest.domain.shapes
{
public class DummyShape : GameShape
    {
        // Author: Greg Kulasik
        public DummyShape(Block anchor, ShapeRenderer.Orientation orientation) : base(anchor, orientation)
        {
            // Check ShapeRenderer.draw___ which will tell you the color of the shape
            this.color = DrawColor.Shade.COLOR_GREY;

            this.blocks.Add(anchor);

            //rotation offset dictionary
            this.nextOriToOffsets = new Dictionary<ShapeRenderer.Orientation, List<Vector2>>();
            // 270 -> 0
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_0, new[] { new Vector2(0, 0) }.ToList());
            // 0 -> 90
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_1, new[] { new Vector2(0, 0) }.ToList());
            // 90 -> 180
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_2, new[] { new Vector2(0, 0) }.ToList());
            // 180 -> 270
            nextOriToOffsets.Add(ShapeRenderer.Orientation.ORIENT_3, new[] { new Vector2(0, 0) }.ToList());
        }


        // Author: Greg Kulasik
        public override void Draw()
        {
            //ShapeRenderer.drawSquare(anchor.GetX(), anchor.GetY(), orientation);
        }

    }
}

