using System;

namespace CSLab1.Operations
{
    class Load : IOperation
    {
        public char OperatorChar { get => 'l'; }
        public bool Run(MathBuffer mathBuffer)
        {
            return false;
        }
    }
}
