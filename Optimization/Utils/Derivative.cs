using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Utils
{
    /// <summary>
    /// Класс для получения производной.
    /// </summary>
    public class Derivative
    {
        protected Func<double, double> function;
        protected double step;

        /// <summary>
        /// Получает или задаёт шаг..
        /// </summary>
        /// <value>Шаг.</value>
        public double Step 
        {
            get { return step; }
            set { step = value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Derivative"/>.
        /// </summary>
        /// <param name="function">Функция</param>
        public Derivative(Func<double, double> function)
        {
            this.function = function;
            step = 1E-3;
        }
        /// <summary>
        /// Получает значение первой производной.
        /// </summary>
        /// <param name="x">Точка.</param>
        /// <returns>Возвращает значение первой производной в заданной точке.</returns>
        public double GetFirstDerivative(double x)
        {
            return (function(x + step) - function(x - step)) / (2 * step);
        }
        /// <summary>
        /// Получает значение второй производной.
        /// </summary>
        /// <param name="x">Точка.</param>
        /// <returns>Возвращает значение второй производной в заданной точке.</returns>
        public double GetSecondDerivative(double x)
        {
            return (function(x + step) - 2 * function(x) + function(x - step)) / (step * step);
        }
    }
}
