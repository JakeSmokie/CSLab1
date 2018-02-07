using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1
{

    static class MathBuffer
    {
        public static double AccValue
        {
            get => accValue;
            set
            {
                accValue = value;
                buffer.Add(value);

                Console.WriteLine("[#{0}] = {1}", buffer.Count, value);
            }
        }
        public static double TempValue { get => tempValue; set => tempValue = value; }

        private static double tempValue = 0;
        public static List<double> buffer = new List<double>();

        private static double accValue = 0;
    }
}
