using System;
using System.Collections.Generic;
using System.Globalization;

namespace CSLabs
{

    public class MathBuffer
    {
        private List<decimal> valuesBuffer;
        private decimal accValue;
        private decimal tempValue;

        public decimal lastTempValue;

        public MathBuffer()
        {
            valuesBuffer = new List<decimal>();
            accValue = 0;
            tempValue = 0;
        }

        public decimal TempValue
        {
            get
            {
                Console.Write("> ");

                while (!decimal.TryParse(Console.ReadLine(),  out tempValue))
                {
                    Utils.CleanPreviousLine(2);
                }

                lastTempValue = tempValue;
                return tempValue;
            }
            set => tempValue = value;
        }


        public decimal AccValue
        {
            get => accValue;
            set
            {
                accValue = value;
                valuesBuffer.Add(value);

                Console.WriteLine($"[#{ valuesBuffer.Count }] = { value }");
            }
        }

        public List<decimal> Buffer { get => valuesBuffer; }
    }
}
