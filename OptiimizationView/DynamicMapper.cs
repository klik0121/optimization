using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimization.Utils;

namespace OptimizationView
{
    public class DynamicMapper: nzy3D.Plot3D.Builder.Mapper
    {
        protected PostFix pf;

        public DynamicMapper(string function)
        {
            pf = new PostFix();
            pf.CachePostFix(function);
        }
        public override double f(double x, double y)
        {
            if (pf.CachedDimCount != 2)
                throw new Exception("Количество переменных не должно превышать 2.");
            return pf.CalculateCached(new double[] { x, y });
        }
    }
}
