namespace Tasks.Forms
{
    partial class StorageCreateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxQName = new System.Windows.Forms.TextBox();
            this.textBoxDescr = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(16, 36);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(395, 22);
            this.textBoxTitle.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxTitle, "Название Хранилища");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Квалифицированное имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Описание:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Класс Хранилища:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Каталог Хранилища:";
            // 
            // textBoxQName
            // 
            this.textBoxQName.Location = new System.Drawing.Point(16, 84);
            this.textBoxQName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxQName.Name = "textBoxQName";
            this.textBoxQName.Size = new System.Drawing.Size(395, 22);
            this.textBoxQName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxQName, "Иерархия классов через точку: Книга.КнигаЭкономика");
            // 
            // textBoxDescr
            // 
            this.textBoxDescr.Location = new System.Drawing.Point(16, 132);
            this.textBoxDescr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDescr.Name = "textBoxDescr";
            this.textBoxDescr.Size = new System.Drawing.Size(395, 22);
            this.textBoxDescr.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxDescr, "Краткое описание Хранилища");
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(16, 180);
            this.textBoxType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(395, 22);
            this.textBoxType.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxType, "Базовый класс документов Хранилища через :: Книга::КнигаЭкономика<Документ,Изобра" +
        "жение>");
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(16, 228);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(395, 22);
            this.textBoxPath.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBoxPath, "Путь к каталогу Хранилища. Для вновь создаваемого Хранилища конечная папка не дол" +
        "жна еще существовать!");
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(420, 228);
            this.button_browse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(49, 28);
            this.button_browse.TabIndex = 5;
            this.button_browse.Text = "...";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(369, 276);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(261, 276);
            this.button_OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 28);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // StorageCreateForm
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(483, 319);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.textBoxDescr);
            this.Controls.Add(this.textBoxQName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "StorageCreateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Свойства Хранилища";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StorageCreateForm_FormClosed);
            this.Load += new System.EventHandler(this.StorageInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxQName;
        private System.Windows.Forms.TextBox textBoxDescr;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}