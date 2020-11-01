using System;
using Azul;

namespace Tetris
{
    public static class ShapeRenderer
    {
        public enum Orientation
        {
            ORIENT_0, // 0
            ORIENT_1, // 90
            ORIENT_2, // 180
            ORIENT_3  // 270
        };

        public static void drawLine(int coor_x, int coor_y, Orientation orient)
        {

            switch (orient)
            {
                case ShapeRenderer.Orientation.ORIENT_0: // Horizontal
                    SOM.drawBox(coor_x - 1, coor_y, GetLineColor());
                    SOM.drawBox(coor_x + 0, coor_y, GetLineAnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetLineColor());
                    SOM.drawBox(coor_x + 2, coor_y, GetLineColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_1: // Vertical
                    SOM.drawBox(coor_x, coor_y + 1, GetLineColor());
                    SOM.drawBox(coor_x, coor_y + 0, GetLineAnchorColor());
                    SOM.drawBox(coor_x, coor_y - 1, GetLineColor());
                    SOM.drawBox(coor_x, coor_y - 2, GetLineColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_2: // Horizontal
                    SOM.drawBox(coor_x - 2, coor_y, GetLineColor());
                    SOM.drawBox(coor_x - 1, coor_y, GetLineColor());
                    SOM.drawBox(coor_x + 0, coor_y, GetLineAnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetLineColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_3: // Vertical
                    SOM.drawBox(coor_x, coor_y + 2, GetLineColor());
                    SOM.drawBox(coor_x, coor_y + 1, GetLineColor());
                    SOM.drawBox(coor_x, coor_y + 0, GetLineAnchorColor());
                    SOM.drawBox(coor_x, coor_y - 1, GetLineColor());
                    break;

                default:
                    break;
            }
        }

        public static void drawT(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case ShapeRenderer.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 1, coor_y, GetTColor());
                    SOM.drawBox(coor_x + 0, coor_y, GetTAnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetTColor());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetTColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x, coor_y + 1, GetTColor());
                    SOM.drawBox(coor_x, coor_y + 0, GetTAnchorColor());
                    SOM.drawBox(coor_x, coor_y - 1, GetTColor());
                    SOM.drawBox(coor_x - 1, coor_y, GetTColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetTColor());
                    SOM.drawBox(coor_x - 1, coor_y, GetTColor());
                    SOM.drawBox(coor_x + 0, coor_y, GetTAnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetTColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x + 1, coor_y, GetTColor());
                    SOM.drawBox(coor_x, coor_y + 1, GetTColor());
                    SOM.drawBox(coor_x, coor_y + 0, GetTAnchorColor());
                    SOM.drawBox(coor_x, coor_y - 1, GetTColor());
                    break;

                default:
                    break;
            }
        }

        public static void drawL1(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case ShapeRenderer.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x + 0, coor_y, GetL1AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetL1Color());
                    SOM.drawBox(coor_x + 2, coor_y, GetL1Color());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetL1Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_1:

                    SOM.drawBox(coor_x - 1, coor_y, GetL1Color());
                    SOM.drawBox(coor_x + 0, coor_y + 0, GetL1AnchorColor());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetL1Color());
                    SOM.drawBox(coor_x + 0, coor_y - 2 , GetL1Color());


                    break;

                case ShapeRenderer.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x - 2, coor_y, GetL1Color());
                    SOM.drawBox(coor_x - 1, coor_y, GetL1Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetL1AnchorColor());
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetL1Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x, coor_y + 2, GetL1Color());
                    SOM.drawBox(coor_x, coor_y + 1, GetL1Color());
                    SOM.drawBox(coor_x, coor_y + 0, GetL1AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y + 0 , GetL1Color());
                    break;

                default:
                    break;
            }
        }

        public static void drawL2(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case ShapeRenderer.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 2, coor_y, GetL2Color());
                    SOM.drawBox(coor_x - 1, coor_y, GetL2Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetL2AnchorColor());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetL2Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_1:

                    SOM.drawBox(coor_x - 1, coor_y, GetL2Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetL2AnchorColor());
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetL2Color());
                    SOM.drawBox(coor_x + 0, coor_y + 2, GetL2Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 2, coor_y, GetL2Color());
                    SOM.drawBox(coor_x + 1, coor_y, GetL2Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetL2AnchorColor());
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetL2Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x, coor_y - 2, GetL2Color());
                    SOM.drawBox(coor_x, coor_y - 1, GetL2Color());
                    SOM.drawBox(coor_x, coor_y + 0, GetL2AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y + 0, GetL2Color());
                    break;

                default:
                    break;
            }
        }

        public static void drawZ1(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case ShapeRenderer.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 1, coor_y, GetZ1Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetZ1AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y - 1, GetZ1Color());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetZ1Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x, coor_y + 1, GetZ1Color());
                    SOM.drawBox(coor_x, coor_y + 0, GetZ1AnchorColor());
                    SOM.drawBox(coor_x - 1, coor_y - 1, GetZ1Color());
                    SOM.drawBox(coor_x - 1, coor_y, GetZ1Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetZ1Color());
                    SOM.drawBox(coor_x - 1, coor_y + 1, GetZ1Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetZ1AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetZ1Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x + 1, coor_y, GetZ1Color());
                    SOM.drawBox(coor_x + 1, coor_y + 1, GetZ1Color());
                    SOM.drawBox(coor_x, coor_y + 0, GetZ1AnchorColor());
                    SOM.drawBox(coor_x, coor_y - 1, GetZ1Color());
                    break;

                default:
                    break;
            }
        }

        public static void drawZ2(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case ShapeRenderer.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 1, coor_y - 1, GetZ2Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetZ2AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetZ2Color());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetZ2Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x - 1, coor_y + 1, GetZ2Color());
                    SOM.drawBox(coor_x, coor_y + 0, GetZ2AnchorColor());
                    SOM.drawBox(coor_x, coor_y - 1, GetZ2Color());
                    SOM.drawBox(coor_x - 1, coor_y, GetZ2Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetZ2Color());
                    SOM.drawBox(coor_x - 1, coor_y, GetZ2Color());
                    SOM.drawBox(coor_x + 0, coor_y, GetZ2AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y + 1, GetZ2Color());
                    break;

                case ShapeRenderer.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x + 1, coor_y, GetZ2Color());
                    SOM.drawBox(coor_x, coor_y + 1, GetZ2Color());
                    SOM.drawBox(coor_x, coor_y + 0, GetZ2AnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y - 1, GetZ2Color());
                    break;

                default:
                    break;
            }
        }

        public static void drawSquare(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case ShapeRenderer.Orientation.ORIENT_0:// Anchor -- Top-left
                    SOM.drawBox(coor_x + 0, coor_y, GetSquareAnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetSquareColor());
                    SOM.drawBox(coor_x + 1, coor_y - 1, GetSquareColor());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetSquareColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_1:// Anchor -- Top-right
                    SOM.drawBox(coor_x + 0, coor_y, GetSquareAnchorColor());
                    SOM.drawBox(coor_x - 1, coor_y, GetSquareColor());
                    SOM.drawBox(coor_x - 1, coor_y - 1, GetSquareColor());
                    SOM.drawBox(coor_x + 0, coor_y - 1, GetSquareColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_2:// Anchor -- Bottom-right
                    SOM.drawBox(coor_x + 0, coor_y, GetSquareAnchorColor());
                    SOM.drawBox(coor_x - 1, coor_y, GetSquareColor());
                    SOM.drawBox(coor_x - 1, coor_y + 1, GetSquareColor());
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetSquareColor());
                    break;

                case ShapeRenderer.Orientation.ORIENT_3:// Anchor -- Bottom-left
                    SOM.drawBox(coor_x + 0, coor_y, GetSquareAnchorColor());
                    SOM.drawBox(coor_x + 1, coor_y, GetSquareColor());
                    SOM.drawBox(coor_x + 1, coor_y + 1, GetSquareColor());
                    SOM.drawBox(coor_x + 0, coor_y + 1, GetSquareColor());
                    break;

                default:
                    break;
            }
        }



        public static DrawColor.Shade GetLineColor()
        {
            return DrawColor.Shade.COLOR_ORANGE;
        }
        public static DrawColor.Shade GetLineAnchorColor()
        {
            return DrawColor.Shade.COLOR_DK_ORANGE;
        }

        public static DrawColor.Shade GetSquareColor()
        {
            return DrawColor.Shade.COLOR_RED;
        }
        public static DrawColor.Shade GetSquareAnchorColor()
        {
            return DrawColor.Shade.COLOR_DK_RED;
        }

        public static DrawColor.Shade GetTColor()
        {
            return DrawColor.Shade.COLOR_YELLOW;
        }
        public static DrawColor.Shade GetTAnchorColor()
        {
            return DrawColor.Shade.COLOR_DK_YELLOW;
        }

        public static DrawColor.Shade GetZ1Color()
        {
            return DrawColor.Shade.COLOR_LT_GREEN;
        }
        public static DrawColor.Shade GetZ1AnchorColor()
        {
            return DrawColor.Shade.COLOR_DK_GREEN;
        }
        
        public static DrawColor.Shade GetZ2Color()
        {
            return DrawColor.Shade.COLOR_CYAN;
        }
        public static DrawColor.Shade GetZ2AnchorColor()
        {
            return DrawColor.Shade.COLOR_DK_CYAN;
        }

        public static DrawColor.Shade GetL1Color()
        {
            return DrawColor.Shade.COLOR_BLUE;
        }
        public static DrawColor.Shade GetL1AnchorColor()
        {
            return DrawColor.Shade.COLOR_DK_BLUE;
        }
        
        public static DrawColor.Shade GetL2Color()
        {
            return DrawColor.Shade.COLOR_PURPLE;
        }
        public static DrawColor.Shade GetL2AnchorColor()
        {
            return DrawColor.Shade.COLOR_DK_PURPLE;
        }
    }
}
