using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Utils
{
    /// <summary>
    /// Предоставляет методы для вычисления функций одной переменной (обязательно x),
    /// заданных строкой.
    /// Допустимые функции: +, -, *, /, ^, (, ), sin, cos, tn, ctg.
    /// Допустимые имена переменных: x.
    /// Пример функции: (100 - x) ^ 2 + 15 / x.
    /// </summary>
    public class PostFix
    {
        Stack<string> stack = new Stack<string>();
        //Список возможных операций
        private List<string> operators = new List<string> { "+", "-", "*", "/", "^", "(", ")",
            "sin", "cos", "tn", "ctg"};
        private Queue<string> queue;

        /// <summary>
        /// Перевод из инфиксной нотации в постфиксную.
        /// </summary>
        /// <param name="input">Входная строка в инфиксной нотации.</param>
        /// <returns>Возвращает очередь из констант и знаков операции в 
        /// постфиксной нотации.</returns>
        private Queue<string> PostFixNotation(string input)
        {
            input.Replace(" ", string.Empty);
            Queue<string> outputSeparated = new Queue<string>();
            Stack<string> stack = new Stack<string>();
            foreach (string c in Separate(input))
            {
                if (operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Enqueue(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) >= GetPriority(stack.Peek())) stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c)
                                < GetPriority(stack.Peek()))
                                outputSeparated.Enqueue(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else stack.Push(c);
                }
                else outputSeparated.Enqueue(c);
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Enqueue(c);
            return outputSeparated;
        }
        /// <summary>
        /// Разделение строки на константы и знаки операций.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>Возвращает список из констант и знаков операций.</returns>
        private IEnumerable<string> Separate(string input)
        {
            int i = 0;
            while (i < input.Length)
            {
                string s = input[i].ToString();
                i++;
                if (char.IsDigit(s[0]) == true)
                {
                    while (i < input.Length && (char.IsDigit(input[i]) || input[i] == ','))
                    {
                        s += input[i];
                        i++;
                    }
                }
                if (char.IsLetter(s[0]) == true)
                {
                    while (i < input.Length && char.IsLetter(input[i]))
                    {
                        s += input[i];
                        i++;
                    }
                }
                yield return s;
            }
        }
        /// <summary>
        /// Определяет приоритет операции.
        /// </summary>
        /// <param name="op">Знак операции.</param>
        /// <returns>Возвращает значение приоритета.</returns>
        private byte GetPriority(string op)
        {
            switch (op)
            {
                case "(":
                    return 0;
                case ")":
                    return 1;
                case "+":
                    return 2;
                case "-":
                    return 3;
                case "*":
                    return 4;
                case "/":
                    return 5;
                case "^":
                    return 6;
                case "sin":
                    return 7;
                case "cos":
                    return 8;
                case "tn":
                    return 9;
                case "ctg":
                    return 10;
                default:
                    return 11;
            }
        }
        /// <summary>
        /// Вычисление выражения, зависящего от одной переменной.
        /// </summary>
        /// <param name="input">Строка в инфиксной нотации</param>
        /// <param name="x">Значение x.</param>
        /// <returns>Возвращает целочисленный результат вычисления</returns>
        public double Result(string input, double x)
        {
            Queue<string> queue = PostFixNotation(input);          
            while (queue.Count > 0)
            {
                string s = queue.Dequeue();
                if (!operators.Contains(s))
                {
                    if (s == "x")
                    {
                        stack.Push(x.ToString());
                    }
                    else
                    {
                        stack.Push(s);
                    }
                }
                else
                {
                    double summ = Calculate(s);
                    stack.Push(summ.ToString());
                }
            }
            return Convert.ToDouble(stack.Pop());
        }
        /// <summary>
        /// Переводит выражение в инфиксной нотации в постфиксную и сохраняет результат.
        /// </summary>
        /// <param name="input">Выражение в инфиксной нотации.</param>
        public void CachePostFix(string input)
        {
            queue = PostFixNotation(input);
        }
        /// <summary>
        /// Вычисляет кешированное выражение.
        /// </summary>
        /// <param name="x">Значение параметра.</param>
        /// <returns>Возвращает результат вычисления кешированного выражения.</returns>
        public double CalculateCached(double x)
        {
            Queue<string> queueCopy = new Queue<string>();
            while (queue.Count > 0)
            {
                string s = queue.Dequeue();
                queueCopy.Enqueue(s);
                if (!operators.Contains(s))
                {
                    if (s == "x")
                    {
                        stack.Push(x.ToString());
                    }
                    else
                    {
                        stack.Push(s);
                    }
                }
                else
                {
                    double summ = Calculate(s);
                    stack.Push(summ.ToString());
                }
            }
            queue = queueCopy;
            return Convert.ToDouble(stack.Pop());
        }
        /// <summary>
        /// Вычисляет значение операции.
        /// </summary>
        /// <param name="operation">Операция.</param>
        /// <returns>Возвращает значение операции.</returns>
        private double Calculate(string operation)
        {
            double summ = 0;
            switch (operation)
            {
                case "+":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        double b = Convert.ToDouble(stack.Pop());
                        summ = a + b;
                        break;
                    }
                case "-":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        double b = Convert.ToDouble(stack.Pop());
                        summ = b - a;
                        break;
                    }
                case "*":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        double b = Convert.ToDouble(stack.Pop());
                        summ = a * b;
                        break;
                    }
                case "/":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        double b = Convert.ToDouble(stack.Pop());
                        summ = b / a;
                        break;
                    }
                case "^":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        double b = Convert.ToDouble(stack.Pop());
                        summ = Math.Pow(b, a);
                        break;
                    }
                case "sin":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        summ = Math.Sin(a);
                        break;
                    }
                case "cos":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        summ = Math.Cos(a);
                        break;
                    }
                case "tn":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        summ = Math.Tan(a);
                        break;
                    }
                case "ctg":
                    {
                        double a = Convert.ToDouble(stack.Pop());
                        summ = 1 / Math.Tan(a);
                        break;
                    }
            }
            return summ;
        }
    }
}