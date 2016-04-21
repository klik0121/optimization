using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimization.OneDimensional;

namespace UnitTests
{
    [TestClass]
    public class OneDimensionalOptimizationTest
    {
        double eps = 1e-9;
        [TestMethod]
        public void TestBisection()
        {
            IOneDimensionalOptimization opt = new BisectionMethod();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }

        protected double TestFunction(double x)
        {
            return Math.Pow(100 - x, 2);
        }
        [TestMethod]
        public void TestGoldenSection()
        {
            IOneDimensionalOptimization opt = new GoldenSectionMethod();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }

        [TestMethod]
        public void TestFibonacci()
        {
            IOneDimensionalOptimization opt = new FibonacciNumbersMethod();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }
    }
}
