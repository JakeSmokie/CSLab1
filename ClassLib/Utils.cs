using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace CSLabs
{
    public delegate bool BoolAction();

    public static class ConsoleUtils
    {
        public static void CleanPreviousLine(int offset)
        {
            Console.CursorTop -= 1;
            Console.MoveBufferArea(offset, Console.CursorTop, Console.BufferWidth - offset, 1, Console.BufferWidth, Console.CursorTop, ' ', Console.ForegroundColor, Console.BackgroundColor);
            Console.CursorLeft = offset;
        }

        public static double ReadDouble(string msg = "> ", Predicate<double> valueCorrectnessPredicate = null)
        {
            double temp;
            Console.WriteLine(msg);

            do
            {
                CleanPreviousLine(msg.Length);

                while (!double.TryParse(Console.ReadLine(), out temp))
                {
                    CleanPreviousLine(msg.Length);
                }
            } while (!(valueCorrectnessPredicate?.Invoke(temp) ?? true));

            return temp;
        }

        public static int ReadInt(string msg = "> ", Predicate<int> valueCorrectnessPredicate = null)
        {
            int temp;
            Console.WriteLine(msg);

            do
            {
                ConsoleUtils.CleanPreviousLine(msg.Length);

                while (!int.TryParse(Console.ReadLine(), out temp))
                {
                    ConsoleUtils.CleanPreviousLine(msg.Length);
                }
            } while (!(valueCorrectnessPredicate?.Invoke(temp) ?? true));

            return temp;
        }

        public static IOperation ReadOperation(List<IOperation> list)
        {
            bool correctKey = false;
            IOperation result = null;

            Console.Write("@: ");

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                var oper = list.Find(x => x.OperatorChar == input.KeyChar);

                if (oper != null)
                {
                    Console.WriteLine(input.KeyChar);
                    correctKey = true;

                    result = oper;
                }
            } while (!correctKey);

            return result;
        }
    }
}
