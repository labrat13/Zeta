namespace Tasks.Forms
{
    partial class SettingTemplatesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingTemplatesForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_Templates = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Reload = new System.Windows.Forms.Button();
            this.textBox_Content = new System.Windows.Forms.TextBox();
            this.imageList_NodeIcons = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_Templates);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(515, 366);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView_Templates
            // 
            this.treeView_Templates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Templates.ImageIndex = 0;
            this.treeView_Templates.ImageList = this.imageList_NodeIcons;
            this.treeView_Templates.Location = new System.Drawing.Point(0, 0);
            this.treeView_Templates.Name = "treeView_Templates";
            this.treeView_Templates.SelectedImageIndex = 0;
            this.treeView_Templates.ShowNodeToolTips = true;
            this.treeView_Templates.Size = new System.Drawing.Size(171, 366);
            this.treeView_Templates.TabIndex = 0;
            this.treeView_Templates.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Templates_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Save, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Reload, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Content, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Cancel.Location = new System.Drawing.Point(247, 338);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(90, 25);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Save
            // 
            this.button_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Save.Location = new System.Drawing.Point(137, 338);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(90, 25);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Reload
            // 
            this.button_Reload.Location = new System.Drawing.Point(3, 338);
            this.button_Reload.Name = "button_Reload";
            this.button_Reload.Size = new System.Drawing.Size(115, 25);
            this.button_Reload.TabIndex = 2;
            this.button_Reload.Text = "Восстановить";
            this.button_Reload.UseVisualStyleBackColor = true;
            this.button_Reload.Click += new System.EventHandler(this.button_Reload_Click);
            // 
            // textBox_Content
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Content, 3);
            this.textBox_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Content.Location = new System.Drawing.Point(3, 3);
            this.textBox_Content.Multiline = true;
            this.textBox_Content.Name = "textBox_Content";
            this.textBox_Content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Content.Size = new System.Drawing.Size(334, 329);
            this.textBox_Content.TabIndex = 3;
            this.textBox_Content.WordWrap = false;
            this.textBox_Content.TextChanged += new System.EventHandler(this.textBox_Content_TextChanged);
            // 
            // imageList_NodeIcons
            // 
            this.imageList_NodeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_NodeIcons.ImageStream")));
            this.imageList_NodeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_NodeIcons.Images.SetKeyName(0, "category2.png");
            this.imageList_NodeIcons.Images.SetKeyName(1, "note.png");
            this.imageList_NodeIcons.Images.SetKeyName(2, "task.png");
            this.imageList_NodeIcons.Images.SetKeyName(3, "tag.png");
            this.imageList_NodeIcons.Images.SetKeyName(4, "application.png");
            this.imageList_NodeIcons.Images.SetKeyName(5, "DocumentHS.png");
            // 
            // SettingTemplatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(515, 366);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "SettingTemplatesForm";
            this.Text = "Изменить шаблоны из настроек:";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingTemplatesForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingTemplatesForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_Templates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Reload;
        private System.Windows.Forms.TextBox textBox_Content;
        private System.Windows.Forms.ImageList imageList_NodeIcons;
    }
}