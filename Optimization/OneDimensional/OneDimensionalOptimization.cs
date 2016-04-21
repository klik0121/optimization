using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод поиска минимума параметра однопараметрической унимодальной функции
    /// и методы работы с ним.
    /// </summary>
    public abstract class OneDimensionalOptimization: IOneDimensionalOptimization
    {
        protected double eps; //точность
        protected int itCount; //количество итераций

        #region IOneDimensionalOptimization Members

        /// <summary>
        /// Получает или задаёт количество итераций.
        /// </summary>
        public int IterationCount
        {
            get
            {
                return itCount;
            }
            set
            {
                itCount = value;
            }
        }
        /// <summary>
        /// Получает или задаёт точность.
        /// </summary>
        public double Accuracy
        {
            get
            {
                return eps;
            }
            set
            {
                eps = value;
            }
        }
        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической функции.
        /// </summary>
        /// <param name="function">Унимодальная однопараметрическая функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возврщает минимальное значение параметра унимодальной однопараметрческой
        /// функции.</returns>
        public abstract double GetMin(Func<double, double> function, double x = 0);

        #endregion
    }
}
