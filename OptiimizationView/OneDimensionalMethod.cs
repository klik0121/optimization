using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationView
{
    /// <summary>
    /// Задаёт возможные методы одномерной оптимизации.
    /// </summary>
    [Flags]
    public enum OneDimensionalMethod
    {
        /// <summary>
        /// Представляет метод половинного деления для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        BisectionMethod,
        /// <summary>
        /// Представляет метод золотого сечения для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        GoldenSectionMethod,
        /// <summary>
        /// Представляет метод чисел Фибоначчи для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        FibonacciNumbersMethod
    }
}
