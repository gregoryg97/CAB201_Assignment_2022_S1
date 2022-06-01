using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class Person
    {
        private string name;
        private string emailAddress;

        public Person(Person person)
        {
            this.name = person.name;
            this.emailAddress = person.emailAddress;
        }

        public Person(string name, string emailAddress)
        {
            this.name = name;
            this.emailAddress = emailAddress;
        }

        public string getName()
        {
            return name;
        }

        public string getEmailAddress()
        {
            return emailAddress;
        }
    };
}
