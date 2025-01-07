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
        public static DateTime ValidateFromDate(int roomID, IBooking? booking, bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(roomID, booking, isAnEdit, previousMenu);

            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }
        public static DateTime ValidateToDate(int roomID, IBooking? booking, bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(roomID, booking, isAnEdit, previousMenu);

            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }

        //public static bool ValidateOccupiedDate(int roomID, DateTime dateToValidate, bool isAnEdit)
        //{
        //    var _isInactive = false;
        //    var _existingBookings = BookingService.GetAll(_isInactive).Where(b => b.RoomID == roomID);

        //    var _occupiedDates = new List<DateTime>();

        //    foreach (var booking in _existingBookings)
        //    {
        //        _occupiedDates = BookedDateSplitter.SplitDates(booking);
        //    }

        //    if (_occupiedDates.Any(d => d.Date == dateToValidate.Date))
        //        return false;
        //    //if (_existingBookings.Any(b => b.RoomID == roomID && b.FromDate <= dateToValidate && b.ToDate > dateToValidate) && isAnEdit == false)
        //    //    return false;
        //    else
        //        return true;
        //}
        //public static bool ValidateOccupiedDay(int roomID, int dateToValidate, bool isAnEdit)
        //{
        //    var _isInactive = false;
        //    var _existingBookings = BookingService.GetAll(_isInactive);

        //    if (_existingBookings.Any(b => b.RoomID == roomID && b.FromDate <= dateToValidate && b.ToDate > dateToValidate) && isAnEdit == false)
        //    {
        //        Console.WriteLine("Rummet är redan bokat under detta datum, försök igen");
        //        LineClearer.ClearLastLine(1000);
        //        return false;
        //    }
        //    else
        //        return true;
        //}

        public static DateTime ValidateOccupiedDateBACKUP(int roomID, IBooking? booking, DateTime dateToValidate, bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            var _existingBookings = BookingService.GetAll(_isInactive);

            while (true)
            {
                var _userInput = UserInputHandlerDateTime.UserInputDateTime(roomID, booking, isAnEdit, previousMenu);

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
