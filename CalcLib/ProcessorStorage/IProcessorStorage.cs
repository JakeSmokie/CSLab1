using CSLabs;

namespace ClassLib
{
    public interface IProcessorStorage
    {
        ICalcIO CalcIO { get; set; }
        IMathBuffer Maths { get; set; }
    }
}