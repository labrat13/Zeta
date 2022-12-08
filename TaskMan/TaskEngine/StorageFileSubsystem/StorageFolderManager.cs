using System;
using System.Collections.Generic;
using System.IO;
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
        public const string DocumentStorageFolderName = "Files";
        #endregion

        #region Поля

        /// <summary>
        /// Путь к основному каталогу Хранилища.
        /// </summary>
        private string m_MainFolderPath;
        /// <summary>
        /// Путь к каталогу документов Хранилища.
        /// </summary>
        private string m_FileStorageFolderPath;
        /// <summary>
        /// Обратная ссылка на движок
        /// </summary>
        private CEngine m_Engine;//проперти не нужно здесь

        #endregion

        /// <summary>
        /// NT-Конструктор
        /// </summary>
        /// <param name="engine">Обратная ссылка на движок</param>
        public StorageFolderManager(CEngine engine, String storagePath)
        {
            this.m_Engine = engine;
            this.m_MainFolderPath = storagePath;
            this.m_FileStorageFolderPath = Path.Combine(m_MainFolderPath, StorageFolderManager.DocumentStorageFolderName);

            //TODO: Add code here...
        }

        #region Проперти

        /// <summary>
        /// Путь к основному каталогу Хранилища.
        /// </summary>
        public string MainFolderPath
        {
            get
            {
                return this.m_MainFolderPath;
            }
            //set
            //{
            //    m_MainFolderPath = value;
            //}
        }

        /// <summary>
        /// Database file path
        /// </summary>
        public string DbFilePath
        {
            get
            {
                return Path.Combine(m_MainFolderPath, SqliteDbAdapter.DatabaseFileName);
            }
        }
        /// <summary>
        /// Путь к каталогу документов Хранилища.
        /// </summary>
        /// <value>
        /// The document storage folder path.
        /// </value>
        public string DocumentStorageFolderPath
        { 
            get { return this.m_FileStorageFolderPath; } 
        }   

        #endregion

        /// <summary>
        /// NR-Получить текстовое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Dir={0}", this.m_MainFolderPath);
        }

        /// <summary>
        /// NR-Создать каталог Хранилища
        /// </summary>
        /// <param name="prjFolder">Путь к еще не существующему каталогу Хранилища</param>
        internal static void CreateStorageFolder(string prjFolder, TaskEngineSettings sett)
        {
            ////check folder is not exists
            //if (Directory.Exists(prjFolder))
            //    throw new ArgumentException(String.Format("Directory already exists: {0}", prjFolder), "prjFolder");
            ////create project folder with all files and folders
            //Utility.CreateNotIndexedFolder(prjFolder);
            ////1 create db file
            //String path = Path.Combine(prjFolder, SqliteDbAdapter.DatabaseFileName);
            //DbAdapter.extractDbFile(path);
            ////2 create setting file
            //path = Path.Combine(prjFolder, EngineSettings.DescriptionFileName);
            //sett.Store(path);
            ////3 create other elements...
            ////TODO: Project folder create: create other files and folders

            return;
        }

        /// <summary>
        /// NR-Проверить, что указанный каталог является каталогом Хранилища
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <returns>Возвращает true, если каталог является каталогом Хранилища. В противном случае возвращает false.</returns>
        public static bool IsStorageFolder(string path)
        {
            ////Этот код только для примера, его нужно переписать
            ////TODO: сделать качественно функцию IsProjectFolder()
            ////проверить:
            ////1 что это не пустая строка
            //if (String.IsNullOrEmpty(path)) return false;
            ////2 что это каталог и он существует
            //if (!Directory.Exists(path)) return false;
            ////3 что это каталог проекта движка

            ////критерии:
            ////папка должна содержать файл "settings.xml"
            ////папка должна содержать файл db.mdb
            ////папка должна содержать ... TODO: добавить признаки каталога данных проекта здесь
            ////файл "settings.xml" должен читаться без проблем

            //String p;

            ////проверяем наличие обязательных файлов и каталогов
            ////p = Path.Combine(path, ArchiveController.DocumentsDir); - пример
            ////if (!Directory.Exists(p)) return false;

            ////проверяем наличие файла БД
            //p = Path.Combine(path, SqliteDbAdapter.DatabaseFileName);
            //if (!File.Exists(p)) return false;
            ////напоследок пытаемся загрузить и прочитать файл настроек движка
            //p = Path.Combine(path, EngineSettings.DescriptionFileName);
            //if (!File.Exists(p)) return false;
            ////try load description file
            //if (EngineSettings.TryLoad(p) == null) return false;

            return true;
        }

        /// <summary>
        /// NT-Проверить что каталог Хранилища только для чтения
        /// </summary>
        /// <returns></returns>
        public bool isReadOnly()
        {
            return StringUtility.isReadOnly(this.m_MainFolderPath);
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
            //info.ReadOnly = StringUtility.isReadOnly(this.m_MainFolderPath);
            //database size
            FileInfo fi = new FileInfo(this.DbFilePath);
            info.DatabaseSize = fi.Length;
            //doc count and doc size
            DirectoryInfo dirInfo = new DirectoryInfo(this.m_FileStorageFolderPath);
            FileInfo[] fis = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            info.DocsCount = fis.Length;
            long len = 0;
            foreach(FileInfo fi2 in fis)
                len += fi2.Length;
            info.DocsSize = len;

            return;
        }

    }
}
