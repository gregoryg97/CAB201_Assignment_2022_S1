using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class EmployeeRegistry : Registry<Employee>
    {
        private Employee activeEmployee;

        public EmployeeRegistry()
        {
            this._registryStore = new List<Employee>();
        }

        public override bool remove(Employee value)
        {
            throw new NotImplementedException();
        }

        public Person getActiveEmployee()
        {
            return activeEmployee;
        }

        public bool authenticate(string email, string password)
        {
            if (email == null || password == null)
            {
                return false;
            }

            Employee searchResult = this._registryStore.Find(delegate (Employee emp)
            {
                return emp.getEmailAddress() == email;
            });

            if (searchResult != null)
            {
                if (searchResult.getPassword()  == password)
                {
                    activeEmployee = searchResult;
                    return true;
                }
            }

            return false;
        }
    }
}
