using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    public class QuadraticFunction: OneDimensionalOptimization
    {
        protected double a;
        protected double b;
        protected double c;
        protected Func<double, double> quad;

        protected void PrepareQuadratic(Func<double, double> function, double x1, double x3)
        {
            double x2 = (x1 + x3) / 2;
            double f1 = function(x1), f2 = function(x2), f3 = function(x3);
            double r12 = x1 - x2, r13 = x1 - x3, r23 = x2 - x3;
            double s12 = x1 + x2, s13 = x1 + x3, s23 = x2 + x3;
            double p12 = x1 * x2, p13 = x1 * x3, p23 = x2 * x3;
            a = f1 / (r12 * r13) - f2 / (r12 * r23) + f3 / (r13 * r23);
            b =  - (f1 * s23 / (r12 * r13) - f2 * s13 / (r12 * r23) + f3 * s12 / (r13 * r23));
            c = f1 * p23 / (r12 * r13) - f2 * p13/ (r12 * r23) + f3 * p12 / (r13 * r23);
            quad = (x) => { return a * x * x + b * x + c; };
        }
        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической квадратичной функции.
        /// </summary>
        /// <param name="function">Унимодальная однопараметрическая функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возврщает минимальное значение параметра унимодальной однопараметрческой
        /// функции.</returns>
        public override double GetMin(Func<double, double> function, double x = 0)
        {
            IterationCount = 1;
            Tuple<double, double> segment = SegmentSearch.SvenMethod(function, x);
            double n = segment.Item1, p = segment.Item2;
            PrepareQuadratic(function, n, p);
            double xMin = -b / (2 * a); //вершина параболы
            double fp = function(p), fn = function(n);
            FunctionCalls = 2;
            if(a > 0)
            {
                if (xMin >= n && xMin <= p) //вершина лежит а отрезке
                    return xMin;
                //иначе проверяем границы отрезка
                FunctionCalls += 2;
                if (fn < fp) return n;
                return p;
            }
            else
            {
                //проверяем гарницы отрезка
                FunctionCalls += 2;
                if (fn < fp) return n;
                return p;
            }
        }
    }
}
