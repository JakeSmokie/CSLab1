using System;

namespace CSLabs
{
    static class Extensions
    {
        public static string ToWolfString(this double val)
        {
            return $"{ val }{ (val - Math.Truncate(val) > 0 ? "" : ".0") }";
        }
    }
}
