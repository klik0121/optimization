using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.OneDimensional
{
    /// <summary>
    /// Представляет метод касательных для поиска минимума однопараметрической унимодальной функции.
    /// </summary>
    /// <seealso cref="Optimization.OneDimensional.OneDimensionalOptimization" />
    public class TangentsMethod: OneDimensionalOptimization
    {
        /// <summary>
        /// Находит минимальное значение параметра унимодальной однопараметрической функции.
        /// </summary>
        /// <param name="function">Унимодальная однопараметрическая функция.</param>
        /// <param name="x">Начальная точка.</param>
        /// <returns>Возврщает минимальное значение параметра унимодальной однопараметрческой
        /// функции.</returns>
        public override double GetMin(Func<double, double> function, double x = 0)
        {
            Derivative der = new Derivative(function);
            double derX = der.GetFirstDerivative(x);
            while(Math.Abs(derX) >= Accuracy)
            {
                x = x - derX / der.GetSecondDerivative(x);
                derX = der.GetFirstDerivative(x);
            }
            return x;
        }
    }
}
