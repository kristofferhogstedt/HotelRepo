using Hotel.src.MenuManagement.Menus.Interfaces;

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
                return false;
            }
        }

        public static bool UserInputRegexPhone(string input, IMenu previousMenu)
        {
            if (RegexHandler.CheckRegexMatch(input, RegexSettings.PhonePattern))
                return true;
            else
            {
                return false;
            }
        }

        public static bool UserInputRegexPostalCode(string input, IMenu previousMenu)
        {
            if (RegexHandler.CheckRegexMatch(input, RegexSettings.PostalCodePattern))
                return true;
            else
            {
                return false;
            }
        }
    }
}
