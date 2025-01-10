using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class StartMenu : IMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();

        public static IMenu GetInstance()
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<StartMenu>(_instance, _lock);

            return (StartMenu)_instance;
        }

        public void Run()
        {
            while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<StartMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowStartMenu())
                        .AddChoices(Enum.GetValues<StartMenuOptions>())
                    );


                switch (option)
                {
                    case StartMenuOptions.Login:
                        Settings.IsAdmin = false;
                        IMenu _mainMenu = MainMenu.GetInstance(this);
                        _mainMenu.Run();
                        break;
                    //case StartMenuOptions.AdminLogin:
                    //    Settings.IsAdmin = true;
                    //    MainMenu.Run();
                    //    break;
                    case StartMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}