using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TaskEngine;
using TaskEngine.SettingSubsystem;
using TaskEngine.Utilities;
using Tasks.Forms;

namespace Tasks
{
    public partial class MainForm : Form
    {

        #region *** Constants and Fields ***  

        /// <summary>
        /// Название окна приложения
        /// </summary>
        public const String MainFormTitle = "Менеджер Задач";

        /// <summary>
        /// Task engine object
        /// </summary>
        private CEngine m_Engine;

        /// <summary>
        /// TreeView control manager
        /// </summary>
        private MainFormTreeViewManager m_TreeManager;

        #endregion        
        /// <summary>
        /// NT-Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //create new engine object
            this.m_Engine = new CEngine();
            //create context menu collection object
            Tasks.Forms.NodeContextMenuCollection nc = new Tasks.Forms.NodeContextMenuCollection();
            nc.TrashcanItemContextMenu = this.contextMenuStrip_TreeItemTrashcanItem;
            nc.TrashcanRootContextMenu = this.contextMenuStrip_TreeItemTrashcanRoot;
            nc.Add(EnumElementType.Category, this.contextMenuStrip_treeItemCategory);
            nc.Add(EnumElementType.Note, this.contextMenuStrip_treeItemNote);
            nc.Add(EnumElementType.Task, this.contextMenuStrip_TreeItemTask);
            nc.Add(EnumElementType.Tag, this.contextMenuStrip_TreeItemTag);
            //create tree view manager
            this.m_TreeManager = new MainFormTreeViewManager(this.m_Engine, this.treeView_TaskTreeView, nc);
            //TODO: add code here

            return;
        }

        #region  *** Properties ***

        /// <summary>
        /// Менеджер движка управления Задачами
        /// </summary>
        public CEngine Engine
        {
            get { return m_Engine; }
        }
        #endregion

        #region *** Form Load Closing Closed handlers ***   

        /// <summary>
        /// NT-Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //загрузить размеры и позицию формы из файла настроек приложения
            Size formSize = Properties.Settings.Default.MainFormSize;
            //limit min size
            if (formSize.Height < this.MinimumSize.Height)
                formSize.Height = this.MinimumSize.Height;
            if (formSize.Width < this.MinimumSize.Width)
                formSize.Width = this.MinimumSize.Width;
            //set form size
            this.Size = formSize;
            //поместить окно в позицию из настроек приложения.
            Point pt = Properties.Settings.Default.MainFormPosition;
            // проверить координаты окна, чтобы его не потерять за пределами дисплея 
            if (pt.X > 1000) pt.X = 1000;
            if (pt.Y > 1000) pt.Y = 1000;
            this.Location = pt;
            //set default form title
            this.setMainFormTitle(null, false);
            //set default status text
            this.setStatusBarText("Для начала работы откройте Хранилище", false);
            //disable some menu items
            this.setEnableMainMenuItems(false);
            //очистить дерево элементов и вставить надпись, что Хранилище не загружено.
            this.setEmptyTreeItems();
            //форма еще не показана на экране, обновлять ее незачем.
            //load default storage?
            this.loadDefaultStorage();

            return;
        }

        /// <summary>
        /// NR-Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this function run before main form closed
            //Тут можно бы отменить закрытие окна, если оно заблокировано неким установленным флагом.
            //TODO: Add code here
        }

        /// <summary>
        /// NT-Handles the FormClosed event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DONE: добавить сохранение размера и позиции формы в файл настроек приложения 
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.MainFormPosition = this.Location;
            //store setting files
            Properties.Settings.Default.Save();
            //close Storage if not closed now
            if ((this.m_Engine != null) && (this.m_Engine.Ready == true))
                this.closeStorage();

            //TODO: Add closing application code here
            return;
        }

        #endregion


        #region *** Обработчики меню Справка главного меню ***   

        /// <summary>
        /// NT-Handles the Click event of the просмотрСправкиToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void просмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //операции показа справки по программе
            this.showHelp();
        }

        /// <summary>
        /// NT-Handles the Click event of the оПрограммеToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm frm = new AboutBoxForm(this);
            frm.ShowDialog(this);
            frm.Dispose();
            return;
        }

        #endregion

        #region *** Обработчики меню Файл главного меню ***

        private void toolStripMenuItem_CreateStorage_Click(object sender, EventArgs e)
        {
            this.createStorage();
            //TODO: Add code here

            return;
        }

        /// <summary>
        /// NT-Handles the Click event of the toolStripMenuItem_OpenStorage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_OpenStorage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Укажите каталог открываемого Хранилища";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            string storagePath = fbd.SelectedPath;
            this.loadStorage(storagePath);

            return;
        }

        /// <summary>
        /// NT-Handles the Click event of the toolStripMenuItem_CloseStorage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_CloseStorage_Click(object sender, EventArgs e)
        {
            this.closeStorage();
            //TODO: Add code here

            return;
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_Exit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            //вся обработка завершения работы должна проводиться в Form.Closing()

            return;
        }

        #endregion

        #region *** Обработчики меню Инструменты главного меню ***        
        /// <summary>
        /// NT-Handles the Click event of the тест1ToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void тест1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String msg;
            CElement result = SelectElementForm.ShowSelectElementForm(this, MainForm.MainFormTitle + " - Выбрать элемент:", this.m_Engine, EnumElementType.AllTypes, 5, false, "Выберите элемент для тестирования:");
            if (result != null)
                msg = result.GetStringElementIdentifier(true);
            else msg = "NULL";
            MessageBox.Show(msg);
            result = SelectElementForm.ShowSelectElementForm(this, MainForm.MainFormTitle + " - Выбрать элемент: Task", this.m_Engine, EnumElementType.Task, 5, false, "Выберите элемент для тестирования:");
            if (result != null)
                msg = result.GetStringElementIdentifier(true);
            else msg = "NULL";
            MessageBox.Show(msg);
            result = SelectElementForm.ShowSelectElementForm(this, MainForm.MainFormTitle + " - Выбрать элемент: Note", this.m_Engine, EnumElementType.Task | EnumElementType.Note, 5, false, "Выберите элемент для тестирования:");
            if (result != null)
                msg = result.GetStringElementIdentifier(true);
            else msg = "NULL";
            MessageBox.Show(msg);
            result = SelectElementForm.ShowSelectElementForm(this, MainForm.MainFormTitle + " - Выбрать элемент: Tag", this.m_Engine, EnumElementType.Tag, 5, false, "Выберите элемент для тестирования:");
            if (result != null)
                msg = result.GetStringElementIdentifier(true);
            else msg = "NULL";
            MessageBox.Show(msg);

            return;
        }

        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_TrashcanClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_TrashcanClear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();//TODO: add code here//TODO: add code here
        }
        /// <summary>
        /// NT-Handles the Click event of the изменитьШаблоныToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void изменитьШаблоныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tasks.Forms.SettingTemplatesForm f = new SettingTemplatesForm();
            f.ShowDialog();
            f.Dispose();
            f = null;

            return;
        }

        #endregion

        /// <summary>
        /// NT-Установить новый текст статусбара
        /// </summary>
        /// <param name="text">Новый текст статусбара</param>
        /// <param name="updateForm">Обновить вид формы?</param>
        private void setStatusBarText(string text, bool updateForm)
        {
            this.toolStripStatusLabel_MainStatus.Text = text;
            if (updateForm)
                Application.DoEvents();

            return;
        }

        /// <summary>
        /// NT-Изменить заголовок главной формы
        /// </summary>
        /// <param name="storage">Название проекта.</param>
        /// <param name="updateForm">Обновить вид формы?.</param>
        /// <returns></returns>
        private void setMainFormTitle(String storage, bool updateForm)
        {
            if (String.IsNullOrEmpty(storage))
                this.Text = MainForm.MainFormTitle; // FormTitle;
            else this.Text = storage + " - " + MainFormTitle; //FormTitle;
                                                              //update form view?
            if (updateForm)
                Application.DoEvents();

            return;
        }

        /// <summary>
        /// NT-Показать диалог сообщения об ошибке.
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        /// <param name="title">Заголовок окна сообщения. Если title = String.Empty или null, используется MainForm.MainFormTitle.</param>
        private void showErrorMessageBox(string title, string text)
        {
            String title1 = title;
            if (String.IsNullOrEmpty(title))
                title1 = MainForm.MainFormTitle;
            MessageBox.Show(this, text, title1, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        /// <summary>
        /// NT-включить-выключить пункты меню при открытии-закрытии Хранилища
        /// </summary>
        /// <param name="opened">True если Хранилище открыто, False если закрыто.</param>
        private void setEnableMainMenuItems(bool opened)
        {
            //если проект открыт, выключить одни пункты и включить другие
            //если проект закрыт, наоборот.
            this.toolStripMenuItem_CreateStorage.Enabled = !opened; //disable
            this.toolStripMenuItem_OpenStorage.Enabled = !opened; //disable
            this.toolStripMenuItem_CloseStorage.Enabled = opened; //enable
            this.правкаToolStripMenuItem.Enabled = opened; //enable
            //меню Инструменты-Настройки должны быть всегда доступны?
            //TODO: другие пункты меню Инструменты зависят от состояния проекта? Но их пока нет.
            //меню Справка всегда доступно.

            return;
        }

        /// <summary>
        /// NT-изменить название формы чтобы оно отражало прогресс процесса
        /// </summary>
        /// <param name="operation">Название процесса или String.Empty или  null если процесс не выполняется</param>
        /// <param name="storageTitle">Название открытого Хранилища или String.Empty или  null если Хранилище не используется.</param>
        /// <param name="srcFolderPath">Путь к папке исходных файлов или String.Empty или  null если процесс не использует исходный каталог.</param>
        /// <param name="percent">значение прогресса в процентах. Укажите значение -1 если прогресс не используется.</param>
        private void SetFormTitle(String operation, String storageTitle, String srcFolderPath, int percent)
        {
            string result = "";
            //сформировать строку вида 38% Добавление TXT - КнигиЛибрусек - С:\temp\librusek1\1
            //если operation  = null, вывести только название приложения.
            if (String.IsNullOrEmpty(operation))
                result = Application.ProductName;
            else
            {
                result = result + operation;

                if (!String.IsNullOrEmpty(storageTitle))
                    result = result + " - " + storageTitle;
                if (!String.IsNullOrEmpty(srcFolderPath))
                    result = result + " - " + srcFolderPath;
                if (percent > -1)
                    result = percent.ToString() + "% " + result;
            }
            //set form title
            this.Text = result;
            Application.DoEvents();

            return;
        }

        /// <summary>
        /// NT-Показать файл справки
        /// </summary>
        private void showHelp()
        {
            try
            {
                Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Справка.chm"));
                //TODO: обновить файл справки "Справка.chm" в каталоге проекта приложения, 
                //сгенерировав его и скопировав из папки Documentation
            }
            catch (Exception ex)
            {
                this.showErrorMessageBox(null, "Файл справки приложения не найден или поврежден.\n" + ex.ToString());
            }

            return;
        }

        /// <summary>
        /// NT-Очистить дерево элементов и добавить одну пустую ноду-надпись.
        /// </summary>
        private void setEmptyTreeItems()
        {
            //TODO:  можно ли это перенести в TreeViewManager?
            this.treeView_TaskTreeView.BeginUpdate();
            this.treeView_TaskTreeView.Nodes.Clear();
            this.treeView_TaskTreeView.Nodes.Add("Нет элементов.");
            this.treeView_TaskTreeView.EndUpdate();
            //disable treeview
            //this.treeView_TaskTreeView.SelectedNode = null;
            this.treeView_TaskTreeView.Enabled = false;

            return;
        }

        #region *** Функции открытия и закрытия Хранилища ***

        /// <summary>
        /// NT-Creates the storage.
        /// </summary>
        private void createStorage()
        {
            //Этот код создания Хранилища кривой, наскоро надерган из других проектов.
            //TODO: Процесс создания Хранилища надо перепроектировать заново и реализовать правильно.
            //А сейчас он только для тестирования написан.

            try
            {
                String storageRootFolder = "";
                TaskStorageInfo info = null;
                //указать каталог для Хранилища
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.RootFolder = Environment.SpecialFolder.MyComputer;
                fb.ShowNewFolderButton = true;
                //if (!String.IsNullOrEmpty(m_storageFolder) && Directory.Exists(m_storageFolder))
                //    fb.SelectedPath = m_storageFolder;
                fb.Description = "Укажите родительский каталог для создаваемого Хранилища";
                if (fb.ShowDialog() != DialogResult.OK) return;
                storageRootFolder = fb.SelectedPath;
                fb = null;
                //1 показать форму свойств Хранилища, чтобы пользователь мог заполнить свойства Хранилища.
                //2 если форма закрыта с Cancel, выйти с сообщением, что создание Хранилища отменено пользователем.
                //  Если форма закрыта с ОК, продолжить
                info = new TaskStorageInfo();
                //info.Creator =  TODO: прописать эти поля в настройках, чтобы пользователь мог их изменить.
                info.Title = "Введите название здесь";
                info.Description = "Введите описание здесь";
                info.QualifiedName = "Задачи";
                info.StorageType = "Задачи";
                //info.StoragePath = storageRootFolder;//TODO: уточнить
                //
                StorageCreateForm f = new StorageCreateForm();
                f.Info = info;
                DialogResult dr = f.ShowDialog(this);
                if (dr != DialogResult.OK)
                {
                    //show information MessageBox
                    MessageBox.Show(this, "Создание Хранилища отменено пользователем.", MainForm.MainFormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //3 из формы извлечь корневую папку, а из прочих полей формы собрать TaskStorageInfo объект.
                TaskStorageInfo info2 = f.Info;

                //4 проверить, что папка доступна для записи
                //  Если нет, вывести сообщение - ошибку об этом и выйти
                if (StringUtility.isReadOnlyFolder(storageRootFolder) == true)
                {
                    this.showErrorMessageBox(null, "Ошибка: Указанный для размещения Хранилища каталог недоступен:\n" + storageRootFolder);
                    return;
                }
                //5 вызвать функцию создания Хранилища.
                CEngine.StorageCreate(storageRootFolder, info2);
                //6 вроде все...
                //TODO: можно сразу и открыть это хранилище по всем этим данным.
                //А лучше -открыть отдельным вызовом в вызывающей функции.
            }
            catch (Exception ex)
            {
                //set status text
                this.setStatusBarText("Ошибка создания Хранилища", true);
                //show exception info
                this.showErrorMessageBox(null, "Ошибка: Исключение " + ex.GetType().ToString() + "\n" + ex.ToString());
            }
            finally
            {


            }

            return;
        }

        /// <summary>
        /// NT-Loads the default storage.
        /// </summary>
        private void loadDefaultStorage()
        {
            //Из настроек приложения извлечь путь к Хранилищу, открываемому при запуске приложения.
            // Если оно не назначено, завершить функцию, чтобы выйти в главную форму.
            String storagePath = Tasks.Properties.Settings.Default.AutoStartStorage;
            if (String.IsNullOrEmpty(storagePath))
                return;
            //проверить что каталог Хранилища существует - это здесь только потому, что надо вывести сообщение о неправильном пути в настройке AutoStartStorage.
            if (!Directory.Exists(storagePath))
            {
                this.showErrorMessageBox(null, "Хранилище из настройки AutoStartStorage не найдено:\n" + storagePath);
                return;
            }
            //открыть указанное Хранилище
            this.loadStorage(storagePath);

            return;
        }

        /// <summary>
        /// NT-Loads the storage.
        /// </summary>
        /// <param name="storagePath">The storage path.</param>
        private void loadStorage(string storagePath)
        {
            try
            {
                //1 проверить что каталог Хранилища существует
                if (!Directory.Exists(storagePath))
                {
                    this.showErrorMessageBox(null, "Хранилище не найдено:\n" + storagePath);
                    return;
                }
                //2 проверить что это каталог Хранилища
                if (!CEngine.IsStorageFolder(storagePath))
                {
                    this.showErrorMessageBox(null, "Указанный каталог не является Хранилищем или Хранилище повреждено:\n" + storagePath);
                    return;
                }
                //3 определить readOnly для каталога Хранилища
                bool readOnlyMode = StringUtility.isReadOnlyFolder(storagePath);
                //4 TODO: Тут запустить показ диалога с прогрессбаром, когда он будет реализован.

                //5 открыть хранилище  при помощи Движка
                this.m_Engine.StorageOpen(storagePath, readOnlyMode);
                //6 если движок открыт в режиме Только чтение, то вывести предупреждение об этом.
                //если пользователь выберет Отмена, то завершить работу Движка и выйти в пустое главное окно.
                if (this.m_Engine.ReadOnly == true)
                {
                    DialogResult dr = MessageBox.Show(this,
                        "Хранилище открыто в режиме \"Только чтение\".\n" +
                        "Любые изменения в нем невозможны.\n" +
                        "Для продолжения работы нажмите OK.\n" +
                        "Для закрытия Хранилища нажмите  Cancel.",
                        MainFormTitle + " Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    //
                    if (dr != DialogResult.OK)
                        throw new Exception("Открытие Хранилища отменено пользователем.");
                    //else work next as readOnly mode
                }
                //Тут из-за дерева нод придется держать БД открытой постоянно.
                //Это нежелательно, но другой способ - держать всю БД в памяти как кеш - был сразу отметен как неподходящий, а теперь поздно переделывать.
                this.m_Engine.DbAdapter.Open();//он закрывается при закрытии Хранилища.
                //7 собрать и показать дерево элементов в форме
                this.ShowMainElementTree();
                //8 собрать и показать СписокСегодня
                this.ShowTodayTaksPanel();
                //9 строку состояния изменить на Хранилище открыто
                this.setStatusBarText("Хранилище успешно открыто: " + storagePath, false);
                //10 заголовок формы заменить на новую с путем хранилища.
                this.setMainFormTitle(storagePath, false);
                //11 переключить пункты меню приложения
                this.setEnableMainMenuItems(true);
                //12 TODO: прекратить показ диалога с прогрессбаром

                //выход
            }
            catch (Exception ex)
            {
                //close engine if initialized
                this.m_Engine.StorageClose();
                //clear all mainform items to Empty form.
                this.setMainFormEmpty(false);
                //set status text
                this.setStatusBarText("Ошибка открытия Хранилища", true);
                //show exception info
                this.showErrorMessageBox(null, "Ошибка: Исключение " + ex.GetType().ToString() + "\n" + ex.ToString());
            }
            finally
            {

            }

            return;
        }

        /// <summary>
        /// NR-собрать и показать СписокСегодня
        /// </summary>
        private void ShowTodayTaksPanel()
        {
            //TODO: add code here
        }

        /// <summary>
        /// NT-собрать и показать дерево элементов в форме.
        /// </summary>
        private void ShowMainElementTree()
        {
            //enable treeview
            this.treeView_TaskTreeView.Enabled = true;
            //show tree content
            this.m_TreeManager.ShowTree();

            return;
        }

        /// <summary>
        /// NT-Closes the storage.
        /// </summary>
        private void closeStorage()
        {
            //close engine if initialized
            this.m_Engine.StorageClose();
            //clear all mainform items to Empty form.
            this.setMainFormEmpty(false);
            //set status text
            this.setStatusBarText("Хранилище закрыто.", true);

            return;
        }

        #endregion

        /// <summary>
        /// NT-Sets the main form empty.
        /// </summary>
        private void setMainFormEmpty(bool updateForm)
        {
            //TODO: clear all mainform items to Empty form.
            try
            {
                //set default form title
                this.setMainFormTitle(null, false);
                ////do not change status text
                //this.setStatusBarText("Для начала работы откройте Хранилище", false);
                //disable some menu items
                this.setEnableMainMenuItems(false);
                //очистить дерево элементов и вставить надпись, что Хранилище не загружено.
                this.setEmptyTreeItems();
                //TODO: очистить правую панель главного окна как СписокСегодня
                //update form
                if (updateForm)
                    Application.DoEvents();
            }
            catch (Exception ex)
            {
                ;
            }

            return;
        }

        #region *** Обработчики событий Дерева элементов главного окна ***        

        /// <summary>
        /// NR-Handles the NodeMouseClick event of the treeView_TaskTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        private void treeView_TaskTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //свернуть или развернуть ноду
            //e.Node.Toggle();

            return;
        }

        /// <summary>
        /// NR-Handles the NodeMouseDoubleClick event of the treeView_TaskTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        private void treeView_TaskTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //для ноды корзины надо проверить, что кликнутая нода  - это нода корзины.
            TreeNode node = e.Node;
            if (node == null) return;
            CElement elem = (CElement)node.Tag;
            if (elem == null)
            {
                //check node is Trashcan
                if (this.m_TreeManager.IsTrashcanRootNode(node))
                    LeftPanelAction_TrashcanRootDoubleClicked(node);
            }
            else
            {
                LeftPanelAction_ElementDoubleClicked(elem);
            }

            return;
        }

        /// <summary>
        /// ТК-Handles the AfterSelect event of the treeView_TaskTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void treeView_TaskTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //skip startup selection
            if (e.Action == TreeViewAction.Unknown)
                return;
            //
            if (e.Node != null)
                e.Node.Toggle();
            //get element from selected node
            CElement elem = this.m_TreeManager.NodeSelected(e);
            if (elem == null)
            {
                //check node is Trashcan
                if (this.m_TreeManager.IsTrashcanRootNode(e.Node))
                    LeftPanelAction_TrashcanRootSelect(e.Node);
            }
            else
            {
                LeftPanelAction_ElementSelect(elem);
            }

            return;
        }

        /// <summary>
        /// NR-Handles the BeforeExpand event of the treeView_TaskTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        private void treeView_TaskTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            this.m_TreeManager.NodeBeforeExpand(e);

            return;
        }

        /// <summary>
        /// NR-Handles the BeforeCollapse event of the treeView_TaskTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        private void treeView_TaskTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            this.m_TreeManager.NodeBeforeCollapse(e);

            return;
        }

        /// <summary>
        /// NR-Handles the AfterSelect event of the treeView_TaskTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>

        #endregion

        #region *** Функции событий левой панели с деревом элементов. ***

        /// <summary>
        /// NR-Обработать событие выделения Корзины в левой панели главного окна
        /// </summary>
        /// <param name="node">The node.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LeftPanelAction_TrashcanRootSelect(TreeNode node)
        {
            String msg = node.Text;
            MessageBox.Show(msg, "Selected Trashcan");
            //TODO: add code here
            return;
        }

        /// <summary>
        /// NR-Обработать событие выделения элемента в левой панели главного окна
        /// </summary>
        /// <param name="elem">Элемент.</param>
        private void LeftPanelAction_ElementSelect(CElement elem)
        {
            String msg = elem.GetStringElementIdentifier(true);
            MessageBox.Show(msg, "Selected element");
            //TODO: add code here
            return;
        }

        /// <summary>
        /// NR-Обработать событие двойного клика Корзины в левой панели главного окна
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LeftPanelAction_TrashcanRootDoubleClicked(TreeNode node)
        {
            String msg = node.Text;
            MessageBox.Show(msg, "Double clicked Trashcan");
            //TODO: add code here
            return;
        }
        /// <summary>
        /// NR-Обработать событие двойного клика элемента в левой панели главного окна
        /// </summary>
        /// <param name="elem">The elem.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void LeftPanelAction_ElementDoubleClicked(CElement elem)
        {
            String msg = elem.GetStringElementIdentifier(true);
            MessageBox.Show(msg, "Double clicked element");
            //TODO: add code here
            return;
        }

        #endregion

        #region *** Обработчики контекстного меню контрола дерева *** 
        
        /// <summary>
        /// NT-Handles the Click event of the toolStripMenuItem_twcExpandAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_twcExpandAll_Click(object sender, EventArgs e)
        {
            this.treeView_TaskTreeView.ExpandAll();
        }

        /// <summary>
        /// NT-Handles the Click event of the toolStripMenuItem_twcCollapseAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_twcCollapseAll_Click(object sender, EventArgs e)
        {
            this.treeView_TaskTreeView.CollapseAll();
        }

        /// <summary>
        /// NT-Handles the Click event of the toolStripMenuItem_twcRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_twcRefresh_Click(object sender, EventArgs e)
        {
            this.m_TreeManager.UpdateTree();
        }

        #endregion

        #region *** Обработчики контекстного меню дерева ноды Категория ***        
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiCategory_Prop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiCategory_Prop_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку выделенного в дереве элемента.
            //Если данные элемента былиизменены, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiCategory_SubCat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiCategory_SubCat_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой категории, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiCategory_SubNote control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiCategory_SubNote_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой заметки, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiCategory_SubTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiCategory_SubTask_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой задачи, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiCategory_SubTag control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiCategory_SubTag_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания нового тега, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiCategory_Remove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiCategory_Remove_Click(object sender, EventArgs e)
        {
            //TODO: пометить текущий выделенный элемент неактивным и обновить дерево
        }
        #endregion

        #region *** Обработчики контекстного меню дерева ноды Заметка ***        
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiNote_Prop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiNote_Prop_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку выделенного в дереве элемента
            //Если данные элемента былиизменены, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiNote_SubTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiNote_SubTask_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой Задачи, где выделенная в дереве Заметка является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiNote_SubNote control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiNote_SubNote_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой Заметки, где выделенная в дереве Заметка является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the toolStripMenuItem_cmstiNote_Remove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItem_cmstiNote_Remove_Click(object sender, EventArgs e)
        {
            //TODO: пометить текущий выделенный элемент неактивным и обновить дерево.
        }
        #endregion

        #region *** Обработчики контекстного меню дерева ноды Задача ***        
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTaskProp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTaskProp_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку выделенного в дереве элемента
            //Если данные элемента былиизменены, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTaskComplet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTaskComplet_Click(object sender, EventArgs e)
        {
            //TODO: отметить выделенный элемент - задачу выполненной. Если это Задача.
            //И обновить дерево элементов. 
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTaskSubTask control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTaskSubTask_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой задачи, где выделенная в дереве Задача является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTaskSubNote control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTaskSubNote_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой Заметки, где выделенная в дереве Задача является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTaskRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTaskRemove_Click(object sender, EventArgs e)
        {
            //TODO: пометить текущий выделенный элемент неактивным и обновить дерево
        }
        #endregion

        #region *** Обработчики контекстного меню дерева ноды Тег ***        
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTagProp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTagProp_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку выделенного в дереве элемента
            //Если данные элемента былиизменены, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTag_SubNote control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTag_SubNote_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания новой Заметки, где выделенный в дереве Тег является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTag_SubTag control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTag_SubTag_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку создания нового Тега, где выделенный в дереве Тег является над-элементом
            //Если элемент был создан, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TreeItemTag_Remove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TreeItemTag_Remove_Click(object sender, EventArgs e)
        {
            //TODO: пометить текущий выделенный элемент неактивным и обновить дерево
        }
        #endregion

        #region *** Обработчики контекстного меню дерева ноды Корзина ***        
        /// <summary>
        /// NR-Handles the Click event of the tsmi_Prop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_Prop_Click(object sender, EventArgs e)
        {
            //TODO: показать Диалог настроек Корзины
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TrashcanClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TrashcanClear_Click(object sender, EventArgs e)
        {
            //TODO: запросить подтверждение операции и очистить Корзину
            //обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_RestoreAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_RestoreAll_Click(object sender, EventArgs e)
        {
            //TODO: запросить подтверждение операции и восстановить все удаленные элементы
            //Обновить дерево элементов.
        }

        #endregion

        #region *** Обработчики контекстного меню дерева ноды Элемент Корзины  ***        
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TrashcanItemProp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TrashcanItemProp_Click(object sender, EventArgs e)
        {
            //TODO: показать карточку выделенного в дереве элемента
            //Если данные элемента былиизменены, обновить дерево элементов.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TrashcanItemRestore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TrashcanItemRestore_Click(object sender, EventArgs e)
        {
            //TODO: Запросить подтверждение операции и восстановить выделенный в дереве элемент 
            //проверить, что элемент был помечен удаленным.
            //Обновить дерево элементов, чтобы отразить изменения.
        }
        /// <summary>
        /// NR-Handles the Click event of the tsmi_TrashcanItemDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tsmi_TrashcanItemDelete_Click(object sender, EventArgs e)
        {
            //TODO: Запросить подтверждение операции и удалить из БД выделенный в дереве элемент 
            //проверить, что элемент был помечен удаленным.
            //Обновить дерево элементов, чтобы отразить изменения.
        }

        #endregion

    }
}
