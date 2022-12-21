using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskEngine;

namespace Tasks.Forms
{
    /// <summary>
    /// NR-базовый класс менеджера дерева
    /// </summary>
    public class TreeViewManagerBase
    {
        #region *** Constants and Fields ***

        //----- Константы цвета текста для TreeView -----

        /// <summary>
        /// Цвет надписи обычных элементов
        /// </summary>
        public static Color Color_NormalElement = Color.Black;

        /// <summary>
        /// Цвет надписи неактивных элементов
        /// </summary>
        public static Color Color_InactiveElement = Color.Gray;

        /// <summary>
        /// Цвет надписи приоритетных задач
        /// </summary>
        public static Color Color_PriorityTask = Color.Red;

        /// <summary>
        /// Цвет надписи неприоритетных задач
        /// </summary>
        public static Color Color_NotPriorityTask = Color.Red;

        //----- Константы индексов иконок для TreeView -----

        /// <summary>
        /// Индекс иконки дерева: Категория.
        /// </summary>
        public const int IconIndex_Category = 0;

        /// <summary>
        /// Индекс иконки дерева: Тег.
        /// </summary>
        public const int IconIndex_Tag = 1;

        /// <summary>
        /// Индекс иконки дерева: Задача.
        /// </summary>
        public const int IconIndex_Task = 2;

        /// <summary>
        /// Индекс иконки дерева: Заметка.
        /// </summary>
        public const int IconIndex_Note = 3;

        /// <summary>
        /// Индекс иконки дерева: Корзина.
        /// </summary>
        public const int IconIndex_Trashcan = 4;

        //----- Переменные класса -----
        //TODO: удалить переменные, которые не вошли в базовый класс.

        /// <summary>
        /// Объект БД
        /// </summary>
        protected CEngine m_engine;

        /// <summary>
        /// Контрол дерева на форме
        /// </summary>
        protected TreeView m_treeView;

        /// <summary>
        /// Начальный или возвращаемый объект элемента
        /// </summary>
        protected CElement m_result;

        //объекты шрифтов для нод дерева, зависят от потока.
        //Чтобы изменить шрифт дерева, измените его в контроле дерева.

        /// <summary>
        ///Шрифт нормальный, используется по умолчанию для нод всех элементов.
        /// </summary>
        protected Font m_FontNormal;

        /// <summary>
        /// Шрифт курсивный.
        /// </summary>
        protected Font m_FontItalic;

        /// <summary>
        /// Шрифт курсивный зачеркнутый.
        /// </summary>
        protected Font m_FontItalicStrike;

        #endregion
        /// <summary>
        /// NR-Default constructor
        /// </summary>
        public TreeViewManagerBase()
        {
        }
        /// <summary>
        /// NT-Initializes a new instance of the <see cref="TreeViewManagerBase"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="treeView">The tree view.</param>
        /// <exception cref="System.ArgumentNullException">
        /// engine
        /// or
        /// treeView
        /// </exception>
        public TreeViewManagerBase(CEngine engine, TreeView treeView)
        {
            this.m_engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.m_treeView = treeView ?? throw new ArgumentNullException(nameof(treeView));

            //set fonts
            this.m_FontNormal = new Font(treeView.Font, FontStyle.Regular);
            this.m_FontItalic = new Font(treeView.Font, FontStyle.Italic);
            this.m_FontItalicStrike = new Font(treeView.Font, FontStyle.Italic | FontStyle.Strikeout);

            return;
        }

        #region Properties

        /// <summary>
        /// Возвращаемый объект элемента
        /// </summary>
        public CElement Result
        {
            get { return m_result; }
            set { m_result = value; }
        }

        #endregion

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
        /// NT-очистить дерево элементов для следующего запуска диалога
        /// </summary>
        public virtual void ClearTree()
        {
            this.m_treeView.BeginUpdate();
            this.m_treeView.Nodes.Clear();
            this.m_treeView.EndUpdate();
            //выполнить прочие очистки здесь
            return;
        }

        /// <summary>
        /// NT-Показать дерево и в нем развернутый путь до элемента, указанного в StartElementId.
        /// </summary>
        public virtual void ShowTree()
        {
            return;
        }

        #region *** Get expanded nodes functions ***  

        /// <summary>
        /// NT-Получить список ид открытых нод дерева.
        /// </summary>
        /// <returns></returns>
        public List<int> GetExpandedNodesElementIdList()
        {
            List<int> lid = new List<int>();
            TreeNodeCollection nodes = this.m_treeView.Nodes;
            this.GetExpandedNodesSub(lid, nodes);

            return lid;
        }

        /// <summary>
        /// NT-Рекурсивно обойти дерево по открытым нодам и внести ид элементов открытых нод в список.
        /// </summary>
        /// <param name="lid">Список ид открытых нод дерева.</param>
        /// <param name="nodes">Коллекция субнод очередной ноды.</param>
        private void GetExpandedNodesSub(List<int> lid, TreeNodeCollection nodes)
        {
            foreach (TreeNode treeNode in nodes)
            {
                //в открытых нодах не может быть временных субнод.
                if (treeNode.IsExpanded)
                {
                    CElement elem = (CElement)treeNode.Tag;
                    lid.Add(elem.Id);
                    if (treeNode.Nodes.Count > 0)
                        this.GetExpandedNodesSub(lid, treeNode.Nodes);
                }
            }
        }

        #endregion

        #region *** Функции обновления дерева после изменений в БД ***

        /// <summary>
        /// NT-Обновить дерево после изменения БД и снова раскрыть и выбрать прежние элементы.
        /// </summary>
        public virtual void UpdateTree()
        {
            //Тут BeginUpdate() и AfterUpdate() неудобно вызывать. Поэтому и их и курсор менять на часы - надо в вызывающем коде. 

            //получить список раскрытых нод дерева
            List<int> expandedNodesIdList = this.GetExpandedNodesElementIdList();
            //получить ид элемента выбранной ноды
            CElement elem = (CElement)null;
            TreeNode selectedNode = this.m_treeView.SelectedNode;
            if (selectedNode != null)
                elem = (CElement)selectedNode.Tag;
            //свернуть все дерево
            this.m_treeView.CollapseAll();
            //для каждого ид из списка раскрытых нод найти его ноду в дереве
            // и если нашел, раскрыть ее. Это приведет к загрузке субнод и можно будет продолжать поиск.
            foreach (int elemId in expandedNodesIdList)
            {
                TreeNode nodeByElementId = this.FindNodeByElementId(elemId);
                if (nodeByElementId != null)
                    nodeByElementId.Expand();
            }
            //теперь найти ноду , бывшую ранее выбранной.
            TreeNode nodeByElementId1 = this.FindNodeByElementId(elem.Id);
            //если нода не найдена, выйти.
            //если нода найдена, сделать ее видимой и выбранной нодой.
            if (nodeByElementId1 == null)
                return;
            nodeByElementId1.EnsureVisible();
            this.m_treeView.SelectedNode = nodeByElementId1;

            return;
        }

        //Ищем ноду в дереве по ид элемента.
        //но дерево тогда должно быть раскрыто, ведь субноды загружаются только при раскрытии ноды.
        //поэтому поиск идет только по раскрытым нодам дерева.

        /// <summary>
        /// NT-Ищем ноду в дереве по ид элемента.
        /// </summary>
        /// <param name="objid">ИД элемента</param>
        /// <returns>Функция возвращает ноду с элементом с указанным идентификатором, либо null если ничего не найдено.</returns>
        protected TreeNode FindNodeByElementId(int objid)
        {
            TreeNodeCollection nodes = this.m_treeView.Nodes;

            return this.FindNodeByElementIdSub(objid, nodes);
        }

        /// <summary>
        /// NT-Рекурсивно ищем ноду в дереве по ид элемента.
        /// </summary>
        /// <param name="objid">ИД элемента</param>
        /// <param name="nodes">Коллекция субнод.</param>
        /// <returns>Функция возвращает ноду с элементом с указанным идентификатором, либо null если ничего не найдено.</returns>
        private TreeNode FindNodeByElementIdSub(int objid, TreeNodeCollection nodes)
        {
            TreeNode resultNode = (TreeNode)null;
            //для каждой ноды в коллекции нод
            foreach (TreeNode tn in nodes)
            {
                //извлечь объект из поля тега ноды
                CElement elem = (CElement)tn.Tag;
                //если объект не нуль, и ид==требуемому и тип элемента==требуемому
                if ((elem != null) && (objid == elem.Id))
                {
                    //возвращаем найденную ноду
                    resultNode = tn;
                    break;
                }
                //если у ноды есть субноды, запускаем поиск для каждой из них.
                //Если такой поиск найдет ноду, возвращаем ее, а если не найдет - возвращаем нуль. 
                if (tn.Nodes.Count > 0)
                {
                    resultNode = this.FindNodeByElementIdSub(objid, tn.Nodes);
                    if (resultNode != null)
                        break;
                }
            }
            return resultNode;
        }

        #endregion

        #region *** Функции коллекции иконок для дерева ***

        //тут нужны функции, управляющие коллекцией иконок для нод дерева.
        //базовые иконки загружаются при старте формы
        //плюс иконки раздела корзины и ее элементов
        //плюс иконки раздела файлы и его элементов - тут планируется извлекать иконку из шелла и добавлять в эту коллекцию, чтобы коллекция использовала родные иконки.
        //для файлов документов это будут иконки по расширению, и ключ - расширение, с точкой мили без?
        //для исполняемых файлов ключом будет название файла-приложения - левая часть до первой точки.
        //если иконка не найдена или еще что, то будет использоваться иконка ошибки.
        //вот эти все функции надо бы вынести в отдельный класс, но пока здесь все свалим в кучу.

        ///// <summary>
        ///// NT-Adds the icon for TreeView.
        ///// </summary>
        ///// <param name="icon">The icon.</param>
        ///// <returns></returns>
        ///// <exception cref="System.ArgumentException">Размер иконки более допустимого 32х32</exception>
        //private int addIconForTreeView(Image icon)
        //{
        //    if (icon.Height > 32 || icon.Width > 32)
        //        throw new ArgumentException("Размер иконки более допустимого 32х32");

        //    string md5Hash = CImageProcessor.GetMD5Hash(icon);

        //    ImageList imageList = this.m_treeView.ImageList;
        //    if (imageList.Images.IndexOfKey(md5Hash) < 0)
        //        imageList.Images.Add(md5Hash, icon);

        //    return imageList.Images.IndexOfKey(md5Hash);
        //}


        //private void ClearIconList()
        //{
        //    this.m_treeView.ImageList.Images.Clear();
        //}

        #endregion

        #region *** Обработчики событий дерева от формы. ***    

        /// <summary>
        /// NT-Клик по ноде сворачивает-разворачивает ноду.
        /// Подключите этот обработчик, если надо разворачивать ноды дерева одиночным кликом.
        /// </summary>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        public virtual void NodeClick(TreeNodeMouseClickEventArgs e)
        {
            e.Node.Toggle();
        }

        /// <summary>
        /// NT-Двойной клик по ноде
        /// </summary>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        public virtual void NodeDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            e.Node.Toggle();
        }

        /// <summary>
        /// NT-Node Before expand event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        public virtual void NodeBeforeExpand(TreeViewCancelEventArgs e)
        {
            return;
        }

        /// <summary>
        /// NT-Node Before collapse event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        public virtual void NodeBeforeCollapse(TreeViewCancelEventArgs e)
        {
            //skip invalid actions
            if (e.Action != TreeViewAction.Collapse)
                return;
            ////skip collapse if blocked
            //if (!this.m_TreeNodeCollapseEventHandlersEnabled)
            //    return;
            //нода сворачивается - вставить в нее временную субноду.
            TreeNode node = e.Node;
            if (node == null)
                return;
            //сначала удалить все имеющиеся субноды - это должна быть только одна субнода временная.
            node.Nodes.Clear();
            //вставить субноду
            node.Nodes.Add("temp node");

            return;
        }

        /// <summary>
        /// NT-пользователь что-то выбрал в дереве, вот событие из дерева.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        /// <returns>Функция возвращает выбранный объект либо null при ошибке.</returns>
        public virtual CElement NodeSelected(TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                return null;
            //надо передать в диалог объект данных выделенного элемента
            TreeNode node = e.Node;
            if (node == null)
                return null;
            CElement obj = (CElement)node.Tag;
            if (obj == null)
                return null;
            //записать объект как результат
            this.m_result = obj;
            //вернуть объект элемента в диалог, чтобы он мог отобразить его описание и включить-выключить кнопку выбора элемента.
            return obj;
        }

        #endregion

        #region ***  Вспомогательные функции ***

        /// <summary>
        /// NT-Adds the element to nodes.
        /// </summary>
        /// <param name="nodes">The nodes collection.</param>
        /// <param name="elementId">The element identifier.</param>
        protected virtual void AddElementToNodes(TreeNodeCollection nodes, int elementId)
        {
            CElement el1 = this.m_engine.DbAdapter.SelectElementWithoutTransaction(elementId);
            bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(elementId) > 0);
            nodes.Add(MakeTreeNode(el1, subnodesExists));

            return;
        }

        /// <summary>
        /// NT-Adds the element to nodes.
        /// </summary>
        /// <param name="nodes">The nodes collection.</param>
        /// <param name="element">The element object.</param>
        protected virtual void AddElementToNodes(TreeNodeCollection nodes, CElement element)
        {
            bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(element.Id) > 0);
            nodes.Add(MakeTreeNode(element, subnodesExists));

            return;
        }

        /// <summary>
        /// NT-создать цепочку открытых нод в дереве, где уже есть корневые ноды разделов.
        /// </summary>
        /// <param name="idChain">Цепочка идентификаторов элементов от корня к листу</param>
        /// <returns>Функция возвращает объект ноды дерева или null при неудаче.</returns>
        protected virtual TreeNode MakeTreeChain(List<int> idChain)
        {
            //выйти если цепочка пустая
            if (idChain.Count == 0)
                return null;
            //get last id in id chain
            int lastId = idChain[idChain.Count - 1];
            //выйти, если в цепочке есть только элемент с индексом 0 или менее
            if (lastId < 1)
                return null;
            //работаем
            //для каждого ид найти и раскрыть ноду в цепочке
            TreeNodeCollection nodes = this.m_treeView.Nodes;
            TreeNode result = null;

            //work
            foreach (int id in idChain)
            {
                //0 не входит в цепочку, ищем в коллекции нод дерева. 
                foreach (TreeNode node in nodes)
                {
                    //get node element
                    CElement elem = (CElement)node.Tag;
                    if (elem == null)
                        return null;//error found

                    if (id == elem.Id)
                    {
                        //store founded node
                        result = node;
                        //expand node - load subnodes to it
                        node.Expand();
                        //change node collection
                        nodes = node.Nodes;
                    }
                    //else continue;
                }
            }//end foreach idChain
            //check last node
            if (result == null) return null;
            CElement element = (CElement)result.Tag;
            if (element == null) return null;
            if (element.Id != lastId)
                return null;
            //return treenode object with last chain id
            return result;
        }

        /// <summary>
        /// NT-Проверить цепочку иерархии элементов дерева на отсутствие колец.
        /// </summary>
        /// <param name="currentElementId">The current element identifier.</param>
        /// <param name="newParentElementId">The parent element identifier.</param>
        /// <returns>Функция возвращает true, если в дереве цепочка вложенности не образует кольцо, false в противном случае.</returns>
        protected virtual bool CheckHierarchyChain(int currentElementId, int newParentElementId)
        {
            //быстро вернуть результат, если элемент ссылается на самого себя.
            if (currentElementId == newParentElementId)
                return false;
            //БД должна быть уже открыта на все время работы формы.
            //1 строим цепочку ид элементов от корня до newParentElementId
            // - тут правильный порядок элементов в цепочке не нужен, только проверить наличие значения в ней.
            List<int> ids = this.m_engine.DbAdapter.GetChainOfElementIds(newParentElementId, false);
            //2 проверяем: если цепочка содержит currentElementId, значит цепочка образует кольцо newParentElementId - currentElementId - ... - newParentElementId
            //Это неправильная цепочка, возвращаем результат.
            bool result = ids.Contains(currentElementId);

            return result;
        }

        /// <summary>
        /// NT-Создать ноду по данным объекта, без актуальных субнод.
        /// </summary>
        /// <param name="obj">Элемент</param>
        /// <param name="addTempSubnode">Добавить временную субноду, чтобы ноду можно было раскрыть. </param>
        /// <returns>Функция возвращает ноду для дерева элементов.</returns>
        protected virtual TreeNode MakeTreeNode(CElement obj, bool addTempSubnode)
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
            //ВАЖНО: нода содержит объект элемента в поле Tag
            tn.Tag = obj;
            //добавить пустую ноду, если надо
            if (addTempSubnode)
                tn.Nodes.Add("temp node");

            return tn;
        }

        /// <summary>
        /// NT-Назначить цвет и шрифт ноды согласно свойствам элемента
        /// </summary>
        /// <param name="tn">Объект ноды.</param>
        /// <param name="obj">Объект Элемента.</param>
        protected void SelectNodeFontAndColor(TreeNode tn, CElement obj)
        {
            //deleted element color
            if (obj.IsDeleted())
            {
                tn.ForeColor = ElementTreeViewManager.Color_InactiveElement;
                tn.NodeFont = this.m_FontItalic;//курсив серый
            }
            else
            {
                //
                tn.ForeColor = ElementTreeViewManager.Color_NormalElement;
                tn.NodeFont = this.m_FontNormal;
                //если это Задача, то цвет определяется ее важностью.
                if (obj.ElementType == EnumElementType.Task)
                {
                    CTask ct = (CTask)obj;
                    //task priority
                    if (ct.TaskPriority == EnumTaskPriority.High)
                        tn.ForeColor = ElementTreeViewManager.Color_PriorityTask;
                    else if (ct.TaskPriority >= EnumTaskPriority.Low)
                        tn.ForeColor = ElementTreeViewManager.Color_NotPriorityTask;
                    //task state
                    if (ct.IsCompleted())
                        tn.NodeFont = this.m_FontItalicStrike;//зачеркнутый курсив 
                    else if (ct.IsPaused())
                        tn.NodeFont = this.m_FontItalic;//курсив 
                }
            }

            return;
        }

        /// <summary>
        /// NT-Gets the index of the node image.
        /// </summary>
        /// <param name="t">Тип элемента</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Неправильный тип элемента: " + t.ToString()</exception>
        protected int GetNodeImageIndex(EnumElementType t)
        {
            int result;

            switch (t)
            {
                case EnumElementType.Category:
                    result = IconIndex_Category;
                    break;
                case EnumElementType.Tag:
                    result = IconIndex_Tag;
                    break;
                case EnumElementType.Task:
                    result = IconIndex_Task;
                    break;
                case EnumElementType.Note:
                    result = IconIndex_Note;
                    break;
                default:
                    throw new Exception("Неправильный тип элемента: " + t.ToString());
            }

            return result;
        }

        #endregion






    }

}