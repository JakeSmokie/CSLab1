using ClassLib;

namespace CSLabs.Operations
{
    public class SaveNumberOperation : IOperation
    {
        public char OperatorChar => '\0';
        public string Description => "save value";
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            mathBuffer.TempValue = storage.InputParser.ReadDouble();
            mathBuffer.AccValue = mathBuffer.TempValue;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
