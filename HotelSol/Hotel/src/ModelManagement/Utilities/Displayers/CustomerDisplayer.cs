using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Displayers
{
    public class CustomerDisplayer
    {
        public static void DisplayModelTable(List<ICustomer> customers)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");

            foreach (var customer in customers)
            {
                table.AddRow(
                    customer.ID.ToString(),
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.Phone
                    );
            }

            AnsiConsole.Write(table);

            //Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
            //Console.ReadLine();
            //Console.Clear();
        }


        public static void RenderTableHighlight(List<ICustomer> customerList, int indexToHighlight)
        {
            var customerArray = customerList.ToArray();

            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");

            for (int i = 0; i < customerArray.Length; i++)
            {
                //calendarContent.Write($"[green]{day,2}[/]   ");

                if (i == indexToHighlight)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    RowContent(i);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                    RowContent(i);
            }

            void RowContent(int i)
            {
                table.AddRow(
                    $"[red]{customerArray[i].ID.ToString()}[/]",
                    customerArray[i].FirstName,
                    customerArray[i].LastName,
                    customerArray[i].Email,
                    customerArray[i].Phone
                    );
            }

            AnsiConsole.Write(table);

            //Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
            //Console.ReadLine();
            //Console.Clear();
        }

        public static void DisplayModel(ICustomer customer)
        {
            var panel = new Panel($@"
                Id: {customer.ID}
                Namn: {customer.FirstName}
                Namn: {customer.LastName}
                E-post: {customer.Email}
                Telefon: {customer.Phone}
            ");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            //Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
            //Console.ReadLine();
            //Console.Clear();
        }

        public static void RenderTable(List<ICustomer> customerList, int indexToHighlight)
        {
            var customerArray = customerList.ToArray();
            var _tableContent = new StringWriter();

            // Kalenderhuvud
            _tableContent.WriteLine($"[red]{customerList.ElementAt(indexToHighlight).FirstName} {customerList.ElementAt(indexToHighlight).LastName}[/]".ToUpper());
            _tableContent.WriteLine("ID  Förnamn  Efternamn  Född  E-post  Telefon");
            _tableContent.WriteLine("─────────────────────────────────────────────");

            //DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            //int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            //int startDay = (int)firstDayOfMonth.DayOfWeek;
            //startDay = startDay == 0 ? 6 : startDay - 1; // Justera för måndag som veckostart

            // Fyll med tomma platser innan första dagen i månaden
            //for (int i = 0; i < startDay; i++)
            //{
            //    _tableContent.Write("     ");
            //}

            // Skriv ut dagarna
            for (int i = 0; i < customerArray.Length; i++)
            {
                if (i == indexToHighlight)
                {
                    // Siffran 2 sätter minimum bredd (även om 1 siffra)
                    _tableContent.WriteLine($"[green]{customerArray[i].Info}[/]   ");
                }
                else
                {
                    _tableContent.WriteLine($"{customerArray[i].Info}   ");
                }

                // Gå till nästa rad efter söndag
                //if ((startDay + day) % 7 == 0)
                //{
                //    _tableContent.WriteLine();
                //}
            }

            // Skapa en panel med dubbla kanter
            var panel = new Panel(_tableContent.ToString())
            {
                Border = BoxBorder.Double,
                Header = new PanelHeader($"[red]{customerArray[indexToHighlight].FirstName} {customerArray[indexToHighlight].LastName}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [blue]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }
    }
}
