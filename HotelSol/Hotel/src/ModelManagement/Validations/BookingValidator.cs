using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Validations
{
    public class BookingValidator
    {
        public static DateTime ValidateFromDate(int roomID, bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(roomID, isAnEdit, previousMenu);

            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }
        public static DateTime ValidateToDate(int roomID, bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(roomID, isAnEdit, previousMenu);

            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }

        public static bool ValidateOccupiedDate(int roomID, DateTime dateToValidate, bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            var _existingBookings = BookingService.GetAll(_isInactive);

                if (_existingBookings.Any(b => b.RoomID == roomID && b.FromDate <= dateToValidate && b.ToDate > dateToValidate) && isAnEdit == false)
                {
                    Console.WriteLine("Rummet är redan bokat under detta datum, försök igen");
                    LineClearer.ClearLastLine(1000);
                    return false;
                }
                else
                    return true;
        }
        public static DateTime ValidateOccupiedDateBACKUP(int roomID, DateTime dateToValidate, bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            var _existingBookings = BookingService.GetAll(_isInactive);

            while (true)
            {
                var _userInput = UserInputHandlerDateTime.UserInputDateTime(roomID, isAnEdit, previousMenu);

                if (_existingBookings.Any(b => b.RoomID == roomID && b.FromDate < _userInput && b.ToDate > _userInput))
                {
                    Console.WriteLine("Rummet är redan bokat under detta datum, försök igen");
                    LineClearer.ClearLastLine(1000);
                }
                else
                {
                    return _userInput;
                }
            }
        }
    }
}
