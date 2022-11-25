using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    public class CElement
    {

        #region Fields
        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        private CElementId m_eid;
        /// <summary>
        /// Название элемента
        /// </summary>
        private String m_Title;
        /// <summary>
        /// Однострочное описание элемента
        /// </summary>
        private String m_Description;
        /// <summary>
        /// Многострочные заметки по элементу
        /// </summary>
        private String m_Remarks;
        /// <summary>
        /// Дата создания элемента
        /// </summary>
        private DateTime m_CreaTime;
        /// <summary>
        /// Дата изменения элемента
        /// </summary>
        private DateTime m_ModiTime;
        /// <summary>
        /// Код типа элемента
        /// </summary>
        private EnumElementType m_ElementType;
        /// <summary>
        /// Ссылка на родительский элемент в дереве элементов
        /// </summary>
        private CElement m_Parent;
        /// <summary>
        /// Список ссылок на объекты тегов
        /// </summary>
        private CTagCollection m_Tags;
        /// <summary>
        /// Список ссылок на дочерние элементы дерева элементов
        /// </summary>
        private CElementCollection m_Childs;
        /// <summary>
        /// Степень заполненности карточки элемента
        /// </summary>
        private EnumCardState m_CardState;
        /// <summary>
        /// Состояние активности элемента
        /// </summary>
        private EnumElementState m_ElementState;

        #endregion        
        /// <summary>
        /// Initializes a new instance of the <see cref="CElement"/> class.
        /// </summary>
        public CElement()
        {
            this.m_CardState = EnumCardState.Default;
            this.m_Childs = new CElementCollection();
            this.m_CreaTime = DateTime.Now;
            this.m_Description = String.Empty;
            this.m_eid = new CElementId(0);
            this.m_ElementState = EnumElementState.Default;
            this.m_ElementType = EnumElementType.Default;
            this.m_ModiTime = DateTime.Now;
            this.m_Parent = null;
            this.m_Remarks = String.Empty;
            this.m_Tags = new CTagCollection(); 
            this.m_Title = String.Empty;
            return;
        }


        #region Properties        
        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        public CElementId EID { get => m_eid; set => m_eid = value; }
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
        public CElement Parent { get => m_Parent; set => m_Parent = value; }
        /// <summary>
        /// Список ссылок на объекты тегов
        /// </summary>
        public CTagCollection Tags { get => m_Tags; set => m_Tags = value; }
        /// <summary>
        /// Список ссылок на дочерние элементы дерева элементов
        /// </summary>
        public CElementCollection Childs { get => m_Childs; set => m_Childs = value; }
        /// <summary>
        /// Степень заполненности карточки элемента
        /// </summary>
        public EnumCardState CardState { get => m_CardState; set => m_CardState = value; }
        /// <summary>
        /// Состояние активности элемента
        /// </summary>
        public EnumElementState ElementState { get => m_ElementState; set => m_ElementState = value; }

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



    }
}