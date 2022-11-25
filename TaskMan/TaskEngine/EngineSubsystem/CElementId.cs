using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine
{
    /// <summary>
    /// Идентификатор элемента
    /// </summary>
    public class CElementId
    {
        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        private int m_id;

        /// <summary>
        /// Initializes a new instance of the <see cref="CElementId"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public CElementId(int id)
        {
            m_id = id;
        }


        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        /// <value>
        /// Идентификатор элемента
        /// </value>
        public int Id { get => m_id; set => m_id = value; }

        /// <summary>
        /// NR-Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}