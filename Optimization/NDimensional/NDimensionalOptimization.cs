using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.NDimensional
{
    /// <summary>
    /// Представляет метод многомерной оптимизации.
    /// </summary>
    /// <seealso cref="Optimization.NDimensional.INDimensionalOptimization" />
    public abstract class NDimensionalOptimization: INDimensionalOptimization
    {
        #region INDimensionalOptimization Members

        /// <summary>
        /// Получает количество итераций алгоритма.
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public int FunctionCallCount
        {
            get;
            set;
        }
        /// <summary>
        /// Получает или задаёт точность.
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public double Accuracy
        {
            get;
            set;
        }

        /// <summary>
        /// Получает минимум целевой функции с заданным начальным приближением.
        /// </summary>
        /// <param name="function">Функция.</param>
        /// <param name="x">Начальное приближение.</param>
        /// <returns>
        /// Возвращает массив, содержащий координаты точки минимума целевой функции.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public abstract double[] GetMin(NFunction function, double[] x);

        #endregion

        #region INDimensionalOptimization Members


        public int IterationCount
        {
            get;
            set;
        }

        #endregion
    }
}
