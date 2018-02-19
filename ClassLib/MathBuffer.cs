using System;
using System.Collections.Generic;

namespace CSLabs
{

    public class MathBuffer
    {
        public List<double> values;
        public double AccValue { get; set; }

        public MathBuffer()
        {
            values = new List<double>();
            AccValue = 0;
        }

        public MathBuffer(MathBuffer old)
        {
            AccValue = old.values[old.values.Count - 1];
            values = old.values;
        }

        public double TempValue { get; set; }

        public double ReadTempValue()
        {
            double temp = double.NaN;
            Console.Write("> ");

            while (!double.TryParse(Console.ReadLine(), out temp))
            {
                Utils.CleanPreviousLine(2);
            }

            TempValue = temp;
            return temp;
        }

        public void SaveAccValue()
        {
            values.Add(AccValue);
            Console.WriteLine($"[#{ values.Count }] = { AccValue }");
        }
    }
}
