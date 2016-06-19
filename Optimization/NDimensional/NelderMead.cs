using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace Optimization.NDimensional
{
    public class NelderMead: NDimensionalOptimization
    {
        protected int h, g, l;
        protected double fh, fg, fl;

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
            double[][] simplex = GetDefaultSimplex(x); //симлекс с (n + 1) вершинами
            while(!TerminationCondition(simplex))
            {
                IterationCount++;
                Sort(simplex, function);
                double[] gc = GetGC(simplex, h);
                double[] r = Reflection(simplex[h], gc); //точка, полученная отражением
                double fr = function(r); FunctionCallCount++;
                if(fr < fl) //направление удачное, пробуем растяжение
                {
                    double[] e = Extension(r, gc); //точка, полученная растяжением (увеличим шаг в два раза)
                    double fe = function(e); FunctionCallCount++;
                    if (fe < fr) simplex[h] = e; //расширяем симплекс до новой точки
                    else if (fr < fe) simplex[h] = r; //растяжение не удалось
                    continue;
                }
                if(fl < fr && fr < fg) //точка r лучше, чем g и h
                {
                    simplex[h] = r;
                    continue;
                }
                if(fg < fr && fr < fh) //точка r лучше h
                {
                    double[] temp = r; r = simplex[h]; simplex[h] = temp;
                    double fTemp = fr; fr = fh; fh = fTemp;
                }
                //новая точка s, полученная сжатием точки h к цетру тяжести
                double[] s = Compression(simplex[h], gc); double fs = function(s); FunctionCallCount++;
                if (fs < fh) simplex[h] = s;
                else if (fs >= fh) Compression(simplex, simplex[l]);
            }
            return simplex[l];
        }

        /// <summary>
        /// Получает центр тяжести заданного симлекса.
        /// </summary>
        /// <param name="simplex">Координаты вершин симплекса.</param>
        /// <param name="exclude">Номера вершин, которые будут исключены из рассчёта.</param>
        /// <returns>Возвращает центр тяжести заданного симплекса.</returns>
        protected double[] GetGC(double[][] simplex, params int[] exclude)
        {
            bool check = exclude != null && exclude.Length > 0;
            double[] result = new double[simplex.Length - 1];
            int count = 0;
            for(int i = 0; i < simplex.Length; i++)
            {
                if(check && exclude.Contains(i)) continue;
                for(int j = 0; j < result.Length; j++)
                {
                    result[j] += simplex[i][j];
                }
                count++;
            }
            for (int i = 0; i < result.Length; i++)
                result[i] /= count;
            return result;
        }
        /// <summary>
        /// Отражает заданную точку относительно другой точки с заданным коэффициентом.
        /// </summary>
        /// <param name="point">Исходная точка.</param>
        /// <param name="gc">Точка, относительно которой отражается исходная.</param>
        /// <param name="alpha">Коэффициент отражения.</param>
        /// <returns>Возвращает результат отражения точки.</returns>
        protected double[] Reflection(double[] point, double[] gc, double alpha = 1)
        {
            double[] result = (double[])point.Clone();
            for (int i = 0; i < result.Length; i++)
                result[i] = (1 + alpha) * gc[i] - alpha * point[i];
            return result;
        }
        /// <summary>
        /// "Растягивает" заданную точку относительно другой точки с заданным коэффициентом.
        /// </summary>
        /// <param name="point">Исходная точка.</param>
        /// <param name="gc">Точка, относительно которой растягивается исходная.</param>
        /// <param name="gamma">Коэффициент растяжения.</param>
        /// <returns>Возвращает результат растяжения точки.</returns>
        protected double[] Extension(double[] point, double[] gc, double gamma = 2)
        {
            double[] result = (double[])point.Clone();
            for (int i = 0; i < result.Length; i++)
                result[i] = (1 - gamma) * gc[i] + gamma * point[i];
            return result;
        }
        /// <summary>
        /// "Сжимает" заданную точку относительно другой точки с заданным коэффициентом.
        /// </summary>
        /// <param name="point">Исходная точка.</param>
        /// <param name="gc">Точка, относительно которой сжимается исходная.</param>
        /// <param name="beta">Коэффициент сжатия.</param>
        /// <returns>Возвращает результат сжатия точки.</returns>
        protected double[] Compression(double[] point, double[] gc, double beta = 0.5)
        {
            double[] result = (double[])point.Clone();
            for (int i = 0; i < result.Length; i++)
                result[i] = (1 - beta) * gc[i] + beta * point[i];
            return result;
        }
        /// <summary>
        /// Сжимает заданный симлекс к заданнй точке.
        /// </summary>
        /// <param name="simplex">Коордианты вершин симплекса.</param>
        /// <param name="gc">Точка, к которой сжимается симплекс.</param>
        protected void Compression(double[][] simplex, double[] gc)
        {
            for(int i = 0; i < simplex.GetLength(0); i++)
            {
                for(int j = 0; j < simplex[i].Length; j++)
                {
                    simplex[i][j] = gc[j] + (simplex[i][j] - gc[j]) / 2;
                }
            }
        }
        /// <summary>
        /// Создаёт симлекс для начала алгоритма, используя начальное приближение.
        /// </summary>
        /// <param name="x">Начальное приближение.</param>
        /// <returns>Возвращает координаты симлекса.</returns>
        protected double[][] GetDefaultSimplex(double[] x)
        {
            double delta1 = (Math.Sqrt(x.Length + 1) + x.Length - 1) / (x.Length * Math.Sqrt(2)) * 2;
            double delta2 = (Math.Sqrt(x.Length + 1) - 1) / (x.Length * Math.Sqrt(2)) * 2;
            double[][] result = new double[x.Length + 1][];
            for(int i = 0; i < x.Length + 1; i++)
            {
                result[i] = new double[x.Length];
                for(int j = 0; j < x.Length; j++)
                {
                    if (i != j) result[i][j] = x[j] + delta1;
                    else result[i][j] = x[j] + delta2;
                }
            }
            return result;
        }
        /// <summary>
        /// Условие завершения алгоритма. В качестве условия завершения выбрана дисперсия точек симплекса.
        /// </summary>
        /// <param name="simplex">Координаты точек симплекса.</param>
        /// <returns>Возвращает true, если выполняется условие завершения.</returns>
        protected bool TerminationCondition(double[][] simplex)
        {
            double d = 0;
            double[] gc = GetGC(simplex);
            for(int i = 0; i < simplex.Length; i++)
            {
                d += Math.Pow(VectorHelper.GetDistance(simplex[i], gc), 2);
            }
            return d <= Accuracy;
        }
        /// <summary>
        /// Выполняет сортировку и поиск значений в соответствии с первым шагом алгоритма.
        /// </summary>
        /// <param name="simplex">Координаты симплекса.</param>
        /// <param name="function">Целевая функция.</param>
        protected void Sort(double[][] simplex, NFunction function)
        {
            h = -1; fh = double.MinValue;
            g = -1; fg = double.MinValue;
            l = -1; fl = double.MaxValue;
            for(int i = 0; i < simplex.Length; i++)
            {
                double f = function(simplex[i]); FunctionCallCount++;
                if(f < fl)
                {
                    l = i; fl = f;
                }
                if(f > fh)
                {
                    g = h; fg = fh;
                    h = i; fh = f;
                    continue;
                }
                if(f > fg)
                {
                    g = i; fg = f;
                }
            }
        }
    }
}
