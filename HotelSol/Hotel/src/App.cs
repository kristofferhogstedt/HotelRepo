using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Interfaces;
using HotelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src
{
    public class App : IApp
    {
        IMenu _menu;

        public App(IMenu menu)
        {
            _menu = menu;
        }

        public void Run()
        {
            _menu.Show();
        }
    }
}
