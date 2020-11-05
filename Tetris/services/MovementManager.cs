using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;

namespace Tetris.services
{
    // Authors: Samuel Stahl, Brandon Wegner
    // Description: processes result of InputAction on GameShape in relation to BlockGrid and performs collision checking
    public static class MovementManager
    {

        // Author: Brandon Wegner, Samuel Stahl
        //Checks for collision in two states:

        //State 1: about to place - If AboutToPlace flag is set and action is MoveDown call placeshape
        //else calculates action as usual to check for legal action and apply accordingly

        //State 2: not about to place - Check's for collision and returns true if action not legal
        // else returns false and calls GameShape.ApplyAction()
        public static void ApplyAction(InputAction action, BlockGrid grid, GameShape shape)
        {
            if (shape.isAboutToPlace)
            {
                if(action == InputAction.MoveDown)
                {
                    grid.PlaceShape(shape);
                }
                else
                {
                    shape.ResetAboutToPlaceFlag();
                    checkAndApply(action, grid, shape);
                }
            }
            else
            {
                checkAndApply(action, grid, shape);
            }
        }

        private static void checkAndApply(InputAction action, BlockGrid grid, GameShape shape)
        {
            List<Block> shapeBlocks = shape.CalcBlocksPostAction(action);
            bool collision = CheckForCollisions(grid, shapeBlocks, shape, action);
            if (!collision)
            {
                shape.ApplyAction(action);
            }
        }

        // Author: Samuel Stahl
        //Checks first for illegal move and returns true if found
        // else returns false if move is legal
        //After illegal move check, checks for imenent collision with bottom or block in grid and sets AboutToPlace if true
        public static bool CheckForCollisions(BlockGrid grid, List<Block> blocks, GameShape shape, InputAction action)
        {
            List<Vector2> occupiedCoordinates = grid.GetOccupiedCoordinates();

            //Checks for illegal collisions with boundary or occupied areas and returns true if collision found
            foreach (Block b in blocks)
            {
                Vector2 blockCoord = b.GetPosition();
                //left boundary check
                if (blockCoord.X < 0)
                {
                    return true;
                }
                //right boundary check
                else if (blockCoord.X >= grid.GetGridColumnCount())
                {
                    return true;
                }
                //bottom boundary check
                else if (blockCoord.Y < 0)
                {
                    return true;
                }
                //check for illegal overlap
                else if (occupiedCoordinates.Contains(blockCoord))
                {
                    return true;
                }

            }

            //Checks for legal collisions that will cause block placement next timer tick
            //If legal collision is imenent applies the action and sets about to place flag
            foreach(Block b in blocks)
            {
                Vector2 blockCoord = b.GetPosition();
                //check for bottom row collision
                if (blockCoord.Y == 0)
                {
                    shape.AboutToPlaceGameShape();
                }
                //above occupied coord collision check
                else
                {
                    Vector2 temp;
                    temp.X = blockCoord.X;
                    temp.Y = blockCoord.Y - 1;
                    if (occupiedCoordinates.Contains(temp))
                    {
                        shape.AboutToPlaceGameShape();
                    }
                }
            }
            return false;
        }

    }
}
