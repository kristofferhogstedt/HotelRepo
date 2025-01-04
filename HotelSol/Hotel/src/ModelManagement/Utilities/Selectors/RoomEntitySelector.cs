using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Displayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Selectors
{
    public class RoomEntitySelector
    {
        public static IRoom Select(List<IRoom> entityList, int startIndex, IMenu previousMenu)
        {
            int _selectedIndex = startIndex;

            while (true)
            {
                Console.Clear();
                RoomDisplayer.RenderTable(entityList, _selectedIndex);

                var _key = Console.ReadKey(true).Key;

                switch (_key)
                {
                    case ConsoleKey.UpArrow:
                        _selectedIndex = --_selectedIndex;
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedIndex = ++_selectedIndex;
                        break;
                    case ConsoleKey.Enter:
                        return entityList.ElementAt(_selectedIndex);
                    case ConsoleKey.Escape:
                        previousMenu.Run();
                        break;
                }
            }
        }
    }
}
