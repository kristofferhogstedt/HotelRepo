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
        public static bool UserInputRegexEmail(string input, IMenu previousMenu)
        {
            if (RegexHandler.CheckRegexMatch(input, RegexSettings.EmailPattern))
                return true;
            else
            {
                //Console.WriteLine("Invalid email. Please enter a valid email.");
                //LineClearer.ClearLastLine(1000);
                return false;
            }
        }

        public static bool UserInputRegexPhone(string input, IMenu previousMenu)
        {
            if (RegexHandler.CheckRegexMatch(input, RegexSettings.PhonePattern))
                return true;
            else
            {
                //Console.WriteLine("Invalid phone number. Please enter a valid email.");
                //LineClearer.ClearLastLine(1000);
                return false;
            }
        }

        public static bool UserInputRegexPostalCode(string input, IMenu previousMenu)
        {
            if (RegexHandler.CheckRegexMatch(input, RegexSettings.PostalCodePattern))
                return true;
            else
            {
                //Console.WriteLine("Invalid Postal code. Please enter a valid email.");
                //LineClearer.ClearLastLine(1000);
                return false;
            }
        }
    }
}
