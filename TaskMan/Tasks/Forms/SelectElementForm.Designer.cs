namespace Tasks.Forms
{
    partial class SelectElementForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Узел0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Узел1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Узел2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Узел3");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectElementForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label_Information = new System.Windows.Forms.Label();
            this.treeView_Elements = new System.Windows.Forms.TreeView();
            this.imageList_ElementPics = new System.Windows.Forms.ImageList(this.components);
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_OK, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_Information, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeView_Elements, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Description, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 436);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(479, 408);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(389, 408);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_Information
            // 
            this.label_Information.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_Information, 4);
            this.label_Information.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Information.Location = new System.Drawing.Point(3, 0);
            this.label_Information.Name = "label_Information";
            this.label_Information.Size = new System.Drawing.Size(551, 40);
            this.label_Information.TabIndex = 2;
            this.label_Information.Text = "Информация об операции";
            // 
            // treeView_Elements
            // 
            this.treeView_Elements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Elements.HideSelection = false;
            this.treeView_Elements.ImageIndex = 0;
            this.treeView_Elements.ImageList = this.imageList_ElementPics;
            this.treeView_Elements.Location = new System.Drawing.Point(3, 43);
            this.treeView_Elements.Name = "treeView_Elements";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Узел0";
            treeNode1.Text = "Узел0";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Узел1";
            treeNode2.Text = "Узел1";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "Узел2";
            treeNode3.Text = "Узел2";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "Узел3";
            treeNode4.Text = "Узел3";
            this.treeView_Elements.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeView_Elements.SelectedImageIndex = 0;
            this.treeView_Elements.ShowNodeToolTips = true;
            this.treeView_Elements.Size = new System.Drawing.Size(271, 358);
            this.treeView_Elements.TabIndex = 3;
            this.treeView_Elements.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_Elements_BeforeCollapse);
            this.treeView_Elements.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_Elements_BeforeExpand);
            this.treeView_Elements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Elements_AfterSelect);
            // 
            // imageList_ElementPics
            // 
            this.imageList_ElementPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ElementPics.ImageStream")));
            this.imageList_ElementPics.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_ElementPics.Images.SetKeyName(0, "category2.png");
            this.imageList_ElementPics.Images.SetKeyName(1, "tag.png");
            this.imageList_ElementPics.Images.SetKeyName(2, "task.png");
            this.imageList_ElementPics.Images.SetKeyName(3, "note.png");
            // 
            // textBox_Description
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Description, 3);
            this.textBox_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Description.Location = new System.Drawing.Point(280, 43);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.ReadOnly = true;
            this.textBox_Description.Size = new System.Drawing.Size(274, 358);
            this.textBox_Description.TabIndex = 4;
            this.textBox_Description.Text = "Свойства выбранного элемента";
            // 
            // SelectElementForm
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(557, 436);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "SelectElementForm";
            this.Text = "SelectElementForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectElementForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectElementForm_FormClosed);
            this.Load += new System.EventHandler(this.SelectElementForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TreeView treeView_Elements;
        private System.Windows.Forms.Label label_Information;
        private System.Windows.Forms.ImageList imageList_ElementPics;
        private System.Windows.Forms.TextBox textBox_Description;
    }
}