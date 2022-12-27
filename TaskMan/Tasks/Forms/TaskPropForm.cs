using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class TaskPropForm : Form
    {
        public TaskPropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static DialogResult ShowTaskPropForm(IWin32Window owner)
        {
            TaskPropForm form = new TaskPropForm();
            DialogResult dr = form.ShowDialog(owner);

            return dr;
        }

        private void TaskPropForm_Load(object sender, EventArgs e)
        {
            //загрузить размеры и позицию формы из файла настроек приложения
            Size formSize = Properties.Settings.Default.TaskPropFormSize;
            MainFormManager.SetFormSize(this, formSize);
            //поместить окно в позицию из настроек приложения.
            Point pt = Properties.Settings.Default.TaskPropFormPosition;
            MainFormManager.SetFormPosition(this, pt);
        }

        private void TaskPropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Сохранить позицию и размер формы в настройки приложения
            Properties.Settings.Default.TaskPropFormSize = this.Size;
            Properties.Settings.Default.TaskPropFormPosition = this.Location;
            //store setting files
            Properties.Settings.Default.Save();

            //TODO: add code here

            return;
        }

        private void TaskPropForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
