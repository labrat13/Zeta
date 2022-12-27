namespace Tasks.Forms
{
    partial class CategoryPropForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_CardStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel_Base = new System.Windows.Forms.TableLayoutPanel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_General = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_EditTags = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_ElementTitle = new System.Windows.Forms.TextBox();
            this.linkLabel_Parent = new System.Windows.Forms.LinkLabel();
            this.button_SelectParent = new System.Windows.Forms.Button();
            this.textBox_ElementDescription = new System.Windows.Forms.TextBox();
            this.label_ElementId = new System.Windows.Forms.Label();
            this.label_ElementCreaTime = new System.Windows.Forms.Label();
            this.label_ElementModiTime = new System.Windows.Forms.Label();
            this.checkBox_ElementActiveState = new System.Windows.Forms.CheckBox();
            this.panel_ElementTagPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel_Tags = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel_TagExample = new System.Windows.Forms.LinkLabel();
            this.tabPage_Remarks = new System.Windows.Forms.TabPage();
            this.myRichTextControl_Remarks = new MyControlsLibrary.myRichTextControl();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel_Base.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_General.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_ElementTagPanel.SuspendLayout();
            this.flowLayoutPanel_Tags.SuspendLayout();
            this.tabPage_Remarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_CardStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(397, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_CardStatus
            // 
            this.toolStripStatusLabel_CardStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel_CardStatus.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel_CardStatus.Name = "toolStripStatusLabel_CardStatus";
            this.toolStripStatusLabel_CardStatus.Size = new System.Drawing.Size(382, 22);
            this.toolStripStatusLabel_CardStatus.Spring = true;
            this.toolStripStatusLabel_CardStatus.Text = "Состояние карточки";
            this.toolStripStatusLabel_CardStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel_Base
            // 
            this.tableLayoutPanel_Base.ColumnCount = 3;
            this.tableLayoutPanel_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel_Base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel_Base.Controls.Add(this.button_Cancel, 2, 1);
            this.tableLayoutPanel_Base.Controls.Add(this.button_OK, 1, 1);
            this.tableLayoutPanel_Base.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Base.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel_Base.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Base.Name = "tableLayoutPanel_Base";
            this.tableLayoutPanel_Base.RowCount = 2;
            this.tableLayoutPanel_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Base.Size = new System.Drawing.Size(397, 455);
            this.tableLayoutPanel_Base.TabIndex = 1;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Cancel.Location = new System.Drawing.Point(319, 428);
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
            this.button_OK.Location = new System.Drawing.Point(229, 428);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "ОК";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // tabControl1
            // 
            this.tableLayoutPanel_Base.SetColumnSpan(this.tabControl1, 3);
            this.tabControl1.Controls.Add(this.tabPage_General);
            this.tabControl1.Controls.Add(this.tabPage_Remarks);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(391, 419);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage_General
            // 
            this.tabPage_General.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_General.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_General.Location = new System.Drawing.Point(4, 27);
            this.tabPage_General.Name = "tabPage_General";
            this.tabPage_General.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_General.Size = new System.Drawing.Size(383, 388);
            this.tabPage_General.TabIndex = 0;
            this.tabPage_General.Text = "Основное";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_EditTags, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ElementTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel_Parent, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_SelectParent, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ElementDescription, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_ElementId, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label_ElementCreaTime, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_ElementModiTime, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_ElementActiveState, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel_ElementTagPanel, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(377, 382);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_EditTags
            // 
            this.button_EditTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_EditTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_EditTags.Location = new System.Drawing.Point(328, 157);
            this.button_EditTags.Margin = new System.Windows.Forms.Padding(1);
            this.button_EditTags.Name = "button_EditTags";
            this.button_EditTags.Size = new System.Drawing.Size(48, 26);
            this.button_EditTags.TabIndex = 14;
            this.button_EditTags.Text = "...";
            this.button_EditTags.UseVisualStyleBackColor = true;
            this.button_EditTags.Click += new System.EventHandler(this.button_EditTags_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Корень:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Описание:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Теги:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "ИД:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Создан:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Изменен:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Активен:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ElementTitle
            // 
            this.textBox_ElementTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ElementTitle.Location = new System.Drawing.Point(113, 3);
            this.textBox_ElementTitle.MinimumSize = new System.Drawing.Size(200, 24);
            this.textBox_ElementTitle.Name = "textBox_ElementTitle";
            this.textBox_ElementTitle.Size = new System.Drawing.Size(211, 24);
            this.textBox_ElementTitle.TabIndex = 8;
            this.textBox_ElementTitle.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // linkLabel_Parent
            // 
            this.linkLabel_Parent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkLabel_Parent.AutoSize = true;
            this.linkLabel_Parent.Location = new System.Drawing.Point(113, 33);
            this.linkLabel_Parent.Name = "linkLabel_Parent";
            this.linkLabel_Parent.Size = new System.Drawing.Size(73, 18);
            this.linkLabel_Parent.TabIndex = 9;
            this.linkLabel_Parent.TabStop = true;
            this.linkLabel_Parent.Text = "linkLabel1";
            this.linkLabel_Parent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel_Parent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Parent_LinkClicked);
            // 
            // button_SelectParent
            // 
            this.button_SelectParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_SelectParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SelectParent.Location = new System.Drawing.Point(328, 29);
            this.button_SelectParent.Margin = new System.Windows.Forms.Padding(1);
            this.button_SelectParent.Name = "button_SelectParent";
            this.button_SelectParent.Size = new System.Drawing.Size(48, 26);
            this.button_SelectParent.TabIndex = 10;
            this.button_SelectParent.Text = "...";
            this.button_SelectParent.UseVisualStyleBackColor = true;
            this.button_SelectParent.Click += new System.EventHandler(this.button_SelectParent_Click);
            // 
            // textBox_ElementDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_ElementDescription, 3);
            this.textBox_ElementDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ElementDescription.Location = new System.Drawing.Point(3, 85);
            this.textBox_ElementDescription.MinimumSize = new System.Drawing.Size(100, 70);
            this.textBox_ElementDescription.Multiline = true;
            this.textBox_ElementDescription.Name = "textBox_ElementDescription";
            this.textBox_ElementDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ElementDescription.Size = new System.Drawing.Size(371, 70);
            this.textBox_ElementDescription.TabIndex = 11;
            this.textBox_ElementDescription.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label_ElementId
            // 
            this.label_ElementId.AutoSize = true;
            this.label_ElementId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ElementId.Location = new System.Drawing.Point(113, 258);
            this.label_ElementId.MinimumSize = new System.Drawing.Size(200, 24);
            this.label_ElementId.Name = "label_ElementId";
            this.label_ElementId.Size = new System.Drawing.Size(211, 28);
            this.label_ElementId.TabIndex = 15;
            this.label_ElementId.Text = "label9";
            this.label_ElementId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ElementCreaTime
            // 
            this.label_ElementCreaTime.AutoSize = true;
            this.label_ElementCreaTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ElementCreaTime.Location = new System.Drawing.Point(113, 286);
            this.label_ElementCreaTime.MinimumSize = new System.Drawing.Size(200, 24);
            this.label_ElementCreaTime.Name = "label_ElementCreaTime";
            this.label_ElementCreaTime.Size = new System.Drawing.Size(211, 28);
            this.label_ElementCreaTime.TabIndex = 16;
            this.label_ElementCreaTime.Text = "label10";
            this.label_ElementCreaTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ElementModiTime
            // 
            this.label_ElementModiTime.AutoSize = true;
            this.label_ElementModiTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ElementModiTime.Location = new System.Drawing.Point(113, 314);
            this.label_ElementModiTime.MinimumSize = new System.Drawing.Size(200, 24);
            this.label_ElementModiTime.Name = "label_ElementModiTime";
            this.label_ElementModiTime.Size = new System.Drawing.Size(211, 28);
            this.label_ElementModiTime.TabIndex = 17;
            this.label_ElementModiTime.Text = "label11";
            this.label_ElementModiTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_ElementActiveState
            // 
            this.checkBox_ElementActiveState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_ElementActiveState.AutoCheck = false;
            this.checkBox_ElementActiveState.AutoSize = true;
            this.checkBox_ElementActiveState.Location = new System.Drawing.Point(113, 347);
            this.checkBox_ElementActiveState.Name = "checkBox_ElementActiveState";
            this.checkBox_ElementActiveState.Size = new System.Drawing.Size(18, 17);
            this.checkBox_ElementActiveState.TabIndex = 18;
            this.checkBox_ElementActiveState.UseVisualStyleBackColor = true;
            this.checkBox_ElementActiveState.CheckedChanged += new System.EventHandler(this.checkBox_ElementActiveState_CheckedChanged);
            // 
            // panel_ElementTagPanel
            // 
            this.panel_ElementTagPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.panel_ElementTagPanel, 3);
            this.panel_ElementTagPanel.Controls.Add(this.flowLayoutPanel_Tags);
            this.panel_ElementTagPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ElementTagPanel.Location = new System.Drawing.Point(3, 187);
            this.panel_ElementTagPanel.Name = "panel_ElementTagPanel";
            this.panel_ElementTagPanel.Size = new System.Drawing.Size(371, 68);
            this.panel_ElementTagPanel.TabIndex = 19;
            // 
            // flowLayoutPanel_Tags
            // 
            this.flowLayoutPanel_Tags.Controls.Add(this.linkLabel_TagExample);
            this.flowLayoutPanel_Tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Tags.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_Tags.Name = "flowLayoutPanel_Tags";
            this.flowLayoutPanel_Tags.Size = new System.Drawing.Size(367, 64);
            this.flowLayoutPanel_Tags.TabIndex = 0;
            // 
            // linkLabel_TagExample
            // 
            this.linkLabel_TagExample.AutoSize = true;
            this.linkLabel_TagExample.Location = new System.Drawing.Point(3, 0);
            this.linkLabel_TagExample.Name = "linkLabel_TagExample";
            this.linkLabel_TagExample.Size = new System.Drawing.Size(104, 18);
            this.linkLabel_TagExample.TabIndex = 0;
            this.linkLabel_TagExample.TabStop = true;
            this.linkLabel_TagExample.Text = "Образец Тега";
            this.linkLabel_TagExample.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_TagExample_LinkClicked);
            // 
            // tabPage_Remarks
            // 
            this.tabPage_Remarks.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Remarks.Controls.Add(this.myRichTextControl_Remarks);
            this.tabPage_Remarks.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Remarks.Name = "tabPage_Remarks";
            this.tabPage_Remarks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Remarks.Size = new System.Drawing.Size(383, 388);
            this.tabPage_Remarks.TabIndex = 1;
            this.tabPage_Remarks.Text = "Заметки";
            // 
            // myRichTextControl_Remarks
            // 
            this.myRichTextControl_Remarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myRichTextControl_Remarks.Location = new System.Drawing.Point(3, 3);
            this.myRichTextControl_Remarks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.myRichTextControl_Remarks.Name = "myRichTextControl_Remarks";
            this.myRichTextControl_Remarks.Size = new System.Drawing.Size(377, 382);
            this.myRichTextControl_Remarks.TabIndex = 0;
            this.myRichTextControl_Remarks.TextReadOnly = false;
            this.myRichTextControl_Remarks.ToolStrip_Visible = false;
            // 
            // CategoryPropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 477);
            this.Controls.Add(this.tableLayoutPanel_Base);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(415, 524);
            this.Name = "CategoryPropForm";
            this.Text = "CategoryPropForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CategoryPropForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CategoryPropForm_FormClosed);
            this.Load += new System.EventHandler(this.CategoryPropForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel_Base.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_General.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_ElementTagPanel.ResumeLayout(false);
            this.flowLayoutPanel_Tags.ResumeLayout(false);
            this.flowLayoutPanel_Tags.PerformLayout();
            this.tabPage_Remarks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_CardStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Base;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_General;
        private System.Windows.Forms.TabPage tabPage_Remarks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MyControlsLibrary.myRichTextControl myRichTextControl_Remarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_ElementTitle;
        private System.Windows.Forms.LinkLabel linkLabel_Parent;
        private System.Windows.Forms.Button button_SelectParent;
        private System.Windows.Forms.TextBox textBox_ElementDescription;
        private System.Windows.Forms.Button button_EditTags;
        private System.Windows.Forms.Label label_ElementId;
        private System.Windows.Forms.Label label_ElementCreaTime;
        private System.Windows.Forms.Label label_ElementModiTime;
        private System.Windows.Forms.CheckBox checkBox_ElementActiveState;
        private System.Windows.Forms.Panel panel_ElementTagPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Tags;
        private System.Windows.Forms.LinkLabel linkLabel_TagExample;
    }
}