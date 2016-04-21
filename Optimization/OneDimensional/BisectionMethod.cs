using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод половинного деления для поиска минимума параметра однопараметрической
    /// унимодальной функции и методы работы с ним.
    /// </summary>
    public class BisectionMethod: OneDimensionalOptimization
    {
        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической функции.
        /// Используется метод половинного деления.
        /// </summary>
        /// <param name="function">Унимодальная однопараметрическая функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возврщает минимальное значение параметра унимодальной однопараметрческой
        /// функции.</returns>
        public override double GetMin(Func<double, double> function, double x = 0)
        {
            Tuple<double, double> segment = SegmentSearch.SvenMethod(function, x, 5);
            double a = segment.Item1; //начало отрезка
            double b = segment.Item2; //конец отрезка
            double l = b - a; //длина отрезка
            double x1 = a + l / 4, x2 = b - l / 4, fx1 = function(x1), fx2 = function(x2),
                xMin = (a + b) / 2, fxMin = function(xMin);
            itCount = 3;

            while (Math.Abs(l) > Accuracy)
            {
                if (fx1 <= fxMin) //x* не принадлежит отрезку (xMin, b]
                {
                    b = xMin;
                    xMin = x1;
                    fxMin = fx1;
                }
                else if (fx2 < fxMin) //x* не принадлежит отрезку [a, xMin)
                {
                    a = xMin;
                    xMin = x2;
                    fxMin = fx2;
                }
                else //x* принадлежит отрезку (x1, x2)
                {
                    a = x1;
                    b = x2;
                    xMin = (a + b) / 2;
                    fxMin = function(xMin);
                    itCount++;
                }
                l = b - a;
                x1 = a + l / 4;
                x2 = b - l / 4;
                fx1 = function(x1);
                fx2 = function(x2);
                itCount += 2;
            } 
            return xMin;
        }
    }
}
