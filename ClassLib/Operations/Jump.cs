using ClassLib;
using System;

namespace CSLabs.Operations
{
    internal class Jump : IOperation
    {
        public char OperatorChar => '#';
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];
            var inOutStream = (ICalcIO)args[1];

            Console.CursorTop -= 1;
            int input = inOutStream.ReadInt(x => (x > 0 && x <= mathBuffer.values.Count));

            mathBuffer.TempValue = input;
            mathBuffer.AccValue = mathBuffer.values[input - 1];
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
