using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод золотого сечения для поиска минимума параметра однопараметрической 
    /// унимодальной функции и методы работы с ним.
    /// </summary>
    public class GoldenSectionMethod: OneDimensionalOptimization
    {
        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической функции.
        /// Используется метод золотого сечения.
        /// </summary>
        /// <param name="function">Унимодальная однопараметрическая функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возврщает минимальное значение параметра унимодальной однопараметрческой
        /// функции.</returns>
        public override double GetMin(Func<double, double> function, double x = 0)
        {
            IterationCount = 0;
            Tuple<double, double> segment = SegmentSearch.SvenMethod(function, x, 5);
            double a = segment.Item1; //начало отрезка
            double b = segment.Item2; //конец отрезка
            double k = (Math.Sqrt(5) - 1) / 2; //коэффициент дробления
            double x1 = a + (1 - k) * (b - a), x2 = a + k * (b - a);
            double fx1 = function(x1), fx2 = function(x2);

            FunctionCalls = 2;
            while(Math.Abs(b - a) > Accuracy)
            {
                FunctionCalls++;
                IterationCount++;
                if(fx1 > fx2) //x* не принадлежит отрезку [a, x1]
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + k * (b - a);
                    fx1 = fx2;
                    fx2 = function(x2);
                }
                else //x* не принадлежит отрезку (x2, b]
                {
                    b = x2;
                    x2 = x1;
                    x1 = a + (1 - k) * (b - a);
                    fx2 = fx1;
                    fx1 = function(x1);
                }
            }
            return (b + a) / 2;
        }
    }
}
