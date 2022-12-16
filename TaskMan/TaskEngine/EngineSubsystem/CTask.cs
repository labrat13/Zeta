using System;
using System.Collections.Generic;
using System.Text;
using TaskEngine.Utilities;

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
        /// <summary>
        /// Дата начала задачи для планировщика
        /// </summary>
        private DateTime m_TaskStartDate;

        #endregion
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CTask"/> class.
        /// </summary>
        public CTask()
        {
            this.m_TaskResult = String.Empty;
            this.m_TaskCompletionDate = DateTime.Now;
            this.m_TaskStartDate = DateTime.Now;
            this.m_TaskPriority = EnumTaskPriority.Normal;
            this.m_TaskState = EnumTaskState.Run;
            return;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CTask"/> class.
        /// </summary>
        /// <param name="el">The CElement element.</param>
        public CTask(CElement el)
        {
            //если элемент не Task типа, то выбросить исключение
            if (el.ElementType != EnumElementType.Task)
                throw new ArgumentException(String.Format("Element {0} is not Task type!", el), "el");
            //копировать данные в новый объект класса
            this.m_eid = el.Id;            
            this.m_Title = el.Title;  
            this.m_Description = el.Description;            
            this.m_Remarks = el.Remarks;
            this.m_CreaTime = el.CreaTime;
            this.m_ModiTime = el.ModiTime;
            this.m_ElementType = el.ElementType;
            this.m_Parent = el.Parent;
            this.m_Tags = el.Tags;
            this.m_Childs = el.Childs;
            this.m_ElementState = el.ElementState;
            //this.m_isModified = false;
            //инициализировать значениями по умолчанию собственные поля класса
            this.m_TaskResult = String.Empty;
            this.m_TaskCompletionDate = DateTime.Now;
            this.m_TaskStartDate = DateTime.Now;
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
        /// <summary>
        /// Gets or sets the task start date.
        /// </summary>
        /// <value>
        /// The task start date.
        /// </value>
        public DateTime TaskStartDate { get => m_TaskStartDate; set => m_TaskStartDate = value; }

        #endregion

        /// <summary>
        /// NT-Получить степень заполненности карточки элемента.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override EnumCardState GetCardState()
        {
            //check CElement fields
            EnumCardState state = EnumCardState.Default;

            //обязательные поля:
            //this.m_TaskCompletionDate
            //this.m_TaskStartDate
            bool ok = true;
            if (String.IsNullOrEmpty(m_Title.Trim())) 
                ok = false;
            if (this.m_TaskStartDate <= this.CreaTime)
                ok = false;
            if (this.m_TaskCompletionDate <= this.CreaTime)
                ok = false;
            //set flag
            if (ok == true)
                state = EnumCardState.BaseValues;

            //дополнительные поля
            //this.m_TaskResult
            ok = true;
            if (String.IsNullOrEmpty(this.m_Description.Trim())) 
                ok = false;
            if (String.IsNullOrEmpty(this.m_Remarks.Trim())) 
                ok = false;
            if (String.IsNullOrEmpty(this.m_TaskResult.Trim()))
                ok = false;
            //set flag
            if (ok == true)
                state |= EnumCardState.SecondValues;

            //check complete 
            return state;
        }

        /// <summary>
        /// NT-Gets the element properties multiline text.
        /// </summary>
        /// <returns>Функция возвращает многострочный текст свойств элемента.</returns>  
        public override string GetPropertiesText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Описание: {0}", StringUtility.GetStringTextNull(this.m_Description)); sb.AppendLine();
            sb.AppendFormat("ID: {0}", this.m_eid); sb.AppendLine();
            sb.AppendFormat("Тип: {0}", this.m_ElementType); sb.AppendLine();
            sb.AppendFormat("Название: {0}", StringUtility.GetStringTextNull(this.m_Title)); sb.AppendLine();
            sb.Append("Активен: ");  sb.AppendLine(StringUtility.GetStringYesNo(this.m_ElementState == EnumElementState.Deleted));
            //task info
            sb.AppendFormat("Состояние задачи: {0}", this.m_TaskState); sb.AppendLine();
            sb.AppendFormat("Важность задачи: {0}", this.m_TaskPriority); sb.AppendLine();
            sb.AppendFormat("Результаты: {0}", StringUtility.GetStringTextNull(this.m_TaskResult)); sb.AppendLine();
            sb.AppendFormat("Дата начала задачи: {0}", StringUtility.StringFromDateTime(this.m_TaskStartDate)); sb.AppendLine();
            sb.AppendFormat("Дата завершения задачи: {0}", StringUtility.StringFromDateTime(this.m_TaskCompletionDate)); sb.AppendLine();
            //timestamps
            sb.AppendFormat("Дата создания: {0}", StringUtility.StringFromDateTime(this.m_CreaTime)); sb.AppendLine();
            sb.AppendFormat("Дата изменения: {0}", StringUtility.StringFromDateTime(this.m_ModiTime)); sb.AppendLine();

            return sb.ToString();
        }

    }
}