using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    internal class StringUtility
    {
        internal static string GetStringTextNull(string s)
        {
            if (s == null)

                return "Null";
            else return s.Trim();
        }
    }
}
