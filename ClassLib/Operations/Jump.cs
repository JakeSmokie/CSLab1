using ClassLib;
using System;

namespace CSLabs.Operations
{
    public class Jump : IOperation
    {
        public char OperatorChar => '#';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
            var inStream = (CalcIn)args[1];

            Console.CursorTop -= 1;
            int input = inStream.ReadInt(x => (x > 0 && x <= mathBuffer.values.Count));

            mathBuffer.TempValue = input;
            mathBuffer.AccValue = mathBuffer.values[input - 1];
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
