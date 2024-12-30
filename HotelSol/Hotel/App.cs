using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.Persistence;
using Hotel.src.Persistence.Interfaces;
using HotelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class App : IApp
    {
        IMenu _menu;
        public IDatabaseLair _databaseLair;

        public App(IMenu menu)
        {
            //_menu = menu;
            _databaseLair = DatabaseLair.GetInstance();
        }

        public void Run()
        {
            _databaseLair.CreateDbConnection();
            DatabaseLair.SeedAndMigrate();
            StartMenu.Run();
        }
    }
}
