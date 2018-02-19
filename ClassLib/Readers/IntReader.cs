using CSLabs;
using System;

namespace ClassLib
{
    public class IntReader
    {
        public int Read(string msg, Predicate<int> valueCorrectnessPredicate = null)
        {
            int temp;
            Console.WriteLine(msg);

            do
            {
                Utils.CleanPreviousLine(msg.Length);

                while (!int.TryParse(Console.ReadLine(), out temp))
                {
                    Utils.CleanPreviousLine(msg.Length);
                }
            } while (!(valueCorrectnessPredicate?.Invoke(temp) ?? true));

            return temp;
        }
    }
}
