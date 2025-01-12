using Hotel.src.FactoryManagement;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Persistence;
using Hotel.src.Persistence.Interfaces;

namespace Hotel
{
    public class App : IApp
    {
        IMenu _menu;
        public static IDatabaseLair AppDatabase;

        public App(IMenu menu)
        {
            ModelFactory _factory = new ModelFactory();
            AppDatabase = DatabaseLair.GetInstance();
        }

        public void Run()
        {
            AppDatabase.SeedDatabase(); // Seed and display successful seed messages
            Thread.Sleep(2000);
            Console.Clear();

            IMenu _startMenu = StartMenu.GetInstance();

            _startMenu.Run();

            Exit.ExitProgram();
        }
    }
}
