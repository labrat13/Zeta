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
    public partial class SelectElementForm : Form
    {
        
        //TODO: убрать неиспользуемые поля здесь - после отладки этой формы.
        //TODO: адаптер Бд лучше бы держать открытым на все время существования этой модальной формы:
        //от Form.Load  до Form.Closing, а то сложно тут с событиями получается, они все Бд используют и когда попало вызываются.
        //а так - исключение поймал - и форму закрыл, и БД закрыл  - все хорошо.

        #region *** Constants and fields ***

        /// <summary>
        /// Идентификатор элемента, представляющего начало обозреваемого дерева элементов.
        /// </summary>
        private int m_StartElementId;
        /// <summary>
        /// Идентификатор выбранного элемента.
        /// </summary>
        private int m_SelectedElementId;
        /// <summary>
        /// Фильтр типа отображаемых элементов.
        /// </summary>
        private TaskEngine.EnumElementType m_ElementType;
        /// <summary>
        /// Task Engine reference
        /// </summary>
        private CEngine m_Engine;
        /// <summary>
        /// Менеджер дерева элементов
        /// </summary>
        private ElementTreeViewManager m_treeManager;
        /// <summary>
        /// Проверять отсутствие нарушения иерархии при выборе родительского элемента в этой форме.
        /// </summary>
        private bool m_checkHierarchy;

#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectElementForm"/> class.
        /// </summary>
        public SelectElementForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectElementForm"/> class.
        /// </summary>
        /// <param name="engine">Task Engine reference for database access.</param>
        /// <param name="elementType">Тип отображаемых элементов: Задачи, итп.</param>
        /// <param name="startElementId">Идентификатор элемента, представляющего начало обозреваемого дерева элементов.</param>
        /// <param name="checkHierarchy">Проверять отсутствие нарушения иерархии при выборе родительского элемента в этой форме.</param>
        /// <param name="title">Текст заголовка окна</param>
        /// <param name="description">Текстовое описание выполняемой операции в верхней части формы.</param>
        public SelectElementForm(CEngine engine, EnumElementType elementType, int startElementId, bool checkHierarchy, string title, string description)
        {
            InitializeComponent();
            this.m_treeManager = new ElementTreeViewManager(this.treeView_Elements, engine, startElementId, elementType);
            this.Text = title;
            this.label_Description.Text = description;
            this.m_checkHierarchy = checkHierarchy; 

            return;
        }

        #region *** Properties ***

        /// <summary>
        /// Идентификатор элемента, представляющего начало обозреваемого дерева элементов.
        /// </summary>
        /// <value>
        /// The start element identifier.
        /// </value>
        public int StartElementId { get => m_StartElementId; set => m_StartElementId = value; }

        /// <summary>
        /// Идентификатор выбранного элемента, либо -1 как значение ошибки.
        /// </summary>
        /// <value>
        /// The selected element identifier.
        /// </value>
        public int SelectedElementId { get => m_SelectedElementId; set => m_SelectedElementId = value; }

        /// <summary>
        /// Фильтр типа отображаемых элементов.
        /// </summary>
        /// <value>
        /// The type of the element.
        /// </value>
        public EnumElementType ElementType { get => m_ElementType; set => m_ElementType = value; }

        /// <summary>
        /// Task Engine reference for database access.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        public CEngine Engine { get => m_Engine; set => m_Engine = value; }

        /// <summary>
        /// Текстовое описание выполняемой операции в верхней части формы.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description
        {
            get { return this.label_Description.Text; }
            set { this.label_Description.Text = value; }
        }

        #endregion

        /// <summary>
        /// NT-Shows the SelectElementForm dialog.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="title">Текст заголовка окна.</param>
        /// <param name="engine">Task Engine reference for database access.</param>
        /// <param name="elementType">Тип выбираемого элемента.</param>
        /// <param name="startElementId">Идентификатор элемента, представляющего начало обозреваемого дерева элементов.</param>
        /// <param name="checkHierarchy">Проверять отсутствие нарушения иерархии при выборе родительского элемента в этой форме.</param>
        /// <param name="description">Текстовое описание выполняемой операции в верхней части формы.</param>
        /// <returns>Функция возвращает идентификатор выбранного элемента либо -1 если пользователь отменил операцию.</returns>
        /// <remarks>
        /// Тип отображаемого элемента: Определяет тип элемента, который можно выбрать для возврата. 
        /// Категории отображаются независимо от этого значения, так как они соединяют всю структуру элементов разных типов.
        /// </remarks>
        public static int ShowSelectElementForm(
            IWin32Window owner,
            String title,
            CEngine engine, 
            EnumElementType elementType,
            int startElementId,
            bool checkHierarchy,
            String description)
        {
            int result = -1; //error value
            SelectElementForm f = null;
            try
            {
                //TODO: добавить загрузку размера и позиции формы из файла настроек приложения 
                f = new SelectElementForm(engine, elementType, startElementId, checkHierarchy, title, description);
                f.SelectedElementId = 0;
                //show form
                DialogResult dr = f.ShowDialog(owner);
                if (dr == DialogResult.OK)
                    result = f.SelectedElementId;
                //TODO: добавить сохранение размера и позиции формы в файл настроек приложения 
                f.Dispose();
                f = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());    
            }
            finally
            {
                if (f != null)
                    if (f.IsDisposed == false)
                    {
                        f.Dispose();
                        f = null;
                    }
            }

            return result;
        }

        #region *** Form functions ***  
        
        /// <summary>
        /// NR-Handles the Load event of the SelectElementForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectElementForm_Load(object sender, EventArgs e)
        {
            //Point pt = Properties.Settings.Default.SelectTreeFormPosition;
            ////TODO: проверить координаты окна, чтобы его не потерять за пределами дисплея 
            //if (pt.X > 1000) pt.X = 1000;
            //if (pt.Y > 1000) pt.Y = 1000;
            //Location = pt;
            //тут заполнить дерево элементов
            this.m_treeManager.ShowTree();
        }

        /// <summary>
        /// NR-Handles the FormClosed event of the SelectElementForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void SelectElementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
//TODO: add code here
        }

        /// <summary>
        /// NR-Handles the FormClosing event of the SelectElementForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void SelectElementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //тут очистить дерево элементов и коллекцию иконок
            //для следующего запуска диалога
            this.m_treeManager.ClearTree();

            return;
        }

        #endregion

        #region *** Form button event handlers ***        
        /// <summary>
        /// NR-Handles the Click event of the button_OK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            //выбранный в дереве элемент запомнить - это должно было быть сделано в обработчике выделения ноды
            //диалог закрыть с ОК
            this.DialogResult = DialogResult.OK;
            //закрыть форму
            this.Close();
        }
        /// <summary>
        /// NR-Handles the Click event of the button_Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //диалог закрыть с отменой
            this.DialogResult = DialogResult.Cancel;
            //закрыть форму
            this.Close();
        }

        #endregion

        #region *** TreeView event handlers ***

        //Одиночный клик это выделение ноды дерева.
        //двойной клик это развертывание-свертывание ноды.

        /// <summary>
        /// NT-Handles the AfterSelect event of the treeView_Elements control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void treeView_Elements_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //тут в диалоге надо вывести инфу о выделенном элементе
            //и кнопку ОК диалога включить или выключить
            //чтобы нельзя было выбрать неподходящий тип элемента
            TaskEngine.CElement obj = this.m_treeManager.NodeSelected(e);
            //skip any wrong events
            if (obj == null)
                return;
            //кнопка ОК диалога
            this.button_OK.Enabled = this.m_treeManager.IsAllowedElement(m_checkHierarchy, obj);
            //создать и вывести описание объекта
            this.label_Information.Text = obj.Description;
            ////TODO: показать полное описание элемента: - вывести многострочный текст в дополнительную правую панель-текстбокс. Требует переделки макета формы.
            //this.label_Information.Text = obj.GetPropertiesText();

            return;
        }


        #endregion

        private void treeView_Elements_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            this.m_treeManager.TreeViewBeforeExpand(sender, e);
        }

        private void treeView_Elements_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            this.m_treeManager.TreeViewBeforeCollapse(sender, e);
        }
    }
}
