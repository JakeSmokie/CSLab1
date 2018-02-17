using System.Globalization;

namespace CSLabs
{
    static class Extensions
    {
        public static string ToWolfString(this decimal obj)
        {
            return string.Format(new NumberFormatInfo { NumberDecimalSeparator = "." }, "{0}{1}", obj, (obj - decimal.Truncate(obj) > 0 ? " " : "."));
        }
    }
}
