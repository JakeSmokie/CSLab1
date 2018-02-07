using CSLab1.Operations;
using System;
using System.Collections.Generic;

namespace CSLab1
{
    static class Processing
    {
        public static void Initialize()
        {
            exitPressed = false;
            currentOperation = null;

            operations = new List<IOperation>
            {
                new Add(),
                new Sub(),
                new Div(),
                new Mul(),
                new Jump(),
                new Exit()
            };
        }

        public static void StartProcessing()
        {
            Console.WriteLine("Usage:\n" +
                "when first symbol on line is ‘>’ – enter operand(number)\n" +
                "when first symbol on line is ‘@’ – enter operation\n" +
                "operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "‘#’ followed with number of evaluation step\n" +
                "‘q’ to exit\n");

            Initialize();
            GetNumber();

            while (!exitPressed)
            {
                GetOperation();
                GetNumber();
            }
        }

        static void GetNumber()
        {
            Console.Write("> ");

            double value = 0;

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                //Console.Write("Try again!\n" + "> ");
                Console.CursorTop -= 1;

                Console.CursorLeft = 0;
                Console.Write("                                                                                                  ");

                Console.CursorLeft = 0;
                Console.Write("> ");
            }

            MathBuffer.TempValue = value;
            DoOperation();
        }

        static void DoOperation()
        {
            if (currentOperation == null)
            {
                MathBuffer.AccValue = MathBuffer.TempValue;
                return;
            }

            currentOperation.Run();
        }

        static void GetOperation()
        {
            bool getNextOperationInsteadNumber;

            do
            {
                getNextOperationInsteadNumber = false;
                bool correctKey = false;

                Console.Write("@: ");

                while (!correctKey)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    foreach (IOperation oper in operations)
                    {
                        if (oper.OperatorChar == input.KeyChar)
                        {
                            Console.WriteLine(input.KeyChar);
                            correctKey = true;

                            currentOperation = oper;
                            break;
                        }
                    }
                }

                if (currentOperation.OperatorChar == 'q' || currentOperation.OperatorChar == '#')
                {
                    currentOperation.Run();
                    getNextOperationInsteadNumber = true;
                }
            } while (getNextOperationInsteadNumber);
        }

        static List<IOperation> operations;
        static bool exitPressed;
        static IOperation currentOperation;
    }
}
