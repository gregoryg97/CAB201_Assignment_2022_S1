using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class which defines the base identification details of a Person
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// Unique Name of Person
        /// </summary>
        private string name;

        /// <summary>
        /// Unique email address of Person
        /// </summary>
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

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (name == p.getName()) && (emailAddress == p.getEmailAddress());
            }
        }

        /// <returns>Return name of Person</returns>
        public string getName()
        {
            return name;
        }

        /// <returns>Return email address of person</returns>
        public string getEmailAddress()
        {
            return emailAddress;
        }
    }}
