using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTest
{
    [TestClass]
    public class DummyTest
    {
        [TestMethod]
        public void SanityTest()
        {
            // intentionally failing test
            Assert.IsTrue(false);
        }
    }
}
