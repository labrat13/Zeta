using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TaskEngine.SettingSubsystem;

namespace Tasks.Forms
{
    public partial class StorageCreateForm : Form
    {
        private TaskStorageInfo m_info;

        public StorageCreateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Storage info about storage
        /// </summary>
        public TaskStorageInfo Info
        {
            get { return m_info; }
            set { m_info = value; }
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.Description = "Выберите каталог как место для нового Хранилища";
            f.RootFolder = Environment.SpecialFolder.MyComputer;
            f.ShowNewFolderButton = true;
            //this can throw exceptions if it is not valid path
            if (!String.IsNullOrEmpty(m_info.StoragePath) && Directory.Exists(m_info.StoragePath))
                f.SelectedPath = m_info.StoragePath;
            //show dialog
            if (f.ShowDialog() != DialogResult.OK)
                return;
            //store new path
            this.textBoxPath.Text = f.SelectedPath;

            return;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            //store values
            m_info.Title = this.textBoxTitle.Text;
            m_info.Description = this.textBoxDescr.Text;
            m_info.StoragePath = this.textBoxPath.Text;
            m_info.QualifiedName = this.textBoxQName.Text;
            m_info.StorageType = this.textBoxType.Text;

            this.DialogResult = DialogResult.OK;
            return;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void StorageInfoForm_Load(object sender, EventArgs e)
        {

            this.textBoxDescr.Text = m_info.Description;
            this.textBoxPath.Text = m_info.StoragePath;
            this.textBoxQName.Text = m_info.QualifiedName;
            this.textBoxTitle.Text = m_info.Title;
            this.textBoxType.Text = m_info.StorageType;

            return;
        }

    }
}
