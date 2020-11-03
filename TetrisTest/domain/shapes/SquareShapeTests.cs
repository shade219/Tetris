using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.domain.shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Tetris.domain.shapes.Tests
{
    // Authors: DeAngelo Wilson, Greg Kulasik
    // Description:
    [TestClass()]
    public class SquareShapeTests
    {

        ShapeRenderer.Orientation defaultOri = ShapeRenderer.Orientation.ORIENT_0;

        private SquareShape BasicShapeInitialize(out List<Vector2> coordinates, ShapeRenderer.Orientation ori)
        {
            Block anchor = new Block(100, 100);
            SquareShape square = new SquareShape(anchor, ori);
            coordinates = new List<Vector2>();
            foreach (Block b in square.blocks)
                coordinates.Add(new Vector2(b.GetX(), b.GetY()));

            return square;
        }


        // Author: DeAngelo Wilson
        [TestMethod()]
        public void SquareShapeConstructionTest()
        {
            //ensure all blocks of square at correct positions
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, defaultOri);

            List<Vector2> expectedCoordinates = new List<Vector2>() { new Vector2(100, 100), new Vector2(101, 100), new Vector2(101, 99), new Vector2(100, 99) };

            foreach (Vector2 coord in expectedCoordinates)
            {
                Assert.IsTrue(coordinates.Contains(coord));
            }
        }

        // Author: Greg Kulasik
        [TestMethod()]
        public void MoveDownTest()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, defaultOri);

            square.ApplyAction(InputAction.MoveDown);

            for (int i = 0; i < coordinates.Count(); i++)
            {
                // Check that X did not change, and Y was reduced by 1
                Assert.AreEqual(coordinates.ElementAt(i).X, square.blocks.ElementAt(i).GetX());
                Assert.AreEqual(coordinates.ElementAt(i).Y - 1, square.blocks.ElementAt(i).GetY());
            }
        }

        // Author: Greg Kulasik
        [TestMethod()]
        public void MoveLeftTest()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, defaultOri);

            square.ApplyAction(InputAction.MoveLeft);

            for (int i = 0; i < coordinates.Count(); i++)
            {
                // Check that X reduced by 1, Y did not change
                Assert.AreEqual(coordinates.ElementAt(i).Y, square.blocks.ElementAt(i).GetY());
                Assert.AreEqual(coordinates.ElementAt(i).X - 1, square.blocks.ElementAt(i).GetX());
            }
        }

        // Author: Greg Kulasik
        [TestMethod()]
        public void MoveRightTest()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, defaultOri);

            square.ApplyAction(InputAction.MoveRight);

            for (int i = 0; i < coordinates.Count(); i++)
            {
                // Check that X increased by 1, Y did not change
                Assert.AreEqual(coordinates.ElementAt(i).Y, square.blocks.ElementAt(i).GetY());
                Assert.AreEqual(coordinates.ElementAt(i).X + 1, square.blocks.ElementAt(i).GetX());
            }
        }

        // Author: Greg Kulasik
        [TestMethod()]
        public void Rotate0To90Test()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, defaultOri);

            //Rotate GameShape
            square.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X + 1, square.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, square.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X, square.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y - 1, square.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X - 1, square.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y, square.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X, square.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y + 1, square.blocks.ElementAt(3).GetY());
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void Rotate90To180Test()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_1);

            //Rotate GameShape
            square.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, square.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y - 1, square.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X - 1, square.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y, square.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X, square.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y + 1, square.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X + 1, square.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y, square.blocks.ElementAt(3).GetY());
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void Rotate180To270Test()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_2);

            //Rotate GameShape
            square.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X - 1, square.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, square.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X, square.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y + 1, square.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X + 1, square.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y, square.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X, square.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y - 1, square.blocks.ElementAt(3).GetY());
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void Rotate270To0Test()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_3);

            //Rotate GameShape
            square.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, square.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y + 1, square.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X + 1, square.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y, square.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X, square.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y - 1, square.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X - 1, square.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y, square.blocks.ElementAt(3).GetY());
        }
    }
}
    