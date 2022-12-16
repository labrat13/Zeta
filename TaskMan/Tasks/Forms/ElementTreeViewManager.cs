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
    /// /// </remarks>
    internal class ElementTreeViewManager
    {

        #region *** Constants and Fields ***

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
        /// Цвет надписи обычных элементов
        /// </summary>
        public static Color NormalColor = Color.Black;

        /// <summary>
        /// Цвет надписи неактивных элементов
        /// </summary>
        public static Color InactiveColor = Color.Gray;

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
            throw new NotImplementedException();//TODO: add code here

            //создание дерева сделано, не тестировано, а остальные фишки - не сделаны.
            //ВАЖНО: нода содержит объект элемента в поле Tag

            //удалить все ноды из дерева
            ClearTree();

            //начать обновление дерева 
            this.m_treeView.BeginUpdate();

            ////тут загрузить из БД всю кучу элементов и построить из них дерево, сначала в памяти, а потом в трееконтрол поместить.
            ////дерево строить в памяти - через поля реф в объектах связей-ссылок.
            ////- не получается - у элемента нет ссылок на подэлементы, только на родителя.
            ////1 загрузить все элементы требуемого типа из БД в список
            //List<UAMX_Element> elements;
            //if (this.m_showedType == ЕнумТипЭлемента.Категория)
            //    elements = this.m_adapter.getAllCategories();
            //else if (this.m_showedType == ЕнумТипЭлемента.КлассЗадачи)
            //    elements = this.m_adapter.getAllClassTasks();
            //else throw new Exception("Неизвестный тип элемента: " + this.m_showedType);

            ////2 создать ноды для каждого элемента и поместить их в словарь <UID, node>
            //Dictionary<Int32, TreeNode> dic = new Dictionary<Int32, TreeNode>();
            //foreach (UAMX_Element el in elements)
            //    dic.Add(el.Id.Id, makeTreeNode(el));

            ////3 создать связи между нодами перебором всех нод в словаре
            //foreach (TreeNode tns in dic.Values)
            //{
            //    if (tns.Tag == null)
            //        continue;
            //    //получить ид родительского элемента (и ноды)
            //    UAMX_Element ut = (UAMX_Element)tns.Tag;
            //    Int32 idd = ut.CategoryLink.ID.Id;
            //    //если ид родительской ноды = 0, значит текущая нода - в корне дерева.
            //    //и тут пока я ничего не  придумал
            //    if (idd == 0)
            //    {
            //        //добавить текущую ноду в треевиев
            //        this.m_treeView.Nodes.Add(tns);
            //    }
            //    else
            //    {
            //        //найти элемент по ид в словаре и его ноду прицепить к текущей
            //        if (dic.ContainsKey(idd))
            //        {
            //            TreeNode tdd = dic[idd];
            //            tdd.Nodes.Add(tns);//TODO: check no dublicates here
            //        }
            //        else
            //        {
            //            //указанного в Parent ссылке элемента нет в БД.
            //            //что тут делать?
            //            //пока просто добавим эту потерянную ноду в корень дерева
            //            //так же, как и с ид=0
            //            //TODO: а можно объединить в один код эти два случая - потом, после отладки.
            //            //добавить текущую ноду в треевиев
            //            this.m_treeView.Nodes.Add(tns);
            //        }
            //    }
            //}

            //===============================================
            //Новое решение, под этот проект:
            this.m_engine.DbAdapter.Open();
            //1 построить цепочку ид элементов от рута до начального элемента
            //передать ее в виде списка инт сверху вниз 
            List<int> idChain = this.m_engine.DbAdapter.GetChainOfElementIds(this.m_startElementId, true);
            //2 построить дерево нод сверху вниз по этой цепочке, раскрывая только ноды, указанные в цепочке.
            //3 раскрыть конечную ноду, если надо?
            //TODO: add code here



            this.m_engine.DbAdapter.Close();
            //закончить обновление дерева
            m_treeView.EndUpdate();

            ////4 список очистить
            //elements.Clear();

            //TODO: остальное смотреть в Инвентарь.CTreeViewManager

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
            return (this.m_AllowedElementTypes == elementType); 
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
            bool isAllowedElementType = (this.m_AllowedElementTypes == toCheck.ElementType);
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
        /// NT-Создать ноду по данным объекта, но без субнод.
        /// </summary>
        /// <param name="obj">Элемент</param>
        /// <returns></returns>
        private TreeNode makeTreeNode(CElement obj)
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
            tn.ForeColor = SelectNodeColor(obj);
            //ВАЖНО: нода содержит объект элемента в поле Tag
            tn.Tag = obj;
            //добавить дочерние элементы, если они есть.
            //здесь нельзя - нет ссылок на них в obj.
            //есть только родительский элемент, и он не поможет здесь.
            return tn;
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
                    result = 0;
                    break;
                case EnumElementType.Tag:
                    result = 1;
                    break;
                case EnumElementType.Task:
                    result = 2;
                    break;
                case EnumElementType.Note:
                    result = 3;
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
            //TODO: добавить еще цвета для показа важности задач прямов дереве - это надо вынести в отдельную функцию тогда.
            Color c = ElementTreeViewManager.NormalColor;
            if (obj.IsDeleted())//if (objElementState == EnumElementState.Deleted)
                c = ElementTreeViewManager.InactiveColor;

            return c;
        }
    }
}
