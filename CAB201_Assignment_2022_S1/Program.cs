using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAB201_UserInterfaceTest;

namespace CAB201_Assignment_2022_S1
{
    internal class Program
    {

        /*static Customer promptCustomerCreation()
        {
            Person person = promptPersonCreation();

            string address = "";
            while (address.Length <= 0)
            {
                address = UserInterface.GetInput("Address").Trim();
            }

            string mobile = "";
            while (mobile.Length <= 0)
            {
                // TODO check is real number
                mobile = UserInterface.GetInput("Mobile").Trim();
            }

            return new Customer(person, address, mobile);
        }*/

       /* static void Main(string[] args)
        {
            Menu program = new HomeMenu("");
            program.Display();

            EmployeeRegistry employeeRegistry = new EmployeeRegistry();
            CustomerRegistry customerRegistry = new CustomerRegistry();

            int option = -1;

            /*while (option != 2)
            {
                option = UserInterface.GetOption("Please select one of the following:",
                "Register as a new Employee", "Login as existing Employee", "Exit");
                UserInterface.Message("");

                switch (option)
                {
                    case 0:
                        Employee newEmployee = promptEmployeeCreation();
                        if (!employeeRegistry.add(newEmployee))
                        {
                            UserInterface.Message(String.Format("Employee {0} already exists. Please try logging in.", newEmployee.getName()));
                        } else
                        {
                            UserInterface.Message(String.Format("Created {0} as new employee.", newEmployee.getName()));
                        }
                        break;
                    case 1:
                        (string email, string password) = promptEmployeeLogin();
                        if (employeeRegistry.authenticate(email, password))
                        {
                            UserInterface.Message(String.Format("Succesfully authenticated {0}. Welcome!", employeeRegistry.getActiveEmployee().getName()));
                        } else
                        {
                            UserInterface.Message("Invalid credentials. Please try again.");                        
                        }
                        break;
                    case 2:
                    default:
                        break;
                };
            }

            Console.WriteLine(option);
        }*/
    }
}
