using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class ConsoleCalcIO : ICalcIO
    {
        public void SendGreeting() => Console.WriteLine(
            "Usage:\n" +
            "  when first symbol on line is ‘>’ – enter operand(number)\n" +
            "  when first symbol on line is ‘@’ – enter operation\n" +
            "  operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or\n" +
            "    ‘#’ followed with number of evaluation step\n" +
            "    ‘q’ to exit");

        public void SendDivideException() => Console.WriteLine(new DivideByZeroException().Message);

        public double ReadDouble(Predicate<double> valueCorrectnessPredicate = null)
        {
            double temp;
            Console.WriteLine("> ");

            do
            {
                ConsoleUtils.CleanPreviousLine(2);

                while (!double.TryParse(Console.ReadLine(), out temp))
                {
                    ConsoleUtils.CleanPreviousLine(2);
                }
            } while (!(valueCorrectnessPredicate?.Invoke(temp) ?? true));

            return temp;
        }

        public int ReadInt(Predicate<int> valueCorrectnessPredicate = null)
        {
            int temp;
            Console.WriteLine("@: #");

            do
            {
                ConsoleUtils.CleanPreviousLine(4);

                while (!int.TryParse(Console.ReadLine(), out temp))
                {
                    ConsoleUtils.CleanPreviousLine(4);
                }
            } while (!(valueCorrectnessPredicate?.Invoke(temp) ?? true));

            return temp;
        }

        public IOperation ReadOperation(List<IOperation> list)
        {
            Console.Write("@: ");

            char key;
            IOperation result = null;

            do
            {
                key = Console.ReadKey(true).KeyChar;
            }
            while ((result = list.Find(x => x.OperatorChar == key)) == null);

            Console.WriteLine(result.OperatorChar);
            return result;
        }

        public double ReadMathsTempValue(IMathBuffer mathBuffer)
        {
            mathBuffer.TempValue = ReadDouble();
            return mathBuffer.TempValue;
        }

        public void SendMathsAccValue(IMathBuffer mathBuffer) => Console.WriteLine($"[#{ mathBuffer.Values.Count }] = { mathBuffer.AccValue }");
    }
}
