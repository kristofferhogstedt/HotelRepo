using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Displayers
{
    public class InvoiceDisplayer
    {
        public static void DisplayModelTable(List<IInvoice> entityList)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Förnamn");
            table.AddColumn("EfterNamn");
            table.AddColumn("E-Post");
            table.AddColumn("Telefon");

            foreach (var entity in entityList)
            {
                table.AddRow(
                    entity.ID.ToString(),
                    entity.DueDate.ToString(),
                    entity.IsPaid.ToString(),
                    entity.PaidDate.ToString()
                    );
            }

            AnsiConsole.Write(table);
        }


        public static void RenderTableHighlight(List<IInvoice> entityList, int indexToHighlight)
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
                    _entityArray[i].DueDate.ToString(),
                    _entityArray[i].IsPaid.ToString(),
                    _entityArray[i].PaidDate.ToString()
                    );
            }

            AnsiConsole.Write(table);
        }

        public static void DisplayModel(IInvoice entity)
        {
            var panel = new Panel($@"
        [yellow]Kund:[/]            {entity.Booking.Customer.FullName}
        [yellow]Summa:[/]           {entity.Amount} sek
        [yellow]Förfallodatum:[/]   {entity.DueDate.Date.ToString()}
        [yellow]Betald?:[/]         {entity.IsPaid}
            ");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);
        }

        public static void RenderTable(List<IInvoice> entityList, int indexToHighlight)
        {
            var _entityArray = entityList.ToArray();
            var _tableContent = new StringWriter();

            _tableContent.WriteLine($"[red]{entityList.ElementAt(indexToHighlight).ID} {entityList.ElementAt(indexToHighlight).DueDate}[/]".ToUpper());
            _tableContent.WriteLine("Kund               |   Summa   |   Förfallodatum   |  Betald?");
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
                Header = new PanelHeader($"[red]{_entityArray[indexToHighlight].ID} {_entityArray[indexToHighlight].DueDate}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [blue]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }
    }
}
