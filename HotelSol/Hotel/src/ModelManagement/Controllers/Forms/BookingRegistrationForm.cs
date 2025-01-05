using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Displayers;
using Hotel.src.ModelManagement.Validations;
using Hotel.src.Utilities.UserInputManagement;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using HotelLibrary.Utilities.UserInputManagement;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class BookingRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.Booking;
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; } = EModelType.Customer;
        public IBooking Booking { get; set; }
        public bool IsAnEdit { get; set; }

        public object Data01 { get; set; } // First name
        public object Data02 { get; set; } // Last name
        public object Data03 { get; set; } // Date of birth
        public object Data04 { get; set; } // Email
        public object Data05 { get; set; } // Phone
        public object Data06 { get; set; } // Street Address
        public object Data07 { get; set; } // Postal Code
        public object Data08 { get; set; } // City
        public object Data09 { get; set; } // Country
        public object Data10 { get; set; }

        public void AssignRelatedForm(IModelRegistrationForm relatedForm)
        {
            RelatedForm = relatedForm;
        }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<BookingRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public IModel CreateForm()
        {
            IsAnEdit = false;
            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Från-datum[/]: ");
            Data01 = BookingValidator.ValidateFromDate(false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Till-datum[/]: ");
            Data02 = BookingValidator.ValidateToDate(false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rum[/]: ");
            var _roomController = ModelFactory.GetModelController(EModelType.Room, PreviousMenu);
            Data03 = _roomController.BrowseOne();

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Kund[/]: ");
            var _customerController = ModelFactory.GetModelController(EModelType.Customer, PreviousMenu);
            Data04 = _customerController.BrowseOne();

            // Create Invoice 
            Data05 = new Invoice();

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                Booking = new Booking((Room)Data01, (Customer)Data02, (DateTime)Data03, (DateTime)Data04);
                return (IModel)Booking;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                return (IModel)Booking;
            }
        }

        public IModel EditForm(IModel entityToUpdate)
        {
            Booking = (IBooking)entityToUpdate;
            IsAnEdit = true;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Från-datum[/]: ");
            Data01 = BookingValidator.ValidateFromDate(false, PreviousMenu);
            if (Data01 == null)
                Data01 = Booking.FromDate;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Till-datum[/]: ");
            Data02 = BookingValidator.ValidateToDate(false, PreviousMenu);
            if (Data02 == null)
                Data02 = Booking.FromDate;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rum[/]: ");
            var _roomController = ModelFactory.GetModelController(EModelType.Room, PreviousMenu);
            Data03 = _roomController.BrowseOne();
            if (Data03 == null)
                Data03 = Booking.Room;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Kund[/]: ");
            var _customerController = ModelFactory.GetModelController(EModelType.Customer, PreviousMenu);
            Data04 = _customerController.BrowseOne();
            if (Data04 == null)
                Data04 = Booking.Customer;

            // Create Invoice 
            InvoiceService.Delete(Booking.Invoice);
            Data05 = new Invoice(Booking.Room.Details.RoomType, Booking.Room.Details.Price);


            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                Booking = new Booking((Room)Data01, (Customer)Data02, (DateTime)Data03, (DateTime)Data04);
                return (IModel)Booking;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                return (IModel)Booking;
            }
        }

        public void DisplaySummary()
        {
            // Room
            Console.Clear();
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rumsnummer", (string)Data01);
            table.AddRow("Beskrivning", (string)Data02);
            table.AddRow("Våning", (string)Data03);

            // Room Details
            table.AddRow("Typ", (string)RelatedForm.Data01);
            table.AddRow("Storlek", (string)RelatedForm.Data02);
            table.AddRow("Antal sängar", (string)Data03);

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="entity"></param>
        public void DisplaySummary(IRoom entity)
        {
            // Visa sammanfattning
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rumsnummer", entity.Name);
            table.AddRow("Beskrivning", entity.Description);
            table.AddRow("Våning", entity.Floor.ToString());
            table.AddRow("Typ", entity.Details.RoomType.Name);
            table.AddRow("Storlek", entity.Details.Size.ToString());
            table.AddRow("Antal sängar", entity.Details.NumberOfBeds.ToString());
            AnsiConsole.Write(table);
        }
    }
}
