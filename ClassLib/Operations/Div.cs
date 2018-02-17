using System;

namespace CSLabs.Operations
{
    public class Div : IOperation
    {
        public char OperatorChar { get => '/'; }
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
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

            return true;
        }
    }
}
