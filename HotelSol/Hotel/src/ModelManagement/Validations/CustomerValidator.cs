using Hotel.src.MenuManagement.Menus.Interfaces;
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
    }
}
