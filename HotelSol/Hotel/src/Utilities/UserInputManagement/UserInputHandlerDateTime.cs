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
        public static DateTime UserInputDateTime(int roomID, bool isAnEdit, IMenu previousMenu)
        {
            return Calendar.DateSelector(roomID, Calendar.StartDate(Calendar.SetStartDate()), isAnEdit, previousMenu);
        }

        ///// <summary>
        ///// Dateselector with user-selected year as starting point
        ///// </summary>
        ///// <param name="year"></param>
        ///// <returns></returns>
        //public static DateTime UserInputDateTime(int year, IMenu previousMenu)
        //{
        //    return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year)), previousMenu);
        //}

        ///// <summary>
        ///// Dateselector with user-selected year and month as starting point
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <returns></returns>
        //public static DateTime UserInputDateTime(int year, int month, IMenu previousMenu)
        //{
        //    return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year, month)), previousMenu);
        //}

        ///// <summary>
        ///// Dateselector with user-selected year, month and day as starting point
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="day"></param>
        ///// <returns></returns>
        //public static DateTime UserInputDateTime(int year, int month, int day, IMenu previousMenu)
        //{
        //    return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year, month, day)), previousMenu);
        //}
    }
}
