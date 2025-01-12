using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Rules
{
    public class CustomerValidator
    {
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
                {
                    Console.WriteLine($"Felaktig e-post angiven, måste vara i format \"abc123@abc123.abc\"");
                    LineClearer.ClearLine(1000);
                }
            }
        }
        public static string ValidatePhone(bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput))
                    return _userInput;
                else if (UserInputRegexHandler.UserInputRegexPhone(_userInput, previousMenu))
                    return _userInput;
                else
                    Console.WriteLine($"Felaktig telefonnummer angivet, måste börja med \"070\" eller \"+46\" och får max vara 8-18 tecken långt");
            }
        }
        public static string ValidatePostalCode(bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput))
                    return _userInput;
                else if (UserInputRegexHandler.UserInputRegexPostalCode(_userInput, previousMenu))
                    return _userInput;
                else
                    Console.WriteLine($"Felaktigt postnummer angiven, måste vara i format \"12345\"");
            }
        }
    }
}
