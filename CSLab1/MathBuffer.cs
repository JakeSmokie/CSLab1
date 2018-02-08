using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1
{

    class MathBuffer
    {
        private List<double> valuesBuffer;

        private double tempValue;
        private double accValue;

        public MathBuffer()
        {
            valuesBuffer = new List<double>();
            tempValue = 0;
            accValue = 0;
        }

        public double TempValue { get => tempValue; set => tempValue = value; }
        public double AccValue
        {
            get => accValue;
            set
            {
                accValue = value;
                valuesBuffer.Add(value);

                Console.WriteLine("[#{0}] = {1}", valuesBuffer.Count, value);
            }
        }

        public List<double> Buffer { get => valuesBuffer; }
    }
}
