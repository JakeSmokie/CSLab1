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

            double input = calcIO.ReadMathsTempValue(mathBuffer);

            while (input == 0)
            {
                calcIO.SendDivideException();
                input = calcIO.ReadMathsTempValue(mathBuffer);
            }

            mathBuffer.AccValue /= input;
            mathBuffer.SaveAccValue();

            return true;
        }
    }
}
