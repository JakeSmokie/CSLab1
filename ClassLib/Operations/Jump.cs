using System;

namespace CSLabs.Operations
{
    public class Jump : IOperation
    {
        public char OperatorChar { get => '#'; }
        public bool Run(params object[] args)
        {
            var mathBuffer = (MathBuffer)args[0];

            int input = 0;
            bool success = false;

            while (!success || input <= 0 || input > mathBuffer.values.Count)
            {
                Utils.CleanPreviousLine(4);
                success = int.TryParse(Console.ReadLine(), out input);
            }

            mathBuffer.lastTempValue = input;
            mathBuffer.AccValue = mathBuffer.values[input - 1];
            return true;
        }
    }
}
