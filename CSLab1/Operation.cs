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

        void Run();
    }

    class Add : IOperation
    {
        public char OperatorChar { get => '+'; }
        public void Run()
        {
            MathBuffer.AccValue += MathBuffer.TempValue;
        }
    }
    class Sub : IOperation
    {
        public char OperatorChar { get => '-'; }
        public void Run()
        {
            MathBuffer.AccValue -= MathBuffer.TempValue;
        }
    }
    class Div : IOperation
    {
        public char OperatorChar { get => '/'; }
        public void Run()
        {
            MathBuffer.AccValue /= MathBuffer.TempValue;
        }
    }
    class Mul : IOperation
    {
        public char OperatorChar { get => '*'; }
        public void Run()
        {
            MathBuffer.AccValue *= MathBuffer.TempValue;
        }
    }
    class Jump : IOperation
    {
        public char OperatorChar { get => '#'; }
        public void Run()
        {
            int value = 0;
            bool success = false;

            while (!success || value <= 0 || value > MathBuffer.buffer.Count)
            {
                Tools.Interface.CleanPreviousLine(4);
                success = int.TryParse(Console.ReadLine(), out value);
            }

            MathBuffer.AccValue = MathBuffer.buffer[value - 1];
        }
    }
    class Exit : IOperation
    {
        public char OperatorChar { get => 'q'; }
        public void Run()
        {
            Console.Beep(880, 1000);
            Processing.exitPressed = true;
        }
    }
}
