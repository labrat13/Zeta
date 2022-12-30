using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class MainFormManager
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

        /// <summary>
        /// NT-Показать всплывающее сообщение - предупреждение.
        /// </summary>
        /// <param name="title">Текст заголовка окна.</param>
        /// <param name="msg">Текст сообщения.</param>
        public void ShowMessageWarning(string title, string msg)
        {
            String t;
            //make title
            if (String.IsNullOrEmpty(title))
                t = MainForm.MainFormTitle + " - Предупреждение";
            else t = MainForm.MainFormTitle + " - " + title;
            //show message box
            MessageBox.Show(MainForm, msg, t, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// NT-Показать всплывающее сообщение об ошибке.
        /// </summary>
        /// <param name="title">Текст заголовка окна.</param>
        /// <param name="msg">Текст сообщения.</param>
        public void ShowMessageError(string title, string msg)
        {
            String t;
            //make title
            if (String.IsNullOrEmpty(title))
                t = MainForm.MainFormTitle + " - Ошибка";
            else t = MainForm.MainFormTitle + " - " + title;
            //show message box
            MessageBox.Show(MainForm, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// NT-Установить размер окна формы по настройкам приложения.
        /// </summary>
        /// <param name="f">Объект формы.</param>
        /// <param name="formSize">Новый размер формы.</param>
        public static void SetFormSize(Form f, Size formSize)
        {
            //limit min size
            if (formSize.Height < f.MinimumSize.Height)
                formSize.Height = f.MinimumSize.Height;
            if (formSize.Width < f.MinimumSize.Width)
                formSize.Width = f.MinimumSize.Width;
            //set form size
            f.Size = formSize;

            return;
        }

        /// <summary>
        /// NT-Установить позицию окна формы по настройкам приложения.
        /// </summary>
        /// <param name="f">Объект формы.</param>
        /// <param name="formpos">Новая позиция формы.</param>
        public static void SetFormPosition(Form f, Point formpos)
        {
            // проверить координаты окна, чтобы его не потерять за пределами дисплея 
            if (formpos.X > 1000) formpos.X = 1000;
            if (formpos.Y > 1000) formpos.Y = 1000;
            f.Location = formpos;

            return;
        }


        #endregion



        #region *** Функции событий дерева элементов левой панели. ***

        /// <summary>
        /// NR-Обработать событие выделения Корзины в левой панели главного окна
        /// </summary>
        /// <param name="node">The node.</param>
        public void LeftPanelAction_TrashcanRootSelect(TreeNode node)
        {
            this.LeftPanelAction_ShowTrashcanView();
            //TODO: add code here
            return;
        }

        /// <summary>
        /// NR-Обработать событие выделения элемента в левой панели главного окна
        /// </summary>
        /// <param name="elem">Элемент.</param>
        public void LeftPanelAction_ElementSelect(CElement elem)
        {
            this.ShowElementView(elem);
            //TODO: add code here
            return;
        }

        /// <summary>
        /// NR-Обработать событие двойного клика Корзины в левой панели главного окна
        /// </summary>
        public void LeftPanelAction_TrashcanRootDoubleClicked(TreeNode node)
        {
            this.LeftPanelAction_TrashcanShowProp();
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
            bool isChanged = this.LeftPanelAction_ShowElementProp();
            if (isChanged == true)
                this.UpdateViews();
            //TODO: add code here
            return;
        }



        #endregion

        #region *** Обработчики контекстного меню дерева ***        

        /// <summary>
        /// NT-Показать карточку выделенного в дереве элемента.
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_ShowElementProp()
        {
            //показать карточку выделенного в дереве элемента.
            CElement elem = this.m_TreeManager.Result;
            if (elem == null)
                return false;//Нет выделенного элемента

            return this.ShowElementProp(elem, false, true);
            //TODO: обновить дерево элементов в вызывающем коде или здесь.
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_CreateSubCategory()
        {
            //TODO: показать карточку создания новой категории, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
            return false;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_CreateSubNote()
        {
            //TODO: показать карточку создания новой заметки, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
            return false;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_CreateSubTask()
        {
            //TODO: показать карточку создания новой задачи, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
            return false;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_CreateSubTag()
        {
            //TODO: показать карточку создания нового тега, где выделенная в дереве категория является над-элементом.
            //Если элемент был создан, обновить дерево элементов.
            return false;
        }

        /// <summary>
        /// NT-пометить текущий выделенный элемент неактивным и обновить дерево
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_MoveToTrashcan()
        {            
            //Получить выделенный элемент
            CElement elem = this.m_TreeManager.Result;
            if (elem == null)
                return false;//Нет выделенного элемента
            //Пометить элемент неактивным, если он активен
            //- если элемент защищен от удаления, выдать предупреждение.
            if (elem.ElementState == EnumElementState.ProtectedFromDelete)
            {
                this.ShowMessageWarning(null, "Элемент защищен от удаления!");
                return false;
            }
            //- если элемент уже неактивен, выдать предупреждение.
            if (elem.ElementState != EnumElementState.Normal)
            {
                this.ShowMessageWarning(null, "Неправильное состояние элемента или элемент уже помечен неактивным!");
                return false;
            }
            //- если элемент имеет активный суб-элемент, выдать предупреждение
            if (this.m_Engine.DbAdapter.IsElementHasActiveChild(elem.Id))
            {
                this.ShowMessageWarning(null, "Элемент не может быть удален, поскольку содержит активные подчиненные элементы!\nСначала удалите все подчиненные элементы.");
                return false;
            }
            //- пометить элемент удаленным.
            elem.SetDeleted(true);
            //записать изменения в БД
            this.Engine.DbAdapter.UpdateElementWithTransaction(elem);
            //Обновить дерево элементов в вызывающем коде
            return true;
        }

        /// <summary>
        /// NT-Отметить выделенный элемент - задачу выполненной. Если это Задача.
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_MarkTaskComplete()
        {
            //TODO: 
            //Получить выделенный элемент
            CElement elem = this.m_TreeManager.Result;
            if (elem == null)
                return false;//Нет выделенного элемента
            //проверить что это Задача
            if (elem.ElementType != EnumElementType.Task)
            {
                this.ShowMessageError(null, "Указанный элемент не является Задачей!");
                return false;
            }
            //Пометить Задачу выполненной
            CTask task = (CTask)elem;
            task.SetCompleted(true);
            //записать изменения в БД
            this.Engine.DbAdapter.UpdateElementWithTransaction(elem);
            //Обновить дерево элементов в вызывающем коде
            return true;
        }

        /// <summary>
        /// NT-Отметить выделенный элемент - задачу приостановленной. Если это Задача.
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_MarkTaskPaused()
        {
            //TODO: добавить пункт приостановки в контекстное меню задачи позже.
            //Получить выделенный элемент
            CElement elem = this.m_TreeManager.Result;
            if (elem == null)
                return false;//Нет выделенного элемента
            //проверить что это Задача
            if (elem.ElementType != EnumElementType.Task)
            {
                this.ShowMessageError(null, "Указанный элемент не является Задачей!");
                return false;
            }
            //Пометить Задачу выполненной
            CTask task = (CTask)elem;
            task.SetPaused(true);
            //записать изменения в БД
            this.Engine.DbAdapter.UpdateElementWithTransaction(elem);
            //Обновить дерево элементов в вызывающем коде
            return true;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_TrashcanShowProp()
        {
            //TODO: показать Диалог настроек Корзины
            DialogResult dr = TrashcanPropForm.ShowTrashcanPropForm(this.m_MainForm);
            return false;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_TrashcanDeleteAll()
        {
            //TODO: запросить подтверждение операции и очистить Корзину
            return false;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_TrashcanRestoreAll()
        {
            //TODO: запросить подтверждение операции и восстановить все удаленные элементы
            return false;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_TrashcanElementRestore()
        {
            //TODO: Запросить подтверждение операции и восстановить выделенный в дереве элемент 
            return false;
        }

        /// <summary>
        /// NR-
        /// </summary>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        public bool LeftPanelAction_TrashcanElementDelete()
        {
            //TODO: Запросить подтверждение операции и удалить из БД выделенный в дереве элемент 
            //проверить, что элемент был помечен удаленным.
            return false;
        }

        #endregion

        //TODO: добавить функции специально для создания новых элементов.

        #region *** ShowElementProp() субфункции ***

        /// <summary>
        /// NT-Показать карточку выделенного в дереве элемента.
        /// </summary>
        /// <param name="elementId">Идентификатор элемента.</param>
        /// <param name="readOnly">Открыть элемент в КарточкаЭлемента без возможности изменения.</param>
        /// <param name="saveChanges">Сохранить изменения элемента в БД, если элемент был изменен в КарточкаЭлемента.</param>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обновить представления данных, <c>false</c> в противном случае.</returns>
        public bool ShowElementProp(Int32 elementId, bool readOnly, bool saveChanges)
        {
            CElement elem = this.m_Engine.DbAdapter.SelectElementWithoutTransaction(elementId); 

            return this.ShowElementProp(elem, readOnly, saveChanges);
        }

        /// <summary>
        /// NT-Показать карточку выделенного в дереве элемента.
        /// </summary>
        /// <param name="elem">Объект элемента.</param>
        /// <param name="readOnly">Открыть элемент в КарточкаЭлемента без возможности изменения.</param>
        /// <param name="saveChanges">Сохранить изменения элемента в БД, если элемент был изменен в КарточкаЭлемента.</param>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обновить представления данных, <c>false</c> в противном случае.</returns>
        public bool ShowElementProp(CElement elem, bool readOnly, bool saveChanges)
        {
            if (elem == null)
            {
                this.ShowMessageWarning("Ошибка", "Элемент не может быть null!");
                return false;//Нет выделенного элемента
            }
            //switch
            bool changed = false;
            EnumElementType ett = elem.ElementType;
            switch (ett)
            {
                case EnumElementType.Category:
                    changed = this.ShowCategoryProp(elem, readOnly);
                    break;
                case EnumElementType.Tag:
                    changed = this.ShowTagProp(elem, readOnly);
                    break;
                case EnumElementType.Task:
                    changed = this.ShowTaskProp((CTask)elem, readOnly);
                    break;
                case EnumElementType.Note:
                    changed = this.ShowNoteProp(elem, readOnly);
                    break;
                default:
                case EnumElementType.Default:
                    throw new Exception(String.Format("Неподдерживаемый тип элемента {0}: {1}", elem.GetStringElementIdentifier(false), ett));
                    //break;
            }
            //store element if changed
            if((readOnly == false) && (changed == true) && (saveChanges == true))
                this.m_Engine.DbAdapter.UpdateElementWithTransaction(elem);
            //Если данные элемента были изменены, обновить дерево элементов - в вызывающем коде.
            return changed;
        }


        /// <summary>
        /// NR-Показать карточку элемента.
        /// </summary>
        /// <param name="category">Отображаемый и существующий в БД элемент типа Категория.</param>
        /// <param name="readOnly">Открыть элемент в КарточкаЭлемента без возможности изменения.</param>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        private bool ShowCategoryProp(CElement category, bool readOnly)
        {
            //TODO: показать карточку выделенного в дереве элемента.
            bool changed = CategoryPropForm.ShowCategoryPropForm(this.m_MainForm, "Свойства Категории", readOnly,  category, this.Engine, this, false);
            //В вызывающем коде: Если данные элемента были изменены, Записать их в Бд и обновить дерево элементов.

            return changed;
        }

        /// <summary>
        /// NR-Показать карточку элемента.
        /// </summary>
        /// <param name="note">Отображаемый и существующий в БД элемент типа Заметка.</param>
        /// <param name="readOnly">Открыть элемент в КарточкаЭлемента без возможности изменения.</param>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        private bool ShowNoteProp(CElement note, bool readOnly)
        {
            //TODO: показать карточку выделенного в дереве элемента
            bool changed = NotePropForm.ShowNotePropForm(this.m_MainForm);
            return false;
        }

        /// <summary>
        /// NR-Показать карточку элемента.
        /// </summary>
        /// <param name="task">Отображаемый и существующий в БД элемент типа Задача.</param>
        /// <param name="readOnly">Открыть элемент в КарточкаЭлемента без возможности изменения.</param>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        private bool ShowTaskProp(CTask task, bool readOnly)
        {
            //TODO: показать карточку выделенного в дереве элемента
            bool changed = TaskPropForm.ShowTaskPropForm(this.m_MainForm);
            return false;
        }

        /// <summary>
        /// NR-Показать карточку элемента.
        /// </summary>
        /// <param name="tag">Отображаемый и существующий в БД элемент типа Тег.</param>
        /// <param name="readOnly">Открыть элемент в КарточкаЭлемента без возможности изменения.</param>
        /// <returns>Функция возвращает <c>true</c>, если изменения были произведены, и нужно обоновить представления данных, <c>false</c> в противном случае.</returns>
        private bool ShowTagProp(CElement tag, bool readOnly)
        {
            //TODO: показать карточку выделенного в дереве элемента
            bool changed = TagPropForm.ShowTagPropForm(this.m_MainForm);
            return false;
        }

        #endregion

#region *** Sub functions for left panel ***

        /// <summary>
        /// NR-Lefts the panel action show trashcan view.
        /// </summary>
        private void LeftPanelAction_ShowTrashcanView()
        {
            //throw new NotImplementedException();//TODO: add code here
        }

        /// <summary>
        /// NR-Shows the element view.
        /// </summary>
        /// <param name="elem">The elem.</param>
        private void ShowElementView(CElement elem)
        {
            //throw new NotImplementedException();//TODO: add code here
        }

        /// <summary>
        /// NR-Updates the views.
        /// </summary>
        public void UpdateViews()
        {
            //update all views in application because changes of database data/
            
        }
        /// <summary>
        /// NR-Обновить дерево элементов.
        /// </summary>
        public void UpdateLeftPanel()
        {
            //throw new NotImplementedException();//TODO: add code here
        }

#endregion

    }
}
