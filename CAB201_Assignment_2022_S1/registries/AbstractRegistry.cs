using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Base Data Registry class which allows for the storage, retrival and modificaction of a generic type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class Registry<T>
    {
        protected List<T> _registryStore;
        
        /// <returns>Returns all objects in the Registry</returns>
        public List<T> getAll()
        {
            List<T> list = new List<T>();
            list.AddRange(_registryStore);
            return list;
        }

        /// <summary>
        /// Add value into registry returns false if object already exists
        /// </summary>
        /// <param name="value">Value to be added</param>
        /// <returns></returns>
        public virtual bool add(T value)
        {
            if (exists(value))
            {
                return false;
            }

            this._registryStore.Add(value);

            return true;
        }

        public abstract bool remove(T value);

        /// <summary>
        /// Comparison function to check object does not already exist in storage
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual bool exists(T value)
        {
            T searchResult = this._registryStore.Find(delegate (T emp)
            {
                return emp.Equals(value);
            });

            if (searchResult == null)
            {
                return false;
            }

            return true;
        }

    }
}