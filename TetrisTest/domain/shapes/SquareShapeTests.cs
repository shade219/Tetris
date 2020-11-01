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
    // Authors: Name1, Name2
    // Description:
    [TestClass()]
    public class SquareShapeTests
    {

        ShapeRenderer.Orientation defaultOri = ShapeRenderer.Orientation.ORIENT_0;

        // Author: Your Name Here
        [TestMethod()]
        public void SquareShapeTest()
        {
            // Ensure anchor set
            // Ensure color set to RED
            // Ensure orientation set semi random
            // Ensure other blocks are added correctly (correct coordinates)
        }

        // Author: Your Name Here
        [TestMethod()]
        public void ApplyActionTest()
        {

        }

        private SquareShape BasicShapeInitialize(out List<Vector2> coordinates, ShapeRenderer.Orientation ori)
        {
            Block anchor = new Block(DrawColor.Shade.COLOR_DK_RED, 100, 100);
            SquareShape square = new SquareShape(anchor, ori);
            coordinates = new List<Vector2>();
            foreach (Block b in square.blocks)
                coordinates.Add(new Vector2(b.GetX(), b.GetY()));

            return square;
        }
        // Author: Greg Kulasik
        [TestMethod()]
        public void MoveDownTest()
        {
            List<Vector2> coordinates;
            GameShape square = BasicShapeInitialize(out coordinates, defaultOri);

            square.ApplyAction(InputAction.MoveDown);

            for(int i = 0; i < coordinates.Count(); i++)
            {
                // Check that X did not change, and Y was reduced by 1
                Assert.AreEqual(coordinates.ElementAt(i).X, square.blocks.ElementAt(i).GetX());
                Assert.AreEqual(coordinates.ElementAt(i).Y-1, square.blocks.ElementAt(i).GetY());
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

            //Automated way of checking if properly rotated --- NOTE:: ASSUMES rotationOffset Lists are accurate
            //IReadOnlyCollection<Vector2> rotationOffsets = square.GetOrientationOffsets(square.GetOrientation());

            //for (int i = 0; i < coordinates.Count; i++)
            //{
            //    //Get position of 
            //    Vector2 pos = new Vector2(square.blocks.ElementAt(i).GetX(), square.blocks.ElementAt(i).GetY());
            //    pos -= rotationOffsets.ElementAt(i);
            //    Assert.AreEqual(coordinates.ElementAt(i), pos);
            //}

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

        // Author: Your Name Here
        [TestMethod()]
        public void CalcBlocksPostActionTest()
        {
            //5 cases
                //rotation
                //move down
                //move left
                //move right
                //invalid action
        }

        //// Author: Your Name Here
        //[TestMethod()]
        //public void DrawTest()
        //{

        //}
    }
}
