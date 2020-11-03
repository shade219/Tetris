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
    // Authors: Dillon Gould
    // Description:
    [TestClass()]
    public class L1ShapeTests
    {
        ShapeRenderer.Orientation defaultOri = ShapeRenderer.Orientation.ORIENT_0;

        private L1Shape BasicShapeInitialize(out List<Vector2> coordinates, ShapeRenderer.Orientation ori)
        {
            Block anchor = new Block(100, 100);
            L1Shape L1 = new L1Shape(anchor, ori);
            coordinates = new List<Vector2>();
            foreach (Block b in L1.blocks)
                coordinates.Add(new Vector2(b.GetX(), b.GetY()));

            return L1;
        }

        // Author: Dillon Gould
        [TestMethod()]
        public void L1ShapeConstructionTest()
        {
            //ensure all blocks of square at correct positions
            List<Vector2> coordinates;
            GameShape L1 = BasicShapeInitialize(out coordinates, defaultOri);

            List<Vector2> expectedCoordinates = new List<Vector2>() { new Vector2(100, 100), new Vector2(100, 99), new Vector2(101, 100), new Vector2(102, 100) };

            foreach (Vector2 coord in expectedCoordinates)
            {
                Assert.IsTrue(coordinates.Contains(coord));
            }
        }

        // Author: Dillon Gould
        [TestMethod()]
        public void Rotate0To90Test()
        {
            List<Vector2> coordinates;
            GameShape L1 = BasicShapeInitialize(out coordinates, defaultOri);

            //Rotate GameShape
            L1.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, L1.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, L1.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X + 1, L1.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y + 1, L1.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X - 1, L1.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y + 1, L1.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X - 2, L1.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y + 2, L1.blocks.ElementAt(3).GetY());
        }

        // Author: Dillon Gould
        [TestMethod()]
        public void Rotate90To180Test()
        {
            List<Vector2> coordinates;
            GameShape L1 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_1);

            //Rotate GameShape
            L1.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, L1.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, L1.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X - 1, L1.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y + 1, L1.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X - 1, L1.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y - 1, L1.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X - 2, L1.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y - 2, L1.blocks.ElementAt(3).GetY());
        }

        // Author: Dillon Gould
        [TestMethod()]
        public void Rotate180To270Test()
        {
            List<Vector2> coordinates;
            GameShape L1 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_2);

            //Rotate GameShape
            L1.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, L1.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, L1.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X - 1, L1.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y - 1, L1.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X + 1, L1.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y - 1, L1.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X + 2, L1.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y - 2, L1.blocks.ElementAt(3).GetY());
        }

        // Author: Dillon Gould
        [TestMethod()]
        public void Rotate270To0Test()
        {
            List<Vector2> coordinates;
            GameShape L1 = BasicShapeInitialize(out coordinates, ShapeRenderer.Orientation.ORIENT_3);

            //Rotate GameShape
            L1.ApplyAction(InputAction.Rotate);

            Assert.AreEqual(coordinates.ElementAt(0).X, L1.blocks.ElementAt(0).GetX());
            Assert.AreEqual(coordinates.ElementAt(0).Y, L1.blocks.ElementAt(0).GetY());

            Assert.AreEqual(coordinates.ElementAt(1).X + 1, L1.blocks.ElementAt(1).GetX());
            Assert.AreEqual(coordinates.ElementAt(1).Y - 1, L1.blocks.ElementAt(1).GetY());

            Assert.AreEqual(coordinates.ElementAt(2).X + 1, L1.blocks.ElementAt(2).GetX());
            Assert.AreEqual(coordinates.ElementAt(2).Y + 1, L1.blocks.ElementAt(2).GetY());

            Assert.AreEqual(coordinates.ElementAt(3).X + 2, L1.blocks.ElementAt(3).GetX());
            Assert.AreEqual(coordinates.ElementAt(3).Y + 2, L1.blocks.ElementAt(3).GetY());
        }

    }
}