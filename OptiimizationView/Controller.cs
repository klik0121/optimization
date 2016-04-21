using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Optimization.OneDimensional;
using Optimization.Utils;

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

        /// <summary>
        /// Инициализирует новый экземпляр OptimizationView.Controller.
        /// </summary>
        public Controller()
        {
            this.methods = new Dictionary<OneDimensionalMethod,
                IOneDimensionalOptimization>();
            this.view = new FormOneDimOpt();
            ((FormOneDimOpt)this.view).Controller = this;
            this.methods.Add(OneDimensionalMethod.BisectionMethod,
                new BisectionMethod());
            this.methods.Add(OneDimensionalMethod.FibonacciNumbersMethod,
                new FibonacciNumbersMethod());
            this.methods.Add(OneDimensionalMethod.GoldenSectionMethod,
                new GoldenSectionMethod());
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
                    currMethod.IterationCount));
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
        /// <summary>
        /// Возвращает точки, необходимые для построения графика функции.
        /// </summary>
        /// <param name="function">Строковое представление функции.</param>
        /// <returns>Возвращает точки, необходимые для построения графика функции.</returns>
        public List<KeyValuePair<double, double>> EvaluateFunction(string function, double x0)
        {
            List<KeyValuePair<double, double>> result = new
                List<KeyValuePair<double, double>>();
            double a = x0 - 30;
            double b = a + 60;
            double step = 0.2;
            PostFix pf = new PostFix();
            pf.CachePostFix(function);
            for(double x = a; x <= b; x+=step)
            {
                result.Add(new KeyValuePair<double, double>(x, pf.CalculateCached(x)));
            }
            return result;
        }
    }
}
