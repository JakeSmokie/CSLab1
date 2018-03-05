using CSLabs;

namespace ClassLib
{
    public class ProcessorStorage : IProcessorStorage
    {
        public IMathBuffer Maths { get; set; }
        public ICalcIO CalcIO { get; set; }

        public ProcessorStorage(IMathBuffer maths, ICalcIO calcIO)
        {
            Maths = maths;
            CalcIO = calcIO;
        }
    }
}
