using System;

namespace CSLabs.Operations
{
    public class Div : IOperation
    {
        public char OperatorChar { get => '/'; }
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
            double input = mathBuffer.ReadTempValue();

            if (input == 0)
            {
                Console.WriteLine(new DivideByZeroException().Message);
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
