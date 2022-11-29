using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TaskEngine
{
    internal class StringUtility
    {
        /// <summary>
        /// Russian culture info object
        /// </summary>
        public static CultureInfo RuCulture = CultureInfo.GetCultureInfo("ru-RU");

        internal static string GetStringTextNull(string s)
        {
            if (s == null)

                return "Null";
            else return s.Trim();
        }
        /// <summary>
        /// NT-Makes the safe title.
        /// </summary>
        /// <param name="s">The unsafe title string</param>
        /// <returns></returns>
        internal static String MakeSafeTitle(String s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            Char lastchar = 's';
            foreach(char ch in s)
            {
                if (isCharTitleAllowed(ch))
                {
                    sb.Append(ch);
                    lastchar = ch;
                }
                else
                {
                    //prevent double __
                    if (lastchar != '_')
                        sb.Append('_');
                    lastchar = '_';
                }
                //limit title to 80 chars
                if (sb.Length > 80)
                    break;
            }

            return sb.ToString();
        }
        /// <summary>
        /// Determines whether is character title allowed as the specified char.
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <returns>
        ///   <c>true</c> if [is character title allowed] [the specified ch]; otherwise, <c>false</c>.
        /// </returns>
        private static bool isCharTitleAllowed(char ch)
        {
            if (Char.IsLetter(ch)) return true;
            if("0123456789!@-+=№\"'%*(){}[]:;,<>?".IndexOf(ch) != -1) return true;

            return false;
        }

        /// <summary>
        /// NT-Распарсить строку в логическое значение.
        /// </summary>
        /// <param name="str">входная строка</param>
        /// <returns>
        /// Функция возвращает Nullable(bool) объект значения, если удалось его распарсить.
        /// Функция возвращает null при любой ошибке парсинга.
        /// </returns>
        public static Boolean? tryParseBoolean(String str)
        {
            //TODO: добавить распознавание значений Да и Нет в любом регистре.
            Boolean? result = null;
            try
            {
                result = Boolean.Parse(str);
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// NT-Распарсить строку в целое число.
        /// </summary>
        /// <param name="str">входная строка</param>
        /// <returns>
        /// Функция возвращает Nullable(Int32) объект числа, если удалось его распарсить.
        /// Функция возвращает null при любой ошибке парсинга.
        /// </returns>
        public static Int32? tryParseInteger(String str)
        {
            Int32? result = null;
            try
            {
                result = Int32.Parse(str, RuCulture);
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }

        #region *** DateTime formatting ***
        /// <summary>
        /// NT-Return formatted string for DateTime.Now
        /// </summary>
        /// <returns>Return formatted string for DateTime.Now</returns>
        public static String DateTimeNowToString()
        {
            DateTime dt = DateTime.Now;

            return DateTimeToString(dt);
        }
        /// <summary>
        ///  NT-Return formatted string for specified DateTime object.
        /// </summary>
        /// <param name="dt">LocalDateTime object.</param>
        /// <returns>Return formatted string for specified DateTime object.</returns>
        public static String DateTimeToString(DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy HH:mm:ss", RuCulture);
        }

        /// <summary>
        /// NT-Return part of filename string for specified LocalDateTime object.
        /// </summary>
        /// <param name="dt">DateTime object.</param>
        /// <returns>Return part of filename for specified DateTime object.</returns>
        public static String DateTimeToFileNameString(DateTime dt)
        {
            return dt.ToString("yyMMdd_HHmmss", RuCulture);
        }

        /// <summary>
        /// RT-Форматировать дату и время в русской культуре.
        /// Пример: воскресенье, 26 апреля 2020г. 01:03:18
        /// </summary>
        /// <param name="dt">дата и время</param>
        /// <returns>Функция возвращает строку даты и времени.</returns>
        public static String CreateLongDatetimeString(DateTime dt)
        {
            return dt.ToString("dddd, d MMMM yyyy'г. 'HH:mm:ss", RuCulture);
        }
        #endregion

    }
}
