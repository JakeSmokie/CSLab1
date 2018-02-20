using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class CalcIn
    {
        public virtual double ReadDouble(Predicate<double> valueCorrectnessPredicate = null)
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

        public virtual int ReadInt(Predicate<int> valueCorrectnessPredicate = null)
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

        public virtual IOperation ReadOperation(List<IOperation> list)
        {
            IOperation result = null;
            char key;

            Console.Write("@: ");

            do
            {
                key = Console.ReadKey(true).KeyChar;
            }
            while ((result = list.Find(x => x.OperatorChar == key)) == null);

            Console.WriteLine(result.OperatorChar);
            return result;
        }

        public virtual string GetFileName()
        {
            string name;

            do
            {
                ConsoleUtils.CleanPreviousLine(3);
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }
    }
}
