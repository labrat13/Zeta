using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Менеджер уникальных идентификаторов элементов
    /// </summary>
    public class CElementIdManager
    {
        /// <summary>
        /// Текущий максимальный идентификатор элемента
        /// </summary>
        private int m_maxid;
        /// <summary>
        /// Initializes a new instance of the <see cref="CElementIdManager"/> class.
        /// </summary>
        /// <param name="maxid">The current max id.</param>
        public CElementIdManager(int maxid)
        {
            m_maxid = maxid;
        }
        /// <summary>
        /// NT-Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Current max ID = " + m_maxid.ToString();
        }
        /// <summary>
        /// NT-Получить новый уникальный идентификатор элемента
        /// </summary>
        /// <returns></returns>
        public Int32 GetNewId()
        {
            return m_maxid + 1;
        }
        /// <summary>
        /// NT-Подтвердить использование нового идентификатора
        /// </summary>
        /// <param name="newId">Новый уникальный идентификатор элемента</param>
        /// <returns></returns>
        public void ClaimUseNewId(Int32 newId)
        {
            if(this.m_maxid < newId)
                this.m_maxid = newId;
            else throw new Exception("Invalid new Id cannot be claimed: " + newId.ToString());  
        }

    }
}