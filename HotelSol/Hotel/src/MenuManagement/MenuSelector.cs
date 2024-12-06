using Hotel.src.MenuManagement.Interfaces;
using HotelLibrary.UserInputManagement;
using HotelLibrary.UserInputManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement
{
    internal class MenuSelector(Dictionary<int, string> menu, IUserInput<EUserInputKeys> userInput) : IMenuSelector
    {
        Dictionary<int, string> _menu = menu;
        IUserInput<EUserInputKeys> _userInput = userInput;

        public IMenuDestination Select()
        {

        }
    }
}
