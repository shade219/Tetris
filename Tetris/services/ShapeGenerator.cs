using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;
using Tetris.domain.shapes;

namespace Tetris.services
{
    // Authors: Yao-Hua Liu
    // Description: Static Class to Generate next GameShape. 
    //              Probability is calculated based on current level.
    //              The anchor coordinate is set to be in the preview window.
    public static class ShapeGenerator
    {
        // Author: Yao-Hua Liu
        private static readonly int ANCHOR_X = Constants.PREVIEW_WINDOW_X;
        private static readonly int ANCHOR_Y = Constants.PREVIEW_WINDOW_X;

        public static GameShape GenerateShape(int currentLevel)
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 1000);

            return PrivateGenerateShape(currentLevel, result);
        }

        private static GameShape PrivateGenerateShape(int currentLevel, int result)
        {
            int SquareAndL12Bound = SquareAndL12ShapeProbability(currentLevel);
            int LineShapeBound = LineShapeProbability();
            int TAndZ12Bound = TAndZ12ShapeProbability(currentLevel);

            Vector2 pos = new Vector2(ANCHOR_X, ANCHOR_Y);

            if (result < SquareAndL12Bound)
            {
                return new SquareShape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_RED), pos));
            }
            else if (result < SquareAndL12Bound * 2)
            {
                return new L1Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_BLUE), pos));
            }
            else if (result < SquareAndL12Bound * 3)
            {
                return new L2Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_PURPLE), pos));
            }
            else if (result < SquareAndL12Bound * 3 + LineShapeBound)
            {
                return new LineShape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_ORANGE), pos));
            }
            else if (result < SquareAndL12Bound * 3 + LineShapeBound + TAndZ12Bound)
            {
                return new TShape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_YELLOW), pos));
            }
            else if (result < SquareAndL12Bound * 3 + LineShapeBound + TAndZ12Bound * 2)
            {
                return new Z1Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_GREEN), pos));
            }
            else
            {
                return new Z2Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_CYAN), pos));
            }
        }

        private static int SquareAndL12ShapeProbability(int currentLevel)
        {
            return (int)((1.0f / 7.0f - ((float)(currentLevel - 4) / 75.0f)) * 1000.0f);
        }

        private static int LineShapeProbability()
        {
            return (int)((1.0f / 7.0f) * 1000.0f);
        }

        private static int TAndZ12ShapeProbability(int currentLevel)
        {
            return (int)((1.0f / 7.0f + ((float)(currentLevel - 4) / 75.0f)) * 1000.0f);
        }
    }
}
