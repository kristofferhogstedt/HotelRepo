using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Displayers;
using Hotel.src.ModelManagement.Utilities.Selectors.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Selectors
{
    public class ModelEntitySelector
    {
        public static IModel Select(List<IModel> entityList, int startIndex, IMenu previousMenu)
        {
            int _selectedIndex = startIndex;

            while (true)
            {
                Console.Clear();
                //CustomerDisplayer.RenderTable(entityList, _selectedIndex);
                //CustomerDisplayer.RenderTableHighlight(listOfCustomers, _selectedIndex);

                // Läsa användarens tangent
                var _key = Console.ReadKey(true).Key;

                switch (_key)
                {
                    case ConsoleKey.UpArrow:
                        _selectedIndex = --_selectedIndex;
                        TopAndBottomAdjuster.AdjustTopBottom(ref _selectedIndex, entityList.Count);
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedIndex = ++_selectedIndex;
                        TopAndBottomAdjuster.AdjustTopBottom(ref _selectedIndex, entityList.Count);
                        break;
                    case ConsoleKey.Enter:
                        //AnsiConsole.MarkupLine($"\nFödelsedatum: [green]{_selectedDate:yyyy-MM-dd}[/]");
                        return entityList.ElementAt(_selectedIndex); // Avslutar loopen
                    case ConsoleKey.Escape:
                        previousMenu.Run(); // Avbryter valet
                        break;
                }
            }
        }
    }
}
