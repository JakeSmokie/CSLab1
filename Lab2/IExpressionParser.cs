using System.Collections.Generic;
using ClassLib;

namespace CSLabs
{
    public interface IExpressionParser
    {
        double Parse(ref string expression, List<double> valBuffer, ICalcIO calcIO);
    }
}