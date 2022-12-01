using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// NR-Движок менеджера задач.
    /// </summary>
    public class CEngine
    {
        /// <summary>
        /// Менеджер уникальных идентификаторов элементов.
        /// </summary>
        private CElementIdManager m_idManager;
        /// <summary>
        /// Адаптер БД 
        /// </summary>
        public TaskDbAdapter m_dbAdapter;

        public CEngine()
        {
            this.m_idManager = new CElementIdManager(0);
            
        }
        /// <summary>
        /// NT-Creates the data solution for engine
        /// </summary>
        /// <param name="rootPath">The root path, must be exists!</param>
        /// <param name="title">The solution title.</param>
        /// <exception cref="System.Exception">
        /// Specified path is not found or Solution already exists
        /// </exception>
        public static void Create(String rootPath, String title)
        {
            //если корневой каталог не существует, выдать сообщение об ошибке.
            if (!Directory.Exists(rootPath))
                throw new Exception("Specified path is not found");
            string homeFolder = Path.Combine(rootPath, StringUtility.MakeSafeTitle(title));
            //если каталог уже существует, выдать сообщение
            if (Directory.Exists(homeFolder))
                throw new Exception("Solution already exists");
            //создать каталог и всю файловую систему в нем.
            Directory.CreateDirectory(homeFolder);
            String databaseFilePath = Path.Combine(homeFolder, TaskDbAdapter.DatabaseFileName);
            TaskDbAdapter.CreateNewDatabase(null, databaseFilePath);
            //TODO: Добавить в БД фиксированные элементы

            return;
        }
        /// <summary>
        /// NR-Opens this Engine instance.
        /// </summary>
        public void Open(string solutionFolderPath)
        {
            //init solution folder manager
            String databaseFilePath = Path.Combine(solutionFolderPath, TaskDbAdapter.DatabaseFileName);

            //инициализировать адаптер БД
            this.m_dbAdapter = new TaskDbAdapter(this);
            //открыть БД
            String connectionString = TaskDbAdapter.CreateConnectionString(databaseFilePath, false);
            this.m_dbAdapter.Open(connectionString);
            //получить максимальный ид элемента из БД и инициализировать менеджер идентификаторов элементов. 
            int maxid = this.m_dbAdapter.GetElementsMaxId();
            this.m_idManager.ClaimUseNewId(maxid);
            //close database
            this.m_dbAdapter.Close();


            return;
        }

        /// <summary>
        /// NR-Closes this engine instance.
        /// </summary>
        public void Close()
        {
            this.m_dbAdapter.Close();
        }

    }
}