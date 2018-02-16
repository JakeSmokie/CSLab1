using System;

namespace CSLabs.Operations
{
    class Load : IOperation
    {
        public char OperatorChar { get => 'l'; }
        public bool Run(MathBuffer mathBuffer)
        {
            return true;
        }
    }
}
