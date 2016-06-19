using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.NDimensional
{
    /// <summary>
    /// Представляет метод Хука-Дживса.
    /// </summary>
    /// <seealso cref="Optimization.NDimensional.NDimensionalOptimization" />
    public class HookJeeves: NDimensionalOptimization
    {
        /// <summary>
        /// Получает минимум целевой функции с заданным начальным приближением.
        /// </summary>
        /// <param name="function">Функция.</param>
        /// <param name="x">Начальное приближение.</param>
        /// <returns>
        /// Возвращает массив, содержащий координаты точки минимума целевой функции.
        /// </returns>
        public override double[] GetMin(NFunction function, double[] x)
        {
            FunctionCallCount = 0;
            IterationCount = 0;
            double step = GetStep(x); //шаг
            double mul = 1 / (double)10; //множитель шага
            double[] pBase = (double[])x.Clone(); //базовая точка
            while(step >= Accuracy)
            {
                IterationCount++;
                double[] pNew;
                while(!Research(function, pBase, step, out pNew) && step >= Accuracy)
                {
                    step *= mul;
                }
                if (step < Accuracy) continue;
                double[] pNext = new double[x.Length];
                //делаем шаг в найденном направлении
                for(int i = 0; i < x.Length; i++)
                {
                    pNext[i] = pBase[i] + 2 * (pNew[i] - pBase[i]);
                }
                FunctionCallCount += 2;
                //сравниваем значения в двух новых точках и выбираем лучшую в качестве новой базовой
                if (function(pNew) < function(pNext))
                {                    
                    pBase = pNew;
                }
                else pBase = pNext;
            } 
            return pBase;
        }
        /// <summary>
        /// Исследующий поиск. Определяет в каком направлении убывает функция, используя базовую точку и
        /// шаг. 
        /// </summary>
        /// <param name="function">Целевая функция.</param>
        /// <param name="pBase">Базовая точка.</param>
        /// <param name="step">Шаг.</param>
        /// <param name="pNew">Новая точка, задающая направление убывания функции.</param>
        /// <returns>Возвращает true, если удалось найти направление убывания функции.</returns>
        public bool Research(NFunction function, double[] pBase, double step, out double[] pNew)
        {
            pNew = (double[])pBase.Clone();
            bool success = false;
            for(int i = 0; i < pBase.Length; i++)
            {
                double f = function(pNew);
                pNew[i] += step; //делаем шаг право вдоль оси x[i]
                double rStepValue = function(pNew);
                pNew[i] -= 2 * step; //делаем шаг влево вдоль оси x[i]
                double lStepValue = function(pNew);
                FunctionCallCount += 3;
                //находим лучшее значение из трёх точек
                if (lStepValue < rStepValue && lStepValue < f) success = true;
                else if (rStepValue < lStepValue && rStepValue < f)
                {
                    success = true;
                    pNew[i] += 2 * step;
                }
                else
                {
                    pNew[i] += step;
                }
            }
            //если не изменилась ни одна координата, нужно уменьшить шаг
            return success;
        }
        /// <summary>
        /// Определяет начальное значение шага.
        /// </summary>
        /// <param name="x">Начальное приближение.</param>
        /// <returns>Возвращает начальное значение шага.</returns>
        protected double GetStep(double[] x)
        {
            double step = double.MinValue;
            foreach (double xi in x)
                step = Math.Max(step, Math.Abs(xi));
            if (step == 0) step++;
            return step / 2;
        }
    }
}
