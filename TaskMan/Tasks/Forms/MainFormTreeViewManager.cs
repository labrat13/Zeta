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
        /// Словарь контекстных меню для нод элементов.
        /// </summary>
        private NodeContextMenuCollection m_menus;

        /// <summary>
        /// NR-Initializes a new instance of the <see cref="MainFormTreeViewManager"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="treeView">The tree view.</param>
        public MainFormTreeViewManager(CEngine engine, TreeView treeView, NodeContextMenuCollection menus) : base(engine, treeView)
        {
            this.m_menus = menus;

            return;
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
        /// NT-Показать дерево и в нем развернутый путь до элемента, указанного в StartElementId.
        /// </summary>
        public override void ShowTree()
        {
            //start update treeview
            this.m_treeView.BeginUpdate();
            this.m_treeView.UseWaitCursor = true;
            //remove all old nodes
            this.m_treeView.Nodes.Clear();
            //Для каждого типа нод, если разрешены, добавить в дерево корневую ноду раздела в правильном порядке.
            //Остальные ноды добавлять раскрытием нод
            this.AddElementToNodes(this.m_treeView.Nodes, TaskDbAdapter.ElementId_TaskRoot);
            this.AddElementToNodes(this.m_treeView.Nodes, TaskDbAdapter.ElementId_TagRoot);
            //add virtual Trashcan root node
            this.m_treeView.Nodes.Add(this.MakeTrashcanRootNode(true));
            //TODO: add virtual FileStorage root node here

            //finish update treeview
            this.m_treeView.UseWaitCursor = false;
            this.m_treeView.EndUpdate();

            return;
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
        /// NT-Node Before collapse event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs" /> instance containing the event data.</param>
        public override void NodeBeforeCollapse(TreeViewCancelEventArgs e)
        {
            base.NodeBeforeCollapse(e);//базовая функция отлично подходит пока что.
        }
        /// <summary>
        /// NR-Node Before expand event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs" /> instance containing the event data.</param>
        public override void NodeBeforeExpand(TreeViewCancelEventArgs e)
        {
            //TODO: код скопирован с ElementTreeViewManager.cs и должен быть переделан.

            //skip invalid actions
            if (e.Action != TreeViewAction.Expand)
                return;
            //разворачиваемая нода
            TreeNode node = e.Node;
            if (node == null)
                return;
            //сначала удалить все имеющиеся субноды - это должна быть только одна субнода временная.
            node.Nodes.Clear();
            //получить ид элемента. если нуль, то выйти.
            CElement el = (CElement)node.Tag;
            if (el == null)
            {
                //TODO: вот тут надо как-то определить, какая это нода:
                //А) неправильная
                //Б) корневая нода Корзина
                //В) корневая нода ХранилищеФайлов
                //и соответственно запустить процедуру их развертывания.
            }
            //start update treeview
            this.m_treeView.BeginUpdate();
            this.m_treeView.UseWaitCursor = true;
            //загрузить субноды
            TreeNode[] nodes = this.MakeElementSubNodes(el.Id);
            node.Nodes.AddRange(nodes);
            //finish update
            this.m_treeView.UseWaitCursor = false;
            this.m_treeView.EndUpdate();

            return;
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

        /// <summary>
        /// NT-Создать ноду по данным объекта, без актуальных субнод.
        /// </summary>
        /// <param name="obj">Элемент</param>
        /// <param name="addTempSubnode">Добавить временную субноду, чтобы ноду можно было раскрыть. </param>
        /// <returns>Функция возвращает ноду для дерева элементов.</returns>
        protected override TreeNode MakeTreeNode(CElement obj, bool addTempSubnode)
        {
            TreeNode tn = new TreeNode();
            //get icon index
            int imgindex = this.GetNodeImageIndex(obj.ElementType);
            tn.ImageIndex = imgindex;
            tn.SelectedImageIndex = imgindex;
            //text
            tn.Text = obj.Title;
            tn.ToolTipText = obj.Description;
            //выбрать цвет надписи ноды
            SelectNodeFontAndColor(tn, obj);
            //Добавить контекстное меню для элемента данного типа
            // Это отличие от функции из базового класса.
            tn.ContextMenuStrip = this.m_menus.Get(obj.ElementType);
            //ВАЖНО: нода содержит объект элемента в поле Tag
            tn.Tag = obj;
            //добавить пустую ноду, если надо
            if (addTempSubnode)
                tn.Nodes.Add("temp node");

            return tn;
        }


        #region *** Trashcan functions ***

        /// <summary>
        /// NT-Создать ноду раздела Корзина
        /// </summary>
        /// <param name="addTempSubnode">Добавить временную субноду, чтобы ноду можно было раскрыть.</param>
        /// <returns>Функция возвращает корневую ноду Корзины дерева элементов.</returns>
        private TreeNode MakeTrashcanRootNode(bool addTempSubnode)
        {
            TreeNode tn = new TreeNode();
            //get icon index
            int imgindex = TreeViewManagerBase.IconIndex_Trashcan;
            tn.ImageIndex = imgindex;
            tn.SelectedImageIndex = imgindex;
            //text
            tn.Text = "Корзина";
            tn.ToolTipText = "Все элементы, помеченные удаленными.";
            //выбрать цвет надписи ноды
            tn.ForeColor = TreeViewManagerBase.Color_NormalElement;
            tn.NodeFont = this.m_FontNormal; 
            //контестного меню у ноды Корзина не будет, все делать через команды главного меню приложения.
            //ВАЖНО: нода НЕ содержит объект элемента в поле Tag
            //добавить пустую ноду, если надо
            if (addTempSubnode)
                tn.Nodes.Add("temp node");

            return tn;
        }

        /// <summary>
        /// NT-Создать для Корзины ноду по данным объекта, без актуальных субнод.
        /// </summary>
        /// <param name="obj">Элемент</param>
        /// <param name="addTempSubnode">Добавить временную субноду, чтобы ноду можно было раскрыть. </param>
        /// <returns>Функция возвращает ноду для Корзины дерева элементов.</returns>
        protected TreeNode MakeTrashcanItemNode(CElement obj, bool addTempSubnode)
        {
            TreeNode tn = new TreeNode();
            //get icon index
            int imgindex = this.GetNodeImageIndex(obj.ElementType);
            tn.ImageIndex = imgindex;
            tn.SelectedImageIndex = imgindex;
            //text
            tn.Text = obj.Title;
            tn.ToolTipText = obj.Description;
            //выбрать цвет надписи ноды
            SelectNodeFontAndColor(tn, obj);
            //Добавить контекстное меню элемента Корзины для элемента любого типа
            // Это отличие от функции из базового класса.
            tn.ContextMenuStrip = this.m_menus.TrashcanItemContextMenu;
            //ВАЖНО: нода содержит объект элемента в поле Tag
            tn.Tag = obj;
            //добавить пустую ноду, если надо
            if (addTempSubnode)
                tn.Nodes.Add("temp node");

            return tn;
        }

#endregion


    }
}
