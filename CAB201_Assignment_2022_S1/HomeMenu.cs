using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAB201_UserInterfaceTest;

namespace CAB201_Assignment_2022_S1
{
    public class CallableItem : MenuItem
    {
        public Action ActionMethod;
        public CallableItem(string text, Action actionMethod) : base(text)
        {
            ActionMethod = actionMethod;
        }
        public override void WhenSelected(Menu parentMenu)
        {
            int returnValue = ActionMethod();

            if (returnValue == 0)
            {
                parentMenu.Display();
            }
        }
        public delegate int Action();
    }

    internal class HomeMenu : Menu
    {
        public HomeMenu(string title, params MenuItem[] menuItems) : base(title, menuItems)
        {
            MenuItem registerEmployee = new CallableItem("Register as a new Employee", RegisterNewEmployee);
            Add(registerEmployee);
        }

        private int RegisterNewEmployee()
        {
            string name = "";
            while (name.Length <= 0)
            {
                name = UserInterface.GetInput("Full name");
            }

            string email = "";
            while (email.Length <= 0 || !Utils.isValidEmailAddress(email))
            {
                email = UserInterface.GetInput("Email address");
                email = email.Trim();
            }

            return 0;
        }
    }
}
