using System.Collections.Generic;

namespace CSLabs
{
    public static class Extensions
    {
        public static bool IsOneOf(this object obj, params object[] list) => (new List<object>(list).Contains(obj));
    }
}