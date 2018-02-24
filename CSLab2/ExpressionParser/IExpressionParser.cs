using System.Collections.Generic;

namespace CSLabs
{
    public interface IExpressionParser
    {
        double Parse(ref string expression, List<double> valBuffer);
    }
}