using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.domain.Tests
{
    // Authors: DeAngelo
    // Description: A class to test basic functions of Block
    [TestClass()]
    public class BlockTests
    {
        // Author: DeAngelo Wilson
        [TestMethod()]
        public void BlockConstructionTest()
        {
            Block block = new Block(DrawColor.Shade.COLOR_BLUE, 100, 101);
            //ensure x and y vals set
            Assert.AreEqual(block.GetX(), 100);
            Assert.AreEqual(block.GetY(), 101);
            Assert.AreEqual(block.GetPosition(), new Vector2(100, 101));

            //ensure color set
            Assert.AreEqual(DrawColor.Shade.COLOR_BLUE, block.color);
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void CopyTest()
        {
            Block block = new Block(DrawColor.Shade.COLOR_BLUE, 100, 101);

            Block copy = block.Copy(new Vector2(1, -1));

            //ensure new block created
            Assert.AreNotSame(block, copy);

            //ensure x and y vals set
            Assert.AreEqual(copy.GetX(), block.GetX() + 1);
            Assert.AreEqual(copy.GetY(), block.GetY() - 1);
        }

        // Author: DeAngelo Wilson
        [TestMethod()]
        public void ApplyOffsetTest()
        {
            Block block = new Block(DrawColor.Shade.COLOR_BLUE, 100, 101);

            block.ApplyOffset(new Vector2(1, -1));
            //ensure x and y vals set
            Assert.AreEqual(block.GetX(), 101);
            Assert.AreEqual(block.GetY(), 100);
        }
    }
}