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
        public static void DisplayModelTable(List<ICustomer> entityList)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");
            table.AddColumn("Antal bokningar");

            foreach (var entity in entityList)
            {
                table.AddRow(
                    entity.ID.ToString(),
                    entity.FirstName,
                    entity.LastName,
                    entity.Email,
                    entity.Phone,
                    entity.Info
                    );
            }

            AnsiConsole.Write(table);
        }


        public static void RenderTableHighlight(List<ICustomer> entityList, int indexToHighlight)
        {
            var entityArray = entityList.ToArray();

            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");
            table.AddColumn("Antal bokningar");

            for (int i = 0; i < entityArray.Length; i++)
            {
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
                    $"[red]{entityArray[i].ID.ToString()}[/]",
                    entityArray[i].FirstName,
                    entityArray[i].LastName,
                    entityArray[i].Email,
                    entityArray[i].Phone,
                    entityArray[i].Info
                    );
            }

            AnsiConsole.Write(table);
        }

        public static void DisplayModel(ICustomer entity)
        {
            var panel = new Panel($@"
                Id: {entity.ID}
                Namn: {entity.FullName}
                Namn: {entity.LastName}
                E-post: {entity.Email}
                Telefon: {entity.Phone}
                Telefon: {entity.Info}
            ");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);
        }

        public static void RenderTable(List<ICustomer> entityList, int indexToHighlight)
        {
            var _entityArray = entityList.ToArray();
            var _tableContent = new StringWriter();

            // Kalenderhuvud
            _tableContent.WriteLine($"[red]{entityList.ElementAt(indexToHighlight).FirstName} {entityList.ElementAt(indexToHighlight).LastName}[/]".ToUpper());
            _tableContent.WriteLine("ID  Namn       Född     E-post     Telefon     Bokningar");
            _tableContent.WriteLine("────────────────────────────────────────────────────────");

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
            for (int i = 0; i < _entityArray.Length; i++)
            {
                if (i == indexToHighlight)
                {
                    // Siffran 2 sätter minimum bredd (även om 1 siffra)
                    _tableContent.WriteLine($"[green]{_entityArray[i].Info}[/]   ");
                }
                else
                {
                    _tableContent.WriteLine($"{_entityArray[i].Info}   ");
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
                Header = new PanelHeader($"[red]{_entityArray[indexToHighlight].FirstName} {_entityArray[indexToHighlight].LastName}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [blue]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }
    }
}
