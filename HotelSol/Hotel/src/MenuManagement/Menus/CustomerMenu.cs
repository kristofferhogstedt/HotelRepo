using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Spectre.Console;

namespace Hotel.src.MenuManagement.Menus
{
    public class CustomerMenu : IMenu, IInstantiable, IControllable, IHandleInactives
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        //private static IModelController ModelController;
        public EModelType ModelType { get; set; } = EModelType.Customer;
        public IModelController ModelController { get; set; }
        public bool HandleInactive { get; set; }

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
            ModelController = ModelFactory.GetModelController(ModelType, this);

            while (true)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CustomerMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCustomerMenu())
                        .AddChoices(Enum.GetValues<CustomerMenuOptions>())
                    );

                switch (option)
                {
                    case CustomerMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case CustomerMenuOptions.DisplayCustomer:
                        HandleInactive = false;
                        ModelController.ManageOne(HandleInactive);
                        break;
                    case CustomerMenuOptions.CreateCustomer:
                        ModelController.Create();
                        break;
                    //case CustomerMenuOptions.DisplayCustomerAll:
                    //    ModelController.ReadAll();
                    //    break;
                    //case CustomerMenuOptions.UpdateCustomer:
                    //    ModelController.Update();
                    //    break;
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
