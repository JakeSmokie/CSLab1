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

        ProcessingFlags Run(MathBuffer mathBuffer);
    }

    class Add : IOperation
    {
        public char OperatorChar { get => '+'; }
        public ProcessingFlags Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue += mathBuffer.TempValue;
            return ProcessingFlags.None;
        }
    }
    class Sub : IOperation
    {
        public char OperatorChar { get => '-'; }
        public ProcessingFlags Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue -= mathBuffer.TempValue;
            return ProcessingFlags.None;
        }
    }
    class Div : IOperation
    {
        public char OperatorChar { get => '/'; }
        public ProcessingFlags Run(MathBuffer mathBuffer)
        {
            if (mathBuffer.TempValue.IsOneOf(0.0, -0.0))
            {
                throw new Exception("Dividing by zero!");
            }

            mathBuffer.AccValue /= mathBuffer.TempValue;
            return ProcessingFlags.None;
        }
    }
    class Mul : IOperation
    {
        public char OperatorChar { get => '*'; }
        public ProcessingFlags Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue *= mathBuffer.TempValue;
            return ProcessingFlags.None;
        }
    }
    class Jump : IOperation
    {
        public char OperatorChar { get => '#'; }
        public ProcessingFlags Run(MathBuffer mathBuffer)
        {
            int input = 0;
            bool success = false;

            while (!success || input <= 0 || input > mathBuffer.Buffer.Count)
            {
                Tools.Interface.CleanPreviousLine(4);
                success = int.TryParse(Console.ReadLine(), out input);
            }

            mathBuffer.AccValue = mathBuffer.Buffer[input - 1];
            return ProcessingFlags.None;
        }
    }

    class Exit : IOperation
    {
        public char OperatorChar { get => 'q'; }
        public ProcessingFlags Run(MathBuffer mathBuffer)
        {
            Console.Beep(880, 1000);
            return  ProcessingFlags.Exit |
                    ProcessingFlags.SkipNumber |
                    ProcessingFlags.SkipOperation;
        }
    }

    class SaveInput : IOperation
    {
        public char OperatorChar { get => '0'; }
        public ProcessingFlags Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue = mathBuffer.TempValue;
            return ProcessingFlags.None;
        }
    }
}
