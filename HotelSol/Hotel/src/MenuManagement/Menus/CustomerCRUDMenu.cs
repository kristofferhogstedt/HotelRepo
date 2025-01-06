using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    // NOT IN USE
    public class CustomerCRUDMenu //: IMenu, ICRUDMenu, IInstantiable, IControllable
    {
        //public IMenu PreviousMenu { get; set; }
        //private static IInstantiable _instance;
        //private static readonly object _lock = new object();
        //public EModelType ModelType { get; set; } = EModelType.Customer;
        //public IModelController ModelController { get; set; }
        //IModel _customer;

        //public static ICRUDMenu GetInstance(IMenu previousMenu)
        //{
        //    _instance = FactoryManagement.InstanceGenerator.GetInstance<CustomerCRUDMenu>(_instance, _lock, previousMenu);

        //    return (CustomerCRUDMenu)_instance;
        //}

        //public void Run()
        //{
        //    ModelController = ModelFactory.GetModelController(ModelType, this);
        //    while (true)
        //    {
        //        // Sprectre menyval!
        //        var option = AnsiConsole.Prompt(
        //            new SelectionPrompt<CRUDMenuOptions>()
        //                .Title("Start")
        //                .UseConverter(option => option.ShowCRUDMenu())
        //                .AddChoices(Enum.GetValues<CRUDMenuOptions>())
        //            );

        //        switch (option)
        //        {
        //            case CRUDMenuOptions.PreviousMenu:
        //                PreviousMenu.Run();
        //                break;
        //            case CRUDMenuOptions.Update:
        //                ModelController.Create();
        //                break;
        //            case CRUDMenuOptions.Exit:
        //                Exit.ExitProgram();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        //public void Run(IModel modelToCRUD) 
        //{
        //    while (true)
        //    {
        //        // Sprectre menyval!
        //        var option = AnsiConsole.Prompt(
        //            new SelectionPrompt<CRUDMenuOptions>()
        //                .Title("Start")
        //                .UseConverter(option => option.ShowCRUDMenu())
        //                .AddChoices(Enum.GetValues<CRUDMenuOptions>())
        //            );

        //        switch (option)
        //        {
        //            case CRUDMenuOptions.PreviousMenu:
        //                PreviousMenu.Run();
        //                break;
        //            case CRUDMenuOptions.Update:
        //                var _controller = CustomerController.GetInstance(this);
        //                _controller.Update(modelToCRUD);
        //                break;
        //            case CRUDMenuOptions.Exit:
        //                Exit.ExitProgram();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
