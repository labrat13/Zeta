using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Состояние активности элемента (активен или удален)
    /// </summary>
    public enum EnumElementState
    {
        /// <summary>
        /// Default value = 0
        /// </summary>
        Default = 0,
        /// <summary>
        /// Element is normal state
        /// </summary>
        Normal,
        /// <summary>
        /// Element is Deleted
        /// </summary>
        Deleted
    }
}