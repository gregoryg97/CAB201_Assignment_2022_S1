using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAB201_UserInterfaceTest;

namespace CAB201_Assignment_2022_S1
{
    internal class HomeMenu : Menu
    {
        public HomeMenu(string title, params MenuItem[] menuItems) : base(title, menuItems)
        {
            MenuItem registerEmployee = new CallableItem("Register as a new Employee", RegisterNewEmployee);
            Add(registerEmployee);

            MenuItem loginEmployee = new CallableItem("Login as existing Employee", LoginEmployee);
            Add(loginEmployee);

            MenuItem exit = new CallableItem("Exit", ExitItem);
            Add(exit);
        }

        private void openBookingMenu()
        {
            Menu menu = new BookingMenu("");
            menu.Display();
        }

        private int ExitItem()
        {
            return -1;
        }

        private int LoginEmployee()
        {
            string email = "";
            while (email.Length <= 0 || !Utils.isValidEmailAddress(email))
            {
                email = UserInterface.GetInput("Email address");
                email = email.Trim();
            }

            string password = "";
            while (password.Length <= 0)
            {
                password = UserInterface.GetPassword("Password");
            }

            if (Airline.EMPLOYEE_REGISTRY.authenticate(email, password))
            {
                UserInterface.Message(String.Format("Succesfully authenticated {0}. Welcome!", Airline.EMPLOYEE_REGISTRY.getActiveEmployee().getName()));
                openBookingMenu();
            }
            else
            {
                UserInterface.Message("Invalid credentials. Please try again.");
            }

            return 0;
        }

        private int RegisterNewEmployee()
        {
            Person person = Utils.promptPersonCreation();

            string password = "";
            while (password.Length <= 0)
            {
                password = UserInterface.GetPassword("Password");
            }

            Employee newEmployee = new Employee(person, password);
            if (!Airline.EMPLOYEE_REGISTRY.add(newEmployee))
            {
                UserInterface.Message(String.Format("Employee {0} already exists. Please try logging in.", newEmployee.getName()));
            }
            else
            {
                UserInterface.Message(String.Format("Created {0} as new employee.", newEmployee.getName()));
            }

            return 0;
        }
    }
}
