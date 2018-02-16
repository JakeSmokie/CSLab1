using System;
using System.Collections.Generic;

namespace CSLab1
{

    class MathBuffer
    {
        private List<decimal> valuesBuffer;
        private decimal accValue;
        private decimal tempValue;

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
                decimal input = 0;

                while (!decimal.TryParse(Console.ReadLine(), out input))
                {
                    Utils.CleanPreviousLine(2);
                }
                 
                tempValue = input;
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

                Console.WriteLine("[#{0}] = {1}", valuesBuffer.Count, value);
            }
        }

        public List<decimal> Buffer { get => valuesBuffer; }
    }
}
