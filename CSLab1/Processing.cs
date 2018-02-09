using CSLab1.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLab1
{
    class Processing
    { 
        private bool exitPressed;

        private List<IOperation> operations;
        private IOperation currentOperation;
        private MathBuffer mathBuffer;

        public Processing()
        {
            exitPressed = false;
            currentOperation = null;

            operations = new List<IOperation>
            {
                new Add(),
                new Sub(),
                new Div(),
                new Mul(),
                new Jump()
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
                GetNumber();

                if (currentOperation == null)
                {
                    mathBuffer.AccValue = mathBuffer.TempValue;
                }
                else
                {
                    currentOperation.Run(mathBuffer);
                }

                GetOperation();
            } while (!exitPressed);
        }

        private void GetNumber()
        {
            Console.Write("> ");
            double input = 0;

            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Tools.Interface.CleanPreviousLine(2);
            }

            mathBuffer.TempValue = input;
        }

        private void GetOperation()
        {
            bool getNextOperationInsteadNumber;
            bool correctKey;

            do
            {
                getNextOperationInsteadNumber = false;
                correctKey = false;

                Console.Write("@: ");

                do
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    if (input.Key == ConsoleKey.Q)
                    {
                        exitPressed = true;
                        return;
                    }

                    var oper = operations.Find(x => x.OperatorChar == input.KeyChar);

                    if (oper != null)
                    {
                        Console.WriteLine(input.KeyChar);
                        correctKey = true;

                        currentOperation = oper;
                    }
                } while (!correctKey);

                if (currentOperation.OperatorChar.IsOneOf('#'))
                {
                    currentOperation.Run(mathBuffer);
                    getNextOperationInsteadNumber = true;
                }

            } while (getNextOperationInsteadNumber);
        }
    }
}
