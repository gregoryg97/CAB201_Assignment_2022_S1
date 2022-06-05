using CAB201_UserInterfaceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Airline Booking Program which implements all 16 User Stories defined by Assesment Outline
    /// 
    /// Contains core DAO objects for Employee, Customer and Flight Data.
    /// While initalising the entry point meny for User Interaction
    /// </summary>
    internal class Airline
    {
        public static EmployeeRegistry EMPLOYEE_REGISTRY = new EmployeeRegistry();
        public static CustomerRegistry CUSTOMER_REGISTRY = new CustomerRegistry();  
        public static FlightRegistry FIGHT_REGISTRY = new FlightRegistry();

        static void Main(string[] args)
        {
            Menu program = new HomeMenu("");
            program.Display();
        }
    }
}
