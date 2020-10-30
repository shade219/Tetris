using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Tetris.domain
{
    // Authors: DeAngelo Wilson, Name2
    // Description: A class which stores all the current blocks placed onto a grid and Converts gameShapes to be Blocks on the grid
    //                  Called on by the Movement Manager and GameManager
    public class BlockGrid
    {
        //2D dimensional array of different width/height
            // - Vacant coordinates MUST be null
        Block[][] grid;
        //NOTE: Grid access --> grid[x][y] || grid[col][row]

        private int row_count;
        private int col_count;

        private List<Block> blocks;

        // Author: DeAngelo Wilson
        public BlockGrid(int maxX, int maxY)//TODO:: FLIP
        {
            row_count = maxY;
            col_count = maxX;

            blocks = new List<Block>(row_count * col_count);
            InitializeBlockGrid(maxX, maxY);
        }

        public void Draw()
        {
            foreach (Block block in blocks)
            {
                block.Draw();
            }
        }


        // Author: DeAngelo
        public void PlaceShape(GameShape toPlace)
        {
            //for each block of the GameShape-- place onto grid + add to list
            foreach (Block block in toPlace.blocks)
            {
                Block blockCopy = block.Copy();
                grid[block.GetX()][block.GetY()] = blockCopy;
                blocks.Add(blockCopy);
            }
        }

        // Author: DeAngelo Wilson
        public void RemoveLines(List<int> toRemove)
        {
            //given a list of row indexes toRemove -- remove row + move all above blocks down 1
            int maxIndex = -1;

            //Note:: there is an animation for this ==> pauses game time, all completed lines flash --> then destroyed
            //remove the completed line
            foreach (int row in toRemove)
            {
                for (int col = 0; col < col_count; col++)
                {
                    //remove + destroy all blocks in row
                    blocks.Remove(grid[col][row]);
                    grid[col][row] = null;
                }
                //
                if (maxIndex < row)
                {
                    maxIndex = row;
                }
            }
            ShiftGridBlocksDown(maxIndex, toRemove.Count);
        }

        public void ShiftGridBlocksDown(int lowestRow, int shift)
        {
            //for all blocks above or equal (lowerIndex) to lowestRow -- shift down by shift amount (total lines cleared)
            for (int col = 0; col < col_count; col++)
            {            
                for (int row = 0; row < lowestRow; row++)
                {
                    //shift block down
                    if (grid[col][row] != null)
                    {
                        grid[col][row].ApplyOffset(Constants.DOWN_OFFSET * shift);
                    }
                }
            }
        }


        // Author: DeAngelo Wilson
        public List<int> GetCompletedLines()
        {
            List<int> completedLineIndex = new List<int>();
            for (int row = 0; row < row_count; row++)
            {
                int rowBlockCount = 0;
                for (int col = 0; col < col_count; col++)
                {
                    if (grid[col][row] != null)
                    {
                        rowBlockCount++;
                    }
                }

                if (rowBlockCount == col_count)
                {
                    completedLineIndex.Add(row);
                }

            }
            return completedLineIndex;
        }

        public List<int> GetCompletedLines(List<int> rowIndexes)//TODO:: CHANGE TO GAMESHAPE
        {
            List<int> completedLineIndex = new List<int>();

            foreach (int row in rowIndexes)
            {
                int rowBlockCount = 0;

                for (int col = 0; col < col_count; col++)
                {
                    if (grid[col][row] != null)
                    {
                        rowBlockCount++;
                    }
                }
                //
                if (rowBlockCount == col_count)
                {
                    completedLineIndex.Add(row);
                }
            }

            return completedLineIndex;
        }


        //TODO:: could maintain a list of Vacant/Occupied Coordinates...
        // Author: DeAngelo Wilson
        public List<Vector2> GetVacantCoordinates()
        {
            List<Vector2> coords = new List<Vector2>();
            for (int col = 0; col < col_count; col++)
            {
                for (int row = 0; row < row_count; row++)
                {
                    if (grid[col][row] == null)
                    {
                        coords.Add(new Vector2( col, row));
                    }
                }
            }
            return coords;
        }

        // Author: DeAngelo Wilson
        public List<Vector2> GetOccupiedCoordinates()
        {
            List<Vector2> coords = new List<Vector2>();
            for (int col = 0; col < col_count; col++)
            {
                for (int row = 0; row < row_count; row++)
                {
                    if (grid[col][row] != null)
                    {
                        coords.Add(new Vector2( col, row));
                    }
                }
            }
            return coords;
        }


        //Author: DeAngelo Wilson
        private void InitializeBlockGrid(int cols, int rows)
        {
            //Initialize Block grid
            grid = new Block[cols][];
            for (int i = 0; i < rows; i++)
            {
                grid[i] = new Block[rows];
            }

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    grid[col][row] = null;
                }
            }
        }
    }
}
