using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimization.OneDimensional;
using Optimization.Utils;
using OptimizationView;
using System.Reflection;

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
        [TestMethod]
        public void TestFlags()
        {
            OneDimensionalMethod methods = OneDimensionalMethod.BisectionMethod;
            methods |= OneDimensionalMethod.ChordMethod | OneDimensionalMethod.FibonacciNumbersMethod |
                 OneDimensionalMethod.GoldenSectionMethod | OneDimensionalMethod.MidPointMethod |
                  OneDimensionalMethod.TangentsMethod;
            EnumCountAttribute attribute = (EnumCountAttribute)methods.GetType().GetCustomAttribute(typeof(EnumCountAttribute));
            Assert.IsTrue(attribute.Count == 9);

        }
        [TestMethod]
        public void TestQuadraticApproximation()
        {
            IOneDimensionalOptimization opt = new QuadraticApproximation();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }
        [TestMethod]
        public void TestCubicApproximation()
        {
            IOneDimensionalOptimization opt = new CubicApproximation();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }
        [TestMethod]
        public void TestQuadraticFunction()
        {
            IOneDimensionalOptimization opt = new QuadraticFunction();
            opt.Accuracy = eps;
            Assert.IsTrue(Math.Abs(opt.GetMin(TestFunction) - 100) < eps);
        }

        protected double TestFunction(double x)
        {
            return x * x - 200 * x + 100;
        }      
    }
}
