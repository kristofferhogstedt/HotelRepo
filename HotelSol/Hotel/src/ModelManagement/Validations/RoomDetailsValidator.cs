﻿using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Validations
{
    public class RoomDetailsValidator
    {
        public static IRoomType ValidateRoomType(IRoomType existingEntityRoomType, bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            bool _getRelatedObjects = true;
            var _allRoomTypes = RoomTypeService.GetAll(_getRelatedObjects, _isInactive);
            while (true)
            {
                var _userInput = UserInputHandler.UserInputString(previousMenu).ToLower();

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return existingEntityRoomType;
                else if (_allRoomTypes.Any(e => e.Name.ToLower() == _userInput))
                    return _allRoomTypes.First(e => e.Name.ToLower() == _userInput);
                else
                {
                    Console.WriteLine("Rumtyp finns inte, prova igen");
                    _allRoomTypes.ForEach(e => Console.WriteLine(e.Name));
                    LineClearer.ClearLastLine(1000);
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
                    LineClearer.ClearLastLine(1000);
                }
            }
        }

        public static int ValidateNumberOfBeds(IRoomType roomType, int roomSize, bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputInt(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return _userInput;
                var _bedsMaxByRoomSize = (roomSize / 10);
                if (_userInput > _bedsMaxByRoomSize || _userInput > roomType.NumberOfBedsMax)
                {
                    Console.WriteLine($"Antal bäddar överstiger maxgränsen för detta rum ({_bedsMaxByRoomSize})");
                    LineClearer.ClearLastLine(1000);
                }
                else if (_userInput <= 0)
                {
                    Console.WriteLine($"Antal bäddar måste överstiga 0)");
                    LineClearer.ClearLastLine(1000);
                }
                else
                    return _userInput;
            }
        }

        public static double ValidateRoomPrice(IRoomType roomType, bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _userInput = UserInputHandler.UserInputDouble(previousMenu);

                if (isAnEdit && InputChecker.UserInputIsEnter(_userInput.ToString()))
                    return _userInput;

                if (_userInput > 0)
                    return _userInput;
                else
                {
                    Console.WriteLine($"Priset måste överstiga 0");
                    LineClearer.ClearLastLine(1000);
                }
            }
        }
    }
}
