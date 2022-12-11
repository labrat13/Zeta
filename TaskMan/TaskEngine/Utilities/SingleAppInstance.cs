using System;
using System.IO;
using System.Threading;

namespace TaskEngine.Utilities
{
    #region Пример использования класса
    //public static void main(String[] args)
    //{
    //    // Сейчас тут уже построен каркас Оператор для запуска движка.
    //    // Тесты вставлять только в виде вызовов функций тестирования!

    //    Engine engine = null;
    //    try
    //    {

    //        // 1. Первым делом, попытаться определить, запущен ли уже Оператор,
    //        // и если да, завершить работу и передать фокус ввода более старой копии
    //        //TODO: фокус ввода передать не могу - не нашел способа.
    //        boolean toExit = checkPreviousInstance();
    //        if (toExit == false)
    //        {
    //            // 3. create engine object
    //            engine = new Engine();
    //            // 4. init engine object
    //            engine.Init();

    //            // 5. запускаем цикл приема запросов
    //            engine.CommandLoop();

    //            engine.Exit();
    //            engine = null;

    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        // print exception
    //        PrintExceptionWithoutEngine(e);
    //    }
    //    finally
    //    {
    //        // close engine object
    //        // записываем в лог сообщение о завершении работы и завершаем работу
    //        // приложения.
    //        // TODO: разобраться с исключениями в engine.Exit()
    //        // if(engine != null)
    //        // engine.Exit();
    //        // engine = null;

    //        //завершить детектор запущенных копий приложения в самом конце работы приложения.
    //        finalPreviousInstance();
    //    }

    //    return;
    //}


    ///**
    // * NT-Освободить ресурсы детектора запущенных копий приложения.
    // */
    //private static void finalPreviousInstance()
    //{
    //    try
    //    {
    //        SingleAppInstance.unlockInstance();
    //    }
    //    catch (Exception e)
    //    {
    //        PrintExceptionWithoutEngine(e);
    //    }

    //    return;
    //}


    ///**
    // * NT-Запустить детектор запущенных копий приложения.
    // * @return Функция возвращает true, если предыдущая копия уже запущена и текущую копию надо завершить, false в противном случае. 
    // */
    //private static boolean checkPreviousInstance()
    //{
    //    boolean toExit = false;
    //    try
    //    {
    //        //create locking file path and start locking
    //        String lockfilepath = FileSystemManager.getAppFolderPath() + FileSystemManager.FileSeparator + SingleAppInstance.LockingFileName;
    //        SingleAppInstance.lockInstance(lockfilepath);
    //        //check flags
    //        if (SingleAppInstance.hasDuplicate() == true)
    //        {
    //            toExit = true;
    //            AnotherCopyOnWork();
    //        }
    //        if (SingleAppInstance.needRestoreData() == true)
    //        {
    //            toExit = false;
    //            needRestoreData();
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        PrintExceptionWithoutEngine(e);

    //        //to exit because errors
    //        finalPreviousInstance();
    //        toExit = true;
    //    }

    //    return toExit;
    //}



    ///**
    // * NT-Обработчик состояния "Возможно, требуется восстановление данных после аварийного завершения Оператор".
    // */
    //private static void needRestoreData()
    //{
    //    String msg = "Возможно, требуется восстановление данных после аварийного завершения предыдущего экземпляра Оператор.";
    //    PrintMessageWithoutEngine(msg);

    //    // TODO Тут запустить проверку состояния и восстановление данных Оператора

    //    return;
    //}


    ///**
    // * NT-обработчик состояния "Другая копия Оператор уже запущена".
    // */
    //private static void AnotherCopyOnWork()
    //{
    //    String msg = "Другая копия Оператор уже запущена. Эта копия будет закрыта.";
    //    PrintMessageWithoutEngine(msg);

    //    // TODO тут найти другую копию и передать ей фокус ввода.  

    //    return;
    //}
    #endregion

    /// <summary>
    /// NT-Определить, работает ли уже другой экземпляр приложения. И если нет, была ли его работа завершена некорректно.
    /// </summary>
    /// <remarks>
    ///  Механизм основан на создании пустого файла блокировки, обычно в рабочем каталоге приложения/проекта.
    /// - Если файл блокировки отсутствует, то нет ранее запущенного экземпляра приложения, и его работа была завершена корректно.
    /// - Если файл блокировки присутствует, то:
    ///   - Если файл блокирован от чтения-записи, то существует ранее запущенный экземпляр приложения. 
    ///      И он должен был восстановить данные, если они были повреждены.
    ///   - Если файл не блокирован от чтения-записи, то нет ранее запущенного экземпляра приложения. 
    ///      Работа предыдущего экземпляра приложения была завершена неожиданно.
    ///      Вероятно, потребуется восстановление данных приложения.
    /// </remarks>
    public class SingleAppInstance
    {
        #region *** Constants and Fields ***
        
        /// <summary>
        /// Имя файла блокировки.
        /// </summary>
        public const String LockingFileName = "session.lock";

        /// <summary>
        /// Флаг, что предыдущая копия приложения уже запущена.
        /// </summary>        
        private bool m_hasDuplicate;

        /// <summary>
        /// Флаг, что предыдущая копия не была завершена корректно, и требуется восстановить данные приложения.
        /// </summary>
        private bool m_needRestoreData;

        /// <summary>
        /// Путь к файлу блокировки.
        /// </summary>
        private String m_lockFilePathName;

        /// <summary>
        /// Locking object must be for entire session
        /// </summary>
        private FileStream m_lockFileStream;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleAppInstance"/> class.
        /// </summary>
        public SingleAppInstance()
        {
            this.m_hasDuplicate = false;
            this.m_lockFilePathName=null;
            this.m_lockFileStream = null;
            this.m_needRestoreData = false;

            return;
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="SingleAppInstance"/> class.
        /// </summary>
        ~SingleAppInstance()
        {
            unlockInstance();

            return;
        }

        #region *** Properties ***

        /// <summary>
        /// NT-Флаг, что предыдущая копия приложения уже запущена.
        /// </summary>
        public bool hasDuplicate
        {
            get { return m_hasDuplicate; }
        }

        /// <summary>
        /// NT-Флаг, что нет запущенных копий, но предыдущая копия не была завершена корректно, и требуется восстановить данные приложения.
        /// </summary>
        public bool needRestoreData
        {
            get { return m_needRestoreData; }
        }

        #endregion

        #region *** Service functions ***

        /// <summary>
        /// NT-Try lock application before start application routine.
        /// </summary>
        /// <param name="lockfilepath">Locking file pathname.</param>
        public  void lockInstance(String lockfilepath)
        {
            bool isAlreadyExists = false;
            bool isAlreadyLocked = false;

            //wait random time 50..3000ms
            waitRandom(3000);

            //store filepath to variable
            m_lockFilePathName = String.Copy(lockfilepath);

            FileInfo fi = new FileInfo(lockfilepath);
            // set file exists flag and create new file if not exists
            isAlreadyExists = true;
            if (fi.Exists == false)
            {
                isAlreadyExists = false;
                FileStream fs = fi.Create();
                fs.Close(); //todo: тут поток создается, чтобы сразу закрыть его. Надо переделать логику функции, чтобы меньше работ было.
            }

            //try lock entire file if not already locked
            isAlreadyLocked = false;
            try
            {
                m_lockFileStream = new FileStream(lockfilepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                // m_lockFileStream.Lock(0, *) - try after debug
            }
            catch (IOException)
            {
                isAlreadyLocked = true;
            }

            // calculate
            if (isAlreadyExists == false)
            {
                m_hasDuplicate = false;
                m_needRestoreData = false;
            }
            else
            {
                if (isAlreadyLocked == false)
                {
                    m_hasDuplicate = false;
                    m_needRestoreData = true;
                }
                else
                {
                    m_hasDuplicate = true;
                    m_needRestoreData = false;
                }
            }

            return;
        }


        /// <summary>
        /// NT - Current thread sleep for 50..maxMs milliseconds.
        /// </summary>
        /// <param name="maxMs">Maximum amount of milliseconds for sleep.</param>
        private void waitRandom(int maxMs)
        {
            Random r = new Random(Environment.TickCount);
            int ms = r.Next(50, maxMs);

            Thread.Sleep(ms);

            return;
        }

        /// <summary>
        /// NT-Unlock application at exit application routine.
        /// </summary>
        public void unlockInstance()
        {
            if (m_lockFileStream != null)
            {
                m_lockFileStream.Close();
                m_lockFileStream = null;    
            }

            //delete lock file at exit application
            if (File.Exists(m_lockFilePathName))
                File.Delete(m_lockFilePathName);    

            m_lockFilePathName = null;
            this.m_hasDuplicate = false;
            this.m_needRestoreData = false;

            return;
        }
        #endregion


    }
}
