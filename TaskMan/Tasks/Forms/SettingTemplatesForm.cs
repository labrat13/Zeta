using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskEngine;

namespace Tasks.Forms
{
    public partial class SettingTemplatesForm : Form
    {

        private const int TreeIconIndex_Category = 0;
        private const int TreeIconIndex_Note = 1;
        private const int TreeIconIndex_Task = 2;
        private const int TreeIconIndex_Tag = 3;
        private const int TreeIconIndex_Application = 4;
        private const int TreeIconIndex_Document = 5;

        public bool m_isChanged = false;

        public string m_nodeTitle;

        
        public SettingTemplatesForm()
        {
            InitializeComponent();

        }

        private void SettingTemplatesForm_Load(object sender, EventArgs e)
        {
            //загрузить размеры и позицию формы из файла настроек приложения
            Size formSize = Properties.Settings.Default.SettingTemplatesFormSize;
            MainFormManager.SetFormSize(this, formSize);
            //поместить окно в позицию из настроек приложения.
            Point pt = Properties.Settings.Default.SettingTemplatesFormPosition;
            MainFormManager.SetFormPosition(this, pt);

            //Fill tree with settings nodes
            UpdateTreeView();
            EnableSaveButtons(false);
        }

        /// <summary>
        /// NT-Updates the TreeView.
        /// </summary>
        private void UpdateTreeView()
        {
            this.treeView_Templates.Nodes.Clear();
            //Properties.Settings sett = Properties.Settings.Default;
            //add items
            TreeNode t1;
            t1 = makeTreeNode(TreeIconIndex_Application, "Приложение", "Параметры приложения", "");
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "AutoStartStorage", "Хранилище, автоматически открываемое при запуске приложения.", ""));
            this.treeView_Templates.Nodes.Add(t1);
            //
            t1 = makeTreeNode(TreeIconIndex_Category, "Категория", "Начальные значения для Категорий.", "");
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateCategoryTitle", "Начальное название Категории.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateCategoryDescription", "Начальное краткое описание Категории.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateCategoryRemarks", "Начальное полное описание Категории.", ""));
            this.treeView_Templates.Nodes.Add(t1);
            //
            t1 = makeTreeNode(TreeIconIndex_Note, "Заметка", "Начальные значения для Заметок.", "");
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateNoteTitle", "Начальное название Заметки.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateNoteDescription", "Начальное краткое описание Заметки.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateNoteRemarks", "Начальное полное описание Заметки.", ""));
            this.treeView_Templates.Nodes.Add(t1);
            //
            t1 = makeTreeNode(TreeIconIndex_Task, "Задача", "Начальные значения для Задач.", "");
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateTaskTitle", "Начальное название Задачи.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateTaskDescription", "Начальное краткое описание Задачи.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateTaskRemarks", "Начальное полное описание Задачи.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateTaskResults", "Начальное перечисление результатов Задачи.", ""));
            this.treeView_Templates.Nodes.Add(t1);
            //
            t1 = makeTreeNode(TreeIconIndex_Tag, "Тег", "Начальные значения для Тегов.", "");
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateTagTitle", "Начальное название Тега.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateTagDescription", "Начальное краткое описание Тега.", ""));
            t1.Nodes.Add(makeTreeNode(TreeIconIndex_Document, "TemplateTagRemarks", "Начальное полное описание Тега.", ""));
            this.treeView_Templates.Nodes.Add(t1);

            return;
        }

        /// <summary>
        /// NT-Makes the tree node.
        /// </summary>
        /// <param name="iconIndex">Index of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="descr">The description.</param>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        private TreeNode makeTreeNode(int iconIndex, string title, string descr, string s)
        {
            TreeNode tn = new TreeNode();
            //get icon index
            tn.ImageIndex = iconIndex;
            tn.SelectedImageIndex = iconIndex;
            //text
            tn.Text = title;
            tn.ToolTipText = descr;

            return tn;
        }

        /// <summary>
        /// NT-Enables the save buttons.
        /// </summary>
        /// <param name="v">if set to <c>true</c> [v].</param>
        private void EnableSaveButtons(bool v)
        {
            this.button_Reload.Enabled = v;
            this.button_Save.Enabled = v;

            return;
        }

        private void SettingTemplatesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Сохранить позицию и размер формы в настройки приложения
            Properties.Settings.Default.SettingTemplatesFormSize = this.Size;
            Properties.Settings.Default.SettingTemplatesFormPosition = this.Location;
            //store setting files
            Properties.Settings.Default.Save();

            //TODO: add code here

            return;
        }

        /// <summary>
        /// NT-Handles the TextChanged event of the textBox_Content control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox_Content_TextChanged(object sender, EventArgs e)
        {
            if (m_isChanged == false)
            {
                m_isChanged = true;
                EnableSaveButtons(true);
            }
        }

        /// <summary>
        /// NT-Handles the AfterSelect event of the treeView_Templates control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void treeView_Templates_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node;
            if (tn == null)
                return;
            String title = tn.Text;
            String descr = tn.ToolTipText;
            //write title to class field for later using
            this.m_nodeTitle = title;
            //load text to control
            Reload();

            return;
        }
        
        /// <summary>
        /// NT-Handles the Click event of the button_Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        /// <summary>
        /// NT-Handles the Click event of the button_Save control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            this.SetSetting(this.m_nodeTitle, this.textBox_Content.Text);
            //store new data to disk
            Properties.Settings.Default.Save();

            return;
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        /// <summary>
        /// NT-Reloads this item text.
        /// </summary>
        private void Reload()
        {
            this.textBox_Content.Clear();
            //load text to control
            object content = getSetting(this.m_nodeTitle);
            if (content == null) return;
            this.textBox_Content.Text = content.ToString();
            this.m_isChanged = false;
            this.EnableSaveButtons(false);
            this.textBox_Content.Focus();

            return;
        }

        /// <summary>
        /// NT-Gets the setting.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        private object getSetting(String title)
        {   
            Object result = null;
            try
            {
                result = Properties.Settings.Default[title];
            }
            catch(Exception ex)
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// NT-Sets the setting.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        private void SetSetting(string title, string text)
        {
            try
            {
                Properties.Settings.Default[title] = text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения данных для " + title + " :\n" + ex.ToString(), MainForm.MainFormTitle + " - Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return;
        }
    }
}
