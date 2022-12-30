using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class NotePropForm : Form
    {
        public NotePropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static bool ShowNotePropForm(IWin32Window owner)
        {
            NotePropForm form = new NotePropForm();
            DialogResult dr = form.ShowDialog(owner);

            return false;
        }

        private void NotePropForm_Load(object sender, EventArgs e)
        {
            //загрузить размеры и позицию формы из файла настроек приложения
            Size formSize = Properties.Settings.Default.NotePropFormSize;
            MainFormManager.SetFormSize(this, formSize);
            //поместить окно в позицию из настроек приложения.
            Point pt = Properties.Settings.Default.NotePropFormPosition;
            MainFormManager.SetFormPosition(this, pt);
        }

        private void NotePropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Сохранить позицию и размер формы в настройки приложения
            Properties.Settings.Default.NotePropFormSize = this.Size;
            Properties.Settings.Default.NotePropFormPosition = this.Location;
            //store setting files
            Properties.Settings.Default.Save();

            //TODO: add code here

            return;
        }

        private void NotePropForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
