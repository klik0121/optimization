using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationView
{
    [Flags]
    [EnumCount(3)]
    public enum OneDimensionalMethodType
    {
        /// <summary>
        /// Методы сокращения отрезков унимодальности.
        /// </summary>
        SegmentShrinking,
        /// <summary>
        /// Методы с использованием производных.
        /// </summary>
        DerivativeUsage,
        /// <summary>
        /// Методы с использованием аппроксимации.
        /// </summary>
        Approximation
    }
}
