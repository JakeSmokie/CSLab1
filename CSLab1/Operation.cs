using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1.Operations
{
    public delegate void Del();

    interface IOperation
    {
        char OperatorChar { get; }

        bool Run(MathBuffer mathBuffer);
    }

    class Add : IOperation
    {
        public char OperatorChar => '+';
        public bool Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue += mathBuffer.TempValue;
            return false;
        }
    }
    class Sub : IOperation
    {
        public char OperatorChar => '-';
        public bool Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue -= mathBuffer.TempValue;
            return false;
        }
    }
    class Div : IOperation
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
    class Mul : IOperation
    {
        public char OperatorChar { get => '*'; }
        public bool Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue *= mathBuffer.TempValue;
            return false;
        }
    }
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

    class Exit : IOperation
    {
        public char OperatorChar { get => 'q'; }
        public bool Run(MathBuffer mathBuffer)
        {
            Console.Beep(880, 1000);
            return  true;
        }
    }

    class SaveInput : IOperation
    {
        public char OperatorChar => '0';
        public bool Run(MathBuffer mathBuffer)
        {
            mathBuffer.AccValue = mathBuffer.TempValue;
            return false;
        }
    }
}
