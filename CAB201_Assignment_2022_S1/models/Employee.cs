using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class to define the core details of a Employee outside of the Base person details required
    /// </summary>
    internal class Employee : Person
    {
        /// <summary>
        /// Password for the purposes of authenticated access to system
        /// </summary>
        private string password;

        public Employee(Person person, string password) : base(person)
        {
            this.password = password;
        }
        public Employee(string name, string emailAddress, string password) : base(name, emailAddress)
        {
            this.password = password;
        }

        /// <returns>Employee password</returns>
        public string getPassword()
        {
            return password;
        }
    }
}
