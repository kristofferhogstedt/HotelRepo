using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Validations
{
    public class RoomDetailsValidator
    {
        public static IRoomType ValidateRoomType(IMenu previousMenu)
        {
            var _allRoomTypes = RoomTypeService.GetAll();
            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu).ToLower();

                if (_allRoomTypes.Any(e => e.Name.ToLower() == _userInput))
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

                if (isAnEdit && _userInput == -1)
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

                if (isAnEdit && _userInput == -1)
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
