using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Selectors.Utilities;

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
                        return entityList.ElementAt(_selectedIndex); 
                    case ConsoleKey.Escape:
                        previousMenu.Run(); 
                        break;
                }
            }
        }
    }
}
