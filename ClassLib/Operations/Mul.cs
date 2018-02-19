namespace CSLabs.Operations
{
    public class Mul : IOperation
    {
        public char OperatorChar { get => '*'; }
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];

            mathBuffer.AccValue *= mathBuffer.ReadTempValue();
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
