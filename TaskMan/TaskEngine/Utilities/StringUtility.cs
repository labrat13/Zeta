using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TaskEngine
{
    /// <summary>
    /// Класс содержит различные вспомогательные операции 
    /// </summary>
    public class StringUtility
    {
        //TODO: перед релизом удалить или закомментировать неиспользуемые функции.

        /// <summary>
        /// Russian culture info object
        /// </summary>
        public static CultureInfo RuCulture = CultureInfo.GetCultureInfo("ru-RU");
        /// <summary>
        /// NT-Возвращает "Null" текст если строка=null. Иначе возвращает строку после Trim().
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
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

        #region *** TryParse functions ***
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
        #endregion

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

        /// <summary>
        /// NT-Return date string as 23.01.2018 23:14:59
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string StringFromDateTime(DateTime time)
        {
            return time.ToString(CultureInfo.GetCultureInfo("ru-RU"));//23.01.2018 23:14:59
        }

        public static DateTime DateTimeFromString(string p)
        {
            return DateTime.Parse(p, CultureInfo.GetCultureInfo("ru-RU"));
        }

        #endregion

        #region *** File path functions ***

        /// <summary>
        /// NT-Возвращает флаг что указанное Хранилище может обновляться.
        /// </summary>
        /// <returns>Returns True if storage is ReadOnly, False otherwise</returns>
        public static bool isReadOnly(String folderPath)
        {
            bool ro = false;
            //generate test file name
            String test = Path.Combine(folderPath, "writetest.txt");

            try
            {
                //if test file already exists, try remove it
                if (File.Exists(test))
                    File.Delete(test);//тут тоже будет исключение, если каталог read-only
                //test creation 
                FileStream fs = File.Create(test);
                fs.Close();
            }
            catch (Exception)
            {
                ro = true;
            }
            finally
            {
                File.Delete(test);
            }
            return ro;
        }

        /// <summary>
        /// NT-Создать каталог, в котором запрещено индексирование средствами операционной системы
        /// </summary>
        /// <param name="folderPath">Путь к создаваемому каталогу</param>
        public static void CreateNotIndexedFolder(String folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            //create directory
            if (!di.Exists)
                di.Create();
            //set attribute Not indexed
            di.Attributes = FileAttributes.NotContentIndexed | FileAttributes.Directory;
            di = null;
            return;
        }


        /// <summary>
        /// Массив запрещенных имен файлов - для коррекции имен файлов
        /// </summary>
        private static String[] RestrictedFileNames = { "CON", "PRN", "AUX", "CLOCK$", "NUL", "COM1", "LPT1", "LPT2", "LPT3", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19" };

        /// <summary>
        /// NT-Проверить, что имя файла является неправильным
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool isRestrictedFileName(string p)
        {
            //fast check = check length
            if ((p.Length > 6) || (p.Length < 3))
                return false;
            //slow check - check content
            foreach (String s in RestrictedFileNames)
                if (String.Equals(s, p, StringComparison.OrdinalIgnoreCase))
                    return true;
            //no restrictions
            return false;
        }

        /// <summary>
        /// NFT-Нормализовать имя файла или каталога
        /// </summary>
        /// <param name="title">имя файла без расширения</param>
        /// <param name="maxLength">Максимальная длина имени, в символах</param>
        /// <returns>Возвращает нормализованное название файла или каталога, без расширения.</returns>
        /// <remarks>
        /// Функция заменяет на подчеркивания _ все символы, кроме букв и цифр.
        /// Если в названии есть пробелы, они удаляются, а следующий символ переводится в верхний регистр.
        /// Если в названии есть символ 'µ', он заменяется на символ 'u'.
        /// Если получившееся название длиннее maxLength, то оно обрезается до maxLength.
        /// Если получившееся название является зарезервированным системным названием (вроде CON), или
        /// если получившееся название короче 3 символов, к нему добавляется случайное число.
        /// </remarks>
        public static string RemoveWrongSymbols(string title, int maxLength)
        {
            //TODO: Optimize - переработать для ускорения работы насколько это возможно
            //надо удалить все запрещенные символы
            //если пробелы, то символ после них перевести в верхний регистр
            //если прочие символы, заменить на подчеркивание
            //если имя длиннее maxLength, то обрезать до maxLength.
            Char[] chars = title.ToCharArray();
            //create string builder
            StringBuilder sb = new StringBuilder(chars.Length);
            //если символ в строке является недопустимым, заменить его на подчеркивание.
            Char c;
            bool toUp = false;//для перевода в верхний регистр
            foreach (char ch in chars)
            {
                c = ch;
                if (ch == ' ')
                {
                    toUp = true;
                    //ничего не записываем в выходной накопитель - так пропускаем все пробелы.
                }
                else
                {
                    //foreach (char ct in RestrictedWebLinkSymbols)
                    //{
                    //    if (ch.Equals(ct))
                    //        c = '_';//замена недопустимого символа на подчеркивание
                    //}
                    //Unicode chars throw exceptions

                    //тут надо пропускать только -_A-Za-zА-Яа-я и все равно будут проблемы с именами файлов архива

                    if (!Char.IsLetterOrDigit(ch))
                        c = '_';//замена недопустимого символа на подчеркивание
                    //перевод в верхний регистр после пробела
                    if (toUp == true)
                    {
                        c = Char.ToUpper(c);
                        toUp = false;
                    }
                    //if c == мю then c = u
                    if (c == 'µ') c = 'u';
                    //добавить в выходной накопитель
                    sb.Append(c);
                }
            }
            //если имя длиннее максимума, обрезать по максимуму
            if (sb.Length > maxLength) sb.Length = maxLength;
            //если имя короче минимума, добавить псевдослучайную последовательность.
            //и проверить, что имя не запрещенное
            if ((sb.Length < 3) || isRestrictedFileName(sb.ToString()))
            {
                sb.Append('_');
                sb.Append(new Random().Next(10, 100).ToString(CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

        /// <summary>
        /// NR-Изменить название каталога так, чтобы оно не содержало недопустимых символов.
        /// И пробелов. И не короче 3 символов, и не длиннее 16 символов.
        /// </summary>
        /// <param name="folderName">Название каталога</param>
        /// <returns></returns>
        public static string makeSafeFolderName(string folderName)
        {
            String result = RemoveWrongSymbols(folderName, 16);
            return result;
        }


        /// <summary>
        /// Заменить неправильные символы пути файла в строке на указанный символ
        /// </summary>
        /// <param name="s">Строка пути файла</param>
        /// <param name="rChar">Символ на замену</param>
        /// <returns>Возвращает строку не содержащую неправильных символов имени файла</returns>
        public static string ReplaceInvalidFilenameChars(string s, char rChar)
        {
            //Получаем массив запрещенных символов
            char[] inv = Path.GetInvalidFileNameChars();
            //Создаем билдер для сборки символов
            StringBuilder sb = new StringBuilder();
            foreach (Char c in s)
            {
                //если символ есть в массиве, то вместо него пишем замену, иначе пишем сам символ
                if (Array.IndexOf(inv, c) == -1)
                    sb.Append(c);
                else sb.Append(rChar);
            }
            return sb.ToString();
        }

        #endregion

        #region Forms functions
        /// <summary>
        /// Цвет для выделения неправильного веб-имени  фоном текстового поля
        /// </summary>
        internal static Color InvalidWebNameBackColor = Color.MistyRose;

        /// <summary>
        /// NT-Установить цвет ошибки для текстбокса и вывести сообщение в строке состояния, если она есть
        /// </summary>
        /// <param name="wrong">Флаг ошибки</param>
        /// <param name="control">Текстбокс</param>
        /// <param name="statusBarLabel">Объект текста на статусбаре или null</param>
        /// <param name="statusMsg">Сообщение об ошибке, для статусбара</param>
        public static void colorizeWrongTextBox(bool wrong, TextBox control, ToolStripStatusLabel statusBarLabel, String statusMsg)
        {
            Color backColor;
            //set error color for textbox
            if (wrong)
            {
                backColor = InvalidWebNameBackColor;

            }
            else
            {
                backColor = Color.White;
            }
            control.BackColor = backColor;

            //set new status bar message text
            String msg;
            if (statusBarLabel != null)
            {
                if (wrong)
                    msg = statusMsg;
                else
                    msg = String.Empty;
                //set new text
                statusBarLabel.Text = msg;
            }

            return;
        }
        #endregion

    }
}
