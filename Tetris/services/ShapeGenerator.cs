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
    //
    // Step 1: Generate an integer randomly between 1-1000.
    // Step 2: Calculate the probability for each shape.
    // Step 3: Determine which shape to generate.
    //
    // Using Level 1 as example, given a randomly generated integer n, the shape to generate is determined based on this map:
    // -----------------------------------------------------------------------------------------------------------------------------------
    // |  SHAPE  |    Square    |       L1       |       L2       |       Line        |        T       |       Z1       |       Z2       | 
    // -----------------------------------------------------------------------------------------------------------------------------------
    // | FORMULA |  Round(1/7 - (currentLevel -4)/75, 3) * 1000   | Floor(1/7 * 1000) |   Round(1/7 + (currentLevel -4)/75, 3) * 1000    |
    // -----------------------------------------------------------------------------------------------------------------------------------
    // |  PROBA  |      183     |       183      |       183      |       142         |       103      |       103      |       103      |
    // -----------------------------------------------------------------------------------------------------------------------------------
    // |  RANGE  | 0 < n <= 183 | 183 < n <= 366 | 366 < n <= 549 |  549 < n <= 691   | 691 < n <= 794 | 794 < n <= 897 | 897 < n <= 1000|
    // -----------------------------------------------------------------------------------------------------------------------------------
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

            switch (result)
            {
                case int n when (n <= SquareAndL12Bound):
                    return new SquareShape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_RED), pos));
                case int n when (n <= SquareAndL12Bound * 2):
                    return new L1Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_BLUE), pos));
                case int n when (n <= SquareAndL12Bound * 3):
                    return new L2Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_PURPLE), pos));
                case int n when (n <= SquareAndL12Bound * 3 + LineShapeBound):
                    return new LineShape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_ORANGE), pos));
                case int n when (n <= SquareAndL12Bound * 3 + LineShapeBound + TAndZ12Bound):
                    return new TShape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_YELLOW), pos));
                case int n when (n <= SquareAndL12Bound * 3 + LineShapeBound + TAndZ12Bound * 2):
                    return new Z1Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_GREEN), pos));
                default:
                    return new Z2Shape(new Block(DrawColor.getColor(DrawColor.Shade.COLOR_DK_CYAN), pos));
            }
        }

        private static int SquareAndL12ShapeProbability(int currentLevel)
        {
            return (int)(Math.Round(1.0f / 7.0f - ((float)(currentLevel - 4) / 75.0f), 3) * 1000.0f);
        }

        private static int LineShapeProbability()
        {
            return (int)Math.Floor((1.0f / 7.0f) * 1000.0f);
        }

        private static int TAndZ12ShapeProbability(int currentLevel)
        {
            return (int)(Math.Round(1.0f / 7.0f + ((float)(currentLevel - 4) / 75.0f), 3) * 1000.0f);
        }
    }
}
