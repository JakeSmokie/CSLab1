using ClassLib;

namespace CSLabs.Operations
{
    internal class Div : IOperation
    {
        public char OperatorChar => '/';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
            var outStream = (CalcOut)args[2];

            double input;

            do
            {
                input = mathBuffer.ReadTempValue();
            } while (input == 0);

            mathBuffer.AccValue /= input;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
