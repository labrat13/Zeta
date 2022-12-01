using System;
using System.Collections.Generic;
using System.Text;

namespace TaskEngine.EngineSubsystem
{
    /// <summary>
    /// NT-Представляет коллекцию CElementRef ссылок на элементы. 
    /// </summary>
    public class CElementRefCollection
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        private Dictionary<Int32, CElementRef> m_dictionary;
        /// <summary>
        /// Initializes a new instance of the <see cref="CElementRefCollection"/> class.
        /// </summary>
        public CElementRefCollection()
        {
            this.m_dictionary = new Dictionary<Int32, CElementRef>();
        }
        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        public Dictionary<Int32,CElementRef> Dictionary
        {
            get { return this.m_dictionary;  }
        }

        public int Count
        {
            get { return this.m_dictionary.Count; }
        }
        /// <summary>
        /// NT-Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(CElementRef item)
        {
            int id = item.Id;
            this.m_dictionary.Add(id, item);

            return;
        }
        /// <summary>
        /// NT-Adds the specified element object or null.
        /// </summary>
        /// <param name="id">The element identifier.</param>
        /// <param name="obj">The element object or null.</param>
        public void Add(int id, CElement obj)
        {
            CElementRef item = new CElementRef(id);
            item.Element = obj;
            this.m_dictionary.Add(id, item);
        }
        /// <summary>
        /// NT-Determines whether this instance contains the object.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   Returns <c>true</c> if contains the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(CElementRef item)
        {
            int id = item.Id;
            return this.m_dictionary.ContainsKey(id);
        }
        /// <summary>
        /// NT-Determines whether this instance contains the object.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///  Returns <c>true</c> if contains the specified identifier; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(Int32 id)
        {
            return this.m_dictionary.ContainsKey(id);
        }
        /// <summary>
        /// NT-Clears this instance.
        /// </summary>
        public void Clear()
        {
            this.m_dictionary.Clear();

            return;
        }
        /// <summary>
        /// NT-Gets the list of identifier in this collection
        /// </summary>
        /// <returns>Returns list of identifier for this collection.</returns>
        public List<int> GetListOfId()
        {
            //можно было просто перечислить ключи словаря коллекции.
            List<int> result = new List<int>();
            foreach (CElementRef item in this.m_dictionary.Values)
                result.Add(item.Id);

            return result;
        }


    }
}
