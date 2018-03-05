using System;
using ClassLib;

namespace CSLabs.Operations
{
    public class DivOperation : IOperation
    {
        public char OperatorChar => '/';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            double input = calcIO.ReadDouble();

            while (input == 0)
            {
                calcIO.Write($"{ new DivideByZeroException().Message }\n");
                input = calcIO.ReadDouble();
            }

            mathBuffer.TempValue = input;
            mathBuffer.AccValue /= input;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
