using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class TrashcanPropForm : Form
    {
        public TrashcanPropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static DialogResult ShowTrashcanPropForm(IWin32Window owner)
        {
            TrashcanPropForm form = new TrashcanPropForm(); 
            DialogResult dr = form.ShowDialog(owner);

            return dr;
        }

        private void TrashcanPropForm_Load(object sender, EventArgs e)
        {
            //загрузить размеры и позицию формы из файла настроек приложения
            Size formSize = Properties.Settings.Default.TrashcanPropFormSize;
            MainFormManager.SetFormSize(this, formSize);
            //поместить окно в позицию из настроек приложения.
            Point pt = Properties.Settings.Default.TrashcanPropFormPosition;
            MainFormManager.SetFormPosition(this, pt);
        }

        private void TrashcanPropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Сохранить позицию и размер формы в настройки приложения
            Properties.Settings.Default.TrashcanPropFormSize = this.Size;
            Properties.Settings.Default.TrashcanPropFormPosition = this.Location;
            //store setting files
            Properties.Settings.Default.Save();

            //TODO: add code here

            return;
        }

        private void TrashcanPropForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
