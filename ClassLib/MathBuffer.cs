using ClassLib;
using System;
using System.Collections.Generic;

namespace CSLabs
{

    public class MathBuffer
    {
        public List<double> values = new List<double>();
        public double AccValue { get; set; }

        public MathBuffer() => AccValue = 0;

        public double TempValue { get; set; }

        public double ReadTempValue()
        {
            TempValue = new ValuesReader<double>().Read("> ");
            return TempValue;
        }

        public void SaveAccValue()
        {
            values.Add(AccValue);
            Console.WriteLine($"[#{ values.Count }] = { AccValue }");
        }
    }
}
