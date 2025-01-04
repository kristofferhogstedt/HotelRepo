using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Displayers
{
    internal class AddressDisplayer_DELETE
    {
        //public static void RenderDeadTable(List<IAddress> entityList, IMenu previousMenu)
        //{
        //    var _entityArray = entityList.ToArray();
        //    var _tableContent = new StringWriter();

        //    // Kalenderhuvud
        //    //_tableContent.WriteLine($"[red]{entityList.ElementAt(indexToHighlight).FirstName} {entityList.ElementAt(indexToHighlight).LastName}[/]".ToUpper());
        //    _tableContent.WriteLine("ID  Gatuadress  Postnummer  Stad  Land");
        //    _tableContent.WriteLine("──────────────────────────────────────");

        //    //DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
        //    //int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
        //    //int startDay = (int)firstDayOfMonth.DayOfWeek;
        //    //startDay = startDay == 0 ? 6 : startDay - 1; // Justera för måndag som veckostart

        //    // Fyll med tomma platser innan första dagen i månaden
        //    //for (int i = 0; i < startDay; i++)
        //    //{
        //    //    _tableContent.Write("     ");
        //    //}

        //    // Skriv ut dagarna
        //    for (int i = 0; i < _entityArray.Length; i++)
        //    {
        //        _tableContent.WriteLine($"{_entityArray[i].Info}   ");

        //        // Gå till nästa rad efter söndag
        //        //if ((startDay + day) % 7 == 0)
        //        //{
        //        //    _tableContent.WriteLine();
        //        //}
        //    }

        //    // Skapa en panel med dubbla kanter
        //    var panel = new Panel(_tableContent.ToString())
        //    {
        //        Border = BoxBorder.Double,
        //        //Header = new PanelHeader($"[red]{_entityArray[indexToHighlight].FirstName} {_entityArray[indexToHighlight].LastName}[/]", Justify.Center)
        //    };

        //    AnsiConsole.Write(panel);
        //    Console.WriteLine();
        //}
    }
}
