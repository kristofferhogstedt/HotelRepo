using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Utilities.Checkers;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Spectre.Console;

namespace Hotel.src.MenuManagement.Menus
{
    public class CustomerMenu : IMenu, IInstantiable, IControllable, IHandleInactives
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
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
                        if (DataElementChecker.CheckCustomerDataExists(HandleInactive))
                            ModelController.ManageOne(HandleInactive);
                        else
                            ServiceMessager.DataNotFoundMessage();
                        break;
                    case CustomerMenuOptions.CreateCustomer:
                        ModelController.Create();
                        break;
                    case CustomerMenuOptions.DisplayInactive:
                        HandleInactive = true;
                        if (DataElementChecker.CheckCustomerDataExists(HandleInactive))
                            ModelController.ManageOne(HandleInactive);
                        else
                            ServiceMessager.DataNotFoundMessage();
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
