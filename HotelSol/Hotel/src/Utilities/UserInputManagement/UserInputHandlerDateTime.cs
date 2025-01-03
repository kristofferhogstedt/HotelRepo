using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Utilities.ConsoleManagement;
using HotelLibrary.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.UserInputManagement
{
    public class UserInputHandlerDateTime
    {
        public static int UserInputYear(IMenu previousMenu)
        {
            var _output = 0;

            while (!int.TryParse(UserInputHandler.UserInputString(previousMenu), out _output) || _output != 0 && _output < DateTime.Now.Year - 150 || _output > DateTime.Now.Year + 150)
            {
                Console.WriteLine("Felaktig inmatning, Ange ett giltigt årtal (nuvarande år +/- 150).");
                LineClearer.ClearLastLine(1000);
            }

            return _output;
        }

        public static int UserInputMonth(IMenu previousMenu)
        {
            var _output = 0;

            while (!int.TryParse(UserInputHandler.UserInputString(previousMenu), out _output) || _output < 0 || _output > 12 || _output != 0)
            {
                Console.WriteLine("Felaktig inmatning, Ange ett giltigt månad (1-12).");
                LineClearer.ClearLastLine(1000);
            }
            return _output;
        }

        public static int UserInputDay(int year, int month, IMenu previousMenu)
        {
            var _output = 0;
            var _monthString = MonthConverter.ConvertMonthToString(month);
            var _daysInMonth = DateTime.DaysInMonth(year, month);

            while (!int.TryParse(UserInputHandler.UserInputString(previousMenu), out _output) || _output < 0 || _output > _daysInMonth || _output != 0)
            {
                Console.WriteLine($"Felaktig inmatning, Ange ett giltigt dag (1-{_daysInMonth} för {_monthString} {year}).");
                LineClearer.ClearLastLine(1000);
            }
            return _output;
        }

        /// <summary>
        /// Dateselector with current date as starting point
        /// </summary>
        /// <returns></returns>
        public static DateTime UserInputDateTime()
        {
            return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate()));
        }

        /// <summary>
        /// Dateselector with user-selected year as starting point
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime UserInputDateTime(int year)
        {
            return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year)));
        }

        /// <summary>
        /// Dateselector with user-selected year and month as starting point
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime UserInputDateTime(int year, int month)
        {
            return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year, month)));
        }

        /// <summary>
        /// Dateselector with user-selected year, month and day as starting point
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime UserInputDateTime(int year, int month, int day)
        {
            return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year, month, day)));
        }
    }
}
