using Hotel.src.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Utilities.UserInputManagement
{
    public class UserInputHandler
    {
        public static string UserInputString()
        {
            return Console.ReadLine();
        }
        public static string UserInputStringEmail()
        {
            // TODO: Add email validation
            return Console.ReadLine();
        }
        public static string UserInputStringPhone()
        {
            // TODO: Add phone validation
            return Console.ReadLine();
        }

        public static int UserInputInt()
        {
            int _output = 0;
            while (!int.TryParse(Console.ReadLine(), out _output))
            {
                Console.WriteLine("Felaktig inmatning, försök igen.");
            }

            return _output;
        }

        public static ushort UserInputUshort()
        {
            ushort _output = 0;
            while (!ushort.TryParse(Console.ReadLine(), out _output))
            {
                Console.WriteLine("Felaktig inmatning, försök igen.");
            }

            return _output;
        }

        /// <summary>
        /// Dateselector with current date as starting point
        /// </summary>
        /// <returns></returns>
        public static DateTime? UserInputDateTime()
        {
            return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate()));
        }

        /// <summary>
        /// Dateselector with user-selected year as starting point
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime UserInputDateTime(ushort year)
        {
            return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year)));
        }

        /// <summary>
        /// Dateselector with user-selected year and month as starting point
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime? UserInputDateTime(ushort year, ushort month)
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
        public static DateTime? UserInputDateTime(ushort year, ushort month, ushort day)
        {
            return Calendar.DateSelector(Calendar.StartDate(Calendar.SetStartDate(year, month, day)));
        }
    }
}
