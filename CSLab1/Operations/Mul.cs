namespace CSLab1.Operations
{
    class Mul : IOperation
    {
        public char OperatorChar { get => '*'; }
        public bool Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue *= mathBuffer.TempValue;
            return false;
        }
    }
}
