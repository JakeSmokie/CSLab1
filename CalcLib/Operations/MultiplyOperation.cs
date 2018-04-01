using ClassLib;

namespace CSLabs.Operations
{
    public class MultiplyOperation : IOperation
    {
        public char OperatorChar => '*';
        public string Description => "multiply by value";
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            mathBuffer.TempValue = storage.InputParser.ReadDouble();
            mathBuffer.AccValue *= mathBuffer.TempValue;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
