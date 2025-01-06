using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Validations
{
    public class RoomDetailsValidator
    {
        public static IRoomType ValidateRoomType(IRoomType existingEntityRooMType, bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            var _allRoomTypes = RoomTypeService.GetAll(_isInactive);
            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu).ToLower();

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return existingEntityRooMType;
                else if (_allRoomTypes.Any(e => e.Name.ToLower() == _userInput))
                    return _allRoomTypes.First(e => e.Name.ToLower() == _userInput);
                else
                {
                    Console.WriteLine("Rumtyp finns inte, prova igen");
                    _allRoomTypes.ForEach(e => Console.WriteLine(e.Name));

                    Thread.Sleep(3000);
                }
            }
        }

        public static int ValidateRoomSize(IRoomType roomType, bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return _userInput;
                else if (_userInput < roomType.SizeMax)
                    return _userInput;
                else
                {
                    Console.WriteLine($"Storleken överstiger maxgränsen för vald rumtyp ({roomType.SizeMax} m2)");
                    Thread.Sleep(1000);
                }
            }
        }

        public static int ValidateNumberOfBeds(IRoomType roomType, bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return _userInput;
                else if (_userInput < roomType.NumberOfBedsMax)
                    return _userInput;
                else
                {
                    Console.WriteLine($"Storleken överstiger maxgränsen för vald rumtyp ({roomType.SizeMax} m2)");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
