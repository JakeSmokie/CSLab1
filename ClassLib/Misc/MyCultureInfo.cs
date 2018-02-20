using System.Globalization;
using System.Threading;

namespace ClassLib
{
    static class MyCultureInfo
    {
        public static void Apply()
        {
            var newCInfo = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            newCInfo.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = newCInfo;
        }
    }
}
