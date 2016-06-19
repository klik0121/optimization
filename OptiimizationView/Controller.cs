using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Optimization.OneDimensional;
using Optimization.Utils;
using Optimization.NDimensional;

namespace OptimizationView
{
    /// <summary>
    /// Контролирует ход работы приложения.
    /// </summary>
    public class Controller
    {
        protected Form view;
        protected Dictionary<OneDimensionalMethod,
            IOneDimensionalOptimization> methods;
        protected Dictionary<NDimensinalMethod,
            INDimensionalOptimization> nMethods;


        /// <summary>
        /// Инициализирует новый экземпляр OptimizationView.Controller.
        /// </summary>
        public Controller()
        {
            this.methods = new Dictionary<OneDimensionalMethod,
                IOneDimensionalOptimization>();
            this.view = new OptimizationTest();
            ((OptimizationTest)this.view).Controller = this;
            this.methods.Add(OneDimensionalMethod.BisectionMethod,
                new BisectionMethod());
            this.methods.Add(OneDimensionalMethod.FibonacciNumbersMethod,
                new FibonacciNumbersMethod());
            this.methods.Add(OneDimensionalMethod.GoldenSectionMethod,
                new GoldenSectionMethod());
            this.methods.Add(OneDimensionalMethod.CubicApproximation,
                new CubicApproximation());
            this.methods.Add(OneDimensionalMethod.ChordMethod,
                new ChordMethod());
            this.methods.Add(OneDimensionalMethod.MidPointMethod,
                new MidPointMethod());
            this.methods.Add(OneDimensionalMethod.QuadraticApproximation,
                new QuadraticApproximation());
            this.methods.Add(OneDimensionalMethod.TangentsMethod,
                new TangentsMethod());
            this.methods.Add(OneDimensionalMethod.QuadraticFunction,
                new QuadraticFunction());

            this.nMethods = new Dictionary<NDimensinalMethod, INDimensionalOptimization>();
            this.nMethods.Add(NDimensinalMethod.CoordinateDescent,
                new CoordinateDescent());
            this.nMethods.Add(NDimensinalMethod.HookJeeves,
                new HookJeeves());
            this.nMethods.Add(NDimensinalMethod.NelderMead,
                new NelderMead());
        }
        /// <summary>
        /// Возвращает форму для старта приложения.
        /// </summary>
        /// <returns>Возвращает форму для старта приложения.</returns>
        public Form Run()
        {
            return view;
        }
        /// <summary>
        /// Получает точки для построения графиков тестов метода.
        /// </summary>
        /// <param name="function">Строковая функция.</param>
        /// <param name="method">Метод оптимизации.</param>
        /// <returns>Возвращает точки для построения графиков тестов метода.</returns>
        public List<KeyValuePair<double, double>> TestMethod(string function,
            OneDimensionalMethod method)
        {
            List<KeyValuePair<double, double>> result = new
                List<KeyValuePair<double, double>>();
            PostFix pf = new PostFix();
            pf.CachePostFix(function);
            IOneDimensionalOptimization currMethod = methods[method];
            double eps = 1;
            for(int i = 1; i < 13; i++)
            {                
                currMethod.Accuracy = eps;
                currMethod.GetMin(pf.CalculateCached);
                result.Add(new KeyValuePair<double, double>(eps,
                    currMethod.FunctionCalls));
                eps /= 10;
            }
            return result;
        }
        /// <summary>
        /// Получает минимальное значение параметра заданной функции заданным методом.
        /// </summary>
        /// <param name="function">Строковое представление метода.</param>
        /// <param name="method">Метод оптимизации.</param>
        /// <returns>Возвращает минимальное значение параметра.</returns>
        public double GetMin(string function, OneDimensionalMethod method, double x0)
        {
            methods[method].Accuracy = 1E-7;
            PostFix pf = new PostFix();
            pf.CachePostFix(function);
            return methods[method].GetMin(pf.CalculateCached, x0);
        }
        public string GetMin(string function, NDimensinalMethod method, double[] x0)
        {
            nMethods[method].Accuracy = 1E-7;
            PostFix pf = new PostFix();
            pf.CachePostFix(function);
            double[] res = nMethods[method].GetMin(pf.CalculateCached, x0);
            string result = string.Empty;
            for(int i = 0; i < res.Length; i++)
            {
                result += Math.Round(res[i], 3) + ";";
            }
            return result;
        }
        /// <summary>
        /// Возвращает точки, необходимые для построения графика функции.
        /// </summary>
        /// <param name="function">Строковое представление функции.</param>
        /// <returns>Возвращает точки, необходимые для построения графика функции.</returns>
        public List<KeyValuePair<double, double>> EvaluateFunction(string function, double x0)
        {
            List<KeyValuePair<double, double>> result = new
                List<KeyValuePair<double, double>>();
            double a = x0 - 5;
            double b = x0 + 5;
            double step = 0.2;
            PostFix pf = new PostFix();
            pf.CachePostFix(function);
            for(double x = a; x <= b; x+=step)
            {
                result.Add(new KeyValuePair<double, double>(x, pf.CalculateCached(x)));
            }
            return result;
        }
        public List<KeyValuePair<double, double>> TestMethodFunc(string function,
            NDimensinalMethod method, double[] x)
        {
            List<KeyValuePair<double, double>> result = new
                List<KeyValuePair<double, double>>();
            PostFix pf = new PostFix();
            pf.CachePostFix(function);
            INDimensionalOptimization currMethod = nMethods[method];
            double eps = 1;
            for (int i = 1; i < 13; i++)
            {
                currMethod.Accuracy = eps;
                currMethod.GetMin(pf.CalculateCached, x);
                result.Add(new KeyValuePair<double, double>(eps,
                    currMethod.FunctionCallCount));
                eps /= 10;
            }
            return result;
        }
        public List<KeyValuePair<double, double>> TestMethodIter(string function,
            NDimensinalMethod method, double[] x)
        {
            List<KeyValuePair<double, double>> result = new
                List<KeyValuePair<double, double>>();
            PostFix pf = new PostFix();
            pf.CachePostFix(function);
            INDimensionalOptimization currMethod = nMethods[method];
            double eps = 1;
            for (int i = 1; i < 13; i++)
            {
                currMethod.Accuracy = eps;
                currMethod.GetMin(pf.CalculateCached, x);
                result.Add(new KeyValuePair<double, double>(eps,
                    currMethod.IterationCount));
                eps /= 10;
            }
            return result;
        }
        public OneDimensionalMethodType GetMethodType(OneDimensionalMethod method)
        {
            int num = (int)method;
            if (num < 8) return OneDimensionalMethodType.SegmentShrinking;
            if (num < 256) return OneDimensionalMethodType.DerivativeUsage;
            if (num < 512) return OneDimensionalMethodType.Approximation;
            throw new ArgumentException(string.Format("Параметр {0} задаёт методы из разных категорий.",
                method));
        }
    }
}
