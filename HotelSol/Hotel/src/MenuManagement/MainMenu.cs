using Hotel.src.MenuManagement;
using Hotel.src.MenuManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManager
{
    internal class MainMenu : Menu, IMenu, IPreviousMenu
    {
        Dictionary<int, string> MenuSelection { get; init; }
        //IMenu _previousMenu;

        public MainMenu(IPreviousMenu previousMenu) : base(previousMenu)
        {
            //_previousMenu = previousMenu;
            MenuSelection = new Dictionary<int, string>();
            MenuSelection.Add(0, "Föregående meny");
            MenuSelection.Add(1, "Artikelhantering");
            MenuSelection.Add(2, "Kampanjhantering");
            MenuSelection.Add(9, "Avsluta");
        }
    }
}
