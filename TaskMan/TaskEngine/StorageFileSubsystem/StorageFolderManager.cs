using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using TaskEngine.SettingSubsystem;

namespace TaskEngine.StorageFileSubsystem
{
    /// <summary>
    /// NR-Это класс, управляющий Каталогом данных проекта.
    /// </summary>
    public class StorageFolderManager
    {

        //Структура папок:
        //  - Каталог Хранилища
        //    - БД Хранилища
        //    - ФайлСвойствХранилища
        //    - Files           - каталог раздела файлового склада материалов для элементов
        //      - TASK001       - каталог материалов к задаче с ид = 001
        //      - CAT002        - каталог материалов к категории с ид=002
        //      - 2023-01-01    - каталог материалов на дату 01012023.


        #region Константы        
        /// <summary>
        /// The document storage folder name
        /// </summary>
        public const string DocumentStorageFolderName = "Files";
        /// <summary>
        /// The database file backup extension - for database backup procedure
        /// </summary>
        public const string DatabaseFileBackupExtension = ".backup";
        #endregion

        #region Поля
        /// <summary>
        /// Обратная ссылка на движок
        /// </summary>
        private CEngine m_Engine;//проперти не нужно здесь
        /// <summary>
        /// Флаг что данный объект был инициализирован
        /// </summary>
        private bool m_Ready;

        /// <summary>
        /// Is Storage folder in ReadOnly mode.
        /// </summary>
        private bool m_ReadOnly;
        /// <summary>
        /// Путь к основному каталогу Хранилища.
        /// </summary>
        private string m_MainFolderPath;
        ///// <summary>
        ///// Путь к каталогу документов Хранилища.
        ///// </summary>
        //private string m_DocumentStorageFolderPath;
        ///// <summary>
        ///// Путь к файлу БД - для открытия БД и процедуры ее бекапа.
        ///// </summary>
        //private string m_DatabaseFilePath;
        #endregion

        /// <summary>
        /// NT-Конструктор
        /// </summary>
        /// <param name="engine">Обратная ссылка на движок</param>
        public StorageFolderManager(CEngine engine)
        {
            this.m_Ready = false;
            this.m_Engine = engine;
            this.m_ReadOnly = false;
            this.m_MainFolderPath = null;
            //this.m_DocumentStorageFolderPath = null;
            //this.m_DatabaseFilePath = null;

            //TODO: Add code here...
            return;
        }



        //TODO: посмотреть в документации, что происходит с наследованием классов и деструктором в них - надо ли переопределять деструкторы в производных классах и как быть вообще.
        /// <summary>
        /// NT-Деструктор объекта
        /// </summary>
        ~StorageFolderManager()
        {
            //вызвать завершение работы в деструкторе, если он не был нормально завершен ранее.
            Close();
        }


        #region Проперти

        /// <summary>
        /// NT- Получить флаг готовности подсистемы.
        /// </summary>
        public bool IsReady
        {
            get { return this.m_Ready; }
        }

        /// <summary>
        /// NT- Получить флаг ReadOnly подсистемы.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.m_ReadOnly; }
        }

        /// <summary>
        /// Путь к основному каталогу Хранилища.
        /// </summary>
        public string MainFolderPath
        {
            get
            {
                return this.m_MainFolderPath;
            }
        }
        /// <summary>
        /// NT-Gets the storage information file path.
        /// </summary>
        /// <value>
        /// The storage information file path.
        /// </value>
        public string StorageInfoFilePath
        {
            get { return getStorageInfoFilePath(this.m_MainFolderPath); }
        }

        /// <summary>
        /// NT-Gets the database file path
        /// </summary>
        public string DatabaseFilePath
        {
            get { return getDatabaseFilePath( m_MainFolderPath); }
        }
        /// <summary>
        /// NT-Gets the database backup file path.
        /// </summary>
        public string DatabaseBackupFilePath
        {
            get { return this.DatabaseFilePath + StorageFolderManager.DatabaseFileBackupExtension; }
        }
        /// <summary>
        /// NT-Получить путь к каталогу документов Хранилища.
        /// </summary>
        public string DocumentStorageFolderPath
        { 
            get { return getDocumentFolder(this.m_MainFolderPath); } 
        }   

        #endregion

        /// <summary>
        /// NT-Получить текстовое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Ready={0}; ReadOnly={1}; Dir={2}", this.m_Ready, this.m_ReadOnly, this.m_MainFolderPath);
        }

        /// <summary>
        /// NT- Initialize subsystem.
        /// </summary>
        /// <param name="storageFolderPath">Путь к каталогу Хранилища.</param>
        /// <param name="readOnly">Флаг, считать ли каталог принудительно как ТолькоДляЧтения.</param>
        public void Open(String storageFolderPath, bool readOnly)
        {
            if (this.m_Ready == false)
            {
                // тут выполнить инициализацию подсистемы.
                this.m_ReadOnly = readOnly;
                this.m_MainFolderPath = storageFolderPath;
                //this.m_DocumentStorageFolderPath = Path.Combine(m_MainFolderPath, StorageFolderManager.DocumentStorageFolderName);
                //this.DatabaseFilePath = Path.Combine(m_MainFolderPath, TaskDbAdapter.DatabaseFileName);
                //TODO: add Open() code here

                // mark object as initialized
                this.m_Ready = true;
            }

            return;
        }

        /// <summary>
        /// NT-Deinitialize subsystem.
        /// </summary>
        public void Close()
        {
            if (this.m_Ready == true)
            {
                //TODO:  тут выполнить де-инициализацию подсистемы.
                this.m_ReadOnly = false;
                this.m_MainFolderPath = null;

                // clear init flag
                this.m_Ready = false;
            }

            return;
        }


        /// <summary>
        /// NT-Создать каталог Хранилища
        /// </summary>
        /// <param name="storageFolderPath">Путь к еще не существующему каталогу Хранилища</param>
        internal static void CreateStorageFolder(string storageFolderPath, TaskEngineSettings sett)
        {
            //check folder is not exists
            if (Directory.Exists(storageFolderPath))
                throw new ArgumentException(String.Format("Directory already exists: {0}", storageFolderPath), "storageFolderPath");
            //create storage folder with all files and folders
            StringUtility.CreateNotIndexedFolder(storageFolderPath);
            //1 create db file
            String path = getDatabaseFilePath(storageFolderPath);
            TaskDbAdapter.CreateNewDatabase(null, path);//ссылка на движок не используетс яв адаптере БД, поэтому передаем null.
            //2 create setting file
            path = getStorageInfoFilePath(storageFolderPath);
            sett.Store(path);
            //3 create Documents folder
            path = getDocumentFolder(storageFolderPath);
            StringUtility.CreateNotIndexedFolder(path);
            //вроде все тут...

            return;
        }
        /// <summary>
        /// NT-Сделать бекап-копию файла БД при запуске приложения. Файл БД еще не открыт, адаптер БД не инициализирован.
        /// </summary>
        internal void DatabaseFileBackup()
        {
            //файл БД еще не открыт, адаптер БД не инициализирован.
            //получить путь к файлу БД
            String src = DatabaseFilePath;
            if (File.Exists(src) == false)
                throw new Exception("Исходный файл БД Хранилища не найден: " + src);
            //получить путь к бекап-копии файла БД
            String dst = DatabaseBackupFilePath;
            //удалить старую бекап-копию файла БД, если она есть.
            if (File.Exists(dst))
                StringUtility.DeleteFile(dst);
            //скопировать файл БД как есть.
            File.Copy(src, dst);
            //set archive attribute to backup
            File.SetAttributes(dst, FileAttributes.ReadOnly | FileAttributes.NotContentIndexed | FileAttributes.Archive);
            
            return;
        }

        /// <summary>
        /// NT-Проверить, что указанный каталог является каталогом Хранилища
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <returns>Возвращает true, если каталог является каталогом Хранилища. В противном случае возвращает false.</returns>
        public static bool IsStorageFolder(string path)
        {
            //проверить:
            //1 что это не пустая строка
            if (String.IsNullOrEmpty(path)) return false;
            //2 что это каталог и он существует
            if (!Directory.Exists(path)) return false;
            //3 что это каталог проекта движка

            //критерии:
            //папка должна содержать файл "settings.xml"
            //папка должна содержать файл db.mdb
            //папка должна содержать ... TODO: добавить признаки каталога данных проекта здесь
            //файл "settings.xml" должен читаться без проблем
            String p;
            //проверяем наличие обязательных файлов и каталогов
            //проверяем наличие каталога документов
            p = getDocumentFolder(path);
            if (!Directory.Exists(p)) 
                return false;
            //проверяем наличие файла БД
            p = getDatabaseFilePath(path);//Path.Combine(path, SqliteDbAdapter.DatabaseFileName);
            if (!File.Exists(p)) return false;
            //напоследок пытаемся загрузить и прочитать файл настроек движка
            p = getStorageInfoFilePath(path);//Path.Combine(path, EngineSettings.DescriptionFileName);
            if (!File.Exists(p)) return false;
            //try load description file
            if (TaskEngineSettings.TryLoad(p) == null) 
                return false;

            return true;
        }

        /// <summary>
        /// NT-Проверить что каталог Хранилища только для чтения
        /// </summary>
        /// <returns></returns>
        public bool isReadOnlyStorageFolder()
        {
            return StringUtility.isReadOnlyFolder(this.m_MainFolderPath);
        }

        /// <summary>
        /// NT-Fills the storage information object.
        /// </summary>
        /// <param name="info">the storage information object</param>
        internal void fillStorageInfo(TaskEngineSettings info)
        {
            //TODO: тут должны быть заполнены поля:
            //info.DatabaseSize
            //info.DocsCount
            //info.DocsSize
            //info.StoragePath
            //info.ReadOnly

            info.StoragePath = this.m_MainFolderPath;
            //read-only flag copy from source only!! Already copied by caller
            //info.ReadOnly = StringUtility.isReadOnlyFolder(this.m_MainFolderPath);
            //database size
            FileInfo fi = new FileInfo(this.DatabaseFilePath);
            info.DatabaseSize = fi.Length;
            //doc count and doc size
            DirectoryInfo dirInfo = new DirectoryInfo(this.DocumentStorageFolderPath);
            FileInfo[] fis = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            info.DocsCount = fis.Length;
            long len = 0;
            foreach(FileInfo fi2 in fis)
                len += fi2.Length;
            info.DocsSize = len;

            return;
        }


        #region *** Вспомогательные функции ***

        /// <summary>
        /// NT-Собрать путь к каталогу документов Хранилища.
        /// </summary>
        /// <param name="path">Путь основного каталога Хранилища</param>
        /// <returns>Функция возвращает собранный путь.</returns>
        private static string getDocumentFolder(string path)
        {
            return Path.Combine(path, StorageFolderManager.DocumentStorageFolderName);
        }
        /// <summary>
        /// NT-Собрать путь к файлу БД Хранилища.
        /// </summary>
        /// <param name="path">Путь основного каталога Хранилища</param>
        /// <returns>Функция возвращает собранный путь.</returns>
        private static string getDatabaseFilePath(string path)
        {
            return Path.Combine(path, TaskDbAdapter.DatabaseFileName);
        }
        /// <summary>
        /// NT-Собрать путь к файлу свойств Хранилища.
        /// </summary>
        /// <param name="path">Путь основного каталога Хранилища</param>
        /// <returns>Функция возвращает собранный путь.</returns>
        private static string getStorageInfoFilePath(string path)
        {
            return Path.Combine(path, TaskEngineSettings.DescriptionFileName);
        }
        #endregion

    }
}
