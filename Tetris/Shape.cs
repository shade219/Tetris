using System;

namespace Tetris
{
    static class Shape
    {
        public enum Orientation
        {
            ORIENT_0,
            ORIENT_1,
            ORIENT_2,
            ORIENT_3
        };


        public static void drawLine(int coor_x, int coor_y, Orientation orient)
        {

            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_ORANGE);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x + 2, coor_y, DrawColor.Shade.COLOR_ORANGE);
                    break;

                case Shape.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x, coor_y + 1, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_ORANGE);
                    SOM.drawBox(coor_x, coor_y - 1, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x, coor_y - 2, DrawColor.Shade.COLOR_ORANGE);
                    break;

                case Shape.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x - 2, coor_y, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_ORANGE);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_ORANGE);
                    break;

                case Shape.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x, coor_y + 2, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x, coor_y + 1, DrawColor.Shade.COLOR_ORANGE);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_ORANGE);
                    SOM.drawBox(coor_x, coor_y - 1, DrawColor.Shade.COLOR_ORANGE);
                    break;

                default:
                    break;
            }
        }

        public static void drawT(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_YELLOW);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_YELLOW);
                    break;

                case Shape.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x, coor_y + 1, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_YELLOW);
                    SOM.drawBox(coor_x, coor_y - 1, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_YELLOW);
                    break;

                case Shape.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_YELLOW);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_YELLOW);
                    break;

                case Shape.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x, coor_y + 1, DrawColor.Shade.COLOR_YELLOW);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_YELLOW);
                    SOM.drawBox(coor_x, coor_y - 1, DrawColor.Shade.COLOR_YELLOW);
                    break;

                default:
                    break;
            }
        }

        public static void drawL1(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_BLUE);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x + 2, coor_y, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_BLUE);
                    break;

                case Shape.Orientation.ORIENT_1:

                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x + 0, coor_y + 0, DrawColor.Shade.COLOR_DK_BLUE);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x + 0, coor_y - 2 , DrawColor.Shade.COLOR_BLUE);


                    break;

                case Shape.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x - 2, coor_y, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_BLUE);
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_BLUE);
                    break;

                case Shape.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x, coor_y + 2, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x, coor_y + 1, DrawColor.Shade.COLOR_BLUE);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_BLUE);
                    SOM.drawBox(coor_x + 1, coor_y + 0 , DrawColor.Shade.COLOR_BLUE);
                    break;

                default:
                    break;
            }
        }

        public static void drawL2(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 2, coor_y, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_PURPLE);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_PURPLE);
                    break;

                case Shape.Orientation.ORIENT_1:

                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_PURPLE);
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x + 0, coor_y + 2, DrawColor.Shade.COLOR_PURPLE);
                    break;

                case Shape.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 2, coor_y, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_PURPLE);
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_PURPLE);
                    break;

                case Shape.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x, coor_y - 2, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x, coor_y - 1, DrawColor.Shade.COLOR_PURPLE);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_PURPLE);
                    SOM.drawBox(coor_x + 1, coor_y + 0, DrawColor.Shade.COLOR_PURPLE);
                    break;

                default:
                    break;
            }
        }

        public static void drawZ1(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_GREEN);
                    SOM.drawBox(coor_x + 1, coor_y - 1, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_LT_GREEN);
                    break;

                case Shape.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x, coor_y + 1, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_GREEN);
                    SOM.drawBox(coor_x - 1, coor_y - 1, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_LT_GREEN);
                    break;

                case Shape.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x - 1, coor_y + 1, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_GREEN);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_LT_GREEN);
                    break;

                case Shape.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x + 1, coor_y + 1, DrawColor.Shade.COLOR_LT_GREEN);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_GREEN);
                    SOM.drawBox(coor_x, coor_y - 1, DrawColor.Shade.COLOR_LT_GREEN);
                    break;

                default:
                    break;
            }
        }

        public static void drawZ2(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x - 1, coor_y - 1, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_CYAN);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_CYAN);
                    break;

                case Shape.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x - 1, coor_y + 1, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_CYAN);
                    SOM.drawBox(coor_x, coor_y - 1, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_CYAN);
                    break;

                case Shape.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_CYAN);
                    SOM.drawBox(coor_x + 1, coor_y + 1, DrawColor.Shade.COLOR_CYAN);
                    break;

                case Shape.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x, coor_y + 1, DrawColor.Shade.COLOR_CYAN);
                    SOM.drawBox(coor_x, coor_y + 0, DrawColor.Shade.COLOR_DK_CYAN);
                    SOM.drawBox(coor_x + 1, coor_y - 1, DrawColor.Shade.COLOR_CYAN);
                    break;

                default:
                    break;
            }
        }

        public static void drawSquare(int coor_x, int coor_y, Orientation orient)
        {
            switch (orient)
            {
                case Shape.Orientation.ORIENT_0:
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_RED);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x + 1, coor_y - 1, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_RED);
                    break;

                case Shape.Orientation.ORIENT_1:
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_RED);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x - 1, coor_y - 1, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x + 0, coor_y - 1, DrawColor.Shade.COLOR_RED);
                    break;

                case Shape.Orientation.ORIENT_2:
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_RED);
                    SOM.drawBox(coor_x - 1, coor_y, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x - 1, coor_y + 1, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_RED);
                    break;

                case Shape.Orientation.ORIENT_3:
                    SOM.drawBox(coor_x + 0, coor_y, DrawColor.Shade.COLOR_DK_RED);
                    SOM.drawBox(coor_x + 1, coor_y, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x + 1, coor_y + 1, DrawColor.Shade.COLOR_RED);
                    SOM.drawBox(coor_x + 0, coor_y + 1, DrawColor.Shade.COLOR_RED);
                    break;

                default:
                    break;
            }
        }


    }
}
