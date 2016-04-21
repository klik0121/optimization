using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimization.OneDimensional;
using Optimization.Utils;

namespace UnitTests
{
    [TestClass]
    public class OneDimensionalOptimizationTest
    {
        double eps = 1e-5;
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

        [TestMethod]
        public void TestDerivative()
        {
            Derivative der = new Derivative(TestFunction);
            double first = der.GetFirstDerivative(50);
            double second = der.GetSecondDerivative(50);
            Assert.IsTrue(Math.Abs(first + 100) < eps &&
                Math.Abs(second - 2) < eps);
        }
        [TestMethod]
        public void TestChordMethod()
        {
            IOneDimensionalOptimization opt = new ChordMethod();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }

        [TestMethod]
        public void TestTangentsMethod()
        {
            IOneDimensionalOptimization opt = new TangentsMethod();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }

        [TestMethod]
        public void TestMidPointMethod()
        {
            IOneDimensionalOptimization opt = new MidPointMethod();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }

    }
}
