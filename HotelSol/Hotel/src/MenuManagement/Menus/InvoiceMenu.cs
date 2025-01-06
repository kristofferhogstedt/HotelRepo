using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class InvoiceMenu : IMenu, IInstantiable, IControllable, IHandleInactives
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        public EModelType ModelType { get; set; } = EModelType.Invoice;
        public IModelController ModelController { get; set; }
        public bool HandleInactive { get; set; }

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<InvoiceMenu>(_instance, _lock, previousMenu);

            return (InvoiceMenu)_instance;
        }

        public void Run()
        {
            Console.Clear();
            ModelController = ModelFactory.GetModelController(ModelType, this);
            while (true)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<InvoiceMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowInvoiceMenu())
                        .AddChoices(Enum.GetValues<InvoiceMenuOptions>())
                    );

                switch (option)
                {
                    case InvoiceMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case InvoiceMenuOptions.DisplayInvoices:
                        HandleInactive = false;
                        ModelController.ManageOne(HandleInactive);
                        break;
                    case InvoiceMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
