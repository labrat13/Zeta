using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Класс Задачи
    /// </summary>
    public class CTask : CElement
    {
        #region Fields
        /// <summary>
        /// Состояние задачи
        /// </summary>
        private EnumTaskState m_TaskState;
        /// <summary>
        /// Важность задачи
        /// </summary>
        private EnumTaskPriority m_TaskPriority;
        /// <summary>
        /// Перечень целей задачи отдельно от описания
        /// </summary>
        private String m_TaskResult;
        /// <summary>
        /// Дата завершения задачи для планировщика
        /// </summary>
        private DateTime m_TaskCompletionDate;
        #endregion        
        /// <summary>
        /// Initializes a new instance of the <see cref="CTask"/> class.
        /// </summary>
        public CTask()
        {
            this.m_TaskResult = String.Empty;
            this.m_TaskCompletionDate = DateTime.Now;
            this.m_TaskPriority = EnumTaskPriority.Normal;
            this.m_TaskState = EnumTaskState.Run;
            return;
        }

        #region Properties        
        /// <summary>
        /// Gets or sets the state of the task.
        /// </summary>
        /// <value>
        /// The state of the task.
        /// </value>
        public EnumTaskState TaskState { get => m_TaskState; set => m_TaskState = value; }
        /// <summary>
        /// Gets or sets the task priority.
        /// </summary>
        /// <value>
        /// The task priority.
        /// </value>
        public EnumTaskPriority TaskPriority { get => m_TaskPriority; set => m_TaskPriority = value; }
        /// <summary>
        /// Gets or sets the Task result.
        /// </summary>
        /// <value>
        /// The Task result.
        /// </value>
        public string TaskResult { get => m_TaskResult; set => m_TaskResult = value; }
        /// <summary>
        /// Gets or sets the task completion date.
        /// </summary>
        /// <value>
        /// The task completion date.
        /// </value>
        public DateTime TaskCompletionDate { get => m_TaskCompletionDate; set => m_TaskCompletionDate = value; }

        #endregion


    }
}