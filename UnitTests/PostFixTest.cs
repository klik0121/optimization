using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimization.Utils;

namespace UnitTests
{
    [TestClass]
    public class PostFixTest
    {
        [TestMethod]
        public void TestPostFix()
        {
            PostFix pf = new PostFix();
            pf.CachePostFix("(100-x)^2");
            Assert.IsTrue(pf.CalculateCached(200) + pf.CalculateCached(200) ==
                TestFunction(200) + TestFunction(200));
        }
        protected double TestFunction(double x)
        {
            return Math.Pow(100 - x, 2);
        }
        [TestMethod]
        public void TestPostFixDimensions()
        {
            PostFix pf = new PostFix();
            pf.CachePostFix("x + y + z * (x + y)");
            Assert.IsTrue(pf.CachedDimCount == 3);
        }
        [TestMethod]
        public void TestPostFixCalculation()
        {
            PostFix pf = new PostFix();
            pf.CachePostFix("x + y + z * (x + y)");
            Assert.IsTrue(pf.CalculateCached(new double[] {1, 0, 3}) == 4);
        }
    }
}
