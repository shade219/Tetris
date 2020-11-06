using System;
using System.Diagnostics;
using Tetris.services;
using Tetris.ui;

namespace Tetris
{    
    
    // Authors: Name1, Name2
    // Description:
    class Program
    {
        static void Main(string[] args)
        {
            // Create the instance
            OldGameLoop game = new OldGameLoop();
            Debug.Assert(game != null);

            // Start the game
            game.Run();
        }
    }
}
