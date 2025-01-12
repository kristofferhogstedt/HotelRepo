using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Validations
{
    public class RoomValidator
    {
        public static string ValidateRoomNumber(bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            bool _getRelatedObjects = true;

            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return _userInput;
                else if (RoomService.GetAll(_getRelatedObjects, _isInactive).Any(e => e.Name == _userInput))
                    Console.WriteLine($"Rumsnummer {_userInput} finns redan, ange nytt");
                else
                    return _userInput;
            }
        }

        public static int ValidateFloor(bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return _userInput;

                if (_userInput > Settings.FloorsMax)
                    Console.WriteLine($"Hotellet har bara {Settings.FloorsMax} våningar");
                else if (_userInput <= 0)
                    Console.WriteLine($"Hotellets bokningsbara rum finns på våning 1 och uppåt");
                else
                    return _userInput;
            }
        }

    }
}
