using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод средней точки для поиска минимума однопараметрической унимодальной функции.
    /// </summary>
    /// <seealso cref="Optimization.OneDimensional.OneDimensionalOptimization" />
    public class MidPointMethod: OneDimensionalOptimization
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
            double a = segment.Item1, b = segment.Item2,
                r = (a + b) / 2,
                derR = der.GetFirstDerivative(r);
            FunctionCalls = 2;
            while(Math.Abs(derR) >= Accuracy)
            {
                IterationCount++;
                if(derR > 0) //x* лежит в интервале [a; r]
                {
                    b = r;
                }
                else //x* лежит в интервале [r; b]
                {
                    a = r;
                }
                r = (a + b) / 2;
                derR = der.GetFirstDerivative(r);
                FunctionCalls += 2;
            }
            return r;
        }
    }
}
