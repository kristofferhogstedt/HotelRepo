using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Spectre.Console;

namespace Hotel.src.MenuManagement.Menus
{
    public class CustomerMenu : IMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        private static IModelController _controller;

        public CustomerMenu()
        {
        }

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<CustomerMenu>(_instance, _lock, previousMenu);
            
            return (CustomerMenu)_instance;
        }

        public void Run()
        {
            _controller = ModelFactory.GetModelController(PreviousMenu);

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
                        _instance.PreviousMenu.Run();
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
                    case CustomerMenuOptions.UpdateCustomer:
                        _controller.Update();
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
