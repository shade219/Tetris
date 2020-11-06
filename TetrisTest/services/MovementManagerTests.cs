using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tetris.domain;
using System.Numerics;
using Tetris.domain.shapes;

namespace Tetris.services.Tests
{
    // Authors: Brandon Wegner, Raffay Hussain
    // Description: Verifies any action (MoveDown in this case) occurred and the grid
    // can verify that the occupied coordinates now exhibit the changed block positioning
    [TestClass()]
    public class MovementManagerTests
    {
        private ShapeRenderer.Orientation defaultOri = ShapeRenderer.Orientation.ORIENT_0;

        // Author: Brandon Wegner
        [TestMethod()]
        public void ApplyActionTest()
        {
            // Create initial space block occupies
            Block anchor = new Block(4, 4);
            // Make square with default orientation
            SquareShape shape = new SquareShape(anchor, defaultOri);
            // Add block coords to coords before action applied
            List<Vector2> coordinates = new List<Vector2>();
            foreach (Block b in shape.blocks)
            { 
                coordinates.Add(new Vector2(b.GetX(), b.GetY()));
            }

            // Make a 10 X 10 grid
            BlockGrid grid = new BlockGrid(10, 10);

            // Apply MoveDown action on shape in grid
            MovementManager.ApplyAction(InputAction.MoveDown, grid, shape);

            List<Vector2> expectedCoord = new List<Vector2>();
            // Loop through and add the new coords of block in grid to expected position
            foreach (Block b in shape.blocks)
            {
                expectedCoord.Add(new Vector2(b.GetX(), b.GetY()));
            }

            int i = 0;
            /* Loops through size of coordinates and expectedCoord (should be same size)
             * and check that the expected is Y - 1 for the shape positioning in org coordinates
             */
            while (i < coordinates.Count() && i < expectedCoord.Count())
            {
                Assert.AreEqual(expectedCoord.ElementAt(i).X, coordinates.ElementAt(i).X);
                Assert.AreEqual(expectedCoord.ElementAt(i).Y, coordinates.ElementAt(i).Y - 1);
                i++;
            }
        }

        // Author: Raffay Hussain
        // CheckForCollisions(BlockGrid grid, List<Block> blocks, GameShape shape, InputAction action)
        [TestMethod()]
        public void CheckForCollisionsTest_Floating_Piece()
        {
            // Piece is not touching anything
            Block anchor = new Block(4, 4);
            BlockGrid grid = new BlockGrid(5, 5);
            //List<Block> blocks = new List<Block> { anchor };
            SquareShape shape = new SquareShape(anchor, defaultOri);
            List<Block> blocks = shape.blocks;
            InputAction action = InputAction.MoveDown;
            Assert.AreEqual(false, MovementManager.CheckForCollisions(grid, blocks, shape, action));
        }

        [TestMethod()]
        public void CheckForCollisionsTest_Left_Bound()
        {
            // block that we are about to add crosses the left bound
            Block anchor = new Block(-1, 4);
            BlockGrid grid = new BlockGrid(5, 5);
            //List<Block> blocks = new List<Block> { anchor };
            SquareShape shape = new SquareShape(anchor, defaultOri);
            List<Block> blocks = shape.blocks;
            InputAction action = InputAction.MoveDown;
            Assert.AreEqual(true, MovementManager.CheckForCollisions(grid, blocks, shape, action));
        }

        [TestMethod()]
        public void CheckForCollisionsTest_Right_Bound()
        {
            // block that we are about to add exceeds max width
            Block anchor = new Block(6, 3);
            BlockGrid grid = new BlockGrid(5, 5);
            //List<Block> blocks = new List<Block> { anchor };
            SquareShape shape = new SquareShape(anchor, defaultOri);
            List<Block> blocks = shape.blocks;
            InputAction action = InputAction.MoveDown;
            Assert.AreEqual(true, MovementManager.CheckForCollisions(grid, blocks, shape, action));
        }

        [TestMethod()]
        public void CheckForCollisionsTest_Pieces_Touching()
        {
            Block anchor = new Block(3, 3);
            BlockGrid grid = new BlockGrid(5, 5);
            GameShape existingShape = new SquareShape(anchor, defaultOri);
            // put an exisiting shape at the coordinate where we are placing a block
            grid.PlaceShape(existingShape);
            //List<Block> blocks = new List<Block> { anchor };
            List<Block> blocks = existingShape.blocks;
            SquareShape shape = new SquareShape(anchor, defaultOri);
            InputAction action = InputAction.MoveDown;
            Assert.AreEqual(true, MovementManager.CheckForCollisions(grid, blocks, shape, action));
        }

        [TestMethod()]
        public void CheckForCollisionsTest_Bottom()
        {
            // block has reached the bottom
            Block anchor = new Block(3, -1);
            BlockGrid grid = new BlockGrid(5, 5);
            //List<Block> blocks = new List<Block> { anchor };
            SquareShape shape = new SquareShape(anchor, defaultOri);
            List<Block> blocks = shape.blocks;
            InputAction action = InputAction.MoveDown;
            Assert.AreEqual(true, MovementManager.CheckForCollisions(grid, blocks, shape, action));
        }
    }
}