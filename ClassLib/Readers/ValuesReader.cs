using CSLabs;
using System;

namespace ClassLib
{
    public class ValuesReader<T>
    {
        public T Read(string msg = "-> ", Predicate<T> valueCorrectnessPredicate = null)
        {
            Console.WriteLine(msg);

            bool success;
            object temp = default(T);

            do
            {
                Utils.CleanPreviousLine(msg.Length);

                if (temp is int)
                {
                    success = int.TryParse(Console.ReadLine(), out int a);
                    temp = a;
                }
                else if (temp is double)
                {
                    success = double.TryParse(Console.ReadLine(), out double a);
                    temp = a;
                }
                else
                {
                    throw new NotSupportedException();
                }

            } while (!success || !(valueCorrectnessPredicate?.Invoke((T)temp) ?? true));

            return (T)temp;
        }
    }
}
