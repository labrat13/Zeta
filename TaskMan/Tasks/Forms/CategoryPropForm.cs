﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskEngine;
using Tasks.Utilities;
using static System.Windows.Forms.LinkLabel;

namespace Tasks.Forms
{
    //TODO: Для категории надо проверить работу в режиме создания нового элемента.
    // - идентификатор получить из менеджера идентификаторов движка.
    // - в БД элемент еще не записан, цепочку пути вычислить нельзя.
    // - парент элемента уже первоначально назначен, но связей в БД нет.
    // - галочка Активен должна быть установлена и заблокирована.
    //    Снять ее нельзя до сохранения элемента, то есть, на все время показа диалога.
    //   - это требует передавать в форму флаг m_isCreating, что объект создается, а не редактируется
    // - для тестирования режима создания элементов надо создать вызывающий код.


    /// <summary>
    /// NR-Форма свойств Категории
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CategoryPropForm : Form
    {
        #region *** Constants and fields ***  

        /// <summary>
        /// Флаг что состояние данных было изменено
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

        /// <summary>
        /// Объект менеджера формы для вызова функций и диалогов
        /// </summary>
        private MainFormManager m_MainFormManager;

        /// <summary>
        /// Флаг, что элемент создается и еще не записан в БД.
        /// </summary>
        private bool m_isCreating;

        #endregion

        /// <summary>
        /// NT-Initializes a new instance of the <see cref="CategoryPropForm"/> class.
        /// </summary>
        public CategoryPropForm()
        {
            InitializeComponent();
            this.m_Changed = false;
            this.m_Element = null;
            this.m_Engine = null;
            this.m_ReadOnly = false;
            this.m_MainFormManager = null;
            this.m_isCreating = false;

            return;
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

        /// <summary>
        /// Флаг что состояние данных было изменено
        /// </summary>
        public bool Changed
        {
            get
            {
                return m_Changed;
            }

            //set
            //{
            //    m_Changed = value;
            //}
        }

        /// <summary>
        /// Объект менеджера формы для вызова функций и диалогов
        /// </summary>
        public MainFormManager FormManager
        {
            get
            {
                return m_MainFormManager;
            }

            set
            {
                m_MainFormManager = value;
            }
        }

        /// <summary>
        /// Флаг, что элемент создается и еще не записан в БД.
        /// </summary>
        public bool IsCreating
        {
            get
            {
                return m_isCreating;
            }

            set
            {
                m_isCreating = value;
            }
        }

        #endregion


        /// <summary>
        /// NT-Shows this form as modal dialog.
        /// </summary>
        /// <param name="owner">The owner window.</param>
        /// <param name="title">Текст названия формы.</param>
        /// <param name="readOnly">Запретить пользователю изменять данные элемента.</param>
        /// <param name="element">Отображаемый элемент.</param>
        /// <param name="engine">Объект Движка.</param>
        /// <param name="formManager">Объект Менеджера функций форм.</param>
        /// <param name="creating">Элемент создается, а не редактируется, нет записи в БД.</param>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public static bool ShowCategoryPropForm(IWin32Window owner, String title, bool readOnly, CElement element, CEngine engine, MainFormManager formManager, bool creating)
        {
            CategoryPropForm form = new CategoryPropForm();
            //set form properties
            form.Text = title;//TODO: заменить заголовок формы на название формы + название элемента.
            form.m_ReadOnly = readOnly;
            form.m_Element = element;
            form.m_Engine = engine;
            form.m_MainFormManager = formManager;
            form.m_isCreating = creating;
            //show form
            DialogResult dr = form.ShowDialog(owner);
            //TODO: add code here
            //Если диалог завершен с ОК, сохранить элемент в БД?
            //- элемент обновляется или создается? Здесь это неизвестно.
            //TODO: для определения, были ли данные элемента изменены, создано проперти Changed.
            //Хотя, диалог нельзя закрыть с ОК, если данные элемента не были изменены.
            //Но - надо четко проследить, чтобы везде, где данные элемента изменяются, флаг изменения тоже устанавливался!
            bool result = form.m_Changed;

            return result; 
        }


        #region *** Form button event handlers ***

        /// <summary>
        /// NT-Handles the Load event of the CategoryPropForm control.
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
        /// NT-Handles the FormClosed event of the CategoryPropForm control.
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
        /// NT-Handles the Click event of the button_SelectParent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_SelectParent_Click(object sender, EventArgs e)
        {
            //тут показать диалог выбора над-элемента, вписать его в линк и установить флаг изменения данных. 
            CElement result = SelectElementForm.ShowSelectElementForm(this, "Выбрать над-категорию:", this.m_Engine, EnumElementType.Category, this.m_Element.Parent.Id, true, "Выберите над-Категорию для текущей Категории:");
            if (result != null)
            {
                //Установить новые данные для linklabel
                this.linkLabel_Parent.Text = result.GetStringElementIdentifier(true);
                this.linkLabel_Parent.Tag = result.Id;
                //включить линк если он выключен
                this.linkLabel_Parent.Enabled = true;
                //установить флаг изменения данных
                this.setChangeFlag(true);
            }

            return;
        }

        /// <summary>
        /// NT-Handles the LinkClicked event of the linkLabel_Parent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabel_Parent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //тут открыть для просмотра или изменения Карточку Элемента кликнутого элемента.
            if (this.linkLabel_Parent.Tag == null)
                throw new Exception("LinkLabel.Tag = null");//TODO: я пока не знаю, что делать
            //get parent id from linklabel
            Int32 id = (Int32)this.linkLabel_Parent.Tag;
            //показать карточку элемента по его ид.
            //сохранить изменения карточки в БД.
            bool result = this.m_MainFormManager.ShowElementProp(id, false, true);
            //обновить дерево элементов если были изменения
            if(result)
                this.m_MainFormManager.UpdateLeftPanel();

            return;
        }

        /// <summary>
        /// NT-Handles the CheckedChanged event of the checkBox_ElementActiveState control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBox_ElementActiveState_CheckedChanged(object sender, EventArgs e)
        {
            //Если элемент имеет состояние Защищен, то игнорировать все события.
            if (this.m_Element.IsProtected())
                return;
            //Если элемент только создается и еще не записан в БД, то игнорировать все события.
            if (this.m_isCreating)
                return;
            //тут отсоединить этот обработчик от чекбокса, чтобы избежать рекурсии при изменении чекстате
            this.checkBox_ElementActiveState.CheckedChanged -= this.checkBox_ElementActiveState_CheckedChanged;

            //проверить возможность изменения состояния элемента по БД
            if (checkBox_ElementActiveState.Checked == false)//новое значение, когда флаг снимается
            {
                //Если флаг снимается, надо проверить, что удаление возможно, при помощи функций БД.
                bool hasActiveChild = this.m_Engine.DbAdapter.IsElementHasActiveChild(this.m_Element.Id);
                //Если невозможно, выдать предупреждение и восстановить флаг.
                if (hasActiveChild)
                {
                    FormUtility.showErrorMessageBox(this, "Ошибка", 
                        "Невозможно удалить этот элемент,\n" +
                        "поскольку он имеет активные пол-элементы!");
                    this.checkBox_ElementActiveState.Checked = true;
                }
                else
                {
                    //Если возможно, изменить состояние контрола и установить флаг изменения данных формы.
                    this.checkBox_ElementActiveState.Checked = false;//необязательно
                    this.setChangeFlag(true);
                }
            }
            else //checkBox_ElementActiveState.Checked == true //новое значение, когда флаг устанавливается
            {
                //Если флаг устанавливается, надо проверить через БД, что восстановление элемента возможно.
                bool hasDeletedParent = this.m_Engine.DbAdapter.IsElementHasDeletedParent(this.m_Element.Id);
                //Если невозможно, выдать предупреждение и восстановить флаг.
                if (hasDeletedParent)
                {
                    FormUtility.showErrorMessageBox(this, "Ошибка", 
                        "Невозможно восстановить этот элемент, поскольку\n" +
                        "в пути от корня дерева до него есть удаленные элементы!");
                    this.checkBox_ElementActiveState.Checked = false;
                }
                else
                {
                    //Если возможно, изменить состояние контрола и установить флаг изменения данных формы.
                    this.checkBox_ElementActiveState.Checked = true;//необязательно
                    this.setChangeFlag(true);
                }
            }
            //тут присоединить этот обработчик к чекбоксу обратно
            this.checkBox_ElementActiveState.CheckedChanged += this.checkBox_ElementActiveState_CheckedChanged;

            return;
        }

        /// <summary>
        /// NT-Handles the Click event of the button_OK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            bool valid = false;
            //check data and store to element object
            if (this.m_Changed == true)
                valid = this.writeFormDataToElement();

            //set form result OK
            this.DialogResult = DialogResult.OK;

            if(valid == true)
                this.Close();

            return;
        }

        /// <summary>
        /// NT-Handles the Click event of the button_Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //set form result Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();

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
            //check title textbox
            bool wrong = String.IsNullOrEmpty(this.textBox_ElementTitle.Text.Trim());
            FormUtility.colorizeWrongTextBox(wrong, this.textBox_ElementTitle, this.toolStripStatusLabel_CardStatus, "Недопустимое название!");

            return;
        }

        //Функции тегов решено отложить на потом.

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

        //TODO: Эти операции уже следует вынести в отдельный класс-менеджер, их накопилось многовато.
        //- можно добавить их в MainFormManager или подобный класс со всеми необходимыми переменными объектов.

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
        /// NT-Загрузить данные из Элемента в контролы формы.
        /// </summary>
        private void setFormData()
        {
            //TODO: Отложить: добавить линки тегов на панель тегов - решено отложить работы с тегами на более поздний релиз.

            //set controls
            //если данные не разрешено изменять, то контролы формы должны быть установлены в режим только для чтения.
            this.textBox_ElementTitle.Text = this.m_Element.Title;
            this.textBox_ElementTitle.ReadOnly = this.m_ReadOnly;
            this.loadLinkLabelForParent(this.linkLabel_Parent);
            //TODO: add object to link if needed 
            this.textBox_ElementDescription.Text = this.m_Element.Description;
            this.textBox_ElementDescription.ReadOnly = this.m_ReadOnly;
            this.label_ElementId.Text = this.m_Element.GetStringElementIdentifier(false);
            this.label_ElementCreaTime.Text = TaskEngine.Utilities.StringUtility.DateTimeToString(this.m_Element.CreaTime);//TODO: move this to CElement class
            this.label_ElementModiTime.Text = TaskEngine.Utilities.StringUtility.DateTimeToString(this.m_Element.ModiTime);//TODO: move this to CElement class
            //prevent checkbox checkedchanged event now
            this.checkBox_ElementActiveState.CheckedChanged -= this.checkBox_ElementActiveState_CheckedChanged;
            this.checkBox_ElementActiveState.Checked = !this.m_Element.IsDeleted();
            //чекбокс включен, если флаг толькоЧтение сброшен И элемент не защищен от удаления И элемент не создается, а редактируется
            this.checkBox_ElementActiveState.Enabled = ((this.m_ReadOnly == false) && (this.m_Element.IsProtected() == false) && (this.m_isCreating == false));
            this.checkBox_ElementActiveState.CheckedChanged += this.checkBox_ElementActiveState_CheckedChanged;

            //add myRichTextBox events to this form
            this.myRichTextControl_Remarks.TextBox.Text = this.m_Element.Remarks;
            this.myRichTextControl_Remarks.TextBox.TextChanged += this.textBox_TextChanged;
            this.myRichTextControl_Remarks.TextReadOnly = this.m_ReadOnly;
            //status label
            this.toolStripStatusLabel_CardStatus.Text = this.getCardStateText();

            return;
        }

        /// <summary>
        /// NT-Gets the card state text.
        /// </summary>
        /// <returns></returns>
        private String getCardStateText()  //TODO: перенести генерацию текста в другой класс. 
        {
            EnumCardState cs = this.m_Element.GetCardState();
            return "Состояние карточки: " + cs.ToString();
        }

        /// <summary>
        ///NT- Loads the link label values for parent.
        /// </summary>
        /// <param name="link">The link.</param>
        private void loadLinkLabelForParent(LinkLabel link)
        {
            int id = this.m_Element.Parent.Id;
            if (id == TaskDbAdapter.ElementId_Root)
            {
                link.Text = "Корень дерева элементов";
                link.Tag = (Int32)0;
                //сделать ссылку неактивной, чтобы избежать кликов по ней
                link.Enabled = false;
            }
            else
            {
                CElement p = this.m_Engine.DbAdapter.SelectElementWithoutTransaction(id);
                link.Text = p.GetStringElementIdentifier(true);
                link.Tag = id;
            }

            return;
        }

        /// <summary>
        /// NT-Writes the form data to element.
        /// </summary>
        /// <returns>Функция возвращает True, если данные элемента прошли проверку и были сохранены; False в противном случае.</returns>
        private bool writeFormDataToElement()
        {
            //write data back to element
            //Сохранить поля: Название, Описание, Заметки, Активность, Теги, Корень

            //тут из текстовых полей только название элемента проверяется.
            String title = this.textBox_ElementTitle.Text;
            title = title.Trim();
            if (String.IsNullOrEmpty(title))
            {
                FormUtility.showErrorMessageBox(this, "Ошибка", "Недопустимое название Категории!");
                return false;
            }
            //store text values
            this.m_Element.Title = title;
            this.m_Element.Description = this.textBox_ElementDescription.Text.Trim();
            this.m_Element.Remarks = this.myRichTextControl_Remarks.TextBox.Text;//not trimmed, for final endline save.
            //set element state - уже должно быть все проверено ранее.
            this.m_Element.SetDeleted(!this.checkBox_ElementActiveState.Checked);
            //store parent id from linklabel Tag
            this.m_Element.Parent.Id = (Int32)this.linkLabel_Parent.Tag;

            //TODO: Отложить: сохранить список тегов элемента в элементе, не в БД! - решено отложить работы с тегами на более поздний релиз.
            return true;
        }

        #endregion

    }
}
