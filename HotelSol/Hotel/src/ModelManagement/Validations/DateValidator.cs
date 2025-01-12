using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Validations
{
    public class DateValidator
    {
        public static bool ValidateOccupiedDate(int roomID, IBooking? booking, DateTime dateToValidate, bool isAnEdit)
        {
            var _isInactive = false;
            bool _getRelatedObjects = true;
            var _existingBookings = BookingService.GetAll(_getRelatedObjects, _isInactive).Where(b => b.RoomID == roomID);

            var _occupiedDatesPerBooking = new List<DateTime>();
            var _occupiedDatesPerRoom = new List<DateTime>();
            var _occupiedDatesForThisBooking = new List<DateTime>(); // Dates that shouldnt be considered (for editing bookings)
            var _occupiedDates = new List<DateTime>();

            foreach (var b in _existingBookings)
            {
                if (booking != null) // Guard if there is no booking to consider
                {
                    if (b.ID == booking.ID)
                    {
                        _occupiedDatesPerBooking = BookedDateSplitter.SplitDates(b);
                        _occupiedDatesPerBooking.ForEach(d => _occupiedDatesForThisBooking.Add(d)); // Dates that are not considered 
                    }
                    else
                    {
                        _occupiedDatesPerBooking = BookedDateSplitter.SplitDates(b);
                        _occupiedDatesPerBooking.ForEach(d => _occupiedDates.Add(d)); // Dates that are considered
                    }
                }
                else
                {
                    _occupiedDatesPerBooking = BookedDateSplitter.SplitDates(b);
                    _occupiedDatesPerBooking.ForEach(d => _occupiedDates.Add(d)); // Dates that are considered
                }
            }

            if (_occupiedDates.Any(d => d.Date == dateToValidate.Date))
                return false;
            else
                return true;
        }
    }
}
