using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UAMX2
{
    internal class Utility
    {
        /// <summary>
        /// NT-Return date string as 23.01.2018 23:14:59
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string StringFromDateTime(DateTime time)
        {
            return time.ToString(CultureInfo.GetCultureInfo("ru-RU"));//23.01.2018 23:14:59
        }
        /// <summary>
        /// DateTime from string.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public static DateTime DateTimeFromString(string p)
        {
            return DateTime.Parse(p, CultureInfo.GetCultureInfo("ru-RU"));
        }

    }
}
