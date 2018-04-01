using ClassLib;

namespace CSLabs.Operations
{
    public class JumpOperation : IOperation
    {
        public char OperatorChar => '#';
        public string Description => "jump to calculated value";
        public bool Run(IProcessorStorage storage)
        {
            ICalcIO calcIO = storage.CalcIO;
            IMathBuffer mathBuffer = storage.Maths;

            int input = storage.InputParser.ReadInt(x => (x > 0 && x <= mathBuffer.Values.Count));

            mathBuffer.TempValue = input;
            mathBuffer.AccValue = mathBuffer.Values[input - 1];
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
