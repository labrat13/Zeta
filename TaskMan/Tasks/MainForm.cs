using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TaskEngine;
using TaskEngine.Utilities;

namespace Tasks
{
    public partial class MainForm : Form
    {

        #region *** Constants and Fields ***  
        /// <summary>
        /// Название окна приложения
        /// </summary>
        private const String MainFormTitle = "Менеджер Задач";

        /// <summary>
        /// Task engine object
        /// </summary>
        private CEngine m_Engine;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            this.m_Engine = new CEngine();
            //TODO: add code here
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

        /// <summary>
        /// NT-Установить новый текст статусбара
        /// </summary>
        /// <param name="text">Новый текст статусбара</param>
        /// <param name="updateForm">Обновить вид формы?</param>
        private void setStatusBarText(string text, bool updateForm)
        {
            this.toolStripStatusLabel_MainStatus.Text = text;
            if(updateForm)
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
            if(String.IsNullOrEmpty(title))
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

        #region *** Form Load Closing Closed handlers ***        
        /// <summary>
        /// NT-Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //TODO: Add code here
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: Add code here
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
            //TODO: Add code here
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
            fbd.RootFolder = Environment.SpecialFolder.MyDocuments;
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
        }

        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            //вся обработка завершения работы должна проводиться в Form.Closing()
        }

        #endregion

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
            catch(Exception ex)
            {
                this.showErrorMessageBox(null, "Файл справки приложения не найден или поврежден.\n" + ex.ToString());
            }
        }

        /// <summary>
        /// NT-Очистить дерево элементов и добавить одну пустую ноду-надпись.
        /// </summary>
        private void setEmptyTreeItems()
        {
            this.treeView_TaskTreeView.BeginUpdate();
            this.treeView_TaskTreeView.Nodes.Clear();
            this.treeView_TaskTreeView.Nodes.Add("Нет элементов.");
            this.treeView_TaskTreeView.EndUpdate();

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
        /// NR-Loads the storage.
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
                if(this.m_Engine.ReadOnly == true)
                {
                    DialogResult dr = MessageBox.Show(this,
                        "Хранилище открыто в режиме \"Только чтение\".\n" +
                        "Любые изменения в нем невозможны.\n" +
                        "Для продолжения работы нажмите OK.\n" +
                        "Для закрытия Хранилища нажмите  Cancel.", 
                        MainFormTitle + " Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    //
                    if(dr != DialogResult.OK)
                        throw new Exception("Открытие Хранилища отменено пользователем.");
                    //else work next as readOnly mode
                }
                //7 собрать и показать дерево элементов в форме
                //TODO: Add code here
                //8 собрать и показать СписокСегодня
                //TODO: Add code here
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
                if(updateForm)
                    Application.DoEvents();
            }
            catch(Exception ex)
            {
                ;
            }

            return;
        }
    }
}
