using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.OneDimensional
{
    public interface IOneDimensionalOptimization
    {
        int IterationCount
        {
            get;
            set;
        }
        double Accuracy
        {
            get;
            set;
        }
        double GetMin(Func<double, double> function, double x = 0);
    }
}
