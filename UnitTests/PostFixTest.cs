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
    }
}
