using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationView
{
    /// <summary>
    /// Показывает, сколько элементов хранит перечисление.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Enum, Inherited = false)]
    public class EnumCountAttribute: Attribute
    {
        public int Count { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="EnumCountAttribute"/>.
        /// </summary>
        /// <param name="count">Количество элементов перечисления.</param>
        public EnumCountAttribute(int count)
        {
            this.Count = count;
        }
    }
}
