using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Validations;
using Hotel.src.Utilities.ConsoleManagement;
using Spectre.Console;

namespace Hotel.src.Utilities.UserInputManagement
{
    public class Calendar
    {
        public static DateTime StartDate(DateTime startDate)
        {
            DateTime _startDate = startDate;
            DateTime _selectedDate = new DateTime(_startDate.Year, _startDate.Month, 1);
            return _selectedDate;
        }

        public static DateTime DateSelector(int roomID, IBooking? booking, DateTime startDate, bool isAnEdit, IMenu previousMenu)
        {
            DateTime _selectedDate = startDate;

            var _isInactive = false;

            while (true)
            {
                Console.Clear();
                RenderCalendar(_selectedDate, roomID, booking, isAnEdit);

                var _key = Console.ReadKey(true).Key;

                switch (_key)
                {
                    case ConsoleKey.RightArrow:
                        _selectedDate = _selectedDate.AddDays(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        _selectedDate = _selectedDate.AddDays(-1);
                        break;
                    case ConsoleKey.UpArrow:
                        _selectedDate = _selectedDate.AddDays(-7);
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedDate = _selectedDate.AddDays(7);
                        break;
                    case ConsoleKey.Enter:
                        if (!DateValidator.ValidateOccupiedDate(roomID, booking, _selectedDate, isAnEdit))
                        {
                            Console.WriteLine("Rummet är redan bokat under detta datum, försök igen");
                            LineClearer.ClearLastLine(1000);
                            break;
                        }
                        else
                            return _selectedDate;
                    case ConsoleKey.Escape:
                        previousMenu.Run();
                        return DateTime.MinValue;
                }
            }
        }

        private static void RenderCalendar(DateTime selectedDate, int roomID, IBooking? booking, bool isAnEdit)
        {
            var calendarContent = new StringWriter();

            calendarContent.WriteLine($"[red]{selectedDate:MMMM}[/]".ToUpper());
            calendarContent.WriteLine("Mån  Tis  Ons  Tor  Fre  Lör  Sön");
            calendarContent.WriteLine("─────────────────────────────────");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = startDay == 0 ? 6 : startDay - 1; 

            var _isInactive = false;
            bool _getRelatedObjects = true;
            var _existingBookings = BookingService.GetAll(_getRelatedObjects, _isInactive).Where(b => b.RoomID == roomID);
            var _occupiedDatesPerBooking = new List<DateTime>();
            var _occupiedDates = new List<DateTime>();
            var _occupiedDatesForThisBooking = new List<DateTime>();

            foreach (var b in _existingBookings)
            {
                if (booking != null)
                {
                    if (b.ID == booking.ID)
                    {
                        _occupiedDatesPerBooking = BookedDateSplitter.SplitDates(b);
                        _occupiedDatesPerBooking.ForEach(d => _occupiedDatesForThisBooking.Add(d));
                    }
                    else
                    {
                        _occupiedDatesPerBooking = BookedDateSplitter.SplitDates(b);
                        _occupiedDatesPerBooking.ForEach(d => _occupiedDates.Add(d));
                    }
                }
                else
                {
                    _occupiedDatesPerBooking = BookedDateSplitter.SplitDates(b);
                    _occupiedDatesPerBooking.ForEach(d => _occupiedDates.Add(d));
                }
            }

            for (int i = 0; i < startDay; i++)
            {
                calendarContent.Write("     ");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                    calendarContent.Write($"[green]{day,2}[/]   ");
                else if (_occupiedDatesForThisBooking.Any(d => d.Day == day))
                    calendarContent.Write($"[yellow]{day,2}[/]   "); // previous dates for this booking 
                else if (_occupiedDates.Any(d => d.Day == day))
                    calendarContent.Write($"[red]{day,2}[/]   "); // occupied dates for selected room
                else
                {
                    calendarContent.Write($"{day,2}   ");
                }

                if ((startDay + day) % 7 == 0)
                {
                    calendarContent.WriteLine();
                }
            }

            var panel = new Panel(calendarContent.ToString())
            {
                Border = BoxBorder.Double,
                Header = new PanelHeader($"[red]{selectedDate:yyyy}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [blue]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }

        public static DateTime SetStartDate()
        {
            return DateTime.Now;
        }
        public static DateTime SetStartDate(int year)
        {
            return new DateTime(year, 1, 1);
        }
        public static DateTime SetStartDate(int year, int month)
        {
            return new DateTime(year, month, 1);
        }
        public static DateTime SetStartDate(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }

    }
}
