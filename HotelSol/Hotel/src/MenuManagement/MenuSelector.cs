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
    internal class MenuSelector(
        IMenu menu
        , IUserInput<EUserInputKeys> userInputter
        ) 
        : IMenuSelector
    {
        IMenu _menu = menu;
        IUserInput<EUserInputKeys> _userInput = userInputter;
        IMenuDestination _menuDestination;

        public IMenuDestination Select()
        {

            return _menuDestination;
        }
    }
}
