using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1.Operations
{
    class Jump : IOperation
    {
        public char OperatorChar { get => '#'; }
        public bool Run(MathBuffer mathBuffer)
        {
            int input = 0;
            bool success = false;

            while (!success || input <= 0 || input > mathBuffer.Buffer.Count)
            {
                Utils.CleanPreviousLine(4);
                success = int.TryParse(Console.ReadLine(), out input);
            }

            mathBuffer.AccValue = mathBuffer.Buffer[input - 1];
            return false;
        }
    }
}
