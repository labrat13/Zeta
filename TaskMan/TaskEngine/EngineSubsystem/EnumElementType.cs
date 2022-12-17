using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Флаговый енум типа элемента.
    /// </summary>
    [Flags]
    public enum EnumElementType
    {
        /// <summary>
        /// Default value (0)
        /// </summary>
        Default = 0,
        /// <summary>
        /// Element is Category
        /// </summary>
        Category = 1,
        /// <summary>
        /// Element is Tag
        /// </summary>
        Tag = 2,
        /// <summary>
        /// Element is Task
        /// </summary>
        Task = 4,
        /// <summary>
        /// Element is Note
        /// </summary>
        Note = 8,
        /// <summary>
        /// All types of Element.
        /// </summary>
        AllTypes = Category | Tag | Task | Note,
    }
}