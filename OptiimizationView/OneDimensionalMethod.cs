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
    [EnumCount(9)]
    public enum OneDimensionalMethod
    {
        /// <summary>
        /// Представляет метод половинного деления для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        BisectionMethod = 1,
        /// <summary>
        /// Представляет метод золотого сечения для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        GoldenSectionMethod = 2,
        /// <summary>
        /// Представляет метод чисел Фибоначчи для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        FibonacciNumbersMethod = 4,
        /// <summary>
        /// Представляет метод хорд для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        ChordMethod = 8,
        /// <summary>
        /// Представляет метод касательных для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        TangentsMethod = 16,
        /// <summary>
        /// Представляет метод средней точки для поиска минимума параметра 
        /// однопараметрической унимодальной функции.
        /// </summary>
        MidPointMethod = 32,
        QuadraticApproximation = 64,
        CubicApproximation = 128,
        QuadraticFunction = 256,
    }
}
