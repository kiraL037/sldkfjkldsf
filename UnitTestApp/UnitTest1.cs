using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using App;

namespace UnitTestApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStatementCoverage()
        {
            int[][] segments = new int[][] 
            { 
                new int[] { 1, 4 }, 
                new int[] { 3, 8 } 
            };
            int totalShadowLength = Program.CalculateShadowLength(segments);
            Assert.AreEqual(6, totalShadowLength);
        }

        [TestMethod]
        public void TestBranchCoverage()
        {
            int[][] segments = new int[][] 
            { 
                new int[] { 1, 4 }, 
                new int[] { 3, 8 }, 
                new int[] { 9, 11 } 
            };
            int totalShadowLength = Program.CalculateShadowLength(segments);
            Assert.AreEqual(9, totalShadowLength);
        }

        [TestMethod]
        public void TestConditionSolutionCoverage()
        {
            int[][] segments = new int[][] 
            { 
                new int[] { 1, 4 }, 
                new int[] { 4, 8 }, 
                new int[] { 9, 11 } 
            };
            int totalShadowLength = Program.CalculateShadowLength(segments);
            Assert.AreEqual(7, totalShadowLength); 
        }

        [TestMethod]
        public void TestCombinatorialCoverage()
        {
            int[][] segments = new int[][] 
            { 
                new int[] { 1, 4 }, 
                new int[] { 4, 8 }, 
                new int[] { 9, 11 }, 
                new int[] { 12, 13 } 
            };
            int totalShadowLength = Program.CalculateShadowLength(segments);
            Assert.AreEqual(9, totalShadowLength);
        }
    }
}
