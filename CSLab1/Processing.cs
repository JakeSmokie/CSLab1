using CSLab1.Operations;
using System;
using System.Collections.Generic;

namespace CSLab1
{
    static class Processing
    {
        public static bool exitPressed;

        private static List<IOperation> operations;
        private static IOperation currentOperation;

        public static void StartProcessing()
        {
            Console.WriteLine(
                "Usage:\n" +
                "       when first symbol on line is ‘>’ – enter operand(number)\n" +
                "       when first symbol on line is ‘@’ – enter operation\n" +
                "       operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
                "           ‘#’ followed with number of evaluation step\n" +
                "           ‘q’ to exit\n");

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

            GetNumber();

            do
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

                    if (currentOperation.OperatorChar.IsOneOf('q', '#'))
                    {
                        currentOperation.Run();
                        getNextOperationInsteadNumber = true;
                    }

                    if (exitPressed)
                        return;

                } while (getNextOperationInsteadNumber);

                GetNumber();
            } while (!exitPressed);
        }

        private static void GetNumber()
        {
            Console.Write("> ");
            double value = 0;

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Tools.Interface.CleanPreviousLine(2);
            }

            MathBuffer.TempValue = value;

            if (currentOperation == null)
            {
                MathBuffer.AccValue = MathBuffer.TempValue;
                return;
            }

            currentOperation.Run();
        }
    }
}
