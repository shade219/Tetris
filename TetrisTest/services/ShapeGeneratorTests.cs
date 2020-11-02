using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.domain;
using Tetris.domain.shapes;

namespace Tetris.services.Tests
{
    // Authors: Yao-Hua Liu
    // Description: Unit Test for ShapeGenerator methods
    [TestClass()]
    public class ShapeGeneratorTests
    {
        // Author: Yao-Hua Liu
        [TestMethod()]
        public void GenerateShapeTest()
        {
            GameShape textShape = ShapeGenerator.GenerateShape(1);
            Assert.IsTrue(textShape is GameShape);
        }

        [TestMethod()]
        [DataRow(1, 100, typeof(SquareShape))]
        [DataRow(1, 200, typeof(L1Shape))]
        [DataRow(1, 400, typeof(L2Shape))]
        [DataRow(1, 600, typeof(LineShape))]
        [DataRow(1, 700, typeof(TShape))]
        [DataRow(1, 800, typeof(Z1Shape))]
        [DataRow(1, 900, typeof(Z2Shape))]
        [DataRow(10, 50, typeof(SquareShape))]
        [DataRow(10, 100, typeof(L1Shape))]
        [DataRow(10, 150, typeof(L2Shape))]
        [DataRow(10, 200, typeof(LineShape))]
        [DataRow(10, 400, typeof(TShape))]
        [DataRow(10, 600, typeof(Z1Shape))]
        [DataRow(10, 700, typeof(Z1Shape))]
        [DataRow(10, 800, typeof(Z2Shape))]
        [DataRow(10, 900, typeof(Z2Shape))]
        public void PrivateGenerateShapeTest(int inLevel, int randResult, Type type)
        {
            PrivateType wrapper = new PrivateType(typeof(ShapeGenerator));
            GameShape result = (GameShape)wrapper.InvokeStatic("PrivateGenerateShape", inLevel, randResult);
            Assert.IsTrue(result.GetType() == type);
        }

        [TestMethod()]
        [DataRow(1, 182)]
        [DataRow(2, 169)]
        [DataRow(3, 156)]
        [DataRow(4, 142)]
        [DataRow(5, 129)]
        [DataRow(6, 116)]
        [DataRow(7, 102)]
        [DataRow(8, 89)]
        [DataRow(9, 76)]
        [DataRow(10, 62)]
        public void SquareAndL12ShapeProbabilityTest(int inLevel, float expectedProbability)
        {
            PrivateType wrapper = new PrivateType(typeof(ShapeGenerator));
            int result = (int)wrapper.InvokeStatic("SquareAndL12ShapeProbability", inLevel);
            Assert.AreEqual(expectedProbability, result);
        }

        [TestMethod()]
        public void LineShapeProbabilityTest()
        {
            PrivateType wrapper = new PrivateType(typeof(ShapeGenerator));
            int result = (int)wrapper.InvokeStatic("LineShapeProbability");
            Assert.AreEqual(142, result);
        }

        [TestMethod()]
        [DataRow(1, 102)]
        [DataRow(2, 116)]
        [DataRow(3, 129)]
        [DataRow(4, 142)]
        [DataRow(5, 156)]
        [DataRow(6, 169)]
        [DataRow(7, 182)]
        [DataRow(8, 196)]
        [DataRow(9, 209)]
        [DataRow(10, 222)]
        public void TAndZ12ShapeProbabilityTest(int inLevel, float expectedProbability)
        {
            PrivateType wrapper = new PrivateType(typeof(ShapeGenerator));
            int result = (int)wrapper.InvokeStatic("TAndZ12ShapeProbability", inLevel);
            Assert.AreEqual(expectedProbability, result);
        }

    }
}