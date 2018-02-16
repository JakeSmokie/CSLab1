using System;

namespace CSLabs.Operations
{
    public class Div : IOperation
    {
        public char OperatorChar { get => '/'; }
        public bool Run(MathBuffer mathBuffer)
        {
            bool exception;

            do
            {
                exception = false;
                decimal input = mathBuffer.TempValue;

                try
                {
                    mathBuffer.AccValue /= input;
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                    exception = true;
                }
            } while (exception);

            return false;
        }
    }
}
