using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод квадратичной аппроксимации для поиска минимума параметра однопараметрической 
    /// унимодальной функции и методы работы с ним.
    /// </summary>
    /// <seealso cref="Optimization.OneDimensional.OneDimensionalOptimization" />
    public class QuadraticApproximation: OneDimensionalOptimization
    {
        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической функции.
        /// </summary>
        /// <param name="function">Унимодальная однопараметрическая функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возврщает минимальное значение параметра унимодальной однопараметрческой
        /// функции.</returns>
        public override double GetMin(Func<double, double> function, double x = 0)
        {
            IterationCount = 0;
            Derivative der = new Derivative(function);
            Tuple<double, double> segment = SegmentSearch.FindZero(der.GetFirstDerivative, x);
            double x1 = segment.Item1, x3 = segment.Item2, x2 =  (x1 + x3) / 2;
            double fx1 = function(x1), fx2 = function(x2), fx3 = function(x3);
            double fxMin, xMin, fx;
            FunctionCalls = 3;
            do
            {
                IterationCount++;
                fxMin = Math.Min(Math.Min(fx1, fx2), fx3);
                xMin = 0;
                if (fxMin == fx1)
                    xMin = fx1;
                else if (fx2 == fxMin) xMin = x2;
                else xMin = x3;
                double num = fx1 * (x2 * x2 - x3 * x3) - fx2 * (x1 * x1 - x3 * x3) +
                    fx3 * (x1 * x1 - x2 * x2);
                double dom = 2 * (fx1 * (x2 - x3) - fx2 * (x1 - x3) + fx3 * (x1 - x2));
                x = num / dom;
                fx = function(x);
                FunctionCalls++;
                if (x >= x1 && x <= x2) //точка x лежит в отрезке [x1, x2]
                {
                    x3 = x2; fx3 = fx2;
                    x2 = x; fx2 = fx;                                        
                }
                else //точка x лежит в отрезке (x2, x3]
                {
                    x1 = x2; fx1 = fx2;
                    x2 = x; fx2 = fx;                                       
                }
            } while (Math.Abs(fx - fxMin) >= Accuracy && Math.Abs(xMin - x) >= Accuracy);
            return x;
        }
    }
}
