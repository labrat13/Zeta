using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// NT - Представляет элемент данных в файле настроек приложения.
    /// </summary>
    /// <remarks>
    /// Элемент данных содержит название-ключ, текстовое значение и текстовое описание.
    /// Текстовое описание должно выводиться на одной строке комментария, если оно однострочное, или на нескольких строках, если оно многострочное.
    /// На следующей строке должно выводиться пара ключ-значение и затем следующая строка должна быть пустой.
    /// Допускается иметь несколько элементов данных с одинаковым ключом, в этом случае они образуют список значений.
    /// </remarks>
    public class SettingItem
    {

        #region *** Fields ***

        /// <summary>
        /// Константа для поля m_storage, обозначает, что данный элемент хранится в Бд Оператор.
        /// </summary>
        /// <remarks>
        /// Все остальные значения этого поля должны соответствовать названиям Библиотек Процедур,
        /// из которых извлечен данный элемент (Место или Процедура).
        /// </remarks>
        public const String StorageKeyForDatabaseItem = "Database";

        /// <summary>
        /// Константа для поля m_storage, обозначает, что данный элемент хранится в ФайлНастроек Оператор.
        /// </summary>
        /// <remarks>
        /// Все остальные значения этого поля должны соответствовать названиям Библиотек Процедур,
        /// из которых извлечен данный элемент (Место или Процедура).
        /// </remarks>
        public const String StorageKeyForSettingFileItem = "SettingFile";


        /// <summary>
        /// первичный ключ таблицы
        /// </summary>
        protected int m_tableid;

        /// <summary>
        /// Название Сущности
        /// </summary>
        protected string m_title;

        /// <summary>
        /// Описание Сущности
        /// </summary>
        protected string m_descr;

        /// <summary>
        /// Путь к Сущности
        /// </summary>
        protected string m_path;

        /// <summary>
        /// Название Хранилища ( Библиотеки Процедур или БД).  Не сохранять в таблицу БД!
        /// </summary>
        protected String m_storage;

        /// <summary>
        /// Название пространства имен Сущности.
        /// </summary>
        protected String m_namespace;
        /// <summary>
        /// Флаг что Сущность не может быть изменена в Хранилище.
        /// </summary>
        protected bool m_readOnly;

        #endregion

        /// <summary>
        /// NT-Конструктор копирования.
        /// </summary>
        /// <param name="p">Копируемый объект.</param>         
        public SettingItem(SettingItem p)
        {
            this.m_descr = (p.m_descr);
            this.m_namespace = (p.m_namespace);
            this.m_path = (p.m_path);
            this.m_storage = (p.m_storage);
            this.m_title = (p.m_title);
            this.m_tableid = p.m_tableid;
            this.m_readOnly = (p.m_readOnly);

            return;
        }

        /// <summary>
        /// NT-Parameter constructor - not for Database Item.
        /// </summary>
        /// <param name="group">Setting item namespace as group.</param>
        /// <param name="title">item title</param>
        /// <param name="value">item value</param>
        /// <param name="descr">item description text</param>
        public SettingItem(String group, String title, String value, String descr)
        {
            this.m_tableid = 0;
            this.m_path = value;
            this.m_descr = descr;
            this.m_title = title;
            this.m_namespace = group;

            return;
        }

        /// <summary>
        /// NT-Parameter constructor - for Database Item.
        /// </summary>
        /// <param name="id">item table id or 0 if not.</param>
        /// <param name="group">Setting item namespace as group.</param>
        /// <param name="title">item title</param>
        /// <param name="value">item value</param>
        /// <param name="descr">item description text</param>
        /// <param name="storage">item storage keyword</param>
        public SettingItem(int id,
                String group,
                String title,
                String value,
                String descr,
                String storage)
        {
            this.m_tableid = id;
            this.m_namespace = group;
            this.m_path = value;
            this.m_descr = descr;
            this.m_title = title;
            this.m_storage = storage;

            return;
        }

        public SettingItem()
        {
            this.m_descr = String.Empty;
            this.m_namespace = String.Empty;
            this.m_path= String.Empty;
            this.m_readOnly= false; 
            this.m_storage= String.Empty;   
            this.m_tableid  = 0;
            this.m_title= String.Empty;

            return;
        }

        #region *** Properties ***

        /// <summary>
        /// первичный ключ таблицы
        /// </summary>
        public int TableId
        {
            get { return m_tableid; }
            set { m_tableid = value; }
        }

        /// <summary>
        /// Уникальное название сущности, до 255 символов
        /// </summary>
        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        /// <summary>
        /// Описание сущности
        /// </summary>
        public string Description
        {
            get { return m_descr; }
            set { m_descr = value; }
        }
        /// <summary>
        /// Путь к сущности, до 255 символов
        /// </summary>
        public string Path
        {
            get { return m_path; }
            set { m_path = value; }
        }

        /// <summary>
        /// Название Хранилища ( Библиотеки Процедур или БД).  Не сохранять в таблицу БД!
        /// </summary>
        public String Storage
        {
            get { return this.m_storage; }
            set { this.m_storage = value; }
        }
        /// <summary>
        /// Название пространства имен Сущности.
        /// </summary>
        public String Namespace
        {
            get { return this.m_namespace; }
            set { this.m_namespace = value; }
        }

        /// <summary>
        /// Флаг что Сущность не может быть изменена в Хранилище.
        /// </summary>
        public bool ReadOnly
        {
            get { return this.m_readOnly; }
            set { this.m_readOnly = value; }
        }
        #endregion


        /// <summary>
        /// NT-Return string for debug
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return getSingleLineProperties();
        }

        /// <summary>
        /// NT-Получить одну строку описания свойств итема
        /// </summary>
        /// <returns></returns>
        public string getSingleLineProperties()
        {
            // TODO: формат строки свойств Сущности неудовлетворительный - нужно переделать на понятный.
            //Одна строка, 80 символов макс.
            StringBuilder sb = new StringBuilder();
            sb.Append(this.m_storage);
            sb.Append(':');
            sb.Append(this.m_tableid);
            sb.Append(";");
            sb.Append(this.m_title);
            sb.Append(";");
            sb.Append("[").Append(this.m_namespace).Append("]");
            sb.Append(";");
            sb.Append(this.m_path);
            sb.Append(";");
            sb.Append(this.m_descr);
            if (sb.Length > 80)
                sb.Length = 80;
            return sb.ToString();
        }

        /// <summary>
        /// NT-получить однострочное описание Настройки.
        /// </summary>
        /// <returns>Функция возвращает однострочное описание Настройки в формате "Команда "Значение" из "Хранилище"."Название": Описание."</returns>        
        public String toSingleDescriptionString()
        {
            return String.Format("Команда \"{0}\" из \"{1}\".\"{2}\": {3}.", this.m_path.Trim(), this.m_storage.Trim(), this.m_title.Trim(), this.m_descr.Trim());
        }

        /// <summary>
        /// NT-Получить одну строку описания свойств Элемента: название и описание, длиной менее 80 символов.
        /// </summary>
        /// <returns>Функция возвращает строку вроде: название Элемента (Описание Элемента.)</returns>
        public String GetShortInfo()
        {
            // TODO: формат строки свойств Сущности неудовлетворительный - нужно переделать на понятный.
            // Одна строка, 80 символов макс.
            StringBuilder sb = new StringBuilder();
            sb.Append(StringUtility.GetStringTextNull(this.m_title));
            sb.Append(" ");
            sb.Append('(');
            sb.Append(StringUtility.GetStringTextNull(this.m_descr));
            if (sb.Length > 75)
            {
                sb.Length = 75;
            }
            sb.Append(')');

            return sb.ToString();
        }

        /// <summary>
        /// Сортировать список по Названию 
        /// </summary>
        /// <param name="x">Item object</param>
        /// <param name="y">Item object</param>
        /// <returns></returns>
        public static int SortByTitle(SettingItem x, SettingItem y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;// If x is null and y is null, they're equal. 
                else
                    return -1;// If x is null and y is not null, y is greater. 
            }
            else
            {   // If x is not null...
                if (y == null)
                    return 1;// ...and y is null, x is greater.
                else
                {
                    String titleX = x.m_title;
                    String titleY = y.m_title;

                    return titleX.CompareTo(titleY);
                }
            }
        }

        /// <summary>
        /// NT- Get value.
        /// </summary>
        /// <returns>Returns Value as String.</returns>
        public String getValueAsString()
        {
            return this.m_path;
        }

        /// <summary>
        /// NT- Set value.
        /// </summary>
        /// <param name="val">Value as String.</param>
        public void setValue(String val)
        {
            this.m_path = val;
        }

        /// <summary>
        /// NT- Get value
        /// </summary>
        /// <returns>Returns Value as Integer; returns null if Value has invalid format.</returns>
        public Int32? getValueAsInteger()
        {
            return StringUtility.tryParseInteger(this.m_path);
        }

        /// <summary>
        /// Gets the value as Boolean.
        /// </summary>
        /// <returns>Returns Value as Boolean; returns null if Value has invalid format.</returns>
        public Boolean? getValueAsBoolean()
        {
            return StringUtility.tryParseBoolean(this.m_path);
        }

        /// <summary>
        /// NT-Settings value as Boolean
        /// </summary>
        /// <param name="value">the value to set</param>
        public void setValue(bool value)
        {
            this.m_path = value.ToString();
        }

        /// <summary>
        /// NT-Settings value as Int32
        /// </summary>
        /// <param name="value">the value to set</param>
        public void setValue(Int32 value)
        {
            this.m_path = value.ToString();
        }
    }
}
