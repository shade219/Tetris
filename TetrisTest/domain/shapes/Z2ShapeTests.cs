using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.domain.shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.shapes.Tests
{
    // Authors: Alex Schertler
    // Description: Tests if Z2 constructs and rotates properly
    [TestClass()]
    public class Z2ShapeTests
    {
        private Z2Shape BasicShapeInitialize(out List<Vector2> coordinates, ShapeRenderer.Orientation ori)
        {
            Block anchor = new Block(100, 100);
            Z2Shape z2 = new Z2Shape(anchor, ori);
            coordinates = new List<Vector2>();
            foreach (Block b in z2.blocks)
                coordinates.Add(new Vector2(b.GetX(), b.GetY()));

            return z2;
        }


        // Author: Alex Schertler
        [TestMethod()]
        public void Z2ShapeConstructionTest()
        {
            //ensure all blocks of square at correct positions
            List<Vector2> coordinates;
            GameShape z2 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_0);

            List<Vector2> expectedCoordinates = new List<Vector2>() { new Vector2(100, 100), new Vector2(101, 100), new Vector2(100, 99), new Vector2(99, 99) };

            foreach (Vector2 coord in expectedCoordinates)
            {
                Assert.IsTrue(coordinates.Contains(coord));
            }
        }

        // Author: Alex Schertler
        [TestMethod()]
        public void Rotate0To90Test()
        {
            List<Vector2> coordinates;
            GameShape z2 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_0);

            //Rotate GameShape
            z2.ApplyAction(InputAction.Rotate);

            //Automated way of checking if properly rotated --- NOTE:: ASSUMES rotationOffset Lists are accurate
            //IReadOnlyCollection<Vector2> rotationOffsets = square.GetOrientationOffsets(square.GetOrientation());

            //for (int i = 0; i < coordinates.Count; i++)
            //{
            //    //Get position of 
            //    Vector2 pos = new Vector2(square.blocks.ElementAt(i).GetX(), square.blocks.ElementAt(i).GetY());
            //    pos -= rotationOffsets.ElementAt(i);
            //    Assert.AreEqual(coordinates.ElementAt(i), pos);
            //}

            Assert.AreEqual(coordinates.ElementAt(0).X, z2.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, z2.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X - 1, z2.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y - 1, z2.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X - 1, z2.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y + 1, z2.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X, z2.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y + 2, z2.blocks.ElementAt(3).GetY());
        }

        // Author: Alex Schertler
        [TestMethod()]
        public void Rotate90To180Test()
        {
            List<Vector2> coordinates;
            GameShape z2 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_1);

            //Rotate GameShape
            z2.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, z2.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, z2.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X + 1, z2.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y + 1, z2.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X + 1, z2.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y - 1, z2.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X, z2.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y - 2, z2.blocks.ElementAt(3).GetY());
        }

        // Author: Alex Schertler
        [TestMethod()]
        public void Rotate180To270Test()
        {
            List<Vector2> coordinates;
            GameShape z2 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_2);

            //Rotate GameShape
            z2.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, z2.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, z2.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X - 1, z2.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y - 1, z2.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X - 1, z2.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y + 1, z2.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X, z2.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y + 2, z2.blocks.ElementAt(3).GetY());
        }

        // Author: Alex Schertler
        [TestMethod()]
        public void Rotate270To0Test()
        {
            List<Vector2> coordinates;
            GameShape z2 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_3);

            //Rotate GameShape
            z2.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, z2.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, z2.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X + 1, z2.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y + 1, z2.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X + 1, z2.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y - 1, z2.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X, z2.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y - 2, z2.blocks.ElementAt(3).GetY());
        }
    }
}