using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1.Operations
{
    interface IOperation
    {
        char OperatorChar { get; }

        bool Run(MathBuffer mathBuffer);
    }
}
