using System;

namespace CSLab1.Operations
{
    class Save : IOperation
    {
        public char OperatorChar { get => 's'; }
        public bool Run(MathBuffer mathBuffer)
        {
            return false;
        }
    }
}
