using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// NR-Движок менеджера задач.
    /// </summary>
    public class CEngine
    {
        /// <summary>
        /// Менеджер уникальных идентификаторов элементов.
        /// </summary>
        CElementIdManager m_idManager;
        /// <summary>
        /// Адаптер БД 
        /// </summary>
        TaskDbAdapter m_dbAdapter;

        public CEngine()
        {
            this.m_idManager = new CElementIdManager(0);
            
        }
        /// <summary>
        /// NR-Opens this Engine instance.
        /// </summary>
        public void Open()
        {
            //инициализировать адаптер БД

            //открыть БД

            //получить максимальный ид элемента из БД и инициализировать менеджер идентификаторов элементов. 
            int maxid = this.m_dbAdapter.GetElementsMaxId();
            this.m_idManager.ClaimUseNewId(maxid);


        }

        /// <summary>
        /// NR-Closes this engine instance.
        /// </summary>
        public void Close()
        {

        }

    }
}