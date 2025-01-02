using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class CustomerMenu : IMenu
    {
        private static IModelController _controller = FactoryManagement.ModelFactory.GetModelController();

        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                // Sprectre menyval!
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CustomerMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCustomerMenu())
                        .AddChoices(Enum.GetValues<CustomerMenuOptions>())
                    );

                switch (option)
                {
                    case CustomerMenuOptions.PreviousMenu:
                        MainMenu.Run();
                        break;
                    case CustomerMenuOptions.DisplayCustomer:
                        _controller.ReadSpecific();
                        break;
                    case CustomerMenuOptions.DisplayCustomerAll:
                        _controller.ReadAll();
                        break;
                    case CustomerMenuOptions.CreateCustomer:
                        _controller.Create();
                        break;
                    case CustomerMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
