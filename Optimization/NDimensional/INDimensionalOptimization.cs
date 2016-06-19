using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.NDimensional
{
    /// <summary>
    /// Многомерная оптимизация.
    /// </summary>
    public interface INDimensionalOptimization
    {
        /// <summary>
        /// Получает количество итераций алгоритма.
        /// </summary>
        int FunctionCallCount
        {
            get;
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
        int IterationCount
        {
            get;
            set;
        }
        /// <summary>
        /// Получает минимум целевой функции с заданным начальным приближением.
        /// </summary>
        /// <param name="function">Функция.</param>
        /// <param name="x">Начальное приближение.</param>
        /// <returns>Возвращает массив, содержащий координаты точки минимума целевой функции.</returns>
        double[] GetMin(NFunction function, double[] x);
    }
}
