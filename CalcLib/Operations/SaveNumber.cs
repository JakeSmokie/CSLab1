using ClassLib;

namespace CSLabs.Operations
{
    internal class SaveNumberOperation : IOperation
    {
        public char OperatorChar => '\0';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            mathBuffer.AccValue = calcIO.ReadMathsTempValue(mathBuffer);
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
