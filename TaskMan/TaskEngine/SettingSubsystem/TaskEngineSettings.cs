using System;
using System.IO;
using System.Reflection;
using System.Xml;
using UAMX_2;

namespace TaskEngine.SettingSubsystem
{
    /// <summary>
    /// NT-Это класс, управляющий файлом настроек Хранилища.
    /// </summary>
    /// <seealso cref="UAMX_2.EngineSettingsBase" />
    public class TaskEngineSettings : UAMX_2.EngineSettingsBase
    {

        #region Константы названий тегов словаря
        //названия свойств писать только латинскими буквами!
        internal const string tagStorageVersion = "StorageVersion";//TODO: узнать что это такое и где брать
        internal const string tagDatabaseSize = "DatabaseSize";//размер файла БД
        internal const string tagQualifiedName = "QualifiedName";//имя подобно классификации "ИмяКлассаХранилищ.НазваниеХранилища"
        internal const string tagStorageType = "StorageType";//как квалиф имя но через ::
        internal const string tagDocsCount = "DocsCount";//количество файлов
        internal const string tagDocsSize = "DocsSize";//общий размер файлов 
        internal const string tagTaskCount = "TaskCount";// общее количество задач.
        internal const string tagStoppedTaskCount = "StoppedTaskCount";//количество приостановленных задач.
        internal const string tagFinishedTaskCount = "FinishedTaskCount";//количество выполненных задач.
        internal const string tagRunTaskCount = "RunTaskCount";//количество Задач для выполнения.
        internal const string tagNotesCount = "NotesCount";//количество Заметок.
        internal const string tagCategoriesCount = "CategoriesCount";//количество Категорий.
        internal const string tagTagsCount = "TagsCount";//количество Тегов.
        internal const string tagDeletedCount = "DeletedCount";//количество удаленных элементов (в Корзине).

        //всего 14 штук + свойства из базовых классов
        #endregion

        /// <summary>
        /// NR-Initializes a new instance of the <see cref="TaskEngineSettings"/> class.
        /// </summary>
        public TaskEngineSettings():base()
        {
            this.m_dictionary.Add(tagStorageVersion , "1.0.0.0");  //TODO: узнать что это такое и где брать
            this.m_dictionary.Add(tagDatabaseSize , "0");           
             this.m_dictionary.Add(tagQualifiedName , ""); //TODO: узнать что это такое и где брать
            this.m_dictionary.Add(tagStorageType , ""); //TODO: узнать что это такое и где брать
            this.m_dictionary.Add(tagDocsCount , "0");
            this.m_dictionary.Add(tagDocsSize , "0");
            this.m_dictionary.Add(tagTaskCount , "0");
            this.m_dictionary.Add(tagStoppedTaskCount , "0");
            this.m_dictionary.Add(tagFinishedTaskCount , "0");
            this.m_dictionary.Add(tagRunTaskCount , "0");
            this.m_dictionary.Add(tagNotesCount , "0");
            this.m_dictionary.Add(tagCategoriesCount, "0");
            this.m_dictionary.Add(tagTagsCount , "0");
            this.m_dictionary.Add(tagDeletedCount , "0");

            return;
        }


        #region *** Properties ***

        //TODO:  добавить проперти для новых свойств        
        /// <summary>
        /// NR-Gets the storage version string.
        /// </summary>
        /// <value>
        /// The storage version string.
        /// </value>
        public String StorageVersionString
        {
            get { return this.m_dictionary[tagStorageVersion];  }
            internal set { this.m_dictionary[tagStorageVersion] = value; }
        }
        /// <summary>
        /// NR-Получить квалифицированое имя Хранилища
        /// </summary>
        public String QualifiedName
        {
            get { return this.getValueAsString(tagQualifiedName); }
            set { this.setValue(tagQualifiedName, value); }
        }
        /// <summary>
        /// NT-Получить строку типа Хранилища
        /// </summary>
        public string StorageType
        {
            get { return this.getValueAsString(tagStorageType); }
            set { this.setValue(tagStorageType, value); }
        }

        /// <summary>
        /// NT-Gets the size of the database.
        /// </summary>
        /// <value>
        /// The size of the database.
        /// </value>
        public Int64 DatabaseSize
        {
            get
            {
                return this.getValueAsInt64(tagDatabaseSize);
            }
            internal set
            {
                this.setValue(tagDatabaseSize, value);
            }
        }

        /// <summary>
        /// NT-Размер архивов документов
        /// </summary>
        public Int64 DocsSize
        {
            get
            {
                return this.getValueAsInt64(tagDocsSize);
            }
            internal set
            {
                this.setValue(tagDocsSize, value);
            }
        }

        /// <summary>
        /// NT-Число файлов в архивах документов
        /// </summary>
        public int DocsCount
        {
            get
            {
                return this.getValueAsInt32(tagDocsCount);
            }
            internal set
            {
                this.setValue(tagDocsCount, value);
            }
        }
        /// <summary>
        /// NT-общее количество задач.
        /// </summary>
        /// <value>
        /// The task count.
        /// </value>
        public int TaskCount
        {
            get
            {
                return this.getValueAsInt32(tagTaskCount);
            }
            internal set
            {
                this.setValue(tagTaskCount, value);
            }
        }
        /// <summary>
        /// количество приостановленных задач.
        /// </summary>
        /// <value>
        /// The stopped task count.
        /// </value>
        public int StoppedTaskCount
        {
            get
            {
                return this.getValueAsInt32(tagStoppedTaskCount);
            }
            internal set
            {
                this.setValue(tagStoppedTaskCount, value);
            }
        }
        /// <summary>
        /// количество выполненных задач.
        /// </summary>
        /// <value>
        /// The finished task count.
        /// </value>
        public int FinishedTaskCount
        {
            get
            {
                return this.getValueAsInt32(tagFinishedTaskCount);
            }
            internal set
            {
                this.setValue(tagFinishedTaskCount, value);
            }
        }
        /// <summary>
        /// количество Задач для выполнения
        /// </summary>
        /// <value>
        /// The run task count.
        /// </value>
        public int RunTaskCount
        {
            get
            {
                return this.getValueAsInt32(tagRunTaskCount);
            }
            internal set
            {
                this.setValue(tagRunTaskCount, value);
            }
        }
        /// <summary>
        /// количество Заметок.
        /// </summary>
        /// <value>
        /// The notes count.
        /// </value>
        public int NotesCount
        {
            get
            {
                return this.getValueAsInt32(tagNotesCount);
            }
            internal set
            {
                this.setValue(tagNotesCount, value);
            }
        }
        /// <summary>
        /// количество Категорий.
        /// </summary>
        /// <value>
        /// The categories count.
        /// </value>
        public int CategoriesCount
        {
            get
            {
                return this.getValueAsInt32(tagCategoriesCount);
            }
            internal set
            {
                this.setValue(tagCategoriesCount, value);
            }
        }
        /// <summary>
        /// количество Тегов.
        /// </summary>
        /// <value>
        /// The tags count.
        /// </value>
        public int TagsCount
        {
            get
            {
                return this.getValueAsInt32(tagTagsCount);
            }
            internal set
            {
                this.setValue(tagTagsCount, value);
            }
        }
        /// <summary>
        /// Количество удаленных элементов (в Корзине).
        /// </summary>
        /// <value>
        /// The deleted count.
        /// </value>
        public int DeletedCount
        {
            get
            {
                return this.getValueAsInt32(tagDeletedCount);
            }
            internal set
            {
                this.setValue(tagDeletedCount, value);
            }
        }


        #endregion

        /// <summary>
        /// NT-проверить что файл настроек читается и правильный.
        /// Исключений не выбрасывает.
        /// </summary>
        /// <param name="filePath">Путь к файлу настроек</param>
        /// <returns>Возвращает объект информации о хранилище или null</returns>
        public static new TaskEngineSettings TryLoad(string filePath)
        {
            TaskEngineSettings result = null;
            try
            {
                result = LoadFile(filePath, true);
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// NT-Загрузить файл настроек движка,
        /// проверить значения настроек на допустимость.
        /// </summary>
        /// <param name="storagePath">Корневой каталог проекта данных движка</param>
        /// <returns>Возвращает объект информации о хранилище.</returns>
        public static new TaskEngineSettings Load(String storagePath)
        {
            String filePath = Path.Combine(storagePath, EngineSettingsBase.DescriptionFileName);
            return LoadFile(filePath, true);
        }
        /// <summary>
        /// NT-Загрузить файл настроек движка
        /// </summary>
        /// <param name="filePath">Путь к файлу настроек</param>
        /// <param name="validate">Проверить значения на допустимость</param>
        /// <re
        public static new TaskEngineSettings LoadFile(string filePath, bool validate)
        {
            TaskEngineSettings si = new TaskEngineSettings();
            si.LoadFromFile(filePath);
            if (validate) si.Validate();
            return si;
        }



        /// <summary>
        /// NT-Получить текущую версию  сборки Движка.
        /// </summary>
        /// <returns></returns>
        public override Version getCurrentEngineVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
        /// <summary>
        /// NT-Получить класс Сущности Движка.
        /// Он нужен, чтобы раличать движки и их Каталог Проекта между собой.
        /// </summary>
        /// <returns>
        /// Возвращает строковый идентификатор класса Сущности Движка
        /// </returns>
        public override string getEngineClass()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
        /// <summary>
        /// NT-Проверить допустимость версии движка из проекта
        /// </summary>
        /// <param name="version">Проверяемая версия движка</param>
        /// <returns>
        /// Возвращает True, если версии совместимы, False в противном случае.
        /// </returns>
        /// <remarks>
        /// Должны совпадать Version.Major и Version.Minor значения.
        /// Если для Движка принята другая концепция совместимости версий, эту функцию надо переопределить в производном классе.
        /// </remarks>
        public override bool isCompatibleEngineVersion(Version version)
        {
            Version curVersion = this.getCurrentEngineVersion();
            return ((curVersion.Major == version.Major) && (curVersion.Minor == version.Minor));
        }
        /// <summary>
        /// NT-получить строковое представление объекта для отладчика
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString();//показывает число записей в словаре
        }
        /// <summary>
        /// NT-Переопределите функцию в производном классе для загрузки дополнительных свойств Хранилища.
        /// </summary>
        /// <param name="rd">Объект ридера</param>
        protected override void loadUserData(XmlReader rd)
        {
            this._readElement(rd, tagStorageVersion);
            this._readElement(rd, tagQualifiedName);
            this._readElement(rd, tagStorageType);
            this._readElement(rd, tagDatabaseSize);
            this._readElement(rd, tagDocsCount);
            this._readElement(rd, tagDocsSize);
            this._readElement(rd, tagTaskCount);
            this._readElement(rd, tagRunTaskCount);
            this._readElement(rd, tagStoppedTaskCount);
            this._readElement(rd, tagFinishedTaskCount);
            this._readElement(rd, tagNotesCount);
            this._readElement(rd, tagCategoriesCount);
            this._readElement(rd, tagTagsCount);
            this._readElement(rd, tagDeletedCount);

            return;
        }
        /// <summary>
        /// NT-Переопределите функцию в производном классе для выгрузки дополнительных свойств Хранилища.
        /// </summary>
        /// <param name="wr">Xml-писатель</param>
        protected override void storeUserData(XmlWriter wr)
        {
            this._writeElement(wr, tagStorageVersion);
            this._writeElement(wr, tagQualifiedName);
            this._writeElement(wr, tagStorageType);
            this._writeElement(wr, tagDatabaseSize);
            this._writeElement(wr, tagDocsCount);
            this._writeElement(wr, tagDocsSize);
            this._writeElement(wr, tagTaskCount);
            this._writeElement(wr, tagRunTaskCount);
            this._writeElement(wr, tagStoppedTaskCount);
            this._writeElement(wr, tagFinishedTaskCount);
            this._writeElement(wr, tagNotesCount);
            this._writeElement(wr, tagCategoriesCount);
            this._writeElement(wr, tagTagsCount);
            this._writeElement(wr, tagDeletedCount);

            return;
        }
        /// <summary>
        /// NT-Переопределите функцию в производном классе для проверки значений дополнительных свойств Хранилища.
        /// </summary>
        protected override void validateUserData()
        {
            //тут в свойствах нечего пока проверять
            return;
        }
    }
}
