using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class CustomerRegistry : Registry<Customer>
    {
        public CustomerRegistry()
        {
            this._registryStore = new List<Customer>();
        }

        public override bool remove(Customer value)
        {
            throw new NotImplementedException();
        }

    }
}
