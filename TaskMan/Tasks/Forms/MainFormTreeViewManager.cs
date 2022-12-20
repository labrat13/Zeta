using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TaskEngine;

namespace Tasks.Forms
{
    /// <summary>
    /// NR-Менеджер класса дерева левой панели главного окна приложения.
    /// </summary>
    public class MainFormTreeViewManager : TreeViewManagerBase
    {
        /// <summary>
        /// NR-Initializes a new instance of the <see cref="MainFormTreeViewManager"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="treeView">The tree view.</param>
        public MainFormTreeViewManager(CEngine engine, TreeView treeView) : base(engine, treeView)
        {
        }

        /// <summary>
        /// NR-Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// NR-Показать дерево и в нем развернутый путь до элемента, указанного в StartElementId.
        /// </summary>
        public override void ShowTree()
        {
            base.ShowTree();
        }

        /// <summary>
        /// NR-Обновить дерево после изменения БД и снова раскрыть и выбрать прежние элементы.
        /// </summary>
        public override void UpdateTree()
        {
            base.UpdateTree();
        }


        #region *** Обработчики событий дерева от формы. *** 

        /// <summary>
        /// NR-Node Before collapse event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs" /> instance containing the event data.</param>
        public override void NodeBeforeCollapse(TreeViewCancelEventArgs e)
        {
            base.NodeBeforeCollapse(e);
        }
        /// <summary>
        /// NR-Node Before expand event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs" /> instance containing the event data.</param>
        public override void NodeBeforeExpand(TreeViewCancelEventArgs e)
        {
            base.NodeBeforeExpand(e);
        }
        /// <summary>
        /// NR-Клик по ноде сворачивает-разворачивает ноду.
        /// Подключите этот обработчик, если надо разворачивать ноды дерева одиночным кликом.
        /// </summary>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
        public override void NodeClick(TreeNodeMouseClickEventArgs e)
        {
            base.NodeClick(e);
        }
        /// <summary>
        /// NR-Двойной клик по ноде
        /// </summary>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
        public override void NodeDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            base.NodeDoubleClick(e);
        }
        /// <summary>
        /// NR-пользователь что-то выбрал в дереве, вот событие из дерева.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewEventArgs" /> instance containing the event data.</param>
        /// <returns>
        /// Функция возвращает выбранный объект либо null при ошибке.
        /// </returns>
        public override CElement NodeSelected(TreeViewEventArgs e)
        {
            return base.NodeSelected(e);
        }

        #endregion


    }
}
