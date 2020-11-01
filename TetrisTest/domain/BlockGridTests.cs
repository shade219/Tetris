﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        ShapeRenderer.Orientation defaultOri = ShapeRenderer.Orientation.ORIENT_3;

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
            grid.PlaceShape(shape2);

            GameShape shape3 = new SquareShape(new Block(DrawColor.Shade.COLOR_RED, 0, 1), defaultOri);
            grid.PlaceShape(shape3);

            return grid;
        }

        public BlockGrid VacantCoordsBlockGridInitialize(out List<Vector2> expectedPoints)
        {
            //points: (0,3) (0,4) (1,3) (1,4) -- (0,1) (0,2) (1,1) (1,2) -- (2,3) (2,4) (3,3) (3,4)
            expectedPoints = new List<Vector2>()
            {
               new Vector2(0,0), new Vector2(1, 0), new Vector2(2, 0), new Vector2(3, 0), new Vector2(4, 0),
               new Vector2(2,1), new Vector2(3, 1), new Vector2(4, 1),
               new Vector2(2, 2), new Vector2(3, 2), new Vector2(4, 2),
               new Vector2(4, 3), new Vector2(4, 4)
            };

            BlockGrid grid = new BlockGrid(5, 5);

            GameShape shape1 = new SquareShape(new Block(DrawColor.Shade.COLOR_BLUE, 0, 3), defaultOri);
            grid.PlaceShape(shape1);

            GameShape shape2 = new SquareShape(new Block(DrawColor.Shade.COLOR_CYAN, 2, 3), defaultOri);
            grid.PlaceShape(shape2);

            GameShape shape3 = new SquareShape(new Block(DrawColor.Shade.COLOR_RED, 0, 1), defaultOri);
            grid.PlaceShape(shape3);

            return grid;
        }


        public BlockGrid CompleteLinesInitialize()
        {
            BlockGrid grid = new BlockGrid(6, 6);

            GameShape shape1 = new SquareShape(new Block(DrawColor.Shade.COLOR_BLUE, 0, 3), defaultOri);
            grid.PlaceShape(shape1);

            GameShape shape2 = new SquareShape(new Block(DrawColor.Shade.COLOR_CYAN, 2, 1), defaultOri);
            grid.PlaceShape(shape2);

            GameShape shape3 = new SquareShape(new Block(DrawColor.Shade.COLOR_RED, 0, 1), defaultOri);
            grid.PlaceShape(shape3);

            //complete line init
            GameShape shape4 = new SquareShape(new Block(DrawColor.Shade.COLOR_YELLOW, 4, 1), defaultOri);
            grid.PlaceShape(shape4);
        
            //2nd line needs 1 more square
            GameShape shape5 = new SquareShape(new Block(DrawColor.Shade.COLOR_ORANGE, 2, 3), defaultOri);
            grid.PlaceShape(shape5);
            
            return grid;
        }

        public BlockGrid RemoveLinesInitialize(out List<Vector2> expectedPoints)
        {
            //points: (0,3) (0,4) (1,3) (1,4) -- (0,1) (0,2) (1,1) (1,2) -- (2,3) (2,4) (3,3) (3,4)
            expectedPoints = new List<Vector2>()
            {
                new Vector2(0,1), new Vector2(0, 2), new Vector2(1, 1), new Vector2(1, 2), new Vector2(2, 2), new Vector2(2,1),
                new Vector2(3,2), new Vector2(3,1)
            };




            BlockGrid grid = new BlockGrid(6, 6);

            GameShape shape1 = new SquareShape(new Block(DrawColor.Shade.COLOR_BLUE, 0, 3), defaultOri);
            grid.PlaceShape(shape1);

            GameShape shape2 = new SquareShape(new Block(DrawColor.Shade.COLOR_CYAN, 2, 1), defaultOri);
            grid.PlaceShape(shape2);

            GameShape shape3 = new SquareShape(new Block(DrawColor.Shade.COLOR_RED, 0, 1), defaultOri);
            grid.PlaceShape(shape3);

            //complete line init
            GameShape shape4 = new SquareShape(new Block(DrawColor.Shade.COLOR_YELLOW, 4, 1), defaultOri);
            grid.PlaceShape(shape4);

            //2nd line needs 1 more square
            GameShape shape5 = new SquareShape(new Block(DrawColor.Shade.COLOR_ORANGE, 2, 3), defaultOri);
            grid.PlaceShape(shape5);

            return grid;
        }

        // Author: Your Name Here
        [TestMethod()]
        public void BlockGridTest()
        {
            BlockGrid grid = new BlockGrid(5, 6);

            Assert.AreEqual(5, grid.GetGridColumnCount());
            Assert.AreEqual(6, grid.GetGridRowCount());

            Assert.AreEqual(grid.GetGridColumnCount(), grid.grid.Length);
            for (int i = 0; i < grid.GetGridColumnCount(); i++)
            {
                Assert.AreEqual(grid.GetGridRowCount(), grid.grid[i].Length);
            }
        }

        // Author: Your Name Here
        [TestMethod()]
        public void PlaceShapeTest()
        {
            List<Vector2> expectedPoints;
            BlockGrid grid = BasicBlockGridInitialize(out expectedPoints);

            //test that the all points from shapes exist on grid 
            List<Vector2> points = grid.GetOccupiedCoordinates();
            foreach (Vector2 p in expectedPoints)
            {
                //check if p in expected points
                if (!points.Contains(p))
                {
                    Assert.Fail("Block at point: {0}, {1} not found on grid", p.X, p.Y);
                }
            }
        }

        // Author: Your Name Here
        [TestMethod()]
        public void RemoveLinesTest()
        {
            List<Vector2> expectedPoints;
            BlockGrid grid = RemoveLinesInitialize(out expectedPoints);

            //Get indexes of lines to remove
            List<int> lineIndexes = grid.GetCompletedLines();
            
            //Remove lines and shift above blocks down
            grid.RemoveLines(lineIndexes);

            //check that blocks removed and remaining above blocks shifted down
            List<Vector2> points = grid.GetOccupiedCoordinates();
            foreach (Vector2 p in expectedPoints)
            {
                //check if p in expected points
                if (!points.Contains(p))
                {
                    Assert.Fail("Block at point: {0}, {1} not found on grid", p.X, p.Y);
                }
            }
        }

        // Author: Your Name Here
        [TestMethod()]
        public void GetCompletedLinesTest()
        { 
            //TEST 1
            GetCompletedLinesTestNoArgs();

            //TEST 2
            GetCompletedLinesTestWithGameShape();
        }

        private void GetCompletedLinesTestNoArgs()
        {
            BlockGrid grid = CompleteLinesInitialize();

            List<int> lineIndexes = grid.GetCompletedLines();
            Assert.AreEqual(2, lineIndexes.Count);
        }
        private void GetCompletedLinesTestWithGameShape()
        {
            BlockGrid grid = CompleteLinesInitialize();
            GameShape gs = new SquareShape(new Block(DrawColor.Shade.COLOR_LT_GREEN, 4, 3), defaultOri);
            grid.PlaceShape(gs);

            List<int> lineIndexes = grid.GetCompletedLines(gs);


            Assert.AreEqual(2, lineIndexes.Count);
        }


        // Author: Your Name Here
        [TestMethod()]
        public void GetVacantCoordinatesTest()
        {
            List<Vector2> expectedPoints;
            BlockGrid grid = VacantCoordsBlockGridInitialize(out expectedPoints);

            //test that the 3 shapes exist on grid 

            List<Vector2> points = grid.GetVacantCoordinates();
            foreach (Vector2 p in expectedPoints)
            {
                //check if p in expected points
                if (!points.Contains(p))
                {
                    Assert.Fail("Block at point: {0}, {1} not found on grid", p.X, p.Y);
                }
            }
        }

        // Author: Your Name Here
        [TestMethod()]
        public void GetOccupiedCoordinatesTest()
        {
            List<Vector2> expectedPoints;
            BlockGrid grid = BasicBlockGridInitialize(out expectedPoints);

            //test that the 3 shapes exist on grid 

            List<Vector2> points = grid.GetOccupiedCoordinates();
            foreach (Vector2 p in expectedPoints)
            {
                //check if p in expected points
                if (!points.Contains(p))
                {
                    Assert.Fail("Block at point: {0}, {1} not found on grid", p.X, p.Y);
                }
            }
        }
    }
}