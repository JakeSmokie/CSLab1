namespace CSLabs.Operations
{
    internal class Sub : IOperation
    {
        public char OperatorChar => '-';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];

            mathBuffer.AccValue -= mathBuffer.ReadTempValue();
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
