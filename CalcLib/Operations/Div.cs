using System;
using ClassLib;

namespace CSLabs.Operations
{
    internal class DivOperation : IOperation
    {
        public char OperatorChar => '/';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            double input = calcIO.ReadDouble();

            while (input == 0)
            {
                calcIO.WriteLine(new DivideByZeroException().Message);
                input = calcIO.ReadDouble();
            }

            mathBuffer.TempValue = input;
            mathBuffer.AccValue /= input;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
