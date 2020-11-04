using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;
using System.Numerics;
using TetrisTest.domain.shapes;
using Tetris.domain.shapes;

namespace Tetris.services.Tests
{
    // Authors: Brandon Wegner, Raffay Hussain
    // Description: 
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
        [TestMethod()]
        public void CheckForCollisionsTest()
        { 
        }
    }
}