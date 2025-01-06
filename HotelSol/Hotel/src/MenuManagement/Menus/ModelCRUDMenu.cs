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
    public class ModelCRUDMenu: IMenu, ICRUDMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        IModel _model;

        public static ICRUDMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<ModelCRUDMenu>(_instance, _lock, previousMenu);

            return (ModelCRUDMenu)_instance;
        }

        public void Run()
        {
            while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CRUDMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCRUDMenu())
                        .AddChoices(Enum.GetValues<CRUDMenuOptions>())
                    );

                switch (option)
                {
                    case CRUDMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    //case CRUDMenuOptions.Update:
                    //    var _controller = ModelFactory.GetModelController(, this);
                    //    _controller.Create();
                    //    break;
                    case CRUDMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Run(IModel modelToCRUD)
        {
            Console.Clear();
            while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CRUDMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCRUDMenu())
                        .AddChoices(Enum.GetValues<CRUDMenuOptions>())
                    );

                switch (option)
                {
                    case CRUDMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case CRUDMenuOptions.Update:
                        var _controller = ModelFactory.GetModelController(modelToCRUD.ModelTypeEnum, this);
                        _controller.Update(modelToCRUD);
                        break;
                    case CRUDMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
