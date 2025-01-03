using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class CustomerCRUDMenu : IMenu, ICRUDMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        IModel _customer;

        public static ICRUDMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<CustomerCRUDMenu>(_instance, _lock, previousMenu);

            return (CustomerCRUDMenu)_instance;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Run(IModel modelToCRUD) 
        {
            while (true)
            {
                // Sprectre menyval!
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CustomerCRUDMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCustomerCRUDMenu())
                        .AddChoices(Enum.GetValues<CustomerCRUDMenuOptions>())
                    );

                switch (option)
                {
                    case CustomerCRUDMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case CustomerCRUDMenuOptions.Update:
                        var _controller = CustomerController.GetInstance(this);
                        _controller.Update(modelToCRUD);
                        break;
                    case CustomerCRUDMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
