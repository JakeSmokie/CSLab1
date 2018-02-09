using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1
{

    class MathBuffer
    {
        private List<decimal> valuesBuffer;
        private decimal accValue;

        public MathBuffer()
        {
            valuesBuffer = new List<decimal>();
            accValue = 0;
            TempValue = 0;
        }

        public decimal TempValue { get; set; }
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
