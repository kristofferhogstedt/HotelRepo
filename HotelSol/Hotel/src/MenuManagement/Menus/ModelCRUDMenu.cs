using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Checkers;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Spectre.Console;

namespace Hotel.src.MenuManagement.Menus
{
    public class ModelCRUDMenu : IMenu, ICRUDMenu, IInstantiable
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
            Console.WriteLine("Återgår till huvudmeny");
            Thread.Sleep(1500);
            MainMenu.ReturnToMainMenu();
        }

        public void Run(IModel entityToCRUD)
        {
            switch (entityToCRUD.ModelTypeEnum)
            {
                case EModelType.Room:
                    RoomCRUDMenu(entityToCRUD);
                    break;
                case EModelType.Booking:
                    BookingCRUDMenu(entityToCRUD);
                    break;
                case EModelType.Invoice:
                    InvoiceCRUDMenu(entityToCRUD);
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

        public void BookingCRUDMenu(IModel entityToCRUD)
        {
            var _controller = ModelFactory.GetModelController(entityToCRUD.ModelTypeEnum, this);
            while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<BookingCRUDMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCRUDMenu())
                        .AddChoices(Enum.GetValues<BookingCRUDMenuOptions>())
                    );

                switch (option)
                {
                    case BookingCRUDMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case BookingCRUDMenuOptions.Update:
                        _controller.Update(entityToCRUD);
                        break;
                    case BookingCRUDMenuOptions.OpenInvoice:
                        var _invoiceController = ModelFactory.GetModelController(EModelType.Invoice, this);
                        var _entityToCRUD = entityToCRUD as IBooking;
                        if (DataElementChecker.CheckInvoiceDataExistsByBookingID(_entityToCRUD.ID))
                            InvoiceCRUDMenu(_entityToCRUD.Invoice);
                        else
                            ServiceMessager.DataNotFoundMessage();
                        break;
                    case BookingCRUDMenuOptions.Inactivate:
                        _controller.Delete(entityToCRUD);
                        break;
                    case BookingCRUDMenuOptions.Reactivate:
                        _controller.Reactivate(entityToCRUD);
                        break;
                    case BookingCRUDMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }

        public void InvoiceCRUDMenu(IModel entityToCRUD)
        {
            var _controller = ModelFactory.GetModelController(entityToCRUD.ModelTypeEnum, this);
            while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<InvoiceCRUDMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCRUDMenu())
                        .AddChoices(Enum.GetValues<InvoiceCRUDMenuOptions>())
                    );

                switch (option)
                {
                    case InvoiceCRUDMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case InvoiceCRUDMenuOptions.Update:
                        _controller.Update(entityToCRUD);
                        break;
                    case InvoiceCRUDMenuOptions.Exit:
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
