﻿using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Displayers.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Displayers
{
    public class RoomDisplayer //: IModelDisplayer
    {      
        public static void RenderTable(List<IRoom> entityList, int indexToHighlight)
        {
            var _entityArray = entityList.ToArray();
            var _tableContent = new StringWriter();
            //if (indexToHighlight < 0)
            //{
            //    indexToHighlight = _entityArray.Length-1;
            //}
            //else if (indexToHighlight >= _entityArray.Length)
            //{
            //    indexToHighlight = 0;
            //}

            _tableContent.WriteLine($"[red]{indexToHighlight} - {entityList.ElementAt(indexToHighlight).Name}" +
                $",  Våning {entityList.ElementAt(indexToHighlight).Floor}" +
                $"[/]".ToUpper());
            _tableContent.WriteLine("Rumsnummer  Beskrivning  Våning     Typ        Pris        Storlek     Antal sängar");
            _tableContent.WriteLine("────────────────────────────────────────────────────────────────────────────");

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
                Header = new PanelHeader($"[red]Vån. {_entityArray[indexToHighlight].Floor} / {_entityArray[indexToHighlight].Description}[/]", Justify.Center)
            };

            AnsiConsole.Write(panel);
            Console.WriteLine();
            AnsiConsole.MarkupLine("\nAnvänd piltangenter [blue]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }

        public static void DisplayModel(IRoom entity)
        {
            var panel = new Panel($@"
        [yellow]Rumsnummer:[/]      {entity.Name}
        [yellow]Beskrivning:[/]     {entity.Description}
        [yellow]Våning:[/]          {entity.Floor}
        [yellow]Rumstyp:[/]         {entity.Details.RoomType.Name}
        [yellow]Storlek:[/]         {entity.Details.Size} m2
        [yellow]Antal sängar:[/]    {entity.Details.NumberOfBeds} st
        [yellow]Pris:[/]            {entity.Details.Price} sek/natt
            ");
            panel.Header = new PanelHeader("Ruminfo");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);
        }

        public static void DisplayModelTable(List<IRoom> entityList)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Rumsnummer");
            table.AddColumn("Beskrivning");
            table.AddColumn("Våning");

            foreach (var entity in entityList)
            {
                table.AddRow(
                    entity.ID.ToString(),
                    entity.Name,
                    entity.Description,
                    entity.Floor.ToString()
                    );
            }

            AnsiConsole.Write(table);
        }
    }
}
