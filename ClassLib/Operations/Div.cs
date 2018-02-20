using ClassLib;

namespace CSLabs.Operations
{
    public class Div : IOperation
    {
        public char OperatorChar => '/';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
            var outStream = (CalcOut)args[2];

            double input = mathBuffer.ReadTempValue();

            if (input == 0)
            {
                outStream.SendDivideException();
            }
            else
            {
                mathBuffer.AccValue /= input;
                mathBuffer.SaveAccValue();
            }

            return true;
        }
    }
}
