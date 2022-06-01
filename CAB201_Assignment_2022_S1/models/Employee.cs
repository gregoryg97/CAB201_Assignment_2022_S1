using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class Employee : Person
    {
        private string password;

        public Employee(Person person, string password) : base(person)
        {
            this.password = password;
        }
        public Employee(string name, string emailAddress, string password) : base(name, emailAddress)
        {
            this.password = password;
        }

        public string getPassword()
        {
            return password;
        }
    }
}
