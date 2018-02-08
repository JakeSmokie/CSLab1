using System;
using System.Collections.Generic;

namespace CSLab1
{
    public static class Extensions
    {
        public static bool IsOneOf(this Object obj, params Object[] list)
        {
            return (new List<Object>(list).Contains(obj));
        }
    }
}