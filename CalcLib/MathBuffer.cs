using ClassLib;
using System.Collections.Generic;

namespace CSLabs
{
    public class MathBuffer : IMathBuffer
    {
        private double _accValue;

        public double AccValue
        {
            get => _accValue;
            set
            {
                if (double.IsInfinity(value))
                {
                    CalcIO.WriteLine("Warning! AccValue is too big. Changes canceled.");
                    return;
                }

                _accValue = value;
            }
        }
        public double TempValue { get; set; }
        public ICalcIO CalcIO { get; set; }
        public List<double> Values { get; set; }
        public MathBuffer(ICalcIO inOut)
        {
            Values = new List<double>();
            CalcIO = inOut;
            AccValue = 0;
        }

        public void SaveAccValue()
        {
            Values.Add(AccValue);
            CalcIO.WriteLine($"[#{ Values.Count }] = { AccValue }");
        }
    }
}
