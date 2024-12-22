using Hotel.src.MenuManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement
{
    public class Menu : IMenu, IPreviousMenu
    {
        Dictionary<int, string> MenuSelection { get; init; }
        IPreviousMenu _previousMenu;

        public Menu(IPreviousMenu previousMenu)
        {
            //_previousMenu = previousMenu;
            MenuSelection = new Dictionary<int, string>();
            MenuSelection.Add(1, "Start");
            MenuSelection.Add(9, "Avsluta");
        }

        public void Show()
        {
            MenuDisplay.DisplayMenu(MenuSelection);
        }

        public void Select()
        {
            throw new NotImplementedException();
        }
        public void Return()
        {
        }
    }
}
