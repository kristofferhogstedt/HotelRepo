using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;

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
            table.AddColumn("Antal bokningar");
            table.AddColumn("Antal bokningar");
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
                    entityArray[i].DateOfBirth.Date.ToString(),
                    entityArray[i].Phone,
                    entityArray[i].Email,
                    entityArray[i].StreetAddress,
                    entityArray[i].PostalCode,
                    entityArray[i].City,
                    entityArray[i].Country
                    );
            }

            AnsiConsole.Write(table);
        }

        public static void DisplayModel(ICustomer entity)
        {
            var panel = new Panel($@"
        [yellow]ID:[/]             {entity.ID}
        [yellow]Förnamn:[/]        {entity.FullName}
        [yellow]Efternamn:[/]      {entity.LastName}
        [yellow]Födelsedatum:[/]   {entity.DateOfBirth.Date}
        [yellow]Telefon:[/]        {entity.Phone}
        [yellow]E-Post:[/]         {entity.Email}
        [yellow]Gatuadress:[/]     {entity.StreetAddress}
        [yellow]Postkod:[/]        {entity.PostalCode}
        [yellow]Stad:[/]           {entity.City}
        [yellow]Land:[/]           {entity.Country}
            ");
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);
        }

        public static void RenderTable(List<ICustomer> entityList, int indexToHighlight)
        {
            var _entityArray = entityList.ToArray();
            var _tableContent = new StringWriter();

            _tableContent.WriteLine($"[red]{entityList.ElementAt(indexToHighlight).FirstName} {entityList.ElementAt(indexToHighlight).LastName}[/]".ToUpper());
            _tableContent.WriteLine("       Namn        |      E-post      |   Telefon");
            _tableContent.WriteLine("─────────────────────────────────────────────────");

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
                Header = new PanelHeader($"[red]{_entityArray[indexToHighlight].FirstName} {_entityArray[indexToHighlight].LastName}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [blue]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }
    }
}
