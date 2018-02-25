using System.Collections.Generic;
using ClassLib;

namespace CSLabs
{
    public interface IMathBuffer
    {
        double AccValue { get; set; }
        ICalcIO CalcIO { get; set; }
        double TempValue { get; set; }
        List<double> Values { get; set; }

        void SaveAccValue();
    }
}