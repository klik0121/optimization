using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimization.OneDimensional;
using Optimization.Utils;
using OptimizationView;
using System.Reflection;
using Optimization.NDimensional;

namespace UnitTests
{
    [TestClass]
    public class NDimensionalOptimizationTest
    {
        double eps = 1E-6;

        [TestMethod]
        public void TestCoordinateDescent()
        {
            INDimensionalOptimization opt = new CoordinateDescent();
            opt.Accuracy = eps;
            PostFix pf = new Optimization.Utils.PostFix();
            double[] x = new double[2];
            x[0] = 1;
            x[1] = 1;
            pf.CachePostFix("x^2 + y^2 - 5");
            Assert.IsTrue(Math.Abs(pf.CalculateCached(new double[2]) -
                pf.CalculateCached(opt.GetMin(pf.CalculateCached, x))) <= eps);
        }
        [TestMethod]
        public void TestHookJeeves()
        {
            INDimensionalOptimization opt = new HookJeeves();
            opt.Accuracy = eps;
            PostFix pf = new Optimization.Utils.PostFix();
            double[] x = new double[2];
            x[0] = 2.57;
            x[1] = 1.68;
            pf.CachePostFix("x^2 + y^2 - 5");
            Assert.IsTrue(Math.Abs(pf.CalculateCached(new double[2]) -
                pf.CalculateCached(opt.GetMin(pf.CalculateCached, x))) <= eps);
        }
        [TestMethod]
        public void TestNelderMead()
        {
            INDimensionalOptimization opt = new NelderMead();
            opt.Accuracy = eps;
            PostFix pf = new Optimization.Utils.PostFix();
            double[] x = new double[2];
            x[0] = 2.57;
            x[1] = 1.68;
            pf.CachePostFix("x^2 + y^2 - 5" );
            Assert.IsTrue(Math.Abs(pf.CalculateCached(new double[2]) -
                pf.CalculateCached(opt.GetMin(pf.CalculateCached, x))) <= eps);
        }
    }
}
