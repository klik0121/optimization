using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Utils
{
    /// <summary>
    /// Алгоритмы для поиска отрезка, содержащего минимум функции.
    /// </summary>
    public static class SegmentSearch
    {
        /// <summary>
        /// Метод Свенна для поиска отрезка, содержащего минимум функции.
        /// </summary>
        /// <param name="function">Унимодальная функция.</param>
        /// <param name="x0">Начальня точка.</param>
        /// <param name="d">Величина шага.</param>
        /// <returns>Возвращает кортеж из двух значений, задающих границы искомого отрезка.</returns>
        public static Tuple<double, double> SvenMethod(Func<double, double> function, double x0,
            double d)
        {
            double x1 = x0; //по окончании работы алгоритма хранит начало отрезка
            double x2 = x1 + d; //по окончании работы алгоритма хранит конец отрезка
            double x3; //новая точка
            double fx2 = function(x2); //значение функции в точке x[n-1]
            double fx3 = 0; //значение функции в точке x[n]            
            //если f(x2) > f(x1), значит функция убывает в направлении x1
            if (fx2 > function(x1)) d = -d; //берём шаг с противоположным знаком
            while(true)
            {
                d *= 2; //удваиваем шаг
                x3 = x2 + d; //вычисление новой точки
                fx3 = function(x3);
                //если значение в очередной точке стало больше, то отрезок найден
                if (fx3 > fx2) break;

                //сдвигаем точки
                x1 = x2;
                x2 = x3;
                fx2 = fx3;
            }
            //если шаг был меньше 0, то меняем границы отрезка местами
            if(x1 > x3)
            {
                double temp = x3;
                x3 = x1;
                x1 = temp;
            }
            //возвращаем искомый отрезок
            return new Tuple<double, double>(x1, x3);
        }
        /// <summary>
        /// Находит отрезок, содержащий корень уравнения f(x) = 0 при заданном начальном приближении.
        /// </summary>
        /// <param name="function">Функция f(x).</param>
        /// <param name="x0">Начальное приближение.</param>
        /// <returns>Возвращает отрезок, на котором лежит корень уравнения f(x) = 0.</returns>
        /// <exception cref="System.StackOverflowException">Максимальное колчиество итераций превышено.</exception>
        public static Tuple<double, double> FindZero(Func<double, double> function, double x0)
        {
            int maxIter = 100000;
            double multiplier = Math.Sqrt(2);
            double d = multiplier / 50;
            if (x0 != 0) d *= x0;
            while(maxIter > 0)
            {
                double a = x0 - d;
                double fx0 = function(x0);
                double fxa = function(a);
                if (fx0 * fxa < 0) return new Tuple<double, double>(a, x0);
                double b = x0 + d;
                if (fxa * function(b) < 0) return new Tuple<double, double>(a, b);
                d *= multiplier;
                maxIter--;
            }
            throw new StackOverflowException("Максимальное колчиество итераций превышено.");
        }
    }
}
