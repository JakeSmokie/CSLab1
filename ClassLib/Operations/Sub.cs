namespace CSLabs.Operations
{
    public class Sub : IOperation
    {
        public char OperatorChar => '-';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];

            mathBuffer.AccValue -= mathBuffer.TempValue;
            return true;
        }
    }
}
