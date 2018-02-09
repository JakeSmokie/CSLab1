using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1
{
    [Flags]
    enum ProcessingFlags : int
    {
        None = 0,
        Exit = 1 << 1,
        SkipOperation = 1 << 2,
        SkipNumber = 1 << 3
    }
}
