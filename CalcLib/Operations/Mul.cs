using ClassLib;

namespace CSLabs.Operations
{
    internal class MulOperation : IOperation
    {
        public char OperatorChar => '*';
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            mathBuffer.AccValue *= calcIO.ReadMathsTempValue(mathBuffer);
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
