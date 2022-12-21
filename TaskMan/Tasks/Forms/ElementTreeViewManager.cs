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
    /// NT-Менеджер класса дерева выбора элементов
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
    /// Фильтр типов элементов:
    /// - если надо выбрать Категорию для Задачи, то фильтр должен включать в себя: Категориии и Задачи.
    ///   - Категории, чтобы можно было выбрать категорию в форме, иначе кнопка ОК будет недоступна.
    ///   - Задачи, чтобы раздел задач отображался в форме. Но он будет и Задачи отображать тоже, тут надо подумать.
    /// - если надо выбрать Категорию для Заметки,  то фильтр должен включать в себя: Категориии, Задачи, Заметки.
    ///   - Категории, чтобы можно было выбрать категорию в форме, иначе кнопка ОК будет недоступна.
    ///   - Задачи, чтобы раздел задач отображался в форме. Но он будет и Задачи отображать тоже, тут надо подумать.
    ///   - Заметки, чтобы раздел Задач отображался в форме. Но он будет и Задачи и Заметки отображать тоже.
    ///   - Задача может включать в себя под-задачи и под-заметки, поэтому задачи нужно отображать как соединительные элементы, если надо отобразить все заметки дерева и все задачи дерева.
    /// - если надо выбрать категорию для Тега, то фильтр должен включать в себя: Категория, Тег.
    ///   - Заметки в дереве тегов не допускаются пока что.
    ///   - Категории, чтобы можно было выбрать категорию в форме, иначе кнопка ОК будет недоступна.
    ///   - Тег, чтобы раздел тегов отображался в форме. Но он будет и теги отображать тоже, тут надо думать.
    /// - если надо выбрать тег, то фильтр должен включать в себя: Теги
    ///   - Категории должны будут отображаться как образующий структуру элемент.
    /// - если надо выбрать Задачу, то фильтр должен включать в себя: Задача
    ///   - Категории должны будут отображаться как образующий структуру элемент. 
    /// - если надо выбрать Заметку, то фильтр должен включать в себя: Задача, Заметка
    ///   - Категории должны будут отображаться как образующий структуру элемент.
    ///   - Задачи, чтобы раздел задач отображался в форме. Но он будет и Задачи отображать тоже, тут надо подумать.
    ///   
    /// 
    /// </remarks>
    internal class ElementTreeViewManager : TreeViewManagerBase
    {

        #region *** Constants and Fields ***
        //из базового класса:
        //protected CEngine m_engine;// Объект БД
        //protected CElement m_result;// Начальный или возвращаемый объект элемента
        //protected TreeView m_treeView;// Контрол дерева на форме
        //объекты шрифтов для нод дерева, зависят от потока.
        //Чтобы изменить шрифт дерева, измените его в контроле дерева.
        //protected Font m_FontNormal;//Шрифт нормальный, используется по умолчанию для нод всех элементов.
        //protected Font m_FontItalic;// Шрифт курсивный.
        //protected Font m_FontItalicStrike;// Шрифт курсивный зачеркнутый.


        /// <summary>
        /// Тип отображаемых элементов: категории, классы, неизвестно (Unknown)
        /// </summary>
        protected EnumElementType m_AllowedElementTypes;

        /// <summary>
        /// Ссылка на текущий  элемент для дерева 
        /// </summary>
        protected int m_startElementId;

        /// <summary>
        /// Проверять отсутствие нарушения иерархии при выборе родительского элемента в этой форме.
        /// </summary>
        protected bool m_checkHierarchy;

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
            : base(engine, tw)
        {
            this.m_result = null;
            this.m_AllowedElementTypes = elementType;
            this.m_startElementId = startElementId;
            this.m_checkHierarchy = checkHierarchy;

            return;
        }

        #region Properties

        //Из базового класса:
        //public CElement Result// Возвращаемый объект элемента

        #endregion

        #region *** Обработчики событий дерева от формы. ***    
        
        ///// <summary>
        ///// NT-Клик по ноде сворачивает-разворачивает ноду.
        ///// Подключите этот обработчик, если надо разворачивать ноды дерева одиночным кликом.
        ///// </summary>
        ///// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        //public override void NodeClick(TreeNodeMouseClickEventArgs e)
        //{
        //    e.Node.Toggle();
        //}

        ///// <summary>
        ///// NT-Двойной клик по ноде
        ///// </summary>
        ///// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        //public override void NodeDoubleClick(TreeNodeMouseClickEventArgs e)
        //{
        //    e.Node.Toggle();
        //}

        /// <summary>
        /// NT-Node Before expand event.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        public override void NodeBeforeExpand(TreeViewCancelEventArgs e)
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
            TreeNode[] nodes = this.MakeElementSubNodes(el.Id);
                node.Nodes.AddRange(nodes);
            //finish update
            this.m_treeView.UseWaitCursor = false;
            this.m_treeView.EndUpdate();

            return;
        }

        ///// <summary>
        ///// NT-Node Before collapse event.
        ///// </summary>
        ///// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        //public override void NodeBeforeCollapse(TreeViewCancelEventArgs e)
        //{
        //    //skip invalid actions
        //    if (e.Action != TreeViewAction.Collapse)
        //        return;
        //    ////skip collapse if blocked
        //    //if (!this.m_TreeNodeCollapseEventHandlersEnabled)
        //    //    return;
        //    //нода сворачивается - вставить в нее временную субноду.
        //    TreeNode node = e.Node;
        //    if (node == null)
        //        return;
        //    //сначала удалить все имеющиеся субноды - это должна быть только одна субнода временная.
        //    node.Nodes.Clear();
        //    //вставить субноду
        //    node.Nodes.Add("temp node");

        //    return;
        //}

        ///// <summary>
        ///// NT-пользователь что-то выбрал в дереве, вот событие из дерева.
        ///// </summary>
        ///// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        ///// <returns>Функция возвращает выбранный объект либо null при ошибке.</returns>
        //public override CElement NodeSelected(TreeViewEventArgs e)
        //{
        //    if (e.Action == TreeViewAction.Unknown)
        //        return null;
        //    //надо передать в диалог объект данных выделенного элемента
        //    TreeNode node = e.Node;
        //    if (node == null)
        //        return null;
        //    CElement obj = (CElement)node.Tag;
        //    if (obj == null)
        //        return null;
        //    //записать объект как результат
        //    this.m_result = obj;
        //    //вернуть объект элемента в диалог, чтобы он мог отобразить его описание и включить-выключить кнопку выбора элемента.
        //    return obj;
        //}

        #endregion  
        
        /// <summary>
        /// NT-Показать дерево и в нем развернутый путь до элемента, указанного в StartElementId.
        /// </summary>
        public override void ShowTree()
        {
            //start update treeview
            this.m_treeView.BeginUpdate();
            this.m_treeView.UseWaitCursor=true;
            //remove all old nodes
            this.m_treeView.Nodes.Clear();
            //Для каждого типа нод, если разрешены, добавить в дерево корневую ноду раздела в правильном порядке.
            //Остальные ноды добавлять раскрытием нод
            if (this.IsAllowedElementType(EnumElementType.Task))
            {
                this.AddElementToNodes(this.m_treeView.Nodes, TaskDbAdapter.ElementId_TaskRoot);
            }
            if (this.IsAllowedElementType(EnumElementType.Tag))
            {
                this.AddElementToNodes(this.m_treeView.Nodes, TaskDbAdapter.ElementId_TagRoot);
            }
            //если стартовый элемент не корневой элемент, то показать и выделить в дереве указанный элемент.
            if ((this.m_startElementId != TaskDbAdapter.ElementId_Root) 
                && (this.m_startElementId != TaskDbAdapter.ElementId_TaskRoot)
                && (this.m_startElementId != TaskDbAdapter.ElementId_TagRoot))
            {
                //тут надо построить цепочку от this.m_startElementId до корня дерева,
                //перевернуть ее,
                List<int> idChain = this.m_engine.DbAdapter.GetChainOfElementIds(this.m_startElementId, true);
                //последовательно найти и раскрыть каждую ноду из имеющихся в цепочке.

                //TODO: remove this commented code after full test

                ////для каждого ид из списка раскрытых нод найти его ноду в дереве
                //// и если нашел, раскрыть ее. Это приведет к загрузке субнод и можно будет продолжать поиск.
                //foreach (int elemId in idChain)
                //{
                //    TreeNode nodeByElementId = this.FindNodeByElementId(elemId);
                //    if (nodeByElementId != null)
                //        nodeByElementId.Expand();
                //}
                ////теперь найти ноду , бывшую ранее выбранной.
                //TreeNode nodeByElementId1 = this.FindNodeByElementId(this.m_startElementId);
                ////выбрать элемент this.m_startElementId
                ////если нода не найдена, выйти.
                ////если нода найдена, сделать ее видимой и выбранной нодой.
                //if (nodeByElementId1 == null)
                //    return;
                //nodeByElementId1.EnsureVisible();
                //this.m_treeView.SelectedNode = nodeByElementId1;

                TreeNode selectedNode = this.MakeTreeChain(idChain);
                //выбрать ноду элемента this.m_startElementId
                //если нода не найдена, выйти.
                //если нода найдена, сделать ее видимой и выбранной нодой.
                if (selectedNode != null)
                {
                    selectedNode.EnsureVisible();
                    this.m_treeView.SelectedNode = selectedNode;
                }
            }

            //finish update treeview
            this.m_treeView.UseWaitCursor = false;
            this.m_treeView.EndUpdate();

            return;
        }



        #region ***  Вспомогательные функции ***



        /// <summary>
        /// NT-Создать массив субнод для текущей ноды элемента
        /// </summary>
        /// <param name="id">Идентификатор элемента.</param>
        /// <returns>Функция возвращает массив субнод для ноды элемента.</returns>
        private TreeNode[] MakeElementSubNodes(int id)
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
            ////удалить из списка не разрешенные фильтром элементы, кроме категорий. (правило 2)
            //elements = CElement.FilterElements(elements, this.m_AllowedElementTypes | EnumElementType.Category);
            ////сортировать по типу и алфавиту (правила 3 и 4)
            //if (elements.Count > 1)
            //    elements = CElement.SortElementsByTypeAndTitle(elements, this.m_AllowedElementTypes | EnumElementType.Category);
            //DONE: Объединить это в одну функцию как второй вариант. Сейчас это слишком много памяти и процессора занимает.
            elements = CElement.FilterAndSortElementsByTypeAndTitle(elements, this.m_AllowedElementTypes | EnumElementType.Category);
            
            //теперь элементы добавить в дерево как папки.
            //свернутыми с временной нодой внутри для возможности развернуть ее при необходимости.
            foreach (CElement el in elements)
            {
                bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(el.Id) > 0);
                nodes.Add(MakeTreeNode(el, subnodesExists));
            }

            return nodes.ToArray();
        }

        /// <summary>
        /// NT-Проверить, допустим ли указанный элемент для выбора в диалоге в качестве выбранного элемента..
        /// </summary>
        /// <param name="checkHierarchy">Проверять иерархию дерева во избежание кольцевания.</param>
        /// <param name="toCheck">Проверяемый элемент.</param>
        /// <returns>
        ///   <c>true</c> if [is allowed element] [the specified check hierarchy]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAllowedElement(CElement toCheck)
        {
            bool isAllowedElementType = IsAllowedElementType(toCheck.ElementType);
            bool isAllowedHierarchyChain = true;
            if (this.m_checkHierarchy == true)
                isAllowedHierarchyChain = this.CheckHierarchyChain(this.m_startElementId, toCheck.Id);

            return isAllowedElementType && isAllowedHierarchyChain;
        }

        /// <summary>
        /// NT-Определить, входит ли тип элемента в фильтр разрешенных типов элементов 
        /// </summary>
        /// <param name="t">Тип элемента.</param>
        /// <returns>
        ///  Функция возвращает <c>true</c>, если указанный тип элемента входит в фильтр разрешенных типов элементов, <c>false</c> в противном случае.
        /// </returns>
        protected bool IsAllowedElementType(EnumElementType t)
        {
            return ((this.m_AllowedElementTypes & t) > 0);
        }

        #endregion


        #region oldCode - пока оставить как свалку идей, до завершения отработки форм деревьев..
        ///// <summary>
        ///// NR-Node Before expand event.
        ///// </summary>
        ///// <param name="e">The <see cref="TreeViewCancelEventArgs"/> instance containing the event data.</param>
        //public void TreeViewBeforeExpandOld( TreeViewCancelEventArgs e)
        //{
        //    //skip invalid actions
        //    if (e.Action != TreeViewAction.Expand)
        //        return;
        //    //нода раскрывается - вставить в нее субноды элементов, если они есть.
        //    TreeNode node = e.Node;
        //    if (node == null)
        //        return;
        //    CElement el = (CElement)node.Tag;
        //    if (el == null)
        //        return;

        //    //сначала удалить все имеющиеся субноды - это должна быть только одна субнода временная.
        //    node.Nodes.Clear();
        //    //теперь открыть бд, получить все суб-элементы, добавить их как суб-ноды, закрыть БД
        //    int parentId = el.Id;
        //    //start update
        //    try
        //    {
        //        this.m_treeView.BeginUpdate();
        //        this.m_treeView.UseWaitCursor = true;
        //        this.m_engine.DbAdapter.Open();

        //        //get child elements
        //        List<CElement> childs = this.m_engine.DbAdapter.SelectElementsByParentId(parentId);
        //        //foreach childs - add to subnodes as new node 
        //        foreach (CElement ch in childs)
        //        {
        //            //filter by type and then by id chain
        //            //игнорировать элементы, помеченные удаленными.
        //            if (ch.IsDeleted())
        //                continue;
        //            //игнорировать элементы любого типа, кроме категорий и указанного в m_AllowedElementType
        //            if (!this.IsAllowedElementType(ch.ElementType))
        //                continue;
        //            //теперь элементы добавить в дерево как папки.
        //            //свернутыми с временной нодой внутри для возможности развернуть ее при необходимости.
        //            bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(ch.Id) > 0);
        //            node.Nodes.Add(MakeTreeNode(ch, subnodesExists));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ;
        //    }
        //    finally
        //    {
        //        //finish update
        //        this.m_engine.DbAdapter.Close();
        //        this.m_treeView.UseWaitCursor = false;
        //        this.m_treeView.EndUpdate();
        //    }

        //    return;
        //}

        ///// <summary>
        ///// NR-Показать ноды для указанного типа элементов
        ///// </summary>
        //internal void ShowTreeOld()
        //{

        //    //создание дерева сделано, не тестировано, а остальные фишки - не сделаны.
        //    //ВАЖНО: нода содержит объект элемента в поле Tag

        //    //начать обновление дерева 
        //    this.m_treeView.BeginUpdate();
        //    //set cursor
        //    Cursor.Current = Cursors.WaitCursor;
        //    //удалить все ноды из дерева
        //    this.m_treeView.Nodes.Clear();

        //    this.m_engine.DbAdapter.Open();
        //    //1 построить цепочку ид элементов от рута до начального элемента
        //    //передать ее в виде списка инт сверху вниз 
        //    List<int> idChain = this.m_engine.DbAdapter.GetChainOfElementIds(this.m_startElementId, true);
        //    //2 построить дерево нод сверху вниз по этой цепочке, раскрывая только ноды, указанные в цепочке.
        //    //- вставить RootId = 0 в начало цепочки
        //    idChain.Insert(0, TaskDbAdapter.ElementId_Root);
        //    //nodes collection for this loop
        //    TreeNodeCollection subnodes = this.m_treeView.Nodes;
        //    TreeNode nextNode = null;
        //    //loop
        //    foreach (int id in idChain)
        //    {
        //        //get child elements
        //        List<CElement> childs = this.m_engine.DbAdapter.SelectElementsByParentId(id);
        //        //foreach childs - add to subnodes as new node 
        //        foreach (CElement el in childs)
        //        {
        //            //filter by type and then by id chain
        //            //игнорировать элементы, помеченные удаленными.
        //            if (el.IsDeleted())
        //                continue;
        //            //игнорировать элементы любого типа, кроме категорий и указанного в m_AllowedElementType
        //            if (!this.IsAllowedElementType(el.ElementType))
        //                continue;
        //            //теперь элементы добавить в дерево как папки.
        //            //только папку со следующим ид в цепочке показать раскрытой, остальные - свернутыми с временной нодой внутри для возможности развернуть ее при необходимости.
        //            if (idChain.Contains(el.Id))
        //            {
        //                nextNode = MakeTreeNode(el, false);
        //                subnodes.Add(nextNode);
        //            }
        //            else
        //            {
        //                bool subnodesExists = (this.m_engine.DbAdapter.GetCountOfElementsByParentId(el.Id) > 0);
        //                subnodes.Add(MakeTreeNode(el, subnodesExists));
        //            }
        //            //end
        //        } //end child elements processing
        //        //nextNode теперь является следующей нодой, в которую добавляются субноды.
        //        if (nextNode != null)
        //        {
        //            subnodes = nextNode.Nodes;
        //            nextNode = null;
        //        }
        //        //else
        //        //{
        //        //    //Если последний элемент не содержит субэлементов, мы оказываемся здесь.
        //        //    //Если элемент цепочки не был найден, мы оказываемся здесь. Но этого не может быть - ведь мы уже собрали цепочку ранее, значит элемент существует..
        //        //    throw new Exception("Не найден элемент цепочки в дереве элементов.");
        //        //}
        //    }//end id chain processing

        //    this.m_engine.DbAdapter.Close();
        //    //закончить обновление дерева
        //    Cursor.Current = Cursors.Default;
        //    m_treeView.EndUpdate();

        //    //3 раскрыть конечную ноду, если надо?
        //    //Важно: В этом месте БД уже не используется и закрыта, поэтому ее могут открывать и закрывать обработчики событий дерева.  
        //    //this.m_treeView.SelectedNode = lastNode; - это не работает, так как в дереве уже нет этой ноды
        //    //надо раскрывать ноды по цепочке ид
        //    this.ExpandNodes(idChain);

        //    //TODO: остальное смотреть в Инвентарь.CTreeViewManager
        //    return;
        //}

        ///// <summary>
        ///// NT-Раскрыть узлы дерева по цепочке идентификаторов элементов. 
        ///// </summary>
        ///// <param name="idChain">The identifier chain.</param>
        //private void ExpandNodes(List<int> idChain)
        //{
        //    TreeNodeCollection subnodes = this.m_treeView.Nodes;
        //    foreach (int id in idChain)
        //    {
        //        //skip root id = 0;
        //        if (id == TaskDbAdapter.ElementId_Root)
        //            continue;
        //        foreach (TreeNode child in subnodes)
        //        {
        //            if (child == null)
        //                continue;
        //            CElement elem = (CElement)child.Tag;
        //            if (elem == null)
        //                continue;
        //            //expand node
        //            if (elem.Id == id)
        //            {
        //                child.Expand();
        //                subnodes = child.Nodes;
        //                break;
        //            }
        //        }
        //    }
        //    //TODO: тут последний элемент не выбирается в дереве.
        //    //а если бы он выбирался - генерировал бы событие NodeSelect.
        //    //А это событие сейчас неправильно обрабатывается, и вызывающему коду возвращается 0.
        //    return;
        //}

        ///// <summary>
        ///// NT-Alloweds the type of the element.
        ///// </summary>
        ///// <param name="elementType">Type of the element.</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// Тип отображаемого элемента: Определяет тип элемента, который можно выбрать для возврата. 
        ///// Категории отображаются независимо от этого значения, так как они соединяют всю структуру элементов разных типов.
        ///// </remarks> 
        //public bool IsAllowedElementType(EnumElementType elementType)
        //{
        //    //TODO: выяснить, где используется и можно ли удалить.
        //    return ((elementType == EnumElementType.Category) || ((this.m_AllowedElementTypes & elementType) > 0));
        //}




        #endregion


    }
}
