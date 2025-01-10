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
    public class ModelCRUDMenu : IMenu, ICRUDMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public IMenu MainMenu { get; set; } = MenuFactory.GetMenu<MainMenu>();
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
            Console.WriteLine("Återgår till huvudmeny");
            Thread.Sleep(1500);
            MainMenu.Run();
        }

        public void Run(IModel entityToCRUD)
        {
            switch (entityToCRUD.ModelTypeEnum)
            {
                case EModelType.Room:
                    RoomCRUDMenu(entityToCRUD);
                    break;
                default:
                    GeneralCRUDMenu(entityToCRUD);
                    break;
            }
        }

        public void GeneralCRUDMenu(IModel entityToCRUD)
        {
            var _controller = ModelFactory.GetModelController(entityToCRUD.ModelTypeEnum, this);
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
                        _controller.Update(entityToCRUD);
                        break;
                    case CRUDMenuOptions.Inactivate:
                        _controller.Delete(entityToCRUD);
                        break;
					case CRUDMenuOptions.Reactivate:
						_controller.Reactivate(entityToCRUD);
						break;
					case CRUDMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }

        public void RoomCRUDMenu(IModel entityToCrud)
        {
            var _controller = (IRoomController)ModelFactory.GetModelController(entityToCrud.ModelTypeEnum, this);
			var _roomToCrud = (IRoom)entityToCrud;
			while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<RoomCRUDMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCRUDMenu())
                        .AddChoices(Enum.GetValues<RoomCRUDMenuOptions>())
                    );

                switch (option)
                {
                    case RoomCRUDMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case RoomCRUDMenuOptions.Update:
                        _controller.Update(entityToCrud);
                        break;
                    case RoomCRUDMenuOptions.UpdateBeds:
                        _roomToCrud = (IRoom)entityToCrud;
                        var _roomDetailsToCRUD = _roomToCrud.Details;
                        _controller.UpdateBeds(_roomDetailsToCRUD);
                        break;
					case RoomCRUDMenuOptions.Inactivate:
						_controller.Delete(_roomToCrud);
						break;
					case RoomCRUDMenuOptions.Reactivate:
						_controller.Reactivate(_roomToCrud);
						break;
					case RoomCRUDMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
