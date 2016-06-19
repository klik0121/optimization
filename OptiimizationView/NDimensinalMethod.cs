using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationView
{
    [Flags]
    public enum NDimensinalMethod
    {       
        CoordinateDescent = 1,
        HookJeeves = 2,
        NelderMead = 4
    }
}
