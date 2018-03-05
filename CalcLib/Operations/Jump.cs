using ClassLib;
using System;

namespace CSLabs.Operations
{
    public class JumpOperation : IOperation
    {
        public char OperatorChar => '#';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            int input = calcIO.ReadInt(x => (x > 0 && x <= mathBuffer.Values.Count));

            mathBuffer.TempValue = input;
            mathBuffer.AccValue = mathBuffer.Values[input - 1];
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
