using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод кубической аппроксимации для поиска минимума параметра однопараметрической 
    /// унимодальной функции и методы работы с ним.
    /// </summary>
    /// <seealso cref="Optimization.OneDimensional.OneDimensionalOptimization" />
    public class CubicApproximation: OneDimensionalOptimization
    {
        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической функции.
        /// </summary>
        /// <param name="function">Унимодальная однопараметрическая функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возвращает минимальное значение параметра унимодальной однопараметрческой
        /// функции.</returns>
        public override double GetMin(Func<double, double> function, double x = 0)
        {
            IterationCount = 0;
            Derivative der = new Derivative(function);
            Tuple<double, double> segment = SegmentSearch.FindZero(der.GetFirstDerivative, x);
            double a = segment.Item1;
            double b = segment.Item2;
            double fa = function(a), fb = function(b);
            double derA = der.GetFirstDerivative(a), derB = der.GetFirstDerivative(b), derX;
            FunctionCalls = 6; //2 вычисления функции + 2 вычисления 1-ых производных (по 2 вычисления функции)
            do
            {
                IterationCount++;
                double z = 3 * ((fa - fb) / (b - a)) + derA + derB;
                double o = Math.Sqrt(z * z - derA * derB);
                double g = (z + o - derA) / (derB - derA + 2 * o);
                x = a + g * (b - a); //точка минимума полинома 3-ей степени
                derX = der.GetFirstDerivative(x);
                FunctionCalls += 2;
                if (derX < 0) //минимум принадлежит [x; b]
                {
                    a = x; derA = derX; fa = function(a);
                    FunctionCalls++;
                }
                else //минимум принадлежит [a; x]
                {
                    b = x; derB = derX; fb = function(b);
                    FunctionCalls++;
                }

            } while (Math.Abs(b - a) >= Accuracy && Math.Abs(derX) >= Accuracy);
            return x;
        }
    }
}
