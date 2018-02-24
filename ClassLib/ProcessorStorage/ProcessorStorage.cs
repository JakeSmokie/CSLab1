using CSLabs;

namespace ClassLib
{
    internal class ProcessorStorage : IProcessorStorage
    {
        public ProcessorStorage()
        {
            CalcIO = new ConsoleCalcIO();
            Maths = new MathBuffer(CalcIO);
        }

        public IMathBuffer Maths { get; set; }
        public ICalcIO CalcIO { get; set; }
    }
}
