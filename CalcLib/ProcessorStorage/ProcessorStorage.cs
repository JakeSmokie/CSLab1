using CSLabs;

namespace ClassLib
{
    public class ProcessorStorage : IProcessorStorage
    {
        public IMathBuffer Maths { get; set; }
        public ICalcIO CalcIO { get; private set; }
        public ICalcInputParser InputParser { get; private set; }
        public ProcessorStorage(IMathBuffer maths, ICalcIO calcIO, ICalcInputParser inputParser)
        {
            Maths = maths;
            CalcIO = calcIO;
            InputParser = inputParser;
        }
    }
}
