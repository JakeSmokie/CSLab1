using CSLabs;
using CSLabs.Operations;
using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class ConsoleCalcIO : ICalcIO
    {
        public void Write(string msg) => Console.Out.Write(msg);
        public string ReadLine() => Console.In.ReadLine();
        public double ReadDouble(Predicate<double> valueCorrectnessPredicate = null)
        {
            double result;
            Write("> ");

            while (!double.TryParse(ReadLine(), out result) || !(valueCorrectnessPredicate?.Invoke(result) ?? true))
            {
                Write("Wrong input. Try again.\n> ");
            }

            return result;
        }
        public int ReadInt(Predicate<int> valueCorrectnessPredicate = null)
        {
            int result;
            Write("#> ");

            while (!int.TryParse(ReadLine(), out result) || !(valueCorrectnessPredicate?.Invoke(result) ?? true))
            {
                Write("Wrong input. Try again.\n#> ");
            }

            return result;
        }
        public IOperation ReadOperation(List<IOperation> list)
        {
            Write("@: ");
            IOperation result = null;
            string input = ReadLine().ToLower();

            while ((result = list.Find(x => x.OperatorChar.ToString() == input)) == null)
            {
                Write("Wrong input. Try again.\n@: ");
                input = ReadLine().ToLower();
            }
            return result;
        }
    }
}
