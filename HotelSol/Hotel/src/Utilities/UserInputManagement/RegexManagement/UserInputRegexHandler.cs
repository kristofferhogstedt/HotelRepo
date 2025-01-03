using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Utilities.ConsoleManagement;
using HotelLibrary.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.UserInputManagement.RegexManagement
{
    public class UserInputRegexHandler
    {
        public static string UserInputRegexEmail(IMenu previousMenu)
        {
            while (true)
            {
                string _email = UserInputHandler.UserInputString(previousMenu);
                if (RegexHandler.CheckRegexEmail(_email))
                    return _email;
                else if (_email == "")
                    return _email;
                else
                {
                    Console.WriteLine("Invalid email. Please enter a valid email.");
                    LineClearer.ClearLastLine(1000);
                }
            }
        }

        public static string UserInputRegexPhone(IMenu previousMenu)
        {
            while (true)
            {
                string _phone = UserInputHandler.UserInputString(previousMenu);
                if (RegexHandler.CheckRegexPhone(_phone))
                    return _phone;
                else if (_phone == "")
                    return _phone;
                else
                { 
                    Console.WriteLine("Invalid phone number. Please enter a valid phone number.");
                    LineClearer.ClearLastLine(1000);
                }
            }
        }
    }
}
