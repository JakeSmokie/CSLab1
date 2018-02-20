using ClassLib;
using System.Collections.Generic;

namespace CSLabs
{

    public class MathBuffer
    {
        private CalcIn inStream;
        private CalcOut outStream;
        
        public List<double> values = new List<double>();
        public double AccValue { get; set; }

        public MathBuffer(CalcIn __inStream, CalcOut __outStream)
        {
            inStream = __inStream;
            outStream = __outStream;

            AccValue = 0;
        }
        public double TempValue { get; set; }

        public double ReadTempValue()
        {
            TempValue = inStream.ReadDouble();
            return TempValue;
        }

        public void SaveAccValue()
        {
            values.Add(AccValue);
            outStream.SendMathAcc($"[#{ values.Count }] = { AccValue }");
        }
    }
}
