using System.Globalization;
using System.Threading;

namespace CSLabs
{
    public static class Utils
    {
        public static void SetDotAsDecimalSeparator()
        {
            var newCInfo = (CultureInfo) Thread.CurrentThread.CurrentCulture.Clone();
            newCInfo.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = newCInfo;
        }
    }
}
