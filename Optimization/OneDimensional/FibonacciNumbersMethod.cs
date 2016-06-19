using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод чисел Фибоначчи для поиска минимума параметра однопараметрической 
    /// унимодальной функции и методы работы с ним.
    /// </summary>
    public class FibonacciNumbersMethod: OneDimensionalOptimization
    {
        //массив чисел Фибоначчи
        long[] fibonacci;

        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической функции.
        /// Используется метод чисел Фибоначчи.
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
            CalculateFibonacciNumbers(b - a, Accuracy);
            int n = FunctionCalls + 2;
            FunctionCalls = 2;
            //новые точки внутри отрезка [a; b]
            double x1 = a + fibonacci[n - 2] * (b - a) / fibonacci[n];
            double x2 = a + fibonacci[n - 1] * (b - a) / fibonacci[n];
            double fx1 = function(x1), fx2 = function(x2);
            int k = 1;
            while (k != n - 2)
            {
                IterationCount++;
                FunctionCalls++;
                if (fx1 > fx2) //x* не принадлежит отрезку [a; x1]
                {
                    a = x1;
                    x1 = x2;
                    //новая точка с коэффициентом сжатия fibonacci[n - k - 1] / fibonacci[n - k]
                    //внутри отрезка (x1; b)
                    x2 = a + fibonacci[n - k - 1] * (b - a) / fibonacci[n - k];
                    fx1 = fx2;
                    fx2 = function(x2);
                }
                else //x* не принадлежит отрезку (x2; b]
                {
                    b = x2;
                    x2 = x1;
                    //новая точка с коэффициентом сжатия fibonacci[n - k - 1] / fibonacci[n - k]
                    //внутри отрезка (a; x1)
                    x1 = a + fibonacci[n - k - 2] * (b - a) / fibonacci[n - k];
                    fx2 = fx1;
                    fx1 = function(x1);
                }
                k++;
            }
            FunctionCalls += 2;
            //x1 и x2 задают середину отрезка (x1 = x2 = (a + b) / 2). 
            //сдивгаем одну из точек на значение eps / 10 (константа неразличимости)
            x2 = x1 + Accuracy / 10;
            fx1 = function(x1);
            fx2 = function(x2);
            if (fx1 == fx2) a = x1;
            else if (fx1 < fx2) b = x2;
            return (a + b) / 2;
        }
        /// <summary>
        /// Функция подготавливает нужное количество чисел Фибоначчи для заданной длины начального
        /// начального и конечного интервалов.
        /// </summary>
        /// <param name="length">Длина начального интервала.</param>
        /// <param name="expLength">Минимальная длина отрезка. Характеризует
        /// точность вычислений.</param>
        protected void CalculateFibonacciNumbers(double length, double expLength)
        {
            List<long> fib = new List<long>();
            fib.Add(1);
            fib.Add(1);
            int n = 1;
            double k = length / expLength;
            while(fib[n] < k)
            {
                n++;
                fib.Add(fib[n - 1] + fib[n - 2]);                
            }
            FunctionCalls = n - 2;
            fibonacci = fib.ToArray();
        }
    }
}
