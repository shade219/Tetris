using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;

namespace Tetris.services
{
    // Authors: Name1, Name2
    // Description:
    public static class MovementManager
    {

        // Author: Your Name Here
        public static void ApplyAction(InputAction action, BlockGrid grid, GameShape shape)
        {
            if (shape.isAboutToPlace && CheckForCollisions(grid, shape.CalcBlocksPostAction(action), shape, action))
            {
                grid.PlaceShape(shape);
            }
            else
            {
                List<Block> shapeBlocks = shape.CalcBlocksPostAction(action);
                bool collision = CheckForCollisions(grid, shapeBlocks, shape, action);
                if (collision)
                {
                    return;
                }
                else
                {
                    shape.ApplyAction(action);
                }
            }
        }

        // Author: Your Name Here
        public static bool CheckForCollisions(BlockGrid grid, List<Block> blocks, GameShape shape, InputAction action)
        {
            List<Vector2> occupiedCoordinates = grid.GetOccupiedCoordinates();

            foreach (Block b in blocks)
            {
                Vector2 blockCoord = b.coordinates;
                //left boundary check
                if (blockCoord.X < 0)
                {
                    return true;
                }
                //right boundary check
                else if (blockCoord.X > grid.rowLength())
                {
                    return true;
                }
                //check for illegal overlap
                else if (occupiedCoordinates.Contains(blockCoord))
                {
                    return true;
                }
                //above occupied coord check
                else
                {
                    Vector2 temp;
                    temp.X = blockCoord.X;
                    //ask how the coords are implemented (matrix or cartesian)
                    temp.Y = blockCoord.Y - 1;
                    if (occupiedCoordinates.Contains(temp))
                    {
                        shape.ApplyAction(action);
                        shape.isAboutToPlace = true;
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

    }
}
