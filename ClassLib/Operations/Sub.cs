namespace CSLabs.Operations
{
    public class Sub : IOperation
    {
        public char OperatorChar => '-';
        public bool Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue -= mathBuffer.TempValue;
            return false;
        }
    }
}
