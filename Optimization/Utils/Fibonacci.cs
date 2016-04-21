using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Utils
{
    /// <summary>
    /// Предоставляет метод для вычисления чисел Фибоначчи.
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Вычисляет число Фибоначчи с заданным номером.
        /// </summary>
        /// <param name="n">Номер числа фибоначчи.</param>
        /// <returns>Возвращает число Фибоначчи с заданным номером.</returns>
        public static int GetFibonacciNumber(int n)
        {
            if (n < 0) return 0;
            if (n == 1 || n == 0) return 1;
            int x = 1;
            int y = 1;
            int result = 0;
            for(int i = 2; i <= n; i++)
            {
                result = x + y;
                y = result;
                x = y;
            }
            return result;
        }
    }
}
