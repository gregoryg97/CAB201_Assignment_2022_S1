using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class which handles the storage and validation of Employee Data
    /// </summary>
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

        /// <summary>
        /// Returns current logged in employee as Person to ensure password security
        /// </summary>
        /// <returns>Person object. Null if no active employee</returns>
        public Person getActiveEmployee()
        {
            return activeEmployee;
        }

        /// <summary>
        /// Validates entry data against employee database. Returns true if authentication succeeds
        /// </summary>
        /// <param name="email">Input Employee Email Address</param>
        /// <param name="password">Input Employee Password</param>
        /// <returns>Bool - True if entry data matches database</returns>
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
