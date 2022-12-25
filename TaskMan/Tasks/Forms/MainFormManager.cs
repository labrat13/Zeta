using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TaskEngine;

namespace Tasks.Forms
{
    /// <summary>
    /// NR-Класс-менеджер главного окна приложения
    /// </summary>
    /// <remarks>
    /// Этот класс - вроде Движка, но для управления главным окном приложения.
    /// Цель его  - разгрузить класс формы главного окна от функций реализации.
    /// Чтобы в классе формы остались только обработчики событий и код, создаваемый автоматически.
    /// Иначе класс формы станет очень большим и студия начнет глючить или тормозить.
    /// </remarks>
    internal class MainFormManager
    {

        #region *** Constants and fields ***

        /// <summary>
        /// Main form object reference
        /// </summary>
        private MainForm m_MainForm;

        /// <summary>
        /// Task engine object reference
        /// </summary>
        private CEngine m_Engine;

        /// <summary>
        /// TreeView control manager
        /// </summary>
        private MainFormTreeViewManager m_TreeManager;






        #endregion

        /// <summary>
        /// NR-Initializes a new instance of the <see cref="MainFormManager"/> class.
        /// </summary>
        /// <param name="mainform">Объект главной формы приложения.</param>
        /// <param name="engine">Task engine object reference.</param>
        public MainFormManager(MainForm mainform, CEngine engine)
        {
            this.m_MainForm = mainform;
            this.m_Engine = engine;

            return;
        }

        #region *** Properties ***
        /// <summary>
        /// TreeView control manager
        /// </summary>
        public MainFormTreeViewManager TreeManager { get => m_TreeManager; internal set => m_TreeManager = value; }
        /// <summary>
        /// Task engine object reference
        /// </summary>
        public CEngine Engine { get => m_Engine; internal set => m_Engine = value; }
        /// <summary>
        /// Main form object reference
        /// </summary>
        public MainForm MainForm { get => m_MainForm; internal set => m_MainForm = value; }
        #endregion

        #region *** Service functions ***

        #endregion

        #region *** Функции событий дерева элементов левой панели. ***

        /// <summary>
        /// NR-Обработать событие выделения Корзины в левой панели главного окна
        /// </summary>
        /// <param name="node">The node.</param>
        public void LeftPanelAction_TrashcanRootSelect(TreeNode node)
        {
            String msg = node.Text;
            MessageBox.Show(msg, "Selected Trashcan");
            //TODO: add code here
            return;
        }

        /// <summary>
        /// NR-Обработать событие выделения элемента в левой панели главного окна
        /// </summary>
        /// <param name="elem">Элемент.</param>
        public void LeftPanelAction_ElementSelect(CElement elem)
        {
            String msg = elem.GetStringElementIdentifier(true);
            MessageBox.Show(msg, "Selected element");
            //TODO: add code here
            return;
        }

        /// <summary>
        /// NR-Обработать событие двойного клика Корзины в левой панели главного окна
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void LeftPanelAction_TrashcanRootDoubleClicked(TreeNode node)
        {
            String msg = node.Text;
            MessageBox.Show(msg, "Double clicked Trashcan");
            //TODO: add code here
            return;
        }
        /// <summary>
        /// NR-Обработать событие двойного клика элемента в левой панели главного окна
        /// </summary>
        /// <param name="elem">The elem.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void LeftPanelAction_ElementDoubleClicked(CElement elem)
        {
            String msg = elem.GetStringElementIdentifier(true);
            MessageBox.Show(msg, "Double clicked element");
            //TODO: add code here
            return;
        }

        #endregion

        #region *** ***

        #endregion

        #region *** ***

        #endregion


        #region *** ***

        #endregion

    }
}
