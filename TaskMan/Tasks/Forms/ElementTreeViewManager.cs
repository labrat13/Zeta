using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using TaskEngine;

namespace Tasks.Forms
{
    /// <summary>
    /// NR-Менеджер класса дерева выбора элементов
    /// </summary>
    /// <remarks>
    /// Этот менеджер заполняет окно дерева элементами, начиная с корня и заканчивая элементом, чей ид указан в m_startElementId.
    /// Если этот элемент содержит субэлементы, они также показываются в дереве.
    /// 
    /// Этот элемент используется в ситуациях:
    /// - Для созданной категории надо указать над-категорию.
    /// - Для созданного/существующего элемента надо указать/изменить категорию или над-элемент.
    /// - Надо выбрать из дерева элемент для выполнения над ним некоторой работы в процедуре.
    /// - Надо выбрать из дерева тегов один тег для пометки элемента в карточке элементов.
    /// 
    /// Проверка отсутствия кольца в дереве:
    /// Если элемент ссылается на самого себя в дереве, он в дереве не отображается?
    /// Для предотвращения этого после выбора элемента надо выполнить проверку: 
    /// Построить цепочку Ид элементов от корня до выбранного в качестве нового parent.
    /// Если в этой цепочке есть ид текущего элемента, то цепочка неправильная, это соединение образует кольцо, надо заблокировать выбор такого нового parent.
    /// 
    /// </remarks>
    internal class ElementTreeViewManager
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

        //----- Переменные класса -----

        /// <summary>
        /// Объект БД
        /// </summary>
        protected CEngine m_engine;

        /// <summary>
        /// Начальный или возвращаемый объект элемента
        /// </summary>
        protected CElement m_result;

        /// <summary>
        /// Тип отображаемых элементов: категории, классы, неизвестно (Unknown)
        /// </summary>
        protected EnumElementType m_AllowedElementTypes;

        ///// <summary>
        ///// Флаг включить обработчики событий разворачивания нод дерева
        ///// </summary>
        //private bool m_TreeNodeCollapseEventHandlersEnabled;

        /// <summary>
        /// Контрол дерева на форме
        /// </summary>
        protected TreeView m_treeView;

        /// <summary>
        /// Ссылка на текущий  элемент для дерева 
        /// </summary>
        protected int m_startElementId;

        /// <summary>
        /// Проверять отсутствие нарушения иерархии при выборе родительского элемента в этой форме.
        /// </summary>
        protected bool m_checkHierarchy;

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
        /// NR-Initializes a new instance of the <see cref="ElementTreeViewManager"/> class.
        /// </summary>
        public ElementTreeViewManager()
        {
            //TODO: add code here
        }

        /// <summary>
        /// NT-Initializes a new instance of the <see cref="ElementTreeViewManager"/> class.
        /// </summary>
        /// <param name="treeView_Elements">Контрол дерева, с которым будем работать.</param>
        /// <param name="engine">Task Engine reference for database access.</param>
        /// <param name="startElementId">Идентификатор элемента, представляющего начало обозреваемого дерева элементов.</param>
        /// <param name="elementType">Фильтр типа отображаемых элементов.</param>
        /// <param name="checkHierarchy">Проверять отсутствие нарушения иерархии при выборе родительского элемента в этой форме</param>
        /// <remarks>
        /// Тип отображаемого элемента: Определяет тип элемента, который можно выбрать для возврата. 
        /// Категории отображаются независимо от этого значения, так как они соединяют всю структуру элементов разных типов.
        /// </remarks>
        public ElementTreeViewManager(TreeView tw, CEngine engine, int startElementId, EnumElementType elementType, bool checkHierarchy)
        {
            this.m_treeView = tw;
            this.m_AllowedElementTypes = elementType;
            this.m_engine = engine;
            this.m_result = null;
            this.m_startElementId = startElementId;
            this.m_checkHierarchy = checkHierarchy;

            //set fonts
            this.m_FontNormal = new Font(tw.Font, FontStyle.Regular);
            this.m_FontItalic = new Font(tw.Font, FontStyle.Italic);
            this.m_FontItalicStrike = new Font(tw.Font, FontStyle.Italic | FontStyle.Strikeout);

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
        /// NT-очистить дерево элементов для следующего запуска диалога
        /// </summary>
        public void ClearTree()
        {
            this.m_treeView.BeginUpdate();
            this.m_treeView.Nodes.Clear();
            this.m_treeView.EndUpdate();
            //выполнить прочие очистки здесь
            return;
        }

        #region *** Get expanded nodes functions ***  
        
        /// <summary>
        /// NT-Получить список ид открытых нод дерева.
        /// </summary>
        /// <returns></returns>
        public List<int> getExpandedNodesElementIdList()
        {
            List<int> lid = new List<int>();
            TreeNodeCollection nodes = this.m_treeView.Nodes;
            this.getExpandedNodesSub(lid, nodes);

            return lid;
        }

        /// <summary>
        /// NT-Рекурсивно обойти дерево по открытым нодам и внести ид элементов открытых нод в список.
        /// </summary>
        /// <param name="lid">Список ид открытых нод дерева.</param>
        /// <param name="nodes">Коллекция субнод очередной ноды.</param>
        private void getExpandedNodesSub(List<int> lid, TreeNodeCollection nodes)
        {
            foreach (TreeNode treeNode in nodes)
            {
                //в открытых нодах не может быть временных субнод.
                if (treeNode.IsExpanded)
                {
                    CElement elem = (CElement) treeNode.Tag;
                    lid.Add(elem.Id);
                    if (treeNode.Nodes.Count > 0)
                        this.getExpandedNodesSub(lid, treeNode.Nodes);
                }
            }
        }

        #endregion

        #region *** Функции обновления дерева после изменений в БД ***
    
        /// <summary>
        /// NT-Обновить дерево после изменения БД и снова раскрыть и выбрать прежние элементы.
        /// </summary>
        public void UpdateTree()
        {
            //Тут BeginUpdate() и AfterUpdate() неудобно вызывать. Поэтому и их и курсор менять на часы - надо в вызывающем коде. 
            
            //получить список раскрытых нод дерева
            List<int> expandedNodesIdList = this.getExpandedNodesElementIdList();
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
                TreeNode nodeByElementId = this.findNodeByElementId(elemId);
                if (nodeByElementId != null)
                    nodeByElementId.Expand();
            }
            //теперь найти ноду , бывшую ранее выбранной.
            TreeNode nodeByElementId1 = this.findNodeByElementId(elem.Id);
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
        private TreeNode findNodeByElementId(int objid)
        {
            TreeNodeCollection nodes = this.m_treeView.Nodes;

            return this.findNodeByElementIdSub(objid, nodes);
        }

        /// <summary>
        /// NT-Рекурсивно ищем ноду в дереве по ид элемента.
        /// </summary>
        /// <param name="objid">ИД элемента</param>
        /// <param name="nodes">Коллекция субнод.</param>
        /// <returns>Функция возвращает ноду с элементом с указанным идентификатором, либо null если ничего не найдено.</returns>
        private TreeNode findNodeByElementIdSub(int objid, TreeNodeCollection nodes)
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
                    resultNode = this.findNodeByElementIdSub(objid, tn.Nodes);
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
        public void NodeClick(TreeNodeMouseClickEventArgs e)
        {
            e.Node.Toggle();
        }

        /// <summary>
        /// NT-Node Before expand event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        public void TreeViewBeforeExpand(TreeViewCancelEventArgs e)
        {
            ////если сворачивание-разворачивание заблокировано
            //if (!this.m_TreeNodeCollapseEventHandlersEnabled)
            //    return;

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
                return;
            //start update treeview
            this.m_treeView.BeginUpdate();
            this.m_treeView.UseWaitCursor = true;
            //загрузить субноды
            TreeNode[] nodes = this.makeElementSubNodes(el.Id);
                node.Nodes.AddRange(nodes);
            //finish update
            this.m_treeView.UseWaitCursor = false;
            this.m_treeView.EndUpdate();

            return;
        }

        /// <summary>
        /// NT-Node Before collapse event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        public void TreeViewBeforeCollapse(TreeViewCancelEventArgs e)
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
        public CElement NodeSelected(TreeViewEventArgs e)
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




        #region oldCode
        /// <summary>
        /// NR-Node Before expand event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        public void TreeViewBeforeExpandOld( TreeViewCancelEventArgs e)
        {
            //skip invalid actions
            if (e.Action != TreeViewAction.Expand)
                return;
            //нода раскрывается - вставить в нее субноды элементов, если они есть.
            TreeNode node = e.Node;
            if (node == null)
                return;
            CElement el = (CElement)node.Tag;
            if (el == null)
                return;

            //сначала удалить все имеющиеся субноды - это должна быть только одна субнода временная.
            node.Nodes.Clear();
            //теперь открыть бд, получить все суб-элементы, добавить их как суб-ноды, закрыть БД
            int parentId = el.Id;
            //start update
            try
            {
                this.m_treeView.BeginUpdate();
                this.m_treeView.UseWaitCursor = true;
                this.m_engine.DbAdapter.Open();

                //get child elements
                List<CElement> childs = this.m_engine.DbAdapter.SelectElementsByParentId(parentId);
                //foreach childs - add to subnodes as new node 
                foreach (CElement ch in childs)
                {
                    //filter by type and then by id chain
                    //игнорировать элементы, помеченные удаленными.
                    if (ch.IsDeleted())
                        continue;
                    //игнорировать элементы любого типа, кроме категорий и указанного в m_AllowedElementType
                    if (!this.IsAllowedElementType(ch.ElementType))
                        continue;
                    //теперь элементы добавить в дерево как папки.
                    //свернутыми с временной нодой внутри для возможности развернуть ее при необходимости.
                    bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(ch.Id) > 0);
                    node.Nodes.Add(makeTreeNode(ch, subnodesExists));
                }
            }
            catch (Exception ex)
            {
                ;
            }
            finally
            {
                //finish update
                this.m_engine.DbAdapter.Close();
                this.m_treeView.UseWaitCursor = false;
                this.m_treeView.EndUpdate();
            }

            return;
        }

        /// <summary>
        /// NR-Показать ноды для указанного типа элементов
        /// </summary>
        internal void ShowTreeOld()
        {

            //создание дерева сделано, не тестировано, а остальные фишки - не сделаны.
            //ВАЖНО: нода содержит объект элемента в поле Tag

            //начать обновление дерева 
            this.m_treeView.BeginUpdate();
            //set cursor
            Cursor.Current = Cursors.WaitCursor;
            //удалить все ноды из дерева
            this.m_treeView.Nodes.Clear();

            this.m_engine.DbAdapter.Open();
            //1 построить цепочку ид элементов от рута до начального элемента
            //передать ее в виде списка инт сверху вниз 
            List<int> idChain = this.m_engine.DbAdapter.GetChainOfElementIds(this.m_startElementId, true);
            //2 построить дерево нод сверху вниз по этой цепочке, раскрывая только ноды, указанные в цепочке.
            //- вставить RootId = 0 в начало цепочки
            idChain.Insert(0, TaskDbAdapter.ElementId_Root);
            //nodes collection for this loop
            TreeNodeCollection subnodes = this.m_treeView.Nodes;
            TreeNode nextNode = null;
            //loop
            foreach (int id in idChain)
            {
                //get child elements
                List<CElement> childs = this.m_engine.DbAdapter.SelectElementsByParentId(id);
                //foreach childs - add to subnodes as new node 
                foreach (CElement el in childs)
                {
                    //filter by type and then by id chain
                    //игнорировать элементы, помеченные удаленными.
                    if (el.IsDeleted())
                        continue;
                    //игнорировать элементы любого типа, кроме категорий и указанного в m_AllowedElementType
                    if (!this.IsAllowedElementType(el.ElementType))
                        continue;
                    //теперь элементы добавить в дерево как папки.
                    //только папку со следующим ид в цепочке показать раскрытой, остальные - свернутыми с временной нодой внутри для возможности развернуть ее при необходимости.
                    if (idChain.Contains(el.Id))
                    {
                        nextNode = makeTreeNode(el, false);
                        subnodes.Add(nextNode);
                    }
                    else
                    {
                        bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(el.Id) > 0);
                        subnodes.Add(makeTreeNode(el, subnodesExists));
                    }
                    //end
                } //end child elements processing
                //nextNode теперь является следующей нодой, в которую добавляются субноды.
                if (nextNode != null)
                {
                    subnodes = nextNode.Nodes;
                    nextNode = null;
                }
                //else
                //{
                //    //Если последний элемент не содержит субэлементов, мы оказываемся здесь.
                //    //Если элемент цепочки не был найден, мы оказываемся здесь. Но этого не может быть - ведь мы уже собрали цепочку ранее, значит элемент существует..
                //    throw new Exception("Не найден элемент цепочки в дереве элементов.");
                //}
            }//end id chain processing

            this.m_engine.DbAdapter.Close();
            //закончить обновление дерева
            Cursor.Current = Cursors.Default;
            m_treeView.EndUpdate();

            //3 раскрыть конечную ноду, если надо?
            //Важно: В этом месте БД уже не используется и закрыта, поэтому ее могут открывать и закрывать обработчики событий дерева.  
            //this.m_treeView.SelectedNode = lastNode; - это не работает, так как в дереве уже нет этой ноды
            //надо раскрывать ноды по цепочке ид
            this.ExpandNodes(idChain);

            //TODO: остальное смотреть в Инвентарь.CTreeViewManager
            return;
        }

        /// <summary>
        /// NT-Раскрыть узлы дерева по цепочке идентификаторов элементов. 
        /// </summary>
        /// <param name="idChain">The identifier chain.</param>
        private void ExpandNodes(List<int> idChain)
        {
            TreeNodeCollection subnodes = this.m_treeView.Nodes;
            foreach (int id in idChain)
            {
                //skip root id = 0;
                if (id == TaskDbAdapter.ElementId_Root)
                    continue;
                foreach (TreeNode child in subnodes)
                {
                    if (child == null)
                        continue;
                    CElement elem = (CElement)child.Tag;
                    if (elem == null)
                        continue;
                    //expand node
                    if (elem.Id == id)
                    {
                        child.Expand();
                        subnodes = child.Nodes;
                        break;
                    }
                }
            }
            //TODO: тут последний элемент не выбирается в дереве.
            //а если бы он выбирался - генерировал бы событие NodeSelect.
            //А это событие сейчас неправильно обрабатывается, и вызывающему коду возвращается 0.
            return;
        }

        /// <summary>
        /// NT-Alloweds the type of the element.
        /// </summary>
        /// <param name="elementType">Type of the element.</param>
        /// <returns></returns>
        /// <remarks>
        /// Тип отображаемого элемента: Определяет тип элемента, который можно выбрать для возврата. 
        /// Категории отображаются независимо от этого значения, так как они соединяют всю структуру элементов разных типов.
        /// </remarks> 
        public bool IsAllowedElementType(EnumElementType elementType)
        {
            return ((elementType == EnumElementType.Category) || ((this.m_AllowedElementTypes & elementType) > 0));
        }



        #endregion



        #region ***  Вспомогательные функции ***

        /// <summary>
        /// NT-Проверить цепочку иерархии элементов дерева на отсутствие колец.
        /// </summary>
        /// <param name="currentElementId">The current element identifier.</param>
        /// <param name="newParentElementId">The parent element identifier.</param>
        /// <returns>Функция возвращает true, если в дереве цепочка вложенности не образует кольцо, false в противном случае.</returns>
        private bool checkHierarchyChain(int currentElementId, int newParentElementId)
        {
            //быстро вернуть результат, если элемент ссылается на самого себя.
            if (currentElementId == newParentElementId)
                return false;
            //open database if not opened 
            this.m_engine.DbAdapter.Open();
            //1 строим цепочку ид элементов от корня до newParentElementId
            // - тут правильный порядок элементов в цепочке не нужен, только проверить наличие значения в ней.
            List<int> ids = this.m_engine.DbAdapter.GetChainOfElementIds(newParentElementId, false);
            //2 проверяем: если цепочка содержит currentElementId, значит цепочка образует кольцо newParentElementId - currentElementId - ... - newParentElementId
            //Это неправильная цепочка, возвращаем результат.
            bool result = ids.Contains(currentElementId);
            //close database
            this.m_engine.DbAdapter.Close();

            return result;
        }

        /// <summary>
        /// NT-Создать массив субнод для текущей ноды элемента
        /// </summary>
        /// <param name="id">Идентификатор элемента.</param>
        /// <returns>Функция возвращает массив субнод для ноды элемента.</returns>
        private TreeNode[] makeElementSubNodes(int id)
        {
            //Заполнить элементами выходной список так, чтобы:
            //1. удаленные элементы не отображались.
            //2. отображались только категории и разрешенные типы элементов (теги, заметки, задачи)
            //3. элементы были группированы по типам: сверху Категории, потом Заметки, снизу Задачи.
            //4. внутри типа элементы были сортированы по алфавиту.

            List<TreeNode> nodes = new List<TreeNode>();
            //получить дочерние элементы из БД
            List<CElement> elements = this.m_engine.DbAdapter.SelectElementsByParentId(id);
            //если субэлементов нет, быстро завершить функцию.
            if (elements.Count == 0)
                return nodes.ToArray();

            //удалить из списка удаленные элементы, чтобы меньше сортировать было. (правило 1)
            //удалить из списка не разрешенные фильтром элементы, кроме категорий. (правило 2)
            elements = CElement.FilterElements(elements, this.m_AllowedElementTypes | EnumElementType.Category);
            //сортировать по типу и алфавиту (правила 3 и 4)
            if (elements.Count > 1)
                elements = CElement.SortElementsByTypeAndTitle(elements, this.m_AllowedElementTypes | EnumElementType.Category);
            //TODO: Объединить это в одну функцию как второй вариант. Сейчас это слишком много памяти и процессора занимает.

            //теперь элементы добавить в дерево как папки.
            //свернутыми с временной нодой внутри для возможности развернуть ее при необходимости.
            foreach (CElement el in elements)
            {
                bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(el.Id) > 0);
                nodes.Add(makeTreeNode(el, subnodesExists));
            }

            return nodes.ToArray();
        }


        /// <summary>
        /// NT-Проверить, допустим ли указанный элемент для выбора в качестве выбранного элемента..
        /// </summary>
        /// <param name="checkHierarchy">Проверять иерархию дерева во избежание кольцевания.</param>
        /// <param name="toCheck">Проверяемый элемент.</param>
        /// <returns>
        ///   <c>true</c> if [is allowed element] [the specified check hierarchy]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAllowedElement(CElement toCheck)
        {
            bool isAllowedElementType = ((this.m_AllowedElementTypes & toCheck.ElementType) > 0);
            bool isAllowedHierarchyChain = true;
            if (this.m_checkHierarchy == true)
                isAllowedHierarchyChain = this.checkHierarchyChain(this.m_startElementId, toCheck.Id);

            return isAllowedElementType && isAllowedHierarchyChain;
        }

        /// <summary>
        /// NT-Создать ноду по данным объекта, без актуальных субнод.
        /// </summary>
        /// <param name="obj">Элемент</param>
        /// <param name="addTempSubnode">Добавить временную субноду, чтобы ноду можно было раскрыть. </param>
        /// <returns>Функция возвращает ноду для дерева элементов.</returns>
        private TreeNode makeTreeNode(CElement obj, bool addTempSubnode)
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
        private void SelectNodeFontAndColor(TreeNode tn, CElement obj)
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
        private int GetNodeImageIndex(EnumElementType t)
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

        ///// <summary>
        ///// NT-Selects the color of the node.
        ///// </summary>
        ///// <param name="obj">Элемент</param>
        ///// <returns></returns>
        //private static Color SelectNodeColor(CElement obj)
        //{
        //    //deleted element color
        //    if (obj.IsDeleted())//if (objElementState == EnumElementState.Deleted)
        //        return ElementTreeViewManager.Color_InactiveElement;

        //    //если это Задача, то цвет определяется ее важностью.
        //    if (obj.ElementType == EnumElementType.Task)
        //    {
        //        CTask ct = (CTask)obj;
        //        if (ct.TaskPriority == EnumTaskPriority.High)
        //            return ElementTreeViewManager.Color_PriorityTask;
        //        else if (ct.TaskPriority >= EnumTaskPriority.Low)
        //            return ElementTreeViewManager.Color_NotPriorityTask; ;
        //    }

        //    return ElementTreeViewManager.Color_NormalElement;
        //}

#endregion

    }
}
