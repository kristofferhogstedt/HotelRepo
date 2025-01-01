using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static DateTime DateSelector(DateTime startDate)
        {
            // Startdatum (början av månaden)
            //DateTime _currentDate = DateTime.Now;
            //DateTime _currentDate = SetStartDate();
            DateTime _selectedDate = startDate;

            while (true)
            {
                Console.Clear();
                RenderCalendar(_selectedDate);

                // Läsa användarens tangent
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
                        AnsiConsole.MarkupLine($"\nDu valde: [green]{_selectedDate:yyyy-MM-dd}[/]");
                        return _selectedDate; // Avslutar loopen
                    case ConsoleKey.Escape:
                        return DateTime.MinValue; // Avbryter valet
                }
            }
        }

        private static void RenderCalendar(DateTime selectedDate)
        {
            var calendarContent = new StringWriter();

            // Kalenderhuvud
            calendarContent.WriteLine($"[red]{selectedDate:MMMM}[/]".ToUpper());
            calendarContent.WriteLine("Mån  Tis  Ons  Tor  Fre  Lör  Sön");
            calendarContent.WriteLine("─────────────────────────────────");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = startDay == 0 ? 6 : startDay - 1; // Justera för måndag som veckostart

            // Fyll med tomma platser innan första dagen i månaden
            for (int i = 0; i < startDay; i++)
            {
                calendarContent.Write("     ");
            }

            // Skriv ut dagarna
            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                {
                    // Siffran 2 sätter minimum bredd (även om 1 siffra)
                    calendarContent.Write($"[green]{day,2}[/]   ");
                }
                else
                {
                    calendarContent.Write($"{day,2}   ");
                }

                // Gå till nästa rad efter söndag
                if ((startDay + day) % 7 == 0)
                {
                    calendarContent.WriteLine();
                }
            }

            // Skapa en panel med dubbla kanter
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
        public static DateTime SetStartDate(ushort year)
        {
            return new DateTime(year, 1, 1);
        }
        public static DateTime SetStartDate(ushort year, ushort month)
        {
            return new DateTime(year, month, 1);
        }
        public static DateTime SetStartDate(ushort year, ushort month, ushort day)
        {
            return new DateTime(year, month, day);
        }

    }
}
