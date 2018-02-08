using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1.Operations
{
    interface IOperation
    {
        char OperatorChar { get; }

        void Run(MathBuffer mathBuffer);
    }

    class Add : IOperation
    {
        public char OperatorChar { get => '+'; }
        public void Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue += mathBuffer.TempValue;
        }
    }
    class Sub : IOperation
    {
        public char OperatorChar { get => '-'; }
        public void Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue -= mathBuffer.TempValue;
        }
    }
    class Div : IOperation
    {
        public char OperatorChar { get => '/'; }
        public void Run(MathBuffer mathBuffer)
        {
            if (mathBuffer.TempValue.IsOneOf(0.0, -0.0))
            {
                throw new Exception("Dividing by zero!");
            }

            mathBuffer.AccValue /= mathBuffer.TempValue;
        }
    }
    class Mul : IOperation
    {
        public char OperatorChar { get => '*'; }
        public void Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue *= mathBuffer.TempValue;
        }
    }
    class Jump : IOperation
    {
        public char OperatorChar { get => '#'; }
        public void Run(MathBuffer mathBuffer)
        {
            int value = 0;
            bool success = false;

            while (!success || value <= 0 || value > mathBuffer.Buffer.Count)
            {
                Tools.Interface.CleanPreviousLine(4);
                success = int.TryParse(Console.ReadLine(), out value);
            }

            mathBuffer.AccValue = mathBuffer.Buffer[value - 1];
        }
    }
    /*class Exit : IOperation
    {
        public char OperatorChar { get => 'q'; }
        public void Run(MathBuffer mathBuffer)
        {
            Console.Beep(880, 1000);
            Processing.exitPressed = true;
        }
    }*/
}
