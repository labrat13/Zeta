﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace TaskEngine
{
    public class TaskDbAdapter : SqliteDbAdapter
    {
        #region *** Fields ***        
        /// <summary>
        /// The table elements
        /// </summary>
        internal const String TableElements = "Elements";
        /// <summary>
        /// The table tagged
        /// </summary>
        internal const String TableTagged = "Tagged";
        /// <summary>
        /// The table tasks
        /// </summary>
        internal const String TableTasks = "Tasks";
        /// <summary>
        /// The table setting
        /// </summary>
        internal const String TableSetting = "Settings";
        /// <summary>
        /// Engine backreference
        /// </summary>
        private CEngine m_Engine;

        /// <summary>
        /// SQL Command for AddSetting function
        /// </summary>
        protected SQLiteCommand m_cmdAddSetting;

        /// <summary>
        ///  SQL Command for UpdateSetting function
        /// </summary>
        protected SQLiteCommand m_cmdUpdateSetting;

        /// <summary>
        /// SQL Command for Insert Task function
        /// </summary>
        protected SQLiteCommand m_cmdInsertTask;
        /// <summary>
        /// SQL Command for UpdateTask function
        /// </summary>
        protected SQLiteCommand m_cmdUpdateTask;

        /// <summary>
        /// SQL Command for InsertElement function
        /// </summary>
        protected SQLiteCommand m_cmdInsertElement;
        /// <summary>
        /// SQL Command for UpdateElement function
        /// </summary>
        protected SQLiteCommand m_cmdUpdateElement;

        #endregion        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDbAdapter"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public TaskDbAdapter(CEngine engine):base()
        {
            this.m_Engine = engine;

            this.m_cmdAddSetting = null;
            this.m_cmdUpdateSetting = null;

            this.m_cmdInsertTask = null;
            this.m_cmdUpdateTask = null;

            this.m_cmdInsertElement = null;
            this.m_cmdUpdateElement = null;

            return;
        }


        /// <summary>
        /// NT-Get string representation of object.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            bool active = this.isConnectionActive;
            String cstr = StringUtility.GetStringTextNull(this.m_connectionString);
            String result = String.Format("TaskDbAdapter; connection=\"{0}\"; active={1}", cstr, active);

            return result;
        }

        /// <summary>
        /// NT-Clear all member commands
        /// </summary>
        protected override void ClearCommands()
        {
            // TODO: add code for new command here!
            //Эта функция вызывается 4 раза при каждом добавлении или изменении любого Элемента в таблицах.
            //закрыть и обнулить каждую команду адаптера

            this.m_cmdAddSetting = null;
            this.m_cmdUpdateSetting = null;

            this.m_cmdInsertTask = null;
            this. m_cmdUpdateTask = null;

            this.m_cmdInsertElement = null;
            this.m_cmdUpdateElement = null;

            return;
        }
        public override void Open()
        {
            base.Open();
        }

        public override void Close()
        {
            base.Close();
        }

        #region Database
        /// <summary>
        /// NT-Create new application database and fill with tables and initial data
        /// </summary>
        /// <param name="engine">Engine object reference for logging</param>
        /// <param name="dbFile">Database file path</param>    
        public static void CreateNewDatabase(CEngine engine, String dbFile)
        {
            // try
            // {
            // Open
            String connectionString = SqliteDbAdapter.CreateConnectionString(dbFile, false);
            TaskDbAdapter db = new TaskDbAdapter(engine);
            db.Open(connectionString);
            // Write
            bool result = db.CreateDatabaseTables();
            if (result == false)
                throw new Exception("Create database failed.");
            // Close database
            db.Close();
            // }
            // catch(Exception ex)
            // {
            // //если произошла ошибка, перезапустить исключение с понятным
            // описанием причины.
            // String msg = "";
            // throw new Exception(msg);
            // }

            return;
        }

        /// <summary>
        /// NT-Create database tables
        /// </summary>
        /// <returns>Returns True if success, False otherwise.</returns>
        public bool CreateDatabaseTables()
        {
            bool result = true;
            try
            {
                this.TransactionBegin();
                // create Tasks table
                TableDrop(TaskDbAdapter.TableElements, 60);
                TableDrop(TaskDbAdapter.TableTasks, 60);
                TableDrop(TaskDbAdapter.TableTagged, 60);
                TableDrop(TaskDbAdapter.TableSetting, 60);

                //create Tasks table
                String query = "CREATE TABLE \"" + TaskDbAdapter.TableTasks + "\" (\"id\" Integer PRIMARY KEY NOT NULL, \"state\" Integer  NOT NULL   DEFAULT(0), \"prio\" Integer  NOT NULL   DEFAULT(0), \"starttime\" Integer  NOT NULL   DEFAULT(0), \"comptime\" Integer  NOT NULL   DEFAULT(0), \"result\" Text  NOT NULL DEFAULT '');";
                this.ExecuteNonQuery(query, 60);

                // create Elements table
                query = "CREATE TABLE \"" + TaskDbAdapter.TableElements + "\" (\"id\" Integer PRIMARY KEY NOT NULL, \"parent\" Integer  NOT NULL DEFAULT (0), \"title\" Text  NOT NULL, \"descr\" Text  NOT NULL, \"remark\" Text NOT NULL, \"creatime\" Integer  NOT NULL DEFAULT (0), \"moditime\" Integer  NOT NULL DEFAULT (0), \"eltype\" Integer  NOT NULL DEFAULT (0),  \"elstate\" Integer  NOT NULL DEFAULT (0));";
                this.ExecuteNonQuery(query, 60);

                //create Tagged table
                query = "CREATE TABLE \"" + TaskDbAdapter.TableTagged + "\" (\"id\" Integer Primary Key Autoincrement  NOT NULL, \"elid\" Integer  NOT NULL DEFAULT (0), \"tagid\" Integer  NOT NULL DEFAULT (0));";
                this.ExecuteNonQuery(query, 60);

                // create Setting table
                query = "CREATE TABLE \"" + TaskDbAdapter.TableSetting + "\" ( \"id\" INTEGER PRIMARY KEY AUTOINCREMENT, \"ns\" TEXT NOT NULL DEFAULT '', \"title\" TEXT NOT NULL DEFAULT '', \"descr\" TEXT NOT NULL DEFAULT '', \"val\" TEXT NOT NULL DEFAULT '' )";
                this.ExecuteNonQuery(query, 60);

                // create index
                query = "CREATE UNIQUE INDEX ix_tagged_tagid ON Tagged(tagid ASC);";
                this.ExecuteNonQuery(query, 60);
                query = "CREATE UNIQUE INDEX ix_tagged_elid ON Tagged(elid ASC);";
                this.ExecuteNonQuery(query, 60);
                query = "CREATE UNIQUE INDEX ix_tasks_parent ON Elements(parent ASC);";
                this.ExecuteNonQuery(query, 60);

                this.TransactionCommit();
            }
            catch (Exception ex)
            {
                result = false;
                this.TransactionRollback();
            }

            return result;
        }

        #endregion

        #region *** Element functions ***        
        /// <summary>
        /// NT-Deletes the element with transaction.
        /// Close database after this operation.
        /// </summary>
        /// <param name="element">Any element.</param>
        public void DeleteElementWithTransaction(CElement element)
        {
            try
            {
                //begin
                this.TransactionBegin();

                int elementId = element.Id;
                //task variant
                if (element.ElementType == EnumElementType.Task)
                    this.intDeleteTask(elementId);
                //tags delete
                this.intDeleteAllElementTags(elementId);
                //element delete
                this.intDeleteElement(elementId);
                //commit
                this.TransactionCommit();
            }
            catch(Exception ex)
            {
                this.TransactionRollback();
                throw ex;   
            }

            return;
        }
        /// <summary>
        /// NT-Inserts any element with transaction.
        /// Close database after this operation.
        /// </summary>
        /// <param name="element">Any element.</param>
        public void InsertElementWithTransaction(CElement element)
        {
            try
            {
                //begin
                this.TransactionBegin();
                //element insert
                //- set last modify time now 
                element.ModiTime = DateTime.Now;
                this.intInsertElement(element);
                //task variant
                if (element.ElementType == EnumElementType.Task)
                    this.intInsertTask((CTask)element);
                //tags insert - for all elements exclude Tags
                if (element.ElementType != EnumElementType.Tag)
                { 
                    List<Int32> ids = element.Tags.GetListOfId();
                    int elementId = element.Id;
                    foreach (Int32 tagid in ids)
                        this.intInsertElementTag(elementId, tagid);
                }
                //commit
                this.TransactionCommit();
            }
            catch(Exception ex)
            {
                this.TransactionRollback();
                throw ex;
            }

            return;
        }
        /// <summary>
        /// NT-Updates any element with transaction.
        /// Close database after this operation.
        /// </summary>
        /// <param name="element">Any element.</param>
        public void UpdateElementWithTransaction(CElement element)
        {
            try
            {
                //begin
                this.TransactionBegin();
                //element update
                //- set last modify time now 
                element.ModiTime = DateTime.Now;
                this.intUpdateElement(element);
                //task variant
                if (element.ElementType == EnumElementType.Task)
                    this.intUpdateTask((CTask)element);
                //tags update - for all elements exclude Tags
                if (element.ElementType != EnumElementType.Tag)
                {
                    int elementId = element.Id;
                    //remove all old tags
                    this.intDeleteAllElementTags(elementId);
                    //insert all new tags
                    List<Int32> ids = element.Tags.GetListOfId();
                    foreach (Int32 tagid in ids)
                        this.intInsertElementTag(elementId, tagid);
                }
                //commit
                this.TransactionCommit();
            }
            catch (Exception ex)
            {
                this.TransactionRollback();
                throw ex;
            }

            return;
        }

        /// <summary>
        /// NT-Selects the element without transaction.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <returns></returns>
        public CElement SelectElementWithoutTransaction(int elementId)
        {
            CElement element = null;
            //read element or null returned if element id is not found
            element = this.intSelectElement(elementId);
            if (element != null)//element record is exists
            {
                element = subSelectElement(elementId, element);
            }
            //return element
            return element;
        }

        /// <summary>
        /// NT-Subread specified element
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="element">The CElement object from Elements table.</param>
        /// <returns>Return CElement or CTask object or null if any needed record not founded</returns>
        private CElement subSelectElement(int elementId, CElement element)
        {
            //task variant
            if (element.ElementType == EnumElementType.Task)
                element = this.intSelectTask(element);
            if (element != null) //task record is exists
            {
                if (element.ElementType != EnumElementType.Tag)
                {
                    //read tags if element is not Tag
                    List<int> ids = this.intGetElementTags(elementId);
                    foreach (int tagid in ids)
                        element.Tags.Add(tagid, null);
                }
            }

            return element;
        }
        /// <summary>
        /// NT-Selects the elements by parent identifier.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>Returns list of founded elements.</returns>
        /// <exception cref="Exception">Task record with id=" + elementId.ToString() + " not found!</exception>
        public List<CElement> SelectElementsByParentId(int parentId)
        {
            List<CElement> result = new List<CElement>();
            //get elements by parent id
            List<CElement> elements = this.intSelectElementsByParent(parentId);
            foreach(CElement element in elements)
            {
                int elementId = element.Id;
                CElement elt = subSelectElement(elementId, element);
                if (elt == null)
                    throw new Exception("Task record with id=" + elementId.ToString() + " not found!");
                //add to result list
                result.Add(elt);
            }

            return result;
        }

        #endregion
        #region *** Elements table ***        
        /// <summary>
        /// NT-Возвращает максимальное значение идентификатора элемента или -1
        /// </summary>
        /// <returns></returns>
        public Int32 GetElementsMaxId()
        {
            return this.getTableMaxInt32(TaskDbAdapter.TableElements, "id", this.m_Timeout);
        }
        /// <summary>
        /// NT-Delete record from Elements table
        /// </summary>
        /// <param name="elementId">Идентификатор элемента</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private Int32 intDeleteElement(int elementId)
        {
            String query = String.Format("DELETE FROM \"{0}\" WHERE (\"id\" = {1});", TaskDbAdapter.TableElements, elementId);
            return this.ExecuteNonQuery(query, this.m_Timeout);
        }
        /// <summary>
        /// NT-Insert element into Elements table
        /// </summary>
        /// <param name="el">CElement object</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intInsertElement(CElement el)
        {
            SQLiteCommand ps = this.m_cmdInsertElement;

            // create if not exists
            if (ps == null)
            {
                String query = "INSERT INTO \"Elements\"(\"id\", \"parent\", \"title\", \"description\", \"remark\", \"creatime\", \"moditime\", \"eltype\", \"elstate\") VALUES (?,?,?,?,?,?,?,?,?);";
                ps = new SQLiteCommand(query, this.m_connection, this.m_transaction);
                // set timeout here
                ps.CommandTimeout = this.m_Timeout;
                //create parameters
                ps.Parameters.Add("a0", DbType.Int32);
                ps.Parameters.Add("a1", DbType.Int32);
                ps.Parameters.Add("a2", DbType.String);
                ps.Parameters.Add("a3", DbType.String);
                ps.Parameters.Add("a4", DbType.String);
                ps.Parameters.Add("a5", DbType.DateTime);
                ps.Parameters.Add("a6", DbType.DateTime);
                ps.Parameters.Add("a7", DbType.Int32);
                ps.Parameters.Add("a8", DbType.Int32);
                // write back
                this.m_cmdInsertElement = ps;
            }

            // set parameters
            ps.Parameters[0].Value = el.Id;
            ps.Parameters[1].Value = el.Parent.Id;
            ps.Parameters[2].Value = el.Title;
            ps.Parameters[3].Value = el.Description;
            ps.Parameters[4].Value = el.Remarks;
            ps.Parameters[5].Value = el.CreaTime;
            ps.Parameters[6].Value = el.ModiTime;
            ps.Parameters[7].Value = (Int32) el.ElementType;
            ps.Parameters[8].Value = (Int32) el.ElementState;
            //execute command
            return ps.ExecuteNonQuery();
        }
        /// <summary>
        /// NT-Update element into Elements table
        /// </summary>
        /// <param name="el">CElement object</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intUpdateElement(CElement el)
        {
            SQLiteCommand ps = this.m_cmdUpdateElement;

            // create if not exists
            if (ps == null)
            {
                String query = "UPDATE \"Elements\" SET  \"parent\" = ?, \"title\" = ?, \"description\" = ?, \"remark\" = ?, \"creatime\" = ?, \"moditime\" = ?, \"eltype\" = ?, \"elstate\" = ? WHERE (\"id\" = ?);";
                ps = new SQLiteCommand(query, this.m_connection, this.m_transaction);
                // set timeout here
                ps.CommandTimeout = this.m_Timeout;
                //create parameters
                ps.Parameters.Add("a1", DbType.Int32);
                ps.Parameters.Add("a2", DbType.String);
                ps.Parameters.Add("a3", DbType.String);
                ps.Parameters.Add("a4", DbType.String);
                ps.Parameters.Add("a5", DbType.DateTime);
                ps.Parameters.Add("a6", DbType.DateTime);
                ps.Parameters.Add("a7", DbType.Int32);
                ps.Parameters.Add("a8", DbType.Int32);
                //add id as last argument
                ps.Parameters.Add("a0", DbType.Int32);
                // write back
                this.m_cmdUpdateElement = ps;
            }

            // set parameters
            ps.Parameters[0].Value = el.Parent.Id;
            ps.Parameters[1].Value = el.Title;
            ps.Parameters[2].Value = el.Description;
            ps.Parameters[3].Value = el.Remarks;
            ps.Parameters[4].Value = el.CreaTime;
            ps.Parameters[5].Value = el.ModiTime;
            ps.Parameters[6].Value = (Int32)el.ElementType;
            ps.Parameters[7].Value = (Int32)el.ElementState;
            //set id as last argument
            ps.Parameters[8].Value = el.Id;
            //execute command
            return ps.ExecuteNonQuery();
        }

        /// <summary>
        /// NR-Select element by id
        /// </summary>
        /// <param name="id">Идентификатор элемента</param>
        /// <returns>Return CElement object or null if id not found.</returns>
        private CElement intSelectElement(int id)
        {
            CElement result = null;
            String query = "SELECT * FROM \"Elements\" WHERE (\"id\" = " + id.ToString() + ");";
            SQLiteDataReader reader = this.ExecuteReader(query, this.m_Timeout);
            if (reader.HasRows)
                while (reader.Read())
                {
                    result = intReadElement(reader);
                }
            // close command and result set objects
            reader.Close();

            return result;
        }
        /// <summary>
        /// NT-Read one CELement object from table reader
        /// </summary>
        /// <param name="reader">table reader object</param>
        /// <returns>Returns filled element object</returns>
        private CElement intReadElement(SQLiteDataReader reader)
        {
            CElement result = new CElement();
            result.Id = reader.GetInt32(0);
            result.Parent = new CElementRef(reader.GetInt32(1));
            result.Title = reader.GetString(2);
            result.Description = reader.GetString(3);
            result.Remarks = reader.GetString(4);
            result.CreaTime = reader.GetDateTime(5);
            result.ModiTime = reader.GetDateTime(6);
            result.ElementType = (EnumElementType)reader.GetInt32(7);
            result.ElementState = (EnumElementState)reader.GetInt32(8);

            return result;
        }

        /// <summary>
        /// NT-Select element by parent id
        /// </summary>
        /// <param name="parentid">Идентификатор родительского элемента</param>
        /// <returns>Returns list of CElement objects</returns>
        private List<CElement> intSelectElementsByParent(int parentid)
        {
            List<CElement> result = new List<CElement>();
            String query = "SELECT * FROM \"Elements\" WHERE (\"parent\" = " + parentid.ToString() + ");";
            SQLiteDataReader reader = this.ExecuteReader(query, this.m_Timeout);
            if (reader.HasRows)
                while (reader.Read())
                {
                    result.Add( intReadElement(reader));
                }
            // close command and result set objects
            reader.Close();

            return result;
        }

        #endregion

        #region *** Tagged table ***
        /// <summary>
        /// NT-Получить список идентификаторов тегов для указанного элемента
        /// </summary>
        /// <param name="elid">The element identificator.</param>
        /// <returns>Returns list of tag Id's for specified element.</returns>
        private List<Int32> intGetElementTags(Int32 elid)
        {
            List<Int32> result = new List<Int32>();
            String query = String.Format("SELECT \"tagid\" FROM \"{0}\" WHERE (\"elid\" = {1});", TaskDbAdapter.TableTagged, elid);
            SQLiteDataReader reader = this.ExecuteReader(query, this.m_Timeout);
            if (reader.HasRows)
                while (reader.Read())
                {
                    Int32 tid = reader.GetInt32(0);
                    //add to list
                    result.Add(tid);
                }

            // close command and result set objects
            reader.Close();

            return result;
        }
        /// <summary>
        /// NT-Получить список идентификаторов элементов с указанным тегом
        /// </summary>
        /// <param name="tagid">The tag id.</param>
        /// <returns>Returns list of id for elements with specified tag</returns>
        public List<Int32> GetElementsIdWithTag(Int32 tagid)
        {
            List<Int32> result = new List<Int32>();
            String query = String.Format("SELECT \"elid\" FROM \"{0}\" WHERE (\"tagid\" = {1});", TaskDbAdapter.TableTagged, tagid);
            SQLiteDataReader reader = this.ExecuteReader(query, this.m_Timeout);
            if (reader.HasRows)
                while (reader.Read())
                {
                    Int32 tid = reader.GetInt32(0);
                    //add to list
                    result.Add(tid);
                }

            // close command and result set objects
            reader.Close();

            return result;
        }
        /// <summary>
        /// NT-Добавить связку элемент-тег
        /// </summary>
        /// <param name="elementId">Идентификатор элемента</param>
        /// <param name="tagId">Идентификатор тега</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intInsertElementTag(int elementId, int tagId)
        {
            String query = String.Format("INSERT INTO \"{0}\" (\"elid\", \"tagid\") VALUES ({1}, {2} );", TaskDbAdapter.TableTagged, elementId, tagId);
            return this.ExecuteNonQuery(query, this.m_Timeout);
        }
        /// <summary>
        /// NT-Удалить связку элемент-тег
        /// </summary>
        /// <param name="elementId">Идентификатор элемента</param>
        /// <param name="tagId">Идентификатор тега</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intDeleteElementTag(int elementId, int tagId)
        {
            String query = String.Format("DELETE FROM \"{0}\" WHERE (\"elid\" = {1}, \"tagid\" = {2});", TaskDbAdapter.TableTagged, elementId, tagId);
            return this.ExecuteNonQuery(query, this.m_Timeout);
        }
        /// <summary>
        /// NT-Удалить все связки указанного элемента с тегами
        /// </summary>
        /// <param name="elementId">Идентификатор элемента</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intDeleteAllElementTags(int elementId)
        {
            String query = String.Format("DELETE FROM \"{0}\" WHERE (\"elid\" = {1});", TaskDbAdapter.TableTagged, elementId);
            return this.ExecuteNonQuery(query, this.m_Timeout);
        }

        #endregion

        #region *** Tasks table ***
        /// <summary>
        /// NT-Read task record
        /// </summary>
        /// <param name="el">Ранее извлеченный из таблицы ELements объект CElement</param>
        /// <returns>
        /// Функция возвращает объект CTask, но без идентификаторов тегов!
        /// Если запись задачи не найдена, функция возвращает null.
        /// </returns>
        private CTask intSelectTask(CElement el)
        {
            //Заменить объект CELement на объект CTask
            CTask result = new CTask(el);
            String query = String.Format("SELECT * FROM \"{0}\" WHERE (\"id\" = {1});", TaskDbAdapter.TableTasks, el.Id);
            SQLiteDataReader reader = this.ExecuteReader(query, this.m_Timeout);
            if (reader.HasRows)
                while (reader.Read())
                {
                    result.TaskState = (EnumTaskState)reader.GetInt32(1);
                    result.TaskPriority = (EnumTaskPriority)reader.GetInt32(2);
                    result.TaskStartDate = reader.GetDateTime(3);
                    result.TaskCompletionDate = reader.GetDateTime(4);
                    result.TaskResult = reader.GetString(5);
                }
            //else return null if task info not found.
            else result = null;
            // close command and result set objects
            reader.Close();

            return result;
        }
        /// <summary>
        /// NT- Add task record
        /// </summary>
        /// <param name="elem">Task element</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intInsertTask(CTask elem)
        {
            SQLiteCommand ps = this.m_cmdInsertTask;

            // create if not exists
            if (ps == null)
            {
                String query = String.Format("INSERT INTO \"{0}\"(\"id\", \"state\", \"prio\", \"starttime\", \"comptime\", \"result\") VALUES (?,?,?,?,?,?);", TaskDbAdapter.TableTasks);
                ps = new SQLiteCommand(query, this.m_connection, this.m_transaction);
                // set timeout here
                ps.CommandTimeout = this.m_Timeout;
                //create parameters
                ps.Parameters.Add("a0", DbType.Int32);
                ps.Parameters.Add("a1", DbType.Int32);
                ps.Parameters.Add("a2", DbType.Int32);
                ps.Parameters.Add("a3", DbType.DateTime);
                ps.Parameters.Add("a4", DbType.DateTime);
                ps.Parameters.Add("a5", DbType.String);
                // write back
                this.m_cmdInsertTask = ps;
            }

            // set parameters
            ps.Parameters[0].Value = elem.Id;
            ps.Parameters[1].Value = (Int32) elem.TaskState;
            ps.Parameters[2].Value = (Int32) elem.TaskPriority;
            ps.Parameters[3].Value = elem.TaskStartDate;
            ps.Parameters[4].Value = elem.TaskCompletionDate;
            ps.Parameters[5].Value = elem.TaskResult;
            //execute command
            return ps.ExecuteNonQuery();
        }
        /// <summary>
        /// NT-Update task record
        /// </summary>
        /// <param name="elem">Task element</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intUpdateTask(CTask elem)
        {
            SQLiteCommand ps = this.m_cmdUpdateTask;

            // create if not exists
            if (ps == null)
            {
                String query = "UPDATE \"Tasks\" SET \"state\" = ?, \"prio\" = ?, \"starttime\" = ?, \"comptime\" = ?, \"result\" = ?  WHERE (\"id\" = ?);";
                ps = new SQLiteCommand(query, this.m_connection, this.m_transaction);
                // set timeout here
                ps.CommandTimeout = this.m_Timeout;
                //create parameters
                ps.Parameters.Add("a1", DbType.Int32);
                ps.Parameters.Add("a2", DbType.Int32);
                ps.Parameters.Add("a3", DbType.DateTime);
                ps.Parameters.Add("a4", DbType.DateTime);
                ps.Parameters.Add("a5", DbType.String);
                ps.Parameters.Add("a0", DbType.Int32);//id is last argument here
                // write back
                this.m_cmdUpdateTask = ps;
            }

            // set parameters
            ps.Parameters[0].Value = (Int32)elem.TaskState;
            ps.Parameters[1].Value = (Int32)elem.TaskPriority;
            ps.Parameters[2].Value = elem.TaskStartDate;
            ps.Parameters[3].Value = elem.TaskCompletionDate;
            ps.Parameters[4].Value = elem.TaskResult;
            ps.Parameters[5].Value = elem.Id;
            //execute command
            return ps.ExecuteNonQuery();
        }
        /// <summary>
        /// NT-Delete record from Task table
        /// </summary>
        /// <param name="elementId">Идентификатор элемента</param>
        /// <returns>Возвращает число измененных строк таблицы</returns>
        private int intDeleteTask(int elementId)
        {
            String query = String.Format("DELETE FROM \"{0}\" WHERE (\"id\" = {1});", TaskDbAdapter.TableTasks, elementId);
            return this.ExecuteNonQuery(query, this.m_Timeout);
        }

        #endregion

        #region *** Setting table function ***

        /// <summary>
        /// NT- Получить все записи таблицы настроек Оператора
        /// </summary>
        /// <returns>Функция возвращает все записи из ТаблицыНастроекОператора.</returns>
        public List<SettingItem> GetAllSettings()
        {

            List<SettingItem> list = new List<SettingItem>();

            String query = String.Format("SELECT * FROM \"{0}\";", TaskDbAdapter.TableSetting);
            SQLiteDataReader reader = this.ExecuteReader(query, this.m_Timeout);
            if (reader.HasRows)
                while (reader.Read())
                {
                    SettingItem si = new SettingItem();
                    si.TableId = reader.GetInt32(0);
                    si.Namespace = reader.GetString(1);
                    si.Title = reader.GetString(2);
                    si.Description = reader.GetString(3);
                    si.Path = reader.GetString(4);// set value as Item.Path
                                                  // set storage field as db
                    si.Storage = SettingItem.StorageKeyForDatabaseItem;
                    // add to result list
                    list.Add(si);
                }

            // close command and result set objects
            reader.Close();

            return list;
        }



        /// <summary>
        /// NT-Добавить Настройку.
        /// </summary>
        /// <param name="p">Добавляемая Настройка.</param>
        public void AddSetting(SettingItem p)
        {

            SQLiteCommand ps = this.m_cmdAddSetting;

            // create if not exists
            if (ps == null)
            {
                String query = String.Format("INSERT INTO \"{0}\"(\"ns\", \"title\", \"descr\", \"val\") VALUES (?,?,?,?);", TaskDbAdapter.TableSetting);
                ps = new SQLiteCommand(query, this.m_connection, this.m_transaction);
                // set timeout here
                ps.CommandTimeout = this.m_Timeout;
                //create parameters
                ps.Parameters.Add("a0", DbType.String);
                ps.Parameters.Add("a1", DbType.String);
                ps.Parameters.Add("a2", DbType.String);
                ps.Parameters.Add("a3", DbType.String);
                // write back
                this.m_cmdAddSetting = ps;
            }
            // set parameters
            ps.Parameters[0].Value = p.Namespace;
            ps.Parameters[1].Value = p.Title;
            ps.Parameters[2].Value = p.Description;
            ps.Parameters[3].Value = p.Path;
            //execute command
            ps.ExecuteNonQuery();

            return;
        }

        /// <summary>
        /// NT-Удалить Настройку.
        /// </summary>
        /// <param name="id">ИД Настройки.</param>
        /// <returns>Функция возвращает число измененных строк таблицы.</returns>
        public int RemoveSetting(int id)
        {
            // DELETE FROM `setting` WHERE (`id` = 1);
            return this.DeleteRow(TaskDbAdapter.TableSetting, "id", id, this.m_Timeout);
        }

        /// <summary>
        /// NT- Изменить Настройку (title, descr, value)
        /// </summary>
        /// <param name="p">Изменяемая Настройка</param>
        /// <returns>Функция возвращает число измененных строк таблицы.</returns>
        public int UpdateSetting(SettingItem p)
        {
            SQLiteCommand ps = this.m_cmdUpdateSetting;

            // create if not exists
            if (ps == null)
            {
                String query = String.Format("UPDATE \"{0}\" SET \"ns\" = ?, \"title\" = ?, \"descr\" = ?, \"val\" = ? WHERE (\"id\" = ?);", TaskDbAdapter.TableSetting);
                ps = new SQLiteCommand(query, this.m_connection, this.m_transaction);
                // set timeout here
                ps.CommandTimeout = this.m_Timeout;
                //create parameters
                ps.Parameters.Add("a0", DbType.String);
                ps.Parameters.Add("a1", DbType.String);
                ps.Parameters.Add("a2", DbType.String);
                ps.Parameters.Add("a3", DbType.String);
                ps.Parameters.Add("a4", DbType.Int32);
                // write back
                this.m_cmdUpdateSetting = ps;
            }
            // set parameters
            ps.Parameters[0].Value = p.Namespace;
            ps.Parameters[1].Value = p.Title;
            ps.Parameters[2].Value = p.Description;
            ps.Parameters[3].Value = p.Path;// get value as Item.Path
            ps.Parameters[4].Value = p.TableId;
            //execute command
            int result = ps.ExecuteNonQuery();

            return result;
        }

        /// <summary>
        /// NT-Remove all Settings
        /// </summary>
        public void RemoveAllSettings()
        {
            this.TableClear(TableSetting, m_Timeout);
        }
        #endregion

    }
}
