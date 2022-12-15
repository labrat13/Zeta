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

#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectElementForm"/> class.
        /// </summary>
        public SelectElementForm()
        {
            InitializeComponent();
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
        /// <param name="engine">Task Engine reference for database access.</param>
        /// <param name="elementType">Фильтр типа отображаемых элементов.</param>
        /// <param name="startElementId">Идентификатор элемента, представляющего начало обозреваемого дерева элементов.</param>
        /// <param name="description">Текстовое описание выполняемой операции в верхней части формы.</param>
        /// <returns>Функция возвращает идентификатор выбранного элемента либо -1 если пользователь отменил операцию.</returns>
        public int ShowSelectElementForm(
            IWin32Window owner, 
            CEngine engine, 
            EnumElementType elementType,
            int startElementId,
            String description)
        {
            int result = -1; //error value
            SelectElementForm f = null;
            try
            {
                f = new SelectElementForm();
                f.Engine = engine;
                f.ElementType = elementType;
                f.StartElementId = startElementId;
                f.SelectedElementId = 0;
                f.Description = description;
                //show form
                DialogResult dr = f.ShowDialog(owner);
                if (dr == DialogResult.OK)
                    result = f.SelectedElementId;
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

        private void SelectElementForm_Load(object sender, EventArgs e)
        {
//TODO: add code here
        }

        private void SelectElementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
//TODO: add code here
        }

        private void SelectElementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
//TODO: add code here
        }

#endregion

#region *** Form button event handlers ***

        private void button_OK_Click(object sender, EventArgs e)
        {
//TODO: add code here
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
//TODO: add code here
        }

#endregion

#region *** TreeView event handlers ***

        //Одиночный клик это выделение ноды дерева.
        //двойной клик это развертывание-свертывание ноды.


        private void treeView_Elements_DoubleClick(object sender, EventArgs e)
        {
//TODO: add code here
        }

#endregion

    }
}
