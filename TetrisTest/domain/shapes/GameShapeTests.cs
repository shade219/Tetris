using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TetrisTest.domain.shapes;

namespace Tetris.domain.Tests
{
    // Authors: DeAngelo Wilson
    // Description: A class to test shared functionality of GameShapes
    [TestClass()]
    public class GameShapeTests
    {

        ShapeRenderer.Orientation defaultOri = ShapeRenderer.Orientation.ORIENT_0;

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void GameShapeTest()
        {
            Vector2 expectedCoordinate = new Vector2(100,100);
            Block anchor = new Block((int)expectedCoordinate.X, (int)expectedCoordinate.Y);
            DummyShape shape = new DummyShape(anchor, defaultOri);
            List<Vector2> coordinates = new List<Vector2>();
            foreach (Block b in shape.blocks)
                coordinates.Add(new Vector2(b.GetX(), b.GetY()));

            // Ensure anchor set
            Assert.AreEqual(anchor, shape.GetBlocks().ElementAt(0));
            // Ensure color set to RED
            Assert.AreEqual(DrawColor.Shade.COLOR_GREY, shape.GetColor());
            // Ensure orientation set
            Assert.AreEqual( defaultOri, shape.GetOrientation());
            // Ensure other blocks are added correctly (correct coordinates)
            Assert.AreEqual(expectedCoordinate, coordinates.ElementAt(0));
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplyInvalidActionTest()
        {
            List<Vector2> coordinates;
            GameShape shape = BasicShapeInitialize(out coordinates, defaultOri);

            shape.ApplyAction(InputAction.Pause);
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void ApplyMoveActionTest()
        {
            List<Vector2> coordinates;
            GameShape shape = BasicShapeInitialize(out coordinates, defaultOri);

            shape.ApplyAction(InputAction.MoveDown);

            //ensure move function called
            foreach (Block b in shape.blocks)
            {
                Assert.IsTrue(coordinates.Contains(new Vector2(b.GetX(), b.GetY() + 1)));
            }
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void ApplyRotateActionTest()
        {
            List<Vector2> coordinates;
            GameShape shape = BasicShapeInitialize(out coordinates, defaultOri);

            shape.ApplyAction(InputAction.Rotate);

            //ensure rotation function called
            foreach (Block b in shape.blocks)
            {
                Assert.IsTrue(coordinates.Contains(b.GetPosition()));
            }
            //ensure orientation adjusted
            Assert.AreEqual(ShapeRenderer.Orientation.ORIENT_1, shape.GetOrientation());
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void SetIsPlacedFlagTest()
        {
            Block anchor = new Block(100, 100);
            DummyShape shape = new DummyShape(anchor, defaultOri);

            shape.GameShapePlaced();

            Assert.AreEqual(true, shape.isPlaced);
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void SetIsAboutToPlaceFlagTest()
        {
            Block anchor = new Block(100, 100);
            DummyShape shape = new DummyShape(anchor, defaultOri);

            shape.AboutToPlaceGameShape();

            Assert.AreEqual(true, shape.isAboutToPlace);

            shape.ResetAboutToPlaceFlag();

            Assert.AreEqual(false, shape.isAboutToPlace);
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void GetNextOrientationTest()
        {
            Block anchor = new Block(100, 100);
            DummyShape shape1 = new DummyShape(anchor, ShapeRenderer.Orientation.ORIENT_0);

            DummyShape shape2 = new DummyShape(anchor, ShapeRenderer.Orientation.ORIENT_1);

            DummyShape shape3 = new DummyShape(anchor, ShapeRenderer.Orientation.ORIENT_2);

            DummyShape shape4 = new DummyShape(anchor, ShapeRenderer.Orientation.ORIENT_3);

            Assert.AreEqual(ShapeRenderer.Orientation.ORIENT_1, shape1.GetNextOrientation());
            Assert.AreEqual(ShapeRenderer.Orientation.ORIENT_2, shape2.GetNextOrientation());
            Assert.AreEqual(ShapeRenderer.Orientation.ORIENT_3, shape3.GetNextOrientation());
            Assert.AreEqual(ShapeRenderer.Orientation.ORIENT_0, shape4.GetNextOrientation());
        }

        private DummyShape BasicShapeInitialize(out List<Vector2> coordinates, ShapeRenderer.Orientation ori)
        {
            Block anchor = new Block(100, 100);
            DummyShape shape = new DummyShape(anchor, ori);
            coordinates = new List<Vector2>();
            foreach (Block b in shape.blocks)
                coordinates.Add(new Vector2(b.GetX(), b.GetY()));

            return shape;
        }


        //******************************************************************
        //NOTE:: Move() logic same regardless of derived GameShape
        //******************************************************************

        // Author: Greg Kulasik
        [TestMethod()]
        public void MoveDownTest()
        {
            List<Vector2> coordinates;
            GameShape shape = BasicShapeInitialize(out coordinates, defaultOri);

            shape.ApplyAction(InputAction.MoveDown);

            for (int i = 0; i < coordinates.Count(); i++)
            {
                // Check that X did not change, and Y was reduced by 1
                Assert.AreEqual(coordinates.ElementAt(i).X, shape.blocks.ElementAt(i).GetX());
                Assert.AreEqual(coordinates.ElementAt(i).Y - 1, shape.blocks.ElementAt(i).GetY());
            }
        }

        // Author: Greg Kulasik
        [TestMethod()]
        public void MoveLeftTest()
        {
            List<Vector2> coordinates;
            GameShape shape = BasicShapeInitialize(out coordinates, defaultOri);

            shape.ApplyAction(InputAction.MoveLeft);

            for (int i = 0; i < coordinates.Count(); i++)
            {
                // Check that X reduced by 1, Y did not change
                Assert.AreEqual(coordinates.ElementAt(i).Y, shape.blocks.ElementAt(i).GetY());
                Assert.AreEqual(coordinates.ElementAt(i).X - 1, shape.blocks.ElementAt(i).GetX());
            }
        }

        // Author: Greg Kulasik
        [TestMethod()]
        public void MoveRightTest()
        {
            List<Vector2> coordinates;
            GameShape shape = BasicShapeInitialize(out coordinates, defaultOri);

            shape.ApplyAction(InputAction.MoveRight);

            for (int i = 0; i < coordinates.Count(); i++)
            {
                // Check that X increased by 1, Y did not change
                Assert.AreEqual(coordinates.ElementAt(i).Y, shape.blocks.ElementAt(i).GetY());
                Assert.AreEqual(coordinates.ElementAt(i).X + 1, shape.blocks.ElementAt(i).GetX());
            }
        }

    }
}
