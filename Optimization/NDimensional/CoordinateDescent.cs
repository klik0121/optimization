using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;
using Optimization.OneDimensional;

namespace Optimization.NDimensional
{
    /// <summary>
    /// Представляет метод покоординатного спуска.
    /// </summary>
    /// <seealso cref="Optimization.NDimensional.NDimensionalOptimization" />
    public class CoordinateDescent: NDimensionalOptimization
    {
        protected IOneDimensionalOptimization[] oneDimensional;
        protected Func<double, int, double>[] functions;

        /// <summary>
        /// Получает минимум целевой функции с заданным начальным приближением.
        /// </summary>
        /// <param name="function">Функция.</param>
        /// <param name="x">Начальное приближение.</param>
        /// <returns>
        /// Возвращает массив, содержащий координаты точки минимума целевой функции.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override double[] GetMin(NFunction function, double[] x)
        {
            this.FunctionCallCount = 0;
            IterationCount = 0;
            double[] result = (double[])x.Clone();
            oneDimensional = new IOneDimensionalOptimization[x.Length];
            functions = new Func<double, int, double>[x.Length];
            for(int i = 0 ; i < x.Length; i++)
            {
                oneDimensional[i] = new GoldenSectionMethod();
                oneDimensional[i].Accuracy = Accuracy;
                functions[i] = (y, j) => { result[j] = y; return function(result); };
            }
            double prevF = double.MaxValue;
            double f = double.MinValue;
            double[] prev = new double[x.Length];
            while (Math.Abs(f - prevF) > Accuracy)
            {               
                prevF = f;
                prev = (double[])result.Clone();
                for (int i = 0; i < x.Length; i++)
                {
                    IterationCount++;
                    result[i] = oneDimensional[i].GetMin((y) => { return functions[i](y, i); }, result[i]);
                    this.FunctionCallCount += oneDimensional[i].FunctionCalls;
                    this.IterationCount += oneDimensional[i].IterationCount;
                    f = function(result);
                    if(Math.Abs(f - prevF) > Accuracy) break;
                }                
            } 
            return result;
        }
    }
}
