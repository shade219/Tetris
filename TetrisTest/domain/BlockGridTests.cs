using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain.shapes;


namespace Tetris.domain.Tests
{
    // Authors: Name1, Name2
    // Description:
    [TestClass()]
    public class BlockGridTests
    {

        // 180 degrees default here
        ShapeRenderer.Orientation defaultOri = ShapeRenderer.Orientation.ORIENT_2;

        public BlockGrid BasicBlockGridInitialize(out List<Vector2> expectedPoints)
        {
            //points: (0,3) (0,4) (1,3) (1,4) -- (0,1) (0,2) (1,1) (1,2) -- (2,3) (2,4) (3,3) (3,4)
            expectedPoints = new List<Vector2>()
            {
                new Vector2(0,3), new Vector2(0, 4), new Vector2(1, 3), new Vector2(1, 4), new Vector2(0, 1), new Vector2(0,2),
                new Vector2(1,1), new Vector2(1,2), new Vector2(2,3), new Vector2(2,4), new Vector2(3,3), new Vector2(3,4)
            };


            BlockGrid grid = new BlockGrid(5, 5);

            GameShape shape1 = new SquareShape(new Block(DrawColor.Shade.COLOR_BLUE, 0,3), defaultOri);
            grid.PlaceShape(shape1);

            GameShape shape2 = new SquareShape(new Block(DrawColor.Shade.COLOR_CYAN, 2, 3), defaultOri);
            grid.PlaceShape(shape1);

            GameShape shape3 = new SquareShape(new Block(DrawColor.Shade.COLOR_RED, 0, 1), defaultOri);
            grid.PlaceShape(shape1);

            return grid;
        }

        public BlockGrid CompleteLinesInitialize()
        {
            BlockGrid grid = new BlockGrid(5, 5);

            GameShape shape1 = new SquareShape(new Block(DrawColor.Shade.COLOR_BLUE, 0, 3), defaultOri);
            grid.PlaceShape(shape1);

            GameShape shape2 = new SquareShape(new Block(DrawColor.Shade.COLOR_CYAN, 2, 3), defaultOri);
            grid.PlaceShape(shape1);

            GameShape shape3 = new SquareShape(new Block(DrawColor.Shade.COLOR_RED, 0, 1), defaultOri);
            grid.PlaceShape(shape1);

            //complete line init
            GameShape shape4 = new LineShape(new Block(DrawColor.Shade.COLOR_YELLOW, 0, 3), defaultOri);
            grid.PlaceShape(shape1);

            return grid;
        }

        // Author: Your Name Here
        [TestMethod()]
        public void BlockGridTest()
        {

        }

        // Author: Your Name Here
        [TestMethod()]
        public void PlaceShapeTest()
        {
            List<Vector2> expectedPoints;
            BlockGrid grid = BasicBlockGridInitialize(out expectedPoints);

            //test that the all points from shapes exist on grid 
            List<Vector2> points = grid.GetOccupiedCoordinates();
            foreach (Vector2 p in points)
            {
                //check if p in expected points
                if (!expectedPoints.Contains(p))
                {
                    Assert.Fail("Block at point: {0}, {1} not found on grid", p.X, p.Y);
                }
            }
        }

        // Author: Your Name Here
        [TestMethod()]
        public void RemoveLinesTest()
        {

        }

        // Author: Your Name Here
        [TestMethod()]
        public void GetCompletedLinesTest()
        {

        }

        // Author: Your Name Here
        [TestMethod()]
        public void GetVacantCoordinatesTest()
        {

        }

        // Author: Your Name Here
        [TestMethod()]
        public void GetOccupiedCoordinatesTest()
        {
            List<Vector2> expectedPoints;
            BlockGrid grid = BasicBlockGridInitialize(out expectedPoints);

            //test that the 3 shapes exist on grid 

            List<Vector2> points = grid.GetOccupiedCoordinates();
            foreach (Vector2 p in points)
            {
                //check if p in expected points
                if (!expectedPoints.Contains(p))
                {
                    Assert.Fail("Block at point: {0}, {1} not found on grid", p.X, p.Y);
                }
            }
        }
    }
}