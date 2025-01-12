using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.Utilities.UserInputManagement
{
    public class UserInputHandlerDateTime
    {
        public static int UserInputYear(IMenu previousMenu)
        {
            var _output = 0;

            while (!int.TryParse(UserInputHandler.UserInputString(previousMenu), out _output) || _output != -1 && _output < DateTime.Now.Year - 150 || _output > DateTime.Now.Year + 150)
            {
                Console.WriteLine("Felaktig inmatning, Ange ett giltigt årtal (nuvarande år +/- 150).");
            }

            return _output;
        }

        public static int UserInputMonth(IMenu previousMenu)
        {
            var _output = -1;
            while (!int.TryParse(UserInputHandler.UserInputString(previousMenu), out _output) || _output < 1 && _output != -1 || _output > 12)
            {
                Console.WriteLine("Felaktig inmatning, Ange ett giltigt månad (1-12).");
            }

            return _output;
        }

        public static int UserInputDay(int year, int month, IMenu previousMenu)
        {
            var _output = -1;
            var _monthString = MonthConverter.ConvertMonthToString(month);
            var _daysInMonth = DateTime.DaysInMonth(year, month);

            while (!int.TryParse(UserInputHandler.UserInputString(previousMenu), out _output) || _output < 1 && _output != -1 || _output > _daysInMonth)
            {
                Console.WriteLine($"Felaktig inmatning, Ange ett giltigt dag (1-{_daysInMonth} för {_monthString} {year}).");
            }
            return _output;
        }

        /// <summary>
        /// Dateselector with current date as starting point
        /// </summary>
        /// <returns></returns>
        public static DateTime UserInputDateTime(int roomID, IBooking? booking, bool isAnEdit, IMenu previousMenu)
        {
            return Calendar.DateSelector(roomID, booking, Calendar.StartDate(Calendar.SetStartDate()), isAnEdit, previousMenu);
        }
    }
}
