using Hotel;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;

namespace HotelLibrary.Utilities.UserInputManagement
{
    public class UserInputHandler
    {

        public static void UserInputEscape(IMenu previousMenu)
        {
            var _key = Console.ReadKey(true).Key;

            switch (_key)
            {
                case ConsoleKey.Escape:
                    if (previousMenu != null)
                        previousMenu.Run();
                    else
                        Exit.ExitProgram();
                    break;
                default:
                    break;
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

        public static int UserInputYear()
        {
            var _output = 0;
            Console.WriteLine("Ange årtal: ");

            while (!int.TryParse(Console.ReadLine(), out _output) || _output < DateTime.Now.Year - 150 || _output > DateTime.Now.Year + 150)
            {
                Console.WriteLine("Felaktig inmatning, Ange ett giltigt årtal (nuvarande år +/- 150).");
                LineClearer.ClearLastLine(1000);
            }

            return _output;
        }

        public static int UserInputMonth()
        {
            var _output = 0;
            Console.WriteLine("Ange månad: ");

            while (!int.TryParse(Console.ReadLine(), out _output) || _output < 1 || _output > 12)
            {
                Console.WriteLine("Felaktig inmatning, Ange ett giltigt månad (1-12).");
            }
            return _output;
        }

        public static int UserInputDay(int year, int month)
        {
            var _output = 0;
            var _monthString = MonthConverter.ConvertMonthToString(month);
            var _daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine("Ange dag: ");

            while (!int.TryParse(Console.ReadLine(), out _output) || _output < 1 || _output > _daysInMonth)
            {
                Console.WriteLine($"Felaktig inmatning, Ange ett giltigt dag (1-{_daysInMonth} för {_monthString} {year}).");
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
