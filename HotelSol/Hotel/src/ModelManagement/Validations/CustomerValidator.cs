using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Utilities.UserInputManagement;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using HotelLibrary.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Rules
{
    public class CustomerValidator
    {
        public static string ValidateFirstName(string input, bool isAnEdit, IMenu previousMenu)
        {
            var _userInput = UserInputHandler.UserInputStringNotNullOrEmpty(previousMenu);
            return _userInput;
        }
        public static string ValidateEmail(bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput))
                    return _userInput;
                else if (UserInputRegexHandler.UserInputRegexEmail(_userInput, previousMenu))
                    return _userInput;
                else
                    Console.WriteLine($"Felaktig e-post angiven, måste vara i format \"abc123@abc123.abc\"");
            }
        }
    }
}
