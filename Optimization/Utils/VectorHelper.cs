using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Utils
{
    /// <summary>
    /// Предоставляет методы для работы с векторами.
    /// </summary>
    public static class VectorHelper
    {
        /// <summary>
        /// Получает евклидово расстояние между двумя вещественными векторами.
        /// </summary>
        /// <param name="from">Первый вектор.</param>
        /// <param name="to">Второй вектор.</param>
        /// <returns>Возвращает евклидово расстояние между двумя вещественными векторами.</returns>
        public static double GetDistance(double[] from, double[] to)
        {
            double result = 0;
            for(int i = 0; i < from.Length; i++)
            {
                result += Math.Pow(to[i] - from[i], 2);
            }
            result = Math.Sqrt(result);
            return result;
        }
    }
}
