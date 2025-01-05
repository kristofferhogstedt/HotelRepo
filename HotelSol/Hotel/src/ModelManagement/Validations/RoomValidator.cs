using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
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
        public static int ValidateRoomNumber(IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (RoomService.GetAll().Any(e => e.Name == Convert.ToString(_userInput)))
                    Console.WriteLine($"Rumsnummer {_userInput} finns redan, ange nytt");
                else if (_userInput.ToString().Length <= 0 || _userInput.ToString().Length > 3)
                    Console.WriteLine("Rumsnummer får inte vara tomt och måste vara kortare än 3 siffror");
                else
                    return _userInput;
            }
        }

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
