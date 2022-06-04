using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    abstract class Registry<T>
    {
        protected List<T> _registryStore;
        
        public List<T> getAll()
        {
            List<T> list = new List<T>();
            list.AddRange(_registryStore);
            return list;
        }

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
        protected abstract bool exists(T value);

    }
}