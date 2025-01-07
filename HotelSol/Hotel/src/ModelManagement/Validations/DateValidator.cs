using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Validations
{
    public class DateValidator
    {
        public static bool ValidateOccupiedDate(int roomID, DateTime dateToValidate, bool isAnEdit)
        {
            var _isInactive = false;
            var _existingBookings = BookingService.GetAll(_isInactive).Where(b => b.RoomID == roomID);

            var _occupiedDatesPerBooking = new List<DateTime>();
            var _occupiedDatesPerRoom = new List<DateTime>();

            foreach (var booking in _existingBookings)
            {
                _occupiedDatesPerBooking = BookedDateSplitter.SplitDates(booking);
                _occupiedDatesPerBooking.ForEach(d => _occupiedDatesPerRoom.Add(d));
            }

            if (_occupiedDatesPerRoom.Any(d => d.Date == dateToValidate.Date))
                return false;
            //if (_existingBookings.Any(b => b.RoomID == roomID && b.FromDate <= dateToValidate && b.ToDate > dateToValidate) && isAnEdit == false)
            //    return false;
            else
                return true;
        }
    }
}
