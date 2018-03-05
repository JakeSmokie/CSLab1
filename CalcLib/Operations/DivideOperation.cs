using System;
using ClassLib;

namespace CSLabs.Operations
{
    public class DivideOperation : IOperation
    {
        public char OperatorChar => '/';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            double input = storage.InputParser.ReadDouble();

            while (input == 0)
            {
                calcIO.WriteLine(new DivideByZeroException().Message);
                input = (calcIO as ICalcInputParser).ReadDouble();
            }

            mathBuffer.TempValue = input;
            mathBuffer.AccValue /= input;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
