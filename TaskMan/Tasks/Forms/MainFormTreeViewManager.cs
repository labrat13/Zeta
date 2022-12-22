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
        //Для корзины надо создать виртуальную ноду с полем Tag = null.
        //В функции NodeExpand() когда Tag == null, обнаружить ноду Корзины и запустить функцию заполнения ноды Корзины субнодами.
        //Для этого ссылку на ноду Корзины сразу после создания надо записать в переменную класса.
        //Функция NodeCollapse() подходит без изменения.

        /// <summary>
        /// Словарь контекстных меню для нод элементов.
        /// </summary>
        private NodeContextMenuCollection m_menus;

        /// <summary>
        /// Объект корневой ноды Корзины, для нахождения ее в дереве.
        /// </summary>
        private TreeNode m_TrashcanRootNode;

        /// <summary>
        /// NR-Initializes a new instance of the <see cref="MainFormTreeViewManager"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="treeView">The tree view.</param>
        public MainFormTreeViewManager(CEngine engine, TreeView treeView, NodeContextMenuCollection menus) : base(engine, treeView)
        {
            this.m_menus = menus;
            this.m_TrashcanRootNode = null;

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
        /// NT-Обновить дерево после изменения БД и снова раскрыть и выбрать прежние элементы.
        /// </summary>
        public override void UpdateTree()
        {
            //start update treeview
            this.m_treeView.BeginUpdate();
            this.m_treeView.UseWaitCursor = true;

            //получить список раскрытых нод дерева, исключая Корзину и ее субноды.
            List<int> expandedNodesIdList = this.GetExpandedNodesElementIdList();
            //получить ид элемента выбранной ноды
            CElement elem = (CElement)null;
            TreeNode selectedNode = this.m_treeView.SelectedNode;
            if (selectedNode != null)
                elem = (CElement)selectedNode.Tag;
            //свернуть все дерево, чтобы остались только корневые ноды, и потом заново загружать структуру дерева из БД, развертывая ноды.
            this.m_treeView.CollapseAll();
            //для каждого ид из списка раскрытых нод найти его ноду в дереве
            // и если нашел, раскрыть ее. Это приведет к загрузке субнод и можно будет продолжать поиск.
            foreach (int elemId in expandedNodesIdList)
            {
                TreeNode nodeByElementId = this.FindNodeByElementId(elemId);
                if (nodeByElementId != null)
                    nodeByElementId.Expand();
            }
            //теперь найти ноду, бывшую ранее выбранной.
            TreeNode nodeByElementId1 = null;
            if (elem != null)
                nodeByElementId1 = this.FindNodeByElementId(elem.Id);
            //если нода не найдена, выйти.
            //если нода найдена, сделать ее видимой и выбранной нодой.
            if (nodeByElementId1 != null)
            {
                nodeByElementId1.EnsureVisible();
                this.m_treeView.SelectedNode = nodeByElementId1;
            }

            //finish update treeview
            this.m_treeView.UseWaitCursor = false;
            this.m_treeView.EndUpdate();

            return;
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
                if (IsTrashcanRootNode(node))
                    //запустить функцию заполнения ноды Корзины
                    node.Nodes.AddRange(this.TrashcanRootNodeFill());
                //В) корневая нода ХранилищеФайлов
                //и соответственно запустить процедуру их развертывания.
            }
            else
            {
                //start update treeview
                this.m_treeView.BeginUpdate();
                this.m_treeView.UseWaitCursor = true;
                //загрузить субноды
                TreeNode[] nodes = this.MakeElementSubNodes(el.Id);
                node.Nodes.AddRange(nodes);
                //finish update
                this.m_treeView.UseWaitCursor = false;
                this.m_treeView.EndUpdate();
            }

            return;
        }

        /// <summary>
        /// NT-Проверить что проверяемая нода является корневой нодой Корзины.
        /// </summary>
        /// <param name="node">Проверяемая нода</param>
        /// <returns></returns>
        public bool IsTrashcanRootNode(TreeNode node)
        {
            return (node == this.m_TrashcanRootNode); 
        }

        /// <summary>
        /// NR-Клик по ноде сворачивает-разворачивает ноду.
        /// Подключите этот обработчик, если надо разворачивать ноды дерева одиночным кликом.
        /// </summary>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
        public override void NodeClick(TreeNodeMouseClickEventArgs e)
        {
             base.NodeClick(e);

             return;
        }
        /// <summary>
        /// NR-Двойной клик по ноде
        /// </summary>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
        public override void NodeDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            base.NodeDoubleClick(e);
            
            return;
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


        /// <summary>
        /// NT-Создать массив субнод для текущей ноды элемента
        /// </summary>
        /// <param name="id">Идентификатор элемента.</param>
        /// <returns>Функция возвращает массив субнод для ноды элемента.</returns>
        private TreeNode[] MakeElementSubNodes(int id)
        {
            //Заполнить элементами выходной список так, чтобы:
            //1. удаленные элементы не отображались.
            //2. отображались все типы элементов: категории, теги, заметки, задачи.
            //3. элементы были группированы по типам: сверху Категории, Заметки, Задачи, в конце Теги.
            //4. внутри типа элементы были сортированы по алфавиту.

            List<TreeNode> nodes = new List<TreeNode>();
            //получить дочерние элементы из БД
            List<CElement> elements = this.m_engine.DbAdapter.SelectElementsByParentId(id);
            //если субэлементов нет, быстро завершить функцию.
            if (elements.Count == 0)
                return nodes.ToArray();

            //удалить из списка удаленные элементы, чтобы меньше сортировать было. (правило 1)
            //сортировать по типу и алфавиту (правила 3 и 4)
            elements = CElement.FilterAndSortElementsByTypeAndTitle(elements, EnumElementType.AllTypes);

            //теперь элементы добавить в дерево как папки.
            //свернутыми с временной нодой внутри для возможности развернуть ее при необходимости.
            foreach (CElement el in elements)
            {
                bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(el.Id) > 0);
                nodes.Add(MakeTreeNode(el, subnodesExists));
            }

            return nodes.ToArray();
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
            //Записать  эту ноду в переменную класса, чтобы найти ее в NodeExpand()
            this.m_TrashcanRootNode = tn;

            return tn;
        }

        /// <summary>
        /// NT-функция заполнения ноды Корзины
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private TreeNode[] TrashcanRootNodeFill()
        {
            //start update treeview
            this.m_treeView.BeginUpdate();
            this.m_treeView.UseWaitCursor = true;

            //Заполнить элементами выходной список так, чтобы:
            //1. отображались только удаленные элементы.
            //2. отображались все типы элементов: категории, теги, заметки, задачи.
            //3. элементы были сортированыы по дате последнего изменения
            //4. не обязательно: элементы были группированы по типам: сверху Категории, Заметки, Задачи, в конце Теги.
            //5. не обязательно: внутри элементы были группированы по алфавиту.

            List<TreeNode> nodes = new List<TreeNode>();
            //получить удаленные элементы из БД
            List<CElement> elements = this.m_engine.DbAdapter.SelectElementsByElementState(EnumElementState.Deleted);
            //если субэлементов нет, быстро завершить функцию.
            if (elements.Count > 0)
            {
                //сортировать элементы в списке по времени модификации
                elements.Sort(CElement.SortElementsByModificationTime);
                //теперь элементы добавить в дерево без субнод.
                foreach (CElement el in elements)
                {
                    nodes.Add(MakeTrashcanItemNode(el, false));
                }
            }
            else
            {
                //вставить ноду пустую, чтобы нода корзины сворачивалась
                TreeNode tn = new TreeNode("Нет элементов", TreeViewManagerBase.IconIndex_EmptyDoc, TreeViewManagerBase.IconIndex_EmptyDoc);
                tn.ToolTipText = "Корзина пустая, голодная и злая.";
                nodes.Add(tn);
            }

            //finish update
            this.m_treeView.UseWaitCursor = false;
            this.m_treeView.EndUpdate();
            
            return nodes.ToArray();
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
