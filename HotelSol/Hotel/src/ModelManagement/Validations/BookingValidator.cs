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
        public static DateTime ValidateFromDate(bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(previousMenu);

            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }
        public static DateTime ValidateToDate(bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(previousMenu);

            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }

        public static DateTime ValidateOccupiedDate(int roomID, DateTime dateToValidate, bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            var _existingBookings = BookingService.GetAll(_isInactive);

            while (true)
            {
                var _userInput = UserInputHandlerDateTime.UserInputDateTime(previousMenu);

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
