using ClassLib;

namespace CSLabs.Operations
{
    internal class SubOperation : IOperation
    {
        public char OperatorChar => '-';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            mathBuffer.TempValue = calcIO.ReadDouble();
            mathBuffer.AccValue -= mathBuffer.TempValue;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
