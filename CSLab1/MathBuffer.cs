using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1
{

    class MathBuffer
    {
        public List<double> buffer;

        private double tempValue;
        private double accValue;

        public MathBuffer()
        {
            buffer = new List<double>();
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
                buffer.Add(value);

                Console.WriteLine("[#{0}] = {1}", buffer.Count, value);
            }
        }
    }
}
