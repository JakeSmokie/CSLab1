using ClassLib;
using System;
using System.Collections.Generic;

namespace CSLabs
{

    public class MathBuffer
    {
        private ICalcIO inOutStream;
        public List<double> values = new List<double>();

        public double AccValue { get; set; }
        public double TempValue { get; set; }

        public MathBuffer(ICalcIO _inOutStream)
        {
            inOutStream = _inOutStream;
            AccValue = 0;
        }

        public double ReadTempValue()
        {
            TempValue = inOutStream.ReadDouble();
            return TempValue;
        }

        public void SaveAccValue()
        {
            values.Add(AccValue);
            inOutStream.SendMathAcc($"[#{ values.Count }] = { AccValue }");
        }
    }
}
