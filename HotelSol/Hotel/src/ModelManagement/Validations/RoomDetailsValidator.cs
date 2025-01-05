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
    public class RoomDetailsValidator
    {
        public static IRoomType ValidateRoomType(IMenu previousMenu)
        {
            var _allRoomTypes = RoomTypeService.GetAll();
            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu);

                if (_allRoomTypes.Any(e => e.Name == _userInput))
                    return _allRoomTypes.First(e => e.Name == _userInput);
                else
                {
                    Console.WriteLine("Rumtyp finns inte, prova igen");
                    _allRoomTypes.ForEach(e => Console.WriteLine(e.Name));

                    Thread.Sleep(3000);
                }
            }
        }

        public static int ValidateRoomSize(IRoomType roomType, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (_userInput < roomType.SizeMax)
                    return _userInput;
                else
                {
                    Console.WriteLine($"Storleken överstiger maxgränsen för vald rumtyp ({roomType.SizeMax} m2)");
                    Thread.Sleep(1000);
                }
            }
        }

        public static int ValidateNumberOfBeds(IRoomType roomType, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (_userInput < roomType.NumberOfBedsMax)
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
