using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Validations
{
    public class RoomValidator
    {
        public static int ValidateFloor(IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (_userInput < Settings.FloorsMax)
                    return _userInput;
                else
                    Console.WriteLine($"Hotellet har bara {Settings.FloorsMax} våningar");
            }
        }

    }
}
