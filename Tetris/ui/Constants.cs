using System;
using System.Numerics;

namespace Tetris
{
    static class Constants
    {
        public const int SCREEN_HEIGHT = 650;
        public const int SCREEN_WIDTH = 500;
        public const int BOX_SIZE = 20;
        public const int BOX_SIZE_HALF = 10;

        public const int PREVIEW_WINDOW_X = 17;
        public const int PREVIEW_WINDOW_Y = 26;

        public const int GAME_MAX_X = 9;
        public const int GAME_CENTER_X = 5;
        public const int GAME_MAX_Y = 29;
        public const int GAME_MIN_X = 0;
        public const int GAME_MIN_Y = 0;

        
        
        
        public static readonly Vector2 DOWN_OFFSET = new Vector2(0, -1);
        public static readonly Vector2 UP_OFFSET = new Vector2(0, 1);
        public static readonly Vector2 LEFT_OFFSET = new Vector2( -1, 0 );
        public static readonly Vector2 RIGHT_OFFSET = new Vector2(1, 0 );
    }
}
