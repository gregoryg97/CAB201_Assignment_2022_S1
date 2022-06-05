using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class defining the specific details of a customer for the purposes of booking
    /// </summary>
    internal class Customer : Person
    {
        /// <summary>
        /// Billing address
        /// </summary>
        private string address;
        /// <summary>
        /// Mobile contact number
        /// </summary>
        private string mobile;

        public Customer(Person person, string address, string mobile) : base(person) {
            this.address = address;
            this.mobile = mobile;
        }

        public Customer(string name, string emailAddress, string address, string mobile) : base(name, emailAddress)
        {
            this.address = address;
            this.mobile = mobile;
        }

        /// <returns>Returrn customer billing address</returns>
        public string getAddress()
        {
            return address;
        }

        /// <returns>Return customer primary contact number</returns>
        public string getMobile()
        {
            return mobile;
        }
    }
}
