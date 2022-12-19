using System;
using System.Collections.Generic;
using System.Text;
using TaskEngine.EngineSubsystem;
using TaskEngine.Utilities;

namespace TaskEngine
{
    public class CElement
    {

        #region Fields
        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        protected Int32 m_eid;
        /// <summary>
        /// Название элемента
        /// </summary>
        protected String m_Title;
        /// <summary>
        /// Однострочное описание элемента
        /// </summary>
        protected String m_Description;
        /// <summary>
        /// Многострочные заметки по элементу
        /// </summary>
        protected String m_Remarks;
        /// <summary>
        /// Дата создания элемента
        /// </summary>
        protected DateTime m_CreaTime;
        /// <summary>
        /// Дата изменения элемента
        /// </summary>
        protected DateTime m_ModiTime;
        /// <summary>
        /// Код типа элемента
        /// </summary>
        protected EnumElementType m_ElementType;
        /// <summary>
        /// Ссылка на родительский элемент в дереве элементов
        /// </summary>
        protected CElementRef m_Parent;
        /// <summary>
        /// Список ссылок на объекты тегов
        /// </summary>
        protected CElementRefCollection m_Tags;
        /// <summary>
        /// Список ссылок на дочерние элементы дерева элементов
        /// </summary>
        protected CElementRefCollection m_Childs;
        /// <summary>
        /// Состояние активности элемента
        /// </summary>
        protected EnumElementState m_ElementState;
        ///// <summary>
        ///// Данные элемента были изменены
        ///// </summary>
        //private Boolean m_isModified;

        #endregion        
        /// <summary>
        /// Initializes a new instance of the <see cref="CElement"/> class.
        /// </summary>
        public CElement()
        {
            this.m_Childs = new CElementRefCollection();
            this.m_CreaTime = DateTime.Now;
            this.m_Description = String.Empty;
            this.m_eid = 0;
            this.m_ElementState = EnumElementState.Default;
            this.m_ElementType = EnumElementType.Default;
            this.m_ModiTime = DateTime.Now;
            this.m_Parent = new CElementRef(0);
            this.m_Remarks = String.Empty;
            this.m_Tags = new CElementRefCollection();
            this.m_Title = String.Empty;
            //this.m_isModified = false;

            return;
        }


        #region Properties        
        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        public Int32 Id { get => m_eid; set => m_eid = value; }
        /// <summary>
        /// Название элемента
        /// </summary>
        public string Title { get => m_Title; set => m_Title = value; }
        /// <summary>
        /// Однострочное описание элемента
        /// </summary>
        public string Description { get => m_Description; set => m_Description = value; }
        /// <summary>
        /// Многострочные заметки по элементу
        /// </summary>
        public string Remarks { get => m_Remarks; set => m_Remarks = value; }
        /// <summary>
        /// Дата создания элемента
        /// </summary>
        public DateTime CreaTime { get => m_CreaTime; set => m_CreaTime = value; }
        /// <summary>
        /// Дата изменения элемента
        /// </summary>
        public DateTime ModiTime { get => m_ModiTime; set => m_ModiTime = value; }
        /// <summary>
        /// Код типа элемента
        /// </summary>
        public EnumElementType ElementType { get => m_ElementType; set => m_ElementType = value; }
        /// <summary>
        /// Ссылка на родительский элемент в дереве элементов
        /// </summary>
        public CElementRef Parent { get => m_Parent; set => m_Parent = value; }
        /// <summary>
        /// Список ссылок на объекты тегов
        /// </summary>
        public CElementRefCollection Tags { get => m_Tags; set => m_Tags = value; }
        /// <summary>
        /// Список ссылок на дочерние элементы дерева элементов
        /// </summary>
        public CElementRefCollection Childs { get => m_Childs; set => m_Childs = value; }
        /// <summary>
        /// Состояние активности элемента
        /// </summary>
        public EnumElementState ElementState { get => m_ElementState; set => m_ElementState = value; }
        ///// <summary>
        ///// Gets a value indicating whether this instance is modified.
        ///// </summary>
        ///// <value>
        /////   <c>true</c> if this instance is modified; otherwise, <c>false</c>.
        ///// </value>
        //public Boolean IsModified
        //{
        //    get { return this.IsModified || this.m_Childs.IsModified || this.m_Tags.IsModified; }
        //}

        #endregion

        /// <summary>
        /// NT-Возвращает true если элемент помечен как неактивный.
        /// </summary>
        /// <returns>
        ///   <c>true</c> если элемент помечен как неактивный; в противном случае, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Эта функция упрощает проверки состояния активности элемента в некоторых функциях.
        /// </remarks>
        public bool IsDeleted()
        {
            return this.m_ElementState == EnumElementState.Deleted;
        }

        /// <summary>
        /// NT-Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return GetStringElementIdentifier(true);
        }
        /// <summary>
        /// Gets the string element identifier.
        /// </summary>
        /// <param name="v">Include element title</param>
        /// <returns>Return string like "TASK001:Task_title"</returns>
        public string GetStringElementIdentifier(bool withTitle)
        {
            String abbrev = null;
            switch (this.m_ElementType)
            {
                case EnumElementType.Note:
                    abbrev = "RULE";
                    break;
                case EnumElementType.Task:
                    abbrev = "TASK";
                    break;
                case EnumElementType.Category:
                    abbrev = "CAT";
                    break;
                case EnumElementType.Tag:
                    abbrev = "TAG";
                    break;
                default:
                    abbrev = "UNK";
                    break;
            }
            //create id digits
            String digits = this.m_eid.ToString("D3");
            //if title included
            String title = String.Empty;
            if (withTitle == true)
                title = StringUtility.MakeSafeTitle(this.m_Title);
            //create result string
            return abbrev + digits + ":" + title;
        }

        /// <summary>
        /// NT-Получить степень заполненности карточки элемента.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual EnumCardState GetCardState()
        {
            //автоматически заполняемые поля
            //this.m_eid
            //this.m_ElementType
            //this.m_Parent 
            //this.m_Childs 
            //this.m_CreaTime
            //this.m_ModiTime 
            //this.m_Tags  

            EnumCardState state = EnumCardState.Default;

            //обязательные поля:
            //this.m_Title 
            if (!String.IsNullOrEmpty(m_Title.Trim())) state = EnumCardState.BaseValues;

            //дополнительные поля
            //this.m_Description
            //this.m_ElementState
            //this.m_Remarks 
            bool ok = true;
            if (String.IsNullOrEmpty(this.m_Description.Trim())) ok = false;
            if (this.m_ElementState == EnumElementState.Default) ok = false;
            if (String.IsNullOrEmpty(this.m_Remarks.Trim())) ok = false;

            if (ok == true)
                state |= EnumCardState.SecondValues;

            //check complete 
            return state;
        }

        /// <summary>
        /// NR-Создать локальную ссылку на текущий элемент
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public String GetElementLink()
        {
            throw new NotImplementedException();//TODO: implement here
        }

        /// <summary>
        /// NT-Получить название элемента, пригодное для использования в качестве названия файла
        /// </summary>
        /// <returns></returns>
        public string GetSafeTitle()
        {
            return StringUtility.MakeSafeTitle(this.m_Title);
        }

        ///// <summary>
        ///// Clears the modified flag.
        ///// </summary>
        //public void ClearModifiedFlag()
        //{
        //    this.m_isModified = false;
        //    this.m_Childs.IsModified = false;
        //    this.m_Tags.IsModified = false;

        //    return;
        //}

        /// <summary>
        /// NT-Gets the element properties multiline text.
        /// </summary>
        /// <returns>Функция возвращает многострочный текст свойств элемента.</returns>  
        public virtual string GetPropertiesText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Описание: {0}", StringUtility.GetStringTextNull(this.m_Description)); sb.AppendLine();
            sb.AppendFormat("ID: {0}", this.GetStringElementIdentifier(false)); sb.AppendLine();
            sb.AppendFormat("Тип: {0}", this.m_ElementType); sb.AppendLine();
            sb.AppendFormat("Название: {0}", StringUtility.GetStringTextNull(this.m_Title)); sb.AppendLine();
            sb.Append("Активен: "); sb.AppendLine(StringUtility.GetStringYesNo(this.m_ElementState != EnumElementState.Deleted));
            //timestamps
            sb.AppendFormat("Дата создания: {0}", StringUtility.StringFromDateTime(this.m_CreaTime)); sb.AppendLine();
            sb.AppendFormat("Дата изменения: {0}", StringUtility.StringFromDateTime(this.m_ModiTime)); sb.AppendLine();

            return sb.ToString();
        }



        #region *** Filter and sort elements for treenode ***

        //TODO: Объединить этов одну функцию как второй вариант.
        
        /// <summary>
        /// NT-Отобрать нужные элементы: не удаленные и разрешенного типа.
        /// </summary>
        /// <param name="elements">Список элементов.</param>
        /// <param name="allowedTypes">Разрешенные типы элементов.</param>
        /// <returns>Функция возвращает новый список, содержащий отобранные элементы.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static List<CElement> FilterElements(List<CElement> elements, EnumElementType allowedTypes)
        {
            //удалить из списка удаленные элементы, чтобы меньше сортировать было. 
            //удалить из списка не разрешенные фильтром элементы, кроме категорий. 
            // Чтобы отображались только категории и разрешенные типы элементов (теги, заметки, задачи)

            List<CElement> result = new List<CElement>();
            foreach (CElement el in elements)
            {
                //skip if  state = Deleted
                if (el.m_ElementState == EnumElementState.Deleted)
                    continue;
                //skip if filter by any of allowed types
                if ((el.m_ElementType & allowedTypes) == 0)
                    continue;
                //add to result list
                result.Add(el);
            }

            return result;
        }

        /// <summary>
        /// NT-Comparison: Sorts the elements by title.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public static int SortElementsByTitle(CElement x, CElement y)
        {

            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                    return 1;
                else
                {
                    //compare by title length
                    String xTitle = x.m_Title;
                    String yTitle = y.m_Title;
                    int retval = xTitle.Length.CompareTo(yTitle.Length);

                    if (retval != 0)
                        // If the strings are not of equal length, the longer string is greater.
                        return retval;
                    else
                    {
                        // If the strings are of equal length, sort them with ordinary string comparison.
                        return xTitle.CompareTo(yTitle);
                    }
                }
            }
        }

        /// <summary>
        /// NT-Sorts the elements by type and title.
        /// </summary>
        /// <param name="elemlist">Список элементов.</param>
        /// <returns></returns>
        public static List<CElement> SortElementsByTypeAndTitle(List<CElement> elemlist, EnumElementType allowedTypes)
        {
            //сортировать по типу и алфавиту
            //элементы должны быть группированы по типам: сверху Категории, потом Заметки, снизу Задачи.
            //внутри типа элементы должны быть сортированы по алфавиту.
            List<CElement> result = new List<CElement>();
            List<CElement> categories = new List<CElement>();
            List<CElement> notes = new List<CElement>();
            List<CElement> tasks = new List<CElement>();
            List<CElement> tags = new List<CElement>();

            //рассортируем по типам
            foreach (CElement elem in elemlist)
            {
                //разложить по спискам согласно типу элемента
                switch (elem.m_ElementType)
                {
                    case EnumElementType.Category:
                        categories.Add(elem);
                        break;
                    case EnumElementType.Note:
                        notes.Add(elem);
                        break;
                    case EnumElementType.Task:
                        tasks.Add(elem);
                        break;
                    case EnumElementType.Tag:
                        tags.Add(elem);
                        break;
                    default:
                        break;
                }
            }
            //теперь сортировать списки и добавить в выходной список элементы в правильном порядке
            if ((allowedTypes & EnumElementType.Category) > 0)
            {
                categories.Sort(SortElementsByTitle);
                result.AddRange(categories);
            }
            if ((allowedTypes & EnumElementType.Note) > 0)
            {
                notes.Sort(SortElementsByTitle);
                result.AddRange(notes);
            }
            if ((allowedTypes & EnumElementType.Task) > 0)
            {
                tasks.Sort(SortElementsByTitle);
                result.AddRange(tasks);
            }
            if ((allowedTypes & EnumElementType.Tag) > 0)
            {
                tags.Sort(SortElementsByTitle);
                result.AddRange(tags);
            }

            categories.Clear();
            notes.Clear();
            tasks.Clear();
            tags.Clear();

            return result;
        }

        #endregion

    }
}