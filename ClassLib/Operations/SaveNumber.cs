namespace CSLabs.Operations
{
    public class SaveNumber : IOperation
    {
        public char OperatorChar => '\0';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];

            mathBuffer.AccValue = mathBuffer.ReadTempValue();
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
