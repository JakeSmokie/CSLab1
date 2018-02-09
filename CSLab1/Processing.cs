using CSLab1.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLab1
{
    class Processing
    {
        private ProcessingFlags operationResult;

        private List<IOperation> operations;
        private IOperation currentOperation;
        private MathBuffer mathBuffer;

        public Processing()
        {
            operationResult = ProcessingFlags.None;
            currentOperation = new SaveInput();

            operations = new List<IOperation>
            {
                new Add(),
                new Sub(),
                new Div(),
                new Mul(),
                new Jump(),
                new Exit()
            };

            mathBuffer = new MathBuffer();
        }

        public void Start()
        {
            Console.WriteLine(
                "Usage:\n" +
                "  when first symbol on line is ‘>’ – enter operand(number)\n" +
                "  when first symbol on line is ‘@’ – enter operation\n" +
                "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "    ‘#’ followed with number of evaluation step\n" +
                "    ‘q’ to exit\n");

            do
            {
                if (!operationResult.HasFlag(ProcessingFlags.SkipNumber))
                {
                    GetNumber();
                }

                operationResult = currentOperation.Run(mathBuffer);

                if (!operationResult.HasFlag(ProcessingFlags.SkipOperation))
                {
                    GetOperation();
                }

            } while (!operationResult.HasFlag(ProcessingFlags.Exit));
        }

        private void GetNumber()
        {
            Console.Write("> ");
            decimal input = 0;

            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                Tools.Interface.CleanPreviousLine(2);
            }

            mathBuffer.TempValue = input;
        }

        private void GetOperation()
        {
            bool correctKey = false;

            Console.Write("@: ");

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                var oper = operations.Find(x => x.OperatorChar == input.KeyChar);

                if (oper != null)
                {
                    Console.WriteLine(input.KeyChar);
                    correctKey = true;

                    currentOperation = oper;
                }
            } while (!correctKey);

            if (currentOperation.OperatorChar.IsOneOf('#', 'q'))
            {
                operationResult |= ProcessingFlags.SkipNumber;
            }
        }
    }
}
