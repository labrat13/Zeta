using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Енум состояния задачи
    /// </summary>
    public enum EnumTaskState
    {
        /// <summary>
        /// Default value = 0
        /// </summary>
        Default = 0,
        /// <summary>
        /// Задача выполняется
        /// </summary>
        Run,
        /// <summary>
        /// Задача остановлена
        /// </summary>
        Paused,
        /// <summary>
        /// Задача выполнена
        /// </summary>
        Completed
    }
}