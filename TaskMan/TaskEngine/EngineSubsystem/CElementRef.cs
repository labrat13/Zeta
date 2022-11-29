using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    public class CElementRef
    {
        private CElement m_element;
        private Int32 m_Id;

        public CElementRef(int id)
        {
            m_Id = id;
        }
        /// <summary>
        /// Gets or sets the element reference.
        /// </summary>
        /// <value>
        /// The element.
        /// </value>
        public CElement Element { get => m_element; set => m_element = value; }
        /// <summary>
        /// Gets or sets the element identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get => m_Id; set => m_Id = value; }
    }
}
