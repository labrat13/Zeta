using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tasks.Forms
{
    public partial class TagPropForm : Form
    {
        public TagPropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static DialogResult ShowTagPropForm(IWin32Window owner)
        {
            TagPropForm form = new TagPropForm();
            DialogResult dr = form.ShowDialog(owner);

            return dr;
        }

        private void TagPropForm_Load(object sender, EventArgs e)
        {
            //загрузить размеры и позицию формы из файла настроек приложения
            Size formSize = Properties.Settings.Default.TagPropFormSize;
            MainFormManager.SetFormSize(this, formSize);
            //поместить окно в позицию из настроек приложения.
            Point pt = Properties.Settings.Default.TagPropFormPosition;
            MainFormManager.SetFormPosition(this, pt);
        }

        private void TagPropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Сохранить позицию и размер формы в настройки приложения
            Properties.Settings.Default.TagPropFormSize = this.Size;
            Properties.Settings.Default.TagPropFormPosition = this.Location;
            //store setting files
            Properties.Settings.Default.Save();

            //TODO: add code here

            return;
        }

        private void TagPropForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
