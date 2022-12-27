namespace Tasks.Forms
{
    partial class StorageShortInfoForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Main = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_ReadOnly = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_Descr = new System.Windows.Forms.TextBox();
            this.textBox_Creator = new System.Windows.Forms.TextBox();
            this.textBox_Directory = new System.Windows.Forms.TextBox();
            this.textBox_Class = new System.Windows.Forms.TextBox();
            this.button_Path = new System.Windows.Forms.Button();
            this.tabPage_Other = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.Controls.Add(this.button_OK, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 315);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(234, 282);
            this.button_OK.Margin = new System.Windows.Forms.Padding(4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 28);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "ОК";
            this.toolTip1.SetToolTip(this.button_OK, "Сохранить изменения");
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(347, 282);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 28);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Отмена";
            this.toolTip1.SetToolTip(this.button_Cancel, "Не сохранять изменения");
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 3);
            this.tabControl1.Controls.Add(this.tabPage_Main);
            this.tabControl1.Controls.Add(this.tabPage_Other);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 270);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.Controls.Add(this.tableLayoutPanel2);
            this.tabPage_Main.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Main.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_Main.Size = new System.Drawing.Size(440, 241);
            this.tabPage_Main.TabIndex = 0;
            this.tabPage_Main.Text = "Основные";
            this.toolTip1.SetToolTip(this.tabPage_Main, "Вкладка Основные свойства");
            this.tabPage_Main.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_ReadOnly, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Version, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Title, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Descr, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Creator, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Directory, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Class, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.button_Path, 2, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(432, 233);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Название: (*)";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Описание:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Создатель:";
            // 
            // checkBox_ReadOnly
            // 
            this.checkBox_ReadOnly.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_ReadOnly.AutoSize = true;
            this.checkBox_ReadOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel2.SetColumnSpan(this.checkBox_ReadOnly, 2);
            this.checkBox_ReadOnly.Location = new System.Drawing.Point(4, 102);
            this.checkBox_ReadOnly.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_ReadOnly.Name = "checkBox_ReadOnly";
            this.checkBox_ReadOnly.Size = new System.Drawing.Size(129, 20);
            this.checkBox_ReadOnly.TabIndex = 3;
            this.checkBox_ReadOnly.Text = "Только чтение:";
            this.toolTip1.SetToolTip(this.checkBox_ReadOnly, "Установите флажок, если изменения в проекте недопустимы");
            this.checkBox_ReadOnly.UseVisualStyleBackColor = true;
            this.checkBox_ReadOnly.CheckedChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(4, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Каталог: (*)";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Класс движка:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Версия движка:";
            // 
            // textBox_Version
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox_Version, 2);
            this.textBox_Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Version.Location = new System.Drawing.Point(131, 196);
            this.textBox_Version.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.ReadOnly = true;
            this.textBox_Version.Size = new System.Drawing.Size(297, 22);
            this.textBox_Version.TabIndex = 7;
            // 
            // textBox_Title
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox_Title, 2);
            this.textBox_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Title.Location = new System.Drawing.Point(131, 4);
            this.textBox_Title.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(297, 22);
            this.textBox_Title.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox_Title, "Введите название проекта");
            this.textBox_Title.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // textBox_Descr
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox_Descr, 2);
            this.textBox_Descr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Descr.Location = new System.Drawing.Point(131, 36);
            this.textBox_Descr.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Descr.Name = "textBox_Descr";
            this.textBox_Descr.Size = new System.Drawing.Size(297, 22);
            this.textBox_Descr.TabIndex = 1;
            this.textBox_Descr.Text = " ";
            this.toolTip1.SetToolTip(this.textBox_Descr, "Введите краткое описание проекта");
            this.textBox_Descr.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // textBox_Creator
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox_Creator, 2);
            this.textBox_Creator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Creator.Location = new System.Drawing.Point(131, 68);
            this.textBox_Creator.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Creator.Name = "textBox_Creator";
            this.textBox_Creator.Size = new System.Drawing.Size(297, 22);
            this.textBox_Creator.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBox_Creator, "Введите название создателя проекта");
            this.textBox_Creator.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // textBox_Directory
            // 
            this.textBox_Directory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Directory.Location = new System.Drawing.Point(131, 132);
            this.textBox_Directory.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Directory.Name = "textBox_Directory";
            this.textBox_Directory.ReadOnly = true;
            this.textBox_Directory.Size = new System.Drawing.Size(244, 22);
            this.textBox_Directory.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBox_Directory, "Путь к каталогу данных проекта");
            this.textBox_Directory.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // textBox_Class
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox_Class, 2);
            this.textBox_Class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Class.Location = new System.Drawing.Point(131, 164);
            this.textBox_Class.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Class.Name = "textBox_Class";
            this.textBox_Class.ReadOnly = true;
            this.textBox_Class.Size = new System.Drawing.Size(297, 22);
            this.textBox_Class.TabIndex = 6;
            // 
            // button_Path
            // 
            this.button_Path.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Path.Location = new System.Drawing.Point(379, 130);
            this.button_Path.Margin = new System.Windows.Forms.Padding(0);
            this.button_Path.Name = "button_Path";
            this.button_Path.Size = new System.Drawing.Size(53, 28);
            this.button_Path.TabIndex = 4;
            this.button_Path.Text = "...";
            this.toolTip1.SetToolTip(this.button_Path, "Кликните чтобы изменить путь к каталогу");
            this.button_Path.UseVisualStyleBackColor = true;
            this.button_Path.Click += new System.EventHandler(this.button_Path_Click);
            // 
            // tabPage_Other
            // 
            this.tabPage_Other.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Other.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_Other.Name = "tabPage_Other";
            this.tabPage_Other.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_Other.Size = new System.Drawing.Size(440, 241);
            this.tabPage_Other.TabIndex = 1;
            this.tabPage_Other.Text = "Другие";
            this.toolTip1.SetToolTip(this.tabPage_Other, "Вкладка Прочие свойства");
            this.tabPage_Other.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 288);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "* - Обязательное поле";
            // 
            // StorageShortInfoForm
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(456, 315);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(461, 346);
            this.Name = "StorageShortInfoForm";
            this.Text = "EngineSettingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StorageShortInfoForm_FormClosed);
            this.Load += new System.EventHandler(this.StorageShortInfoForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Main.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Main;
        private System.Windows.Forms.TabPage tabPage_Other;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_ReadOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox_Descr;
        private System.Windows.Forms.TextBox textBox_Creator;
        private System.Windows.Forms.TextBox textBox_Directory;
        private System.Windows.Forms.TextBox textBox_Class;
        private System.Windows.Forms.Button button_Path;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
    }
}