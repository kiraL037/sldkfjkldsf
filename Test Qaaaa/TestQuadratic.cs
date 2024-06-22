using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Qaaaa;

namespace TestQaa
{
    [TestClass]
    public class TestQuadratic
    {
        [TestMethod]
        public void RootsExpexted()
        {
            double a = 2;
            double b = -5;
            double c = 3;
            double[] expected = { 1.5, 1 };
            double[] actual = Program.Qaaa(a, b, c);
            Assert.AreEqual(expected, actual);
        }
        public void RootsNotExpexted()
        {
            double a = 2;
            double b = -5;
            double c = 3;
            double[] expected = { 1, 1 };
            double[] actual = Program.Qaaa(a, b, c);
            Assert.AreNotEqual(expected, actual);
        }
        public void RootsNull()
        {
            double a = 3;
            double b = 6;
            double c = 3;
            double[] actual = Program.Qaaa(a, b, c);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.GetLength(0) == 0);
        }
        public void RootsNotNull()
        {
            double a = 3;
            double b = 6;
            double c = 3;
            double[] actual = Program.Qaaa(a, b, c);
            Assert.IsNull(actual);
            Assert.IsTrue(actual.GetLength(0) != 0);
        }
    }
}