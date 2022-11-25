using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Енум приоритета задачи
    /// </summary>
    public enum EnumTaskPriority
    {
        /// <summary>
        /// Default value = 0
        /// </summary>
        Default = 0,
        /// <summary>
        /// Нормальный приоритет задачи.
        /// </summary>
        Normal,
        /// <summary>
        /// Важная задача, должна исполняться в первую очередь.
        /// </summary>
        High,
        /// <summary>
        /// Не важная задача, должна исполняться в последнюю очередь.
        /// </summary>
        Low
    }
}