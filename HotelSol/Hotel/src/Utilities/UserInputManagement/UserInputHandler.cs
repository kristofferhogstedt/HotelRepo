using Hotel;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using Microsoft.IdentityModel.Tokens;

namespace HotelLibrary.Utilities.UserInputManagement
{
    public class UserInputHandler
    {
        public static ConsoleKey? UserInputEscape(IMenu previousMenu)
        {
            var _key = Console.ReadKey(true).Key;

            if (_key == ConsoleKey.Escape)
            {
                if (previousMenu != null)
                {
                    Console.WriteLine("Återgår...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    previousMenu.Run();
                }
                else
                    Exit.ExitProgram();
                return _key;
            }
            else
            {
                return _key;
            }
        }

        public static bool UserInputEnter(ConsoleKeyInfo consoleKeyInput)
        {
            if (consoleKeyInput.Key == ConsoleKey.Enter)
                return true;
            else
                return false;
        }

        public static string UserInputString(IMenu previousMenu)
        {
            UserInputEscape(previousMenu);
            return Console.ReadLine();
        }

        public static string UserInputStringNotNullOrEmpty(IMenu previousMenu)
        {
            var _input = "";
            while (_input.IsNullOrEmpty())
            {
                _input = UserInputString(previousMenu);
                if (_input.IsNullOrEmpty())
                {
                    Console.WriteLine("Får inte vara tomt.");
                    LineClearer.ClearLastLine(1000);
                }
            }

            return _input;
        }

        public static int UserInputInt(IMenu previousMenu)
        {
            int _output = 0;
            while (!int.TryParse(UserInputString(previousMenu), out _output))
            {
                Console.WriteLine("Felaktig inmatning, måste vara heltal (int).");
                LineClearer.ClearLine(1000);
            }

            return _output;
        }

        public static ushort UserInputUshort(IMenu previousMenu)
        {
            ushort _output = 0;
            while (!ushort.TryParse(UserInputString(previousMenu), out _output))
            {
                Console.WriteLine("Felaktig inmatning, heltal (ushort).");
                LineClearer.ClearLine(1000);
            }

            return _output;
        }

        public static int UserInputYear(IMenu previousMenu)
        {
            var _output = 0;

            while (!int.TryParse(UserInputString(previousMenu), out _output) || _output !=0 && _output < DateTime.Now.Year - 150 || _output > DateTime.Now.Year + 150 || _output != 0)
            {
                Console.WriteLine("Felaktig inmatning, Ange ett giltigt årtal (nuvarande år +/- 150).");
                LineClearer.ClearLastLine(1000);
            }

            return _output;
        }

        public static int UserInputMonth(IMenu previousMenu)
        {
            var _output = 0;

            while (!int.TryParse(UserInputString(previousMenu), out _output) || _output < 0 || _output > 12 || _output != 0)
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

            while (!int.TryParse(UserInputString(previousMenu), out _output) || _output < 0 || _output > _daysInMonth || _output != 0)
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
