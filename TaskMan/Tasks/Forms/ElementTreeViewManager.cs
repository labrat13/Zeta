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
        /// <remarks>
        /// Тип отображаемого элемента: Определяет тип элемента, который можно выбрать для возврата. 
        /// Категории отображаются независимо от этого значения, так как они соединяют всю структуру элементов разных типов.
        /// </remarks>
        public ElementTreeViewManager(TreeView tw, CEngine engine, int startElementId, EnumElementType elementType)
        {
            this.m_treeView = tw;
            this.m_AllowedElementTypes = elementType;
            this.m_engine = engine;
            this.m_result = null;
            this.m_startElementId = startElementId;

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
        internal void ClearTree()
        {
            this.m_treeView.BeginUpdate();
            this.m_treeView.Nodes.Clear();
            this.m_treeView.EndUpdate();
            //выполнить прочие очистки здесь
            return;
        }

        /// <summary>
        /// NR-Показать ноды для указанного типа элементов
        /// </summary>
        internal void ShowTree()
        {

            //создание дерева сделано, не тестировано, а остальные фишки - не сделаны.
            //ВАЖНО: нода содержит объект элемента в поле Tag

            //начать обновление дерева 
            this.m_treeView.BeginUpdate();
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
                    foreach(CElement el in childs)
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
                if (nextNode == null)
                    throw new Exception("Не найден элемент цепочки в ереве элементов.");
                else
                {
                    subnodes = nextNode.Nodes;
                    nextNode = null;
                }
            }//end id chain processing

            this.m_engine.DbAdapter.Close();
            //закончить обновление дерева
            m_treeView.EndUpdate();
            //3 раскрыть конечную ноду, если надо?
            this.m_treeView.SelectedNode = nextNode;

            //TODO: остальное смотреть в Инвентарь.CTreeViewManager
            return;
        }



        /// <summary>
        /// NT-пользователь что-то выбрал в дереве, вот событие из дерева.
        /// </summary>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        internal CElement NodeSelected(TreeViewEventArgs e)
        {
            //надо передать в диалог объект данных выделенного элемента
            TreeNode node = e.Node;
            CElement obj = (CElement)node.Tag;
            //записать объект как результат
            this.m_result = obj;
            //вернуть объект элемента в диалог, чтобы он мог отобразить его описание
            return obj;
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

        /// <summary>
        /// NT-Проверить, допустим ли указанный элемент для выбора в качестве выбранного элемента..
        /// </summary>
        /// <param name="checkHierarchy">Проверять иерархию дерева во избежание кольцевания.</param>
        /// <param name="toCheck">Проверяемый элемент.</param>
        /// <returns>
        ///   <c>true</c> if [is allowed element] [the specified check hierarchy]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAllowedElement(bool checkHierarchy, CElement toCheck)
        {
            bool isAllowedElementType = ((this.m_AllowedElementTypes & toCheck.ElementType) > 0);
            bool isAllowedHierarchyChain = true;
            if(checkHierarchy == true)
                isAllowedHierarchyChain = this.checkHierarchyChain(this.m_startElementId, toCheck.Id);

            return isAllowedElementType && isAllowedHierarchyChain;
        }

        /// <summary>
        /// NT-Проверить цепочку иерархии элементов дерева на отсутствие колец.
        /// </summary>
        /// <param name="currentElementId">The current element identifier.</param>
        /// <param name="newParentElementId">The parent element identifier.</param>
        /// <returns>Функция возвращает true, если в дереве цепочка вложенности не образует кольцо, false в противном случае.</returns>
        private bool checkHierarchyChain(int currentElementId, int newParentElementId)
        {
            //быстро вернуть результат, если элемент ссылается на самого себя.
            if(currentElementId == newParentElementId)
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
                    if(ct.IsCompleted())
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

        /// <summary>
        /// NT-Selects the color of the node.
        /// </summary>
        /// <param name="obj">Элемент</param>
        /// <returns></returns>
        private static Color SelectNodeColor(CElement obj)
        {
            //deleted element color
             if (obj.IsDeleted())//if (objElementState == EnumElementState.Deleted)
                return ElementTreeViewManager.Color_InactiveElement;           
            
            //если это Задача, то цвет определяется ее важностью.
            if(obj.ElementType == EnumElementType.Task)
            {
                CTask ct = (CTask)obj;
                if (ct.TaskPriority == EnumTaskPriority.High)
                    return ElementTreeViewManager.Color_PriorityTask;
                else if (ct.TaskPriority >= EnumTaskPriority.Low)
                    return ElementTreeViewManager.Color_NotPriorityTask;;
            }

            return ElementTreeViewManager.Color_NormalElement;
        }
    }
}
