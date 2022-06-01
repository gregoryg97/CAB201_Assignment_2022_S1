using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    internal class Customer : Person
    {
        private string address;
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

        public string getAddress()
        {
            return address;
        }

        public string getMobile()
        {
            return mobile;
        }
    }
}
