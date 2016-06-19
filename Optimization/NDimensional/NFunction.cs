using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.NDimensional
{
    /// <summary>
    /// N-мерная функция.
    /// </summary>
    /// <param name="args">Массив значений переменных фукнции.</param>
    /// <returns>Возвращает рузльтат функции от заданных аргументов.</returns>
    public delegate double NFunction(double[] args);
}
