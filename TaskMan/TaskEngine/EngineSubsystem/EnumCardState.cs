using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Енум состояния карточки - все ли поля заполнены
    /// </summary>
    [Flags]
    public enum EnumCardState
    {
        /// <summary>
        /// Default value = 0
        /// </summary>
        Default = 0,
        /// <summary>
        /// Основные поля заполнены
        /// </summary>
        BaseValues = 1,
        /// <summary>
        /// Дополнительные поля заполнены
        /// </summary>
        SecondValues = 2,
        /// <summary>
        /// Все поля заполнены
        /// </summary>
        AllValues = BaseValues | SecondValues,  
    }
}