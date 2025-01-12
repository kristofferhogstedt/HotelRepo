using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Validations
{
    public class BookingValidator
    {
        public static DateTime ValidateFromDate(int roomID, IBooking? booking, bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(roomID, booking, isAnEdit, previousMenu);

                if (isAnEdit && _dateToReturn == DateTime.MinValue)
                    return DateTime.MinValue;

                if (_dateToReturn < DateTime.Now.Date)
                {
                    Console.WriteLine("Från-datum måste ligga senare i tid än dagens datum");
                    Thread.Sleep(2000);
                }
                else
                    return _dateToReturn;
            }
        }
        public static DateTime ValidateToDate(int roomID, IBooking? booking, DateTime fromDate, bool isAnEdit, IMenu previousMenu)
        {
            while (true)
            {
                var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(roomID, booking, isAnEdit, previousMenu);

                if (isAnEdit && _dateToReturn == DateTime.MinValue)
                    return DateTime.MinValue;

                if (_dateToReturn < fromDate)
                {
                    Console.WriteLine("Till-datum måste ligga senare i tid än Från-datum");
                    Thread.Sleep(2000);
                }
                else
                    return _dateToReturn;
            }
        }


        public static DateTime ValidateOccupiedDateBACKUP(int roomID, IBooking? booking, DateTime dateToValidate, bool isAnEdit, IMenu previousMenu)
        {
            var _isInactive = false;
            bool _getRelatedObjects = true;
            var _existingBookings = BookingService.GetAll(_getRelatedObjects, _isInactive);

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
