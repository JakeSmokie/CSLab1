using CSLabs;

namespace ClassLib
{
    public interface IProcessorStorage
    {
        ICalcIO CalcIO { get; }
        IMathBuffer Maths { get; }
        ICalcInputParser InputParser { get; }
    }
}