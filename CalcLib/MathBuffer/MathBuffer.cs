using ClassLib;
using System.Collections.Generic;

namespace CSLabs
{
    public class MathBuffer : IMathBuffer
    {
        public double AccValue { get; set; }
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
