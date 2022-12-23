using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TaskEngine;

namespace Tasks.Forms
{
    /// <summary>
    /// NT-Коллекция контекстных меню элементов для нод дерева
    /// </summary>
    /// <remarks>
    /// Этот класс создан, чтобы немного упростить менеджер дерева элементов.
    /// Оьбъекты контекстных меню создаются внутри конструктора формы и потом сюда передаются.
    /// И эта коллекция вся передается менеджеру дерева элементов как один аргумент и хранится внутри него.
    /// И используется, чтобы прицепить к каждой ноде дерева свое контекстное меню согласно типу элемента ноды.
    /// </remarks>
    public class NodeContextMenuCollection
    {

        #region *** Constants and fields ***

        /// <summary>
        /// Отдельное поле для итема корзины, поскольку его нет в EnumElementType.
        /// </summary>
        private ContextMenuStrip m_TrashcanItemContextMenu;

        /// <summary>
        /// Отдельное поле для ноды корзины, поскольку его нет в EnumElementType.
        /// </summary>
        private ContextMenuStrip m_TrashcanRootContextMenu;

        /// <summary>
        /// NT-Словарь содержимое коллекции
        /// </summary>
        private Dictionary<int, ContextMenuStrip> m_dict;

        #endregion

        public NodeContextMenuCollection()
        {
            this.m_dict = new Dictionary<int, ContextMenuStrip>();
        }

        #region *** Properties ***

        /// <summary>
        /// Отдельное поле для итема корзины, поскольку его нет в EnumElementType.
        /// </summary>
        public ContextMenuStrip TrashcanItemContextMenu { get => m_TrashcanItemContextMenu; set => m_TrashcanItemContextMenu = value; }

        /// <summary>
        /// Отдельное поле для ноды корзины, поскольку его нет в EnumElementType.
        /// </summary>
        public ContextMenuStrip TrashcanRootContextMenu { get => m_TrashcanRootContextMenu; set => m_TrashcanRootContextMenu = value; }

        #endregion

        /// <summary>
        /// NT-Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Коллекция содержит " + this.m_dict.Count + " элементов";
        }

        /// <summary>
        /// NT-Добавить элемент коллекции
        /// </summary>
        /// <param name="type">Тип элемента как ключ.</param>
        /// <param name="val">Элемент коллекции.</param>
        public void Add(EnumElementType type, ContextMenuStrip val)
        {
            int key = (int)type;
            this.m_dict.Add(key, val);

            return;
        }

        /// <summary>
        /// NT-Получить элемент коллекции.
        /// </summary>
        /// <param name="type">Тип элемента как ключ.</param>
        /// <returns>Функция возвращает элемент коллекции.</returns>
        public ContextMenuStrip Get(EnumElementType type)
        {
            int key = (int)type;
            return this.m_dict[key];
        }

    }
}
