using System;
using System.Collections.Generic;

namespace CSLabs
{

    public class MathBuffer
    {
        private double accValue;
        private double tempValue;

        public double lastTempValue;
        public List<double> values;

        public MathBuffer()
        {
            values = new List<double>();
            accValue = 0;
            tempValue = 0;
        }

        public MathBuffer(MathBuffer old)
        {
            accValue = old.values[old.values.Count - 1];
            values = old.values;
        }

        public double TempValue
        {
            get
            {
                Console.Write("> ");

                while (!double.TryParse(Console.ReadLine(),  out tempValue))
                {
                    Utils.CleanPreviousLine(2);
                }

                lastTempValue = tempValue;
                return tempValue;
            }
            set => tempValue = value;
        }


        public double AccValue
        {
            get => accValue;
            set
            {
                accValue = value;
                values.Add(value);

                Console.WriteLine($"[#{ values.Count }] = { value }");
            }
        }

        public double AccValueNoAdd
        {
            set => accValue = value;
        }
    }
}
