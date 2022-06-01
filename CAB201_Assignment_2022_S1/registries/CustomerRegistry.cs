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

        protected override bool exists(Customer value)
        {
            Customer searchResult = this._registryStore.Find(delegate (Customer emp)
            {
                return emp.getEmailAddress() == value.getEmailAddress();
            });

            if (searchResult == null)
            {
                return false;
            }

            return true;
        }

        public override bool remove(Customer value)
        {
            throw new NotImplementedException();
        }

    }
}
