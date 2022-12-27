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
    public partial class CategoryPropForm : Form
    {
        #region *** Constants and fields ***  

        /// <summary>
        /// Флаг что состочние данных было изменено
        /// </summary>
        private bool m_Changed;

        /// <summary>
        /// Флаг, что данные элемента не должны быть изменены, форма только для просмотра.
        /// </summary>
        private bool m_ReadOnly;

        /// <summary>
        /// Элемент, отображаемый в форме.
        /// </summary>
        private CElement m_Element;

        /// <summary>
        /// Объект Движка для доступа к БД Хранилища.
        /// </summary>
        private CEngine m_Engine;

        #endregion

        /// <summary>
        /// NT-Initializes a new instance of the <see cref="CategoryPropForm"/> class.
        /// </summary>
        public CategoryPropForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NR-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <returns>Function returns <c>DialogResult</c> code.</returns>
        public static DialogResult ShowCategoryPropForm(IWin32Window owner)
        {
            CategoryPropForm form = new CategoryPropForm();
            DialogResult dr = form.ShowDialog(owner);
            //TODO: add code here
            //Если диалог завершен с ОК, сохранить элемент в БД?
            //- элемент обновляется или создается? Здесь это неизвестно.
            return dr;
        }

        #region *** Properties ***

        /// <summary>
        /// Элемент, отображаемый в форме.
        /// </summary>
        public CElement Element { get => m_Element; set => m_Element = value; }

        /// <summary>
        /// Объект Движка для доступа к БД Хранилища.
        /// </summary>
        public CEngine Engine { get => m_Engine; set => m_Engine = value; }

        /// <summary>
        /// Флаг, что данные элемента не должны быть изменены, форма только для просмотра.
        /// </summary>
        public bool ReadOnly { get => m_ReadOnly; set => m_ReadOnly = value; }

        #endregion

        #region *** Form button event handlers ***

        /// <summary>
        /// NR-Handles the Load event of the CategoryPropForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CategoryPropForm_Load(object sender, EventArgs e)
        {
            //загрузить размеры и позицию формы из файла настроек приложения
            Size formSize = Properties.Settings.Default.CategoryPropFormSize;
            MainFormManager.SetFormSize(this, formSize);
            //поместить окно в позицию из настроек приложения.
            Point pt = Properties.Settings.Default.CategoryPropFormPosition;
            MainFormManager.SetFormPosition(this, pt);

            //set form data
            this.setFormData();

            //clear change flag and disable  OK button
            this.setChangeFlag(false);

            return;
        }

        /// <summary>
        /// NR-Handles the FormClosing event of the CategoryPropForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void CategoryPropForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO: add code here
        }

        /// <summary>
        /// NR-Handles the FormClosed event of the CategoryPropForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void CategoryPropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Сохранить позицию и размер формы в настройки приложения
            Properties.Settings.Default.CategoryPropFormSize = this.Size;
            Properties.Settings.Default.CategoryPropFormPosition = this.Location;
            //store setting files
            Properties.Settings.Default.Save();

            //TODO: add code here
            
            return;
        }
        /// <summary>
        /// NR-Handles the Click event of the button_SelectParent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_SelectParent_Click(object sender, EventArgs e)
        {
            //TODO: тут показать диалог выбора над-элемента, вписать его в линк и установить флаг изменения данных. 

        }
        /// <summary>
        /// NR-Handles the LinkClicked event of the linkLabel_Parent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabel_Parent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: тут открыть для просмотра Карточку Элемента кликнутого элемента.
        }
        /// <summary>
        /// NR-Handles the Click event of the button_EditTags control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_EditTags_Click(object sender, EventArgs e)
        {
            //TODO: Отложить: тут показать диалог выбора тегов элемента, после его закрытия вписать теги как линки в панель тегов на форме.
            //И установить обработчики кликов по линкам. а как обрабатывать эти клики - я пока не знаю. Надо придумать.
            //- решено отложить работы с тегами на более поздний релиз.
        }
        /// <summary>
        /// NR-Handles the CheckedChanged event of the checkBox_ElementActiveState control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBox_ElementActiveState_CheckedChanged(object sender, EventArgs e)
        {
            //TODO: Если флаг снимается, надо проверить, что удаление возможно, при помощи функций БД.
            //Если невозможно, выдать предупреждение и восстановить флаг.
            //Если возможно, изменить состояние контрола и установить флаг изменения данных формы.
            //Если флаг устанавливается. надо проверить через БД, что восстановление элемента возможно.
            //Если невозможно, выдать предупреждение и восстановить флаг.
            //Если возможно, изменить состояние контрола и установить флаг изменения данных формы.

            //Эти операции уже следует вынести в отдельный класс-менеджер, их накопилось многовато.
            //- можно добавить их в MainFormManager или подобный класс со всеми необходимыми переменными объектов. 
        }
        /// <summary>
        /// NR-Handles the Click event of the button_OK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this.m_Changed == true)
                this.writeFormDataToElement();
            //set form result OK
            this.DialogResult = DialogResult.OK;

            return;
        }



        /// <summary>
        /// NR-Handles the Click event of the button_Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //set form result Cancel
            this.DialogResult = DialogResult.Cancel;

            return;
        }

        /// <summary>
        /// NT-Handles the TextChanged event of the textBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            this.setChangeFlag(true);
        }
        /// <summary>
        /// NR-Handles the LinkClicked event of the linkLabel_TagExample control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabel_TagExample_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Отложить: Это обработчик клика по линку тега в панели тегов формы.
            //Его надо подключать к объекту линка кодом
            //А тут надо обработать клик по тегу, но я не знаю, как.
            //- решено отложить работы с тегами на более поздний релиз.
        }

        #endregion

        #region *** Service functions ***

        /// <summary>
        /// NT-Sets the form data change flag.
        /// </summary>
        /// <param name="changed">if set to <c>true</c> [changed].</param>
        private void setChangeFlag(bool changed)
        {
            //enable button OK if data is changed
            this.button_OK.Enabled = changed;
            this.m_Changed = changed;

            return;
        }

        /// <summary>
        /// NR-Загрузить данные из Элемента в контролы формы.
        /// </summary>
        private void setFormData()
        {
            throw new NotImplementedException();
            //TODO: Отложить: добавить линки тегов на панель тегов - решено отложить работы с тегами на более поздний релиз.

            //add myRichTextBox events to this form
            this.myRichTextControl_Remarks.TextBox.Text = "";
            this.myRichTextControl_Remarks.TextBox.TextChanged += this.textBox_TextChanged;
            //если данные не разрешено изменять, то контролы формы 
            //должны быть установлены в режим только для чтения.
            this.myRichTextControl_Remarks.TextReadOnly = this.m_ReadOnly;

            return;
        }

        /// <summary>
        /// NR-Writes the form data to element.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void writeFormDataToElement()
        {
            throw new NotImplementedException();//TODO: write data back to element

            //TODO: Отложить: сохранить список тегов элемента в элементе, не в БД! - решено отложить работы с тегами на более поздний релиз.
        }

        #endregion


    }
}
