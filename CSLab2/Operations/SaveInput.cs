﻿namespace CSLab1.Operations
{
    class SaveInput : IOperation
    {
        public char OperatorChar => '\0';
        public bool Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue = mathBuffer.TempValue;
            return false;
        }
    }
}