using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Одномерная оптимизация.
    /// </summary>
    public interface IOneDimensionalOptimization
    {
        /// <summary>
        /// Получает количество итераций алгоритма.
        /// </summary>
        int FunctionCalls
        {
            get;
            set;
        }
        int IterationCount
        { get;
            set;
        }
        /// <summary>
        /// Получает или задаёт точность.
        /// </summary>
        double Accuracy
        {
            get;
            set;
        }
        /// <summary>
        /// Получает минимальное значение заданной функции в окрестности заданной точки.
        /// </summary>
        /// <param name="function">Функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возвращает минимум заданной функции.</returns>
        double GetMin(Func<double, double> function, double x = 0);
    }
}
