using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAB201_UserInterfaceTest;

namespace CAB201_Assignment_2022_S1
{
    /// <summary>
    /// Class which defines a MenuItem prompt within each menu class.
    /// </summary>
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
            } else if (returnValue == -1)
            {
                parentMenu.Exit();
            }
        }
        public delegate int Action();
    }

    /// <summary>
    /// Class of Helper methods that can be used throughout the entire application
    /// </summary>
    class Utils
    {
        /// <summary>
        /// Checks if an input string is a valid email address
        /// </summary>
        /// <param name="value">String containing input email address</param>
        /// <returns>Bool if email address is valid</returns>
        public static bool isValidEmailAddress(string value)
        {
            var trimmedEmail = value.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// General person creation prompt used across application
        /// </summary>
        public static Person promptPersonCreation()
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

            return new Person(name, email);
        }
    }
}