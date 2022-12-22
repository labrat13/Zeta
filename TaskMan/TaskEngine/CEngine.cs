using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TaskEngine.SettingSubsystem;
using TaskEngine.StorageFileSubsystem;
using TaskEngine.Utilities;

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

        #region *** Constants and fields ***

        /// <summary>
        /// Флаг, что движок работает в режиме Только чтение.
        /// </summary>
        protected bool m_ReadOnly;

        /// <summary>
        /// Флаг, что Движок открыт
        /// </summary>
        protected bool m_Ready;

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
        protected TaskStorageInfo m_settings;

        /// <summary>
        /// Менеджер файловой системы проекта данных движка
        /// </summary>
        protected StorageFolderManager m_FSM; //проперти для него пока не делаем, потом видно будет.

        #endregion

        /// <summary>
        /// NT-Initializes a new instance of the <see cref="CEngine"/> class.
        /// </summary>
        public CEngine()
        {
            this.m_ReadOnly = false;
            this.m_Ready = false;
            //создать пакет настроек по умолчанию, пока для отладки.
            this.m_settings = new TaskStorageInfo();
            this.m_idManager = new CElementIdManager(0);
            this.m_dbAdapter = new TaskDbAdapter(this);
            this.m_FSM = new StorageFolderManager(this);
            //TODO: add code here

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

        /// <summary>
        /// Флаг, что Движок открыт.
        /// </summary>
        public bool Ready
        {
            get { return m_Ready; }
        }

        //Хотя адаптер БД нужен, проперти на него вряд ли потребуется где-то вне сборки
        //TODO: решить: А в сборке он не должен быть виден снаружи Движка? 
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
        public TaskStorageInfo Settings
        {
            get { return m_settings; }
        }

        /// <summary>
        /// NT-Gets the Storage filesystem manager
        /// </summary>
        internal StorageFolderManager FSM
        {
            get { return this.m_FSM; }
        }

        /// <summary>
        /// NT-Получить текущую версию движка
        /// </summary>
        public Version EngineVersion
        {
            get { return this.m_settings.getCurrentEngineVersion(); }
        }

        #endregion

        #region *** Главные функции движка ***

        /// <summary>
        /// NT-Создать новое Хранилище
        /// </summary>
        /// <param name="rootFolder">The root path, must be exists!</param>
        /// <param name="si">Заполненный объект свойств создаваемого Хранилища.</param>
        /// <exception cref="System.Exception">
        /// Specified path is not found or Solution already exists
        /// </exception>
        public static void StorageCreate(String rootFolder, TaskStorageInfo si)
        {
            //тут флаг открытия движка или флаг ридонли не учитываются

            if (si == null) 
                throw new ArgumentNullException("si", "Объект свойств Хранилища не должен быть null.");
            //если корневой каталог не существует, выдать сообщение об ошибке.
            if (!Directory.Exists(rootFolder))
                throw new Exception("Родительский каталог для Хранилища не найден.");
            //4 проверить, что папка доступна для записи
            //  Если нет, вывести сообщение - ошибку об этом и выйти
            if (StringUtility.isReadOnlyFolder(rootFolder) == true)
                throw new Exception("Родительский каталог для Хранилища недоступен для записи.");
            //title
            if (String.IsNullOrEmpty(si.Title))
                throw new Exception(String.Format("Неправильное название Хранилища: \"{0}\"", StringUtility.GetStringTextNull(si.Title)));
            string homeFolder = Path.Combine(rootFolder, StringUtility.MakeSafeTitle(si.Title));
            //если каталог уже существует, выдать сообщение
            if (Directory.Exists(homeFolder))
                throw new Exception("Solution already exists: " + homeFolder );
            //  записать правильный путь к проекту в переданный объект EngineSettings
            si.StoragePath = homeFolder;
            //создать каталог Хранилища и всю файловую систему в нем.
            //И добавить в БД фиксированные элементы при создании БД.
            StorageFolderManager.CreateStorageFolder(homeFolder, si);

            return;
        }

        /// <summary>
        /// NT-Открыть Хранилище
        /// </summary>
        /// <param name="solutionFolder">Путь к каталогу данных Хранилища</param>
        /// <param name="readOnly">Открыть только для чтения</param>
        /// <remarks>
        /// Аргумент readOnly влияет следующим образом:
        /// - Хранилище открывается в режиме  read-only тогда, когда ФайлНастроекХранилища имеет атрибут read-only, 
        /// либо в ФайлНастроекХранилища свойство ReadOnly имеет значение True, либо аргумент readOnly данной функции 
        /// имеет значение True. В этом случае резервное копирование БД не производится, внести какие-либо изменения в Хранилище нельзя.
        /// В других случаях Хранилище открываается в нормальном режиме, выполняется резервное копирование БД, изменения в Хранилище сохраняются.
        /// </remarks>
        public void StorageOpen(string solutionFolder, bool readOnly)
        {
            //заблокировать вызов функции, если Движок уже открыл любое Хранилище.
            if(this.m_Ready == true)
                throw new Exception("Движок уже используется.");
            //первым инициализировать менеджер файлов Хранилища.
            this.m_FSM.Open(solutionFolder, readOnly);
            //1.Хранилище открыто в рид-онли?
            //- Если нет,проверить, не открыто ли уже кем-то Хранилище.
            if (readOnly == false)
            {
                //- Если да, выбросить исключение с текстом
                if (this.m_FSM.checkPreviousInstance() == true)
                    throw new Exception("Хранилище уже открыто другим процессом: " + solutionFolder);
                //else pass
            }
            //2. Загрузить файл свойств Хранилища
            //- если исключение, выбросить исключение при загрузке файла свойств Хранилища.
            //- если каталог проекта реально рид-онли или пользователь хочет рид-онли, или настройки проекта - рид-онли, то выставляем рид-онли флаг.
            //   управление readOnly: аргумент ИЛИ флаг из ФайлНастроекХранилища ИЛИ атрибут ФайлНастроекХранилища
            //    и если любой из этих трех флагов установлен, хранилище открывается только для чтения.
            //    Об этом надо предупредить пользователя после открытия Хранилища! Но это не ошибка, поэтому продолжаем работу.
            String p = this.m_FSM.StorageInfoFilePath;
            bool infoFileReadOnly = StringUtility.isReadOnlyFile(p);
            //try load storage info file
            TaskStorageInfo sett = TaskStorageInfo.TryLoad(p);
            if (sett == null)
                throw new Exception("Ошибка при загрузке Настроек Хранилища: файл " + p);
            else
                this.m_settings = sett;
            //readonly processing for each subsystem
            bool finalReadOnly = readOnly || infoFileReadOnly || this.m_settings.ReadOnly;
            this.m_ReadOnly = finalReadOnly;
            this.m_FSM.ReadOnly = finalReadOnly;

            //3. Если режим не ридонли, создать бекап-копию файла БД Хранилища.
            //- если исключение, выбросить исключение при создании файла резервной копии БД Хранилища.
            if (finalReadOnly == false)
            {
                try
                {
                    this.m_FSM.DatabaseFileBackup();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при создании резервной копии БД Хранилища.", ex);
                }
            }
            //else pass
            //4. Инициализация менеджера лога
            //- а его нет в проекте пока что.
            //5. Инициализация FSM - это уже должно быть сделано ранее, точно ранее лога.
            //6. инициализация БД Хранилища
            String connectionString = TaskDbAdapter.CreateConnectionString(this.m_FSM.DatabaseFilePath, finalReadOnly);
            this.m_dbAdapter.Open(connectionString);
            //7. Инициализация МенеджерИдентификаторовЭлементов
            //получить максимальный ид элемента из БД и инициализировать менеджер идентификаторов элементов. 
            int maxid = this.m_dbAdapter.GetElementsMaxId();
            //close database
            this.m_dbAdapter.Close();
            //- если записей элементов нет, функция вернет -1, а нужен хотя бы 0.
            if (maxid <= 0) maxid = 0;
            //- установить полученный ид как текущий в менеджере
            this.m_idManager.internalSetCurrentId(maxid);
            //8. я ничего не забыл ?
            //установить флаг открытия движка
            this.m_Ready = true;

            return;
        }

        /// <summary>
        /// NT-Завершить сеанс работы движка
        /// </summary>
        /// <remarks>
        /// Функция закрывает Хранилище, сбрасывает флаг готовности CEngine.Ready.
        /// </remarks>
        public void StorageClose()
        {
            //не все объекты можно сбросить или восстановить?
            //TODO: проверить что объекты здесь восстанавливаются до начального состояния
            //TODO:  убедиться, что два и более вызовов StorageClose() подряд не вызывают исключений и Движок сможет снова открыть Хранилище потом..

            //настройки надо записать в файл настроек перед закрытием, но только если движок был открыт правильно.
            if ((this.m_Ready == true) && (this.m_ReadOnly == false))
            {
                //add setting version and statistic info before saving
                TaskStorageInfo sett = this.StorageGetInfo();
                sett.upgradeStorageVersion();
                sett.Store();
            }
            //settings not clearable, create new object
            this.m_settings = new TaskStorageInfo();

            //Close database if opened
            this.m_dbAdapter.Close();
            //reset ID manager
            this.m_idManager.internalSetCurrentId(0);
            //reset FSM object
            this.FSM.Close();
            //reset readOnly flag
            this.m_ReadOnly = false;

            //clear Ready flag
            this.m_Ready = false;

            return;
        }

        /// <summary>
        /// NT-Получить статистику Хранилища
        /// </summary>
        /// <remarks>
        /// Важно: Функция открывает и закрывает адаптер БД.
        /// </remarks>
        public TaskStorageInfo StorageGetInfo()
        {
            //check ready
            this.ThrowIfNotReady();

            //copy all fields to new object 
            TaskStorageInfo info = new TaskStorageInfo(this.m_settings);
            //тут должны быть скопированы поля:
            //info.EngineVersion           
            //info.Creator 
            //info.Title 
            //info.Description 
            //info.EngineClass 
            //info.StoragePath - повторно будет  заполнено позже
            //info.ReadOnly  - повторно будет  заполнено позже
            //info.LinkPrefix 
            //info.QualifiedName 
            //info.StorageType 
            //info.StorageVersionString


            //get from database:
            //this.m_dbAdapter.Open();
            String errmsg = this.m_dbAdapter.FillStorageInfo(info);
            //this.m_dbAdapter.Close();
            //TODO: строку сообщения об ошибках надо как-то показать пользователю
            //тут должны быть заполнены поля:
            //info.TaskCount - TODO: сейчас включая задачи в Корзине.
            //info.StoppedTaskCount - TODO: сейчас включая задачи в Корзине.
            //info.FinishedTaskCount - TODO: сейчас включая задачи в Корзине.
            //info.RunTaskCount - TODO: сейчас включая задачи в Корзине.
            //info.NotesCount
            //info.CategoriesCount
            //info.TagsCount
            //info.DeletedCount


            //get from FSM
            this.m_FSM.fillStorageInfo(info);
            //тут должны быть заполнены поля:
            //info.DatabaseSize
            //info.DocsCount
            //info.DocsSize
            //info.StoragePath
            //info.ReadOnly

            return info;
        }

        /// <summary>
        /// NR-Оптимизация Хранилища - незакончено, неясно как сделать и как использовать потом
        /// </summary>
        /// <returns>Return True if success, False otherwise.</returns>
        public bool StorageOptimize()
        {
            //check ready
            this.ThrowIfNotReady();
            //check read-only
            this.ThrowIfReadOnly();

            ////TODO: добавить код оптимизаци Хранилища здесь
            throw new System.NotImplementedException();//TODO: add code here
        }

        //Функция очистки. Ни разу не пользовался, проще создать новый проект. Но для комплекта тут реализована.
        /// <summary>
        /// NR-Очистить текущее Хранилище
        /// </summary>
        /// <returns>Return True if success, False otherwise</returns>
        public bool StorageClear()
        {
            //check ready
            this.ThrowIfNotReady();
            //check read-only
            this.ThrowIfReadOnly();

            ////Тут очищаем все таблицы БД кроме таблицы свойств, удаляем все архивы, пересчитываем статистику и вносим ее в БД.
            ////в результате должно получиься пустое Хранилище, сохранившее свойства - имя, квалифицированное имя, путь итп.
            //if (m_db.ClearDb() == true)
            //{
            //    m_docController.Clear();
            //    m_picController.Clear();
            //    this.updateStorageInfo();//это будет выполнено также при закрытии менеджера.
            //    return true;
            //}
            //else return false;

            throw new System.NotImplementedException();//TODO: add code here
        }

        /// <summary>
        /// NT-Проверить, что указанный каталог является каталогом Хранилища
        /// </summary>
        /// <param name="path">Путь к каталогу</param>
        /// <returns>Возвращает true, если каталог является каталогом Хранилища. В противном случае возвращает false</returns>
        public static bool IsStorageFolder(string path)
        {
            return StorageFolderManager.IsStorageFolder(path);
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
            //if (isReadOnlyFolder(storagePath)) return false;
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
        protected void ThrowIfReadOnly()
        {
            if (this.m_ReadOnly == true)
                throw new Exception("Ошибка: Попытка записи в Хранилище, открытое только для чтения!");

            return;
        }

        /// <summary>
        /// NT-Выбросить исключение, если Хранилище не открыто.
        /// </summary>
        /// <exception cref="System.Exception">ОшибкаЖ:Хранилище не открыто!</exception>
        protected void ThrowIfNotReady()
        {
            //check ready flag
            if (this.m_Ready != true)
                throw new Exception("ОшибкаЖ:Хранилище не открыто!");

            return;
        }

        #endregion

    }
}