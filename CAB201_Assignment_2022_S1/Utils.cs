using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAB201_UserInterfaceTest;

namespace CAB201_Assignment_2022_S1
{
    class Utils
    {
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
    }
}