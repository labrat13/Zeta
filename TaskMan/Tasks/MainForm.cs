using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TaskEngine;

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
        /// <param name="title">Заголовок окна сообщения</param>
        private void showErrorMessageBox(string title, string text)
        {
            MessageBox.Show(this, text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

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

        }

        private void toolStripMenuItem_OpenStorage_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem_CloseStorage_Click(object sender, EventArgs e)
        {

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
                this.showErrorMessageBox("Файл справки приложения не найден или поврежден.", ex.ToString());
            }
        }




    }
}
