using CSLabs;

namespace ClassLib
{
    internal class ProcessorStorage : IProcessorStorage
    {
        public IMathBuffer Maths { get; set; }
        public ICalcIO CalcIO { get; set; }

        public ProcessorStorage()
        {
            CalcIO = new ConsoleCalcIO();
            Maths = new MathBuffer(CalcIO);
        }
    }
}
