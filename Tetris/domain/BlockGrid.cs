using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain
{
    // Authors: Name1, Name2
    // Description:
    public class BlockGrid
    {

        //2D dimensional array of different width/height
        // - Vacant coordinates MUST be null
        public readonly Block[][] grid;
        //NOTE: Grid access --> grid[x][y] || grid[col][row]

        private readonly int row_count;
        private readonly int col_count;

        private List<Block> blocks;


        // Author: Your Name Here
        public BlockGrid(int maxX, int maxY)
        {

        }

        public void Draw()
        {
            foreach (Block block in blocks)
            {
                block.Draw();
            }
        }

        // Author: Your Name Here
        public void PlaceShape(GameShape toPlace)
        {

        }

        // Author: Your Name Here
        public void RemoveLines(List<int> toRemove)
        {

        }

        // Author: Your Name Here
        public List<int> GetCompletedLines()
        {
            return null;
        }

        // Author: Your Name Here
        public List<Vector2> GetVacantCoordinates()
        {
            return null;
        }

        // Author: Your Name Here
        public List<Vector2> GetOccupiedCoordinates()
        {
            return null;
        }

    }
}
