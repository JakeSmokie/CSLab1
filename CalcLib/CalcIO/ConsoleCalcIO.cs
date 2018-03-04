using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class ConsoleCalcIO : ICalcIO
    {
        public void WriteLine(string msg) => Console.WriteLine(msg);
        public double ReadDouble(Predicate<double> valueCorrectnessPredicate = null)
        {
            Console.WriteLine("> ");

            double temp;
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
            Console.WriteLine("@: #");

            int temp;
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
        public string ReadLine() => Console.ReadLine();
    }
}
