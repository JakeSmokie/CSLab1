using CSLabs;
using System;

namespace ClassLib
{
    public class DoubleReader
    {
        public double Read(string msg, Predicate<double> valueCorrectnessPredicate = null)
        {
            double temp;
            Console.WriteLine(msg);

            do
            {
                Utils.CleanPreviousLine(msg.Length);

                while (!double.TryParse(Console.ReadLine(), out temp))
                {
                    Utils.CleanPreviousLine(msg.Length);
                }
            } while (!(valueCorrectnessPredicate?.Invoke(temp) ?? true));

            return temp;
        }
    }
}
