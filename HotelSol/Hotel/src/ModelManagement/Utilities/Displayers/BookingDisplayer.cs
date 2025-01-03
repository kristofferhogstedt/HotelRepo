using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Displayers
{
    public class BookingDisplayer
    {
        public static void DisplayModelTable(List<IBooking> entities)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");

            foreach (var entity in entities)
            {
                table.AddRow(
                    entity.ID.ToString(),
                    entity.CustomerID.ToString(),
                    entity.RoomID.ToString(),
                    entity.FromDate.ToString(),
                    entity.ToDate.ToString()
                    );
            }

            AnsiConsole.Write(table);
        }


        public static void RenderTableHighlight(List<IBooking> entityList, int indexToHighlight)
        {
            var _entityArray = entityList.ToArray();

            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");

            for (int i = 0; i < _entityArray.Length; i++)
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
                    $"[red]{_entityArray[i].ID.ToString()}[/]",
                    _entityArray[i].CustomerID.ToString(),
                    _entityArray[i].RoomID.ToString(),
                    _entityArray[i].FromDate.ToString(),
                    _entityArray[i].ToDate.ToString()
                    );
            }

            AnsiConsole.Write(table);
        }

        public static void DisplayModel(IBooking entity)
        {
            var panel = new Panel($@"
                Id: {entity.ID}
                Namn: {entity.CustomerID.ToString()}
                Namn: {entity.RoomID.ToString()}
                E-post: {entity.FromDate.ToString()}
                Telefon: {entity.ToDate.ToString()}
            ");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);
        }

        public static void RenderTable(List<IBooking> entityList, int indexToHighlight)
        {
            var _entityArray = entityList.ToArray();
            var _tableContent = new StringWriter();

            _tableContent.WriteLine($"[red]{entityList.ElementAt(indexToHighlight).ID} {entityList.ElementAt(indexToHighlight).CustomerID}[/]".ToUpper());
            _tableContent.WriteLine("ID  Förnamn  Efternamn  Född  E-post  Telefon");
            _tableContent.WriteLine("─────────────────────────────────────────────");

            for (int i = 0; i < _entityArray.Length; i++)
            {
                if (i == indexToHighlight)
                {
                    _tableContent.WriteLine($"[green]{_entityArray[i].Info}[/]   ");
                }
                else
                {
                    _tableContent.WriteLine($"{_entityArray[i].Info}   ");
                }
            }

            var panel = new Panel(_tableContent.ToString())
            {
                Border = BoxBorder.Double,
                Header = new PanelHeader($"[red]{_entityArray[indexToHighlight].ID} {_entityArray[indexToHighlight].CustomerID}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [blue]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }
    }
}
