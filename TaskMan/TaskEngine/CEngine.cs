using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TaskEngine.SettingSubsystem;
using TaskEngine.SolutionSubsystem;

namespace TaskEngine
{
    /// <summary>
    /// NR-Движок менеджера задач, подобный УАМХ.
    /// </summary>
    /// <remarks>
    /// + ВАЖНО: Для определения совместимости движка и данных Хранилищ используется версия сборки.
    ///  А именно - поля Major и Minor версии движка должны совпадать у движка и у всех наборов данных.
    ///  Поэтому при несущественных переделках движка можно изменять только младшие поля.
    ///  А при существенных переделках нужно изменять поле Minor, и это потребует конвертировать все ранее созданные наборы данных.
    ///  Которые все равно придется конвертировать из-за существенных изменений в движке.
    /// + ВАЖНО: Название сборки Движка используется в качестве имени класса Движка. 
    ///  Класс Движка введен для того, чтобы по свойствам Хранилища из ФайлаНастроекХранилища находить Движок, который должен его открыть.
    ///  Сборка движка поэтому должна называться очень тематическим, уникальным, оригинальным именем.
    ///  А не "Engine".
    /// 
    /// </remarks>
    public class CEngine
    {
        //TODO: написать правильный код функций работы с солюшеном.
        //TODO: написать правильный код подсистемы настроек солюшена.
        //TODO: добавить логику операций с элементами как функции движка перед адаптером БД.:
        //- удалить тег можно только если он не используется в элементах.
        //-- запрос ид элементов по ид тега в таблице Tagged должен быть пустой.
        //- удалить элементы кроме тегов можно, если они не являются родительскими к другим элементам.
        //-- запрос списка элементов по parentid должен быть пустой.
        
        /// <summary>
        /// Флаг, что движок работает в режиме Только чтение.
        /// </summary>
        protected bool m_ReadOnly;

        /// <summary>
        /// Менеджер уникальных идентификаторов элементов.
        /// </summary>
        private CElementIdManager m_idManager;
        /// <summary>
        /// Адаптер БД 
        /// </summary>
        protected TaskDbAdapter m_dbAdapter;

        /// <summary>
        /// Объект настроек проекта движка
        /// </summary>
        protected TaskEngineSettings m_settings;
        /// <summary>
        /// Менеджер файловой системы проекта данных движка
        /// </summary>
        protected SolutionManager m_SolutionManager; //проперти для него пока не делаем, потом видно будет.        
        /// <summary>
        /// NR-Initializes a new instance of the <see cref="CEngine"/> class.
        /// </summary>
        public CEngine()
        {

            //TODO: add code here
            //создать пакет настроек по умолчанию, пока для отладки.
            this.m_settings = new TaskEngineSettings();
            //ElementIdManager нельзя здесь инициализировать, так как ему нужна присоединенная БД.
            //его надо инициализировать в Open()
            this.m_idManager = null;
            this.m_dbAdapter = null;


            return;
        }

        #region *** Проперти движка ***

        /// <summary>
        /// Флаг, что движок работает в режиме Только чтение.
        /// </summary>
        public bool ReadOnly
        {
            get { return m_ReadOnly; }
        }

        //Хотя адаптер БД нужен, проперти на него вряд ли потребуется где-то вне сборки
        //А в сборке он не должен быть виден снаружи Движка. 
        /// <summary>
        /// Адаптер БД для хранения элементов
        /// </summary>
        public TaskDbAdapter DbAdapter
        {
            get { return m_dbAdapter; }
        }

        /// <summary>
        /// Объект настроек проекта движка
        /// </summary>
        public TaskEngineSettings Settings
        {
            get { return m_settings; }
        }
        /// <summary>
        /// Gets the solution manager
        /// </summary>
        internal SolutionManager Solution
        {
            get { return this.m_SolutionManager; }
        }

        /// <summary>
        /// NT-Получить текущую версию движка
        /// </summary>
        public Version EngineVersion
        {
            get { return StringUtility.getCurrentEngineVersion(); }
        }

        #endregion

        #region *** Главные функции движка ***
        //Использовать "static new" вместо "static" при переопределении статических функций в производных классах
        /// <summary>
        /// NT-Создать новое Хранилище
        /// </summary>
        /// <param name="rootFolder">The root path, must be exists!</param>
        /// <param name="title">The solution title.</param>
        /// <exception cref="System.Exception">
        /// Specified path is not found or Solution already exists
        /// </exception>
        public static void SolutionCreate(String rootFolder, TaskEngineSettings si) //String title)
        {
            ////0 проверить аргументы
            //if (!Directory.Exists(rootFolder)) throw new ArgumentException("Root folder must be exists", "rootFolder");
            //if (si == null) throw new ArgumentNullException("si", "Engine settings object cannot be null");
            //if (String.IsNullOrEmpty(si.Title)) throw new ArgumentException("Project title cannot be empty");
            ////1 создать каталог данных проекта
            //String prjSafeName = Utility.makeSafeFolderName(si.Title);
            //String prjFolder = Path.Combine(rootFolder, prjSafeName);
            ////  записать правильный путь к проекту в переданный объект EngineSettings
            //si.StoragePath = prjFolder;
            //ProjectFolderManager.CreateProjectFolder(prjFolder, si);
            ////не буду тут открывать движок, его некуда возвращать. Потом откроем соответствующей фукцией.
            //////2 открыть движок, чтобы проверить и записать данные если нужно.
            //////3 закрыть движок

            ////TODO: добавить дополнительный код создания движка менеджера проектов


            //если корневой каталог не существует, выдать сообщение об ошибке.
            if (!Directory.Exists(rootFolder))
                throw new Exception("Specified path is not found");
            string homeFolder = Path.Combine(rootFolder, StringUtility.MakeSafeTitle(title));
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
        /// NT-Открыть Хранилище
        /// </summary>
        /// <param name="solutionFolder">Путь к каталогу данных Хранилища</param>
        /// <param name="readOnly">Открыть только для чтения</param>
        public void SolutionOpen(string solutionFolder, bool readOnly)
        {
            ////1 инициализировать менеджер каталога проекта движка
            //this.m_StorageFolderManager = new ProjectFolderManager(this, storagePath);
            ////2 загрузить настройки движка
            //this.m_settings = EngineSettings.Load(storagePath);
            ////3 проверить что каталог доступен для записи
            ////если каталог проекта реально рид-онли или пользователь хочет рид-онли, или настройки проекта - рид-онли, то выставляем рид-онли флаг.
            //this.m_ReadOnly = (this.m_StorageFolderManager.isReadOnly() || readOnly || m_settings.ReadOnly);
            ////4 инициализировать адаптер БД и подключиться к БД, даже в рид-онли режиме
            ////String dbpath = Path.Combine(storagePath, PMEngine.DbAdapter.DatabaseFileName); 
            //this.m_dbAdapter = PMEngine.DbAdapter.SetupDbAdapter(this.m_StorageFolderManager.DbFilePath, this.m_ReadOnly);
            ////5 инициализировать менеджер идентификаторов элементов
            ////создать объект менеджера идентификаторов, он уже требует доступной БД для подсчета максимального существующего ИД
            //this.m_IdManager = new МенеджерИдентификаторовЭлемента(this);
            //this.m_IdManager.InitCacheValues();//init id manager - read db
            ////TODO: добавить дополнительный код открытия движка менеджера проектов
            ////загрузить префикс ссылок в классы
            //String prefix = this.m_settings.LinkPrefix.Trim();
            //ElementId.Init(prefix.Substring(0, 1));
            //ElementLink.Init(prefix);


            //init solution folder manager
            String databaseFilePath = Path.Combine(solutionFolder, TaskDbAdapter.DatabaseFileName);

            //инициализировать адаптер БД
            this.m_dbAdapter = new TaskDbAdapter(this);
            //открыть БД
            String connectionString = TaskDbAdapter.CreateConnectionString(databaseFilePath, false);
            this.m_dbAdapter.Open(connectionString);
            //получить максимальный ид элемента из БД и инициализировать менеджер идентификаторов элементов. 
            int maxid = this.m_dbAdapter.GetElementsMaxId();
            //если записей элементов нет, функция вернет -1, а нужен хотя бы 0.
            if (maxid <= 0) maxid = 0;
            //установить полученный ид как текущий в менеджере
            this.m_idManager = new CElementIdManager(maxid);
            //close database
            this.m_dbAdapter.Close();


            return;
        }

        /// <summary>
        /// NT-Завершить сеанс работы движка
        /// </summary>
        public void SolutionClose()
        {
            ////1 close ID manager
            //this.m_IdManager = null;
            ////2 close database adapter
            //this.m_dbAdapter.Disconnect();
            //this.m_dbAdapter = null;
            ////3 настройки сейчас сохранять надо сразу после изменения, а не в конце работы движка.
            ////поэтому тут их не сохраняем.
            ////4 менеджер каталога сейчас ничего не содержит такого, чтобы его специально закрывать.
            //this.m_ReadOnly = false;
            //this.m_StorageFolderManager = null;
            ////TODO: добавить дополнительный код закрытия движка менеджера проектов

            //return;


            this.m_dbAdapter.Close();
        }

        //TODO: сбор статистики Хранилища - как это унифицировать?
        //- как словарь ключ-значение
        //- каждый элемент словаря - представлен текстовым ключом-названием и цифровым значением
        //- или текстовым названием, типом данных и значением?
        //Все равно эта статистика нужна только пользователю посмотреть сколько чего в Хранилище.
        //Отложу это на потом - если пригодится.

        ///// <summary>
        ///// NR-
        ///// </summary>
        //public virtual void StorageGetStatistics()
        //{

        //    ////TODO: добавить код сбора статистики Хранилища здесь
        //    throw new System.NotImplementedException();
        //}

        ///// <summary>
        ///// NR-Оптимизация проекта - незакончено, неясно как сделать и как использовать потом
        ///// </summary>
        //public virtual void StorageOptimize()
        //{
        //    //CheckReadOnly();
        //    ////TODO: добавить код оптимизаци Хранилища здесь
        //    throw new System.NotImplementedException();
        //}

        //Функция очистки. Ни разу не пользовался, проще создать новый проект. Но для комплекта тут реализована.
        ///// <summary>
        ///// NFT-Очистить проект
        ///// </summary>
        ///// <returns>Return True if success, False otherwise</returns>
        //public bool StorageClear()
        //{
        //    CheckReadOnly();
        //    //Тут очищаем все таблицы БД кроме таблицы свойств, удаляем все архивы, пересчитываем статистику и вносим ее в БД.
        //    //в результате должно получиься пустое Хранилище, сохранившее свойства - имя, квалифицированное имя, путь итп.
        //    if (m_db.ClearDb() == true)
        //    {
        //        m_docController.Clear();
        //        m_picController.Clear();
        //        this.updateStorageInfo();//это будет выполнено также при закрытии менеджера.
        //        return true;
        //    }
        //    else return false;
        //}

        /// <summary>
        /// NT-Проверить, что указанный каталог является каталогом Хранилища
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <returns>Возвращает true, если каталог является каталогом Хранилища. В противном случае возвращает false</returns>
        public static bool IsSolutionFolder(string path)
        {
            return SolutionManager.IsSolutionFolder(path);
        }

        /// <summary>
        /// NR-Удалить Хранилище
        /// </summary>
        /// <param name="storagePath">Путь к каталогу Хранилища</param>
        /// <returns>Возвращает true, если Хранилище успешно удалено или его каталог не существует.
        /// Возвращает false, если удалить Хранилище не удалось по какой-либо причине.</returns>
        public static bool StorageDelete(String storagePath)
        {
            //Этот код только для примера, его нужно переписать
            throw new System.NotImplementedException();//TODO: add code here

            ////если каталог не существует, возвращаем  true
            //if (!Directory.Exists(storagePath)) return true;
            ////1) если Хранилище на диске только для чтения, то вернуть false.
            //if (isReadOnly(storagePath)) return false;
            ////2) пробуем переименовать каталог Хранилища
            ////если получится, то каталог никем не используется. удалим каталог и вернем true.
            ////иначе будет выброшено исключение - перехватим его и вернем false
            ////сначала еще надо сгенерировать такое новое имя каталога, чтобы незанятое было.
            //String newName = String.Empty;
            //String preRoot = Path.GetDirectoryName(storagePath);
            //for (int i = 0; i < 16384; i++)
            //{
            //    newName = Path.Combine(preRoot, "tmp" + i.ToString());
            //    if (!Directory.Exists(newName)) break;
            //}
            ////тут мы должны оказаться с уникальным именем
            //if (Directory.Exists(newName))
            //    throw new Exception("Error! Cannot create temp directory name!");
            ////пробуем переименовать каталог
            //try
            //{
            //    Directory.Move(storagePath, newName);
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            ////каталог не используется, удалим его
            ////TODO: вот лучше бы его через шелл и в корзину удалить. Хотя... Удалять же будет не приложение. Некому показывать шелл.
            ////Надо это решить как удобнее будет. Может, через аргументы передавать способ - с гуем в корзину или нет.
            //Directory.Delete(newName, true);
            ////если тут возникнут проблемы, то хранилище все равно уже будет повреждено.
            ////так что выброшенное исключение достанется вызывающему коду.
            //return true;
        }


        /// <summary>
        /// NR-зарегистрировать единственный экземпляр. Если это не так, вернуть False.
        /// </summary>
        /// <param name="uid">Уникальный строковый идентификатор приложения</param>
        public virtual bool RegisterSingleInstance(string uid)
        {
            throw new System.NotImplementedException();//TODO: add code here
        }

        /// <summary>
        /// NR-Получить текстовое представление движка для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return base.ToString();//TODO: add code here
        }

        #endregion


        #region *** BotAPI functions ***
        //TODO: добавить тут рабочие функции движка 
        #endregion

        #region *** Вспомогательные функции движка ***
        //Тут размещать внутренние функции движка

        /// <summary>
        /// NT-Проверить режим read-only и выбросить исключение
        /// </summary>
        protected void ThrowReadOnly()
        {
            if (this.m_ReadOnly == true)
                throw new Exception("Error: Writing to read-only storage!");
        }

        #endregion

    }
}