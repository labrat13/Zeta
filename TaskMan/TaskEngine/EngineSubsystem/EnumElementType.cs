using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Енум типа элемента
    /// </summary>
    public enum EnumElementType
    {
        /// <summary>
        /// Default value (0)
        /// </summary>
        Default = 0,
        /// <summary>
        /// Element is Category
        /// </summary>
        Category,
        /// <summary>
        /// Element is Tag
        /// </summary>
        Tag,
        /// <summary>
        /// Element is Task
        /// </summary>
        Task,
        /// <summary>
        /// Element is Note
        /// </summary>
        Note,
    }
}