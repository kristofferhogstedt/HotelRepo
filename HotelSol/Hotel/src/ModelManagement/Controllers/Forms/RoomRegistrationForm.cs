using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Validations;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class RoomRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.Room;
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; } = EModelType.RoomDetails;
        public IRoom Room { get; set; }
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
            _instance = InstanceGenerator.GetInstance<RoomRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public IModel CreateForm()
        {
            IsAnEdit = false;
            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumsnummer[/]: ");
            Data01 = RoomValidator.ValidateRoomNumber(false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Beskrivning[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Våning[/]: ");
            Data03 = RoomValidator.ValidateFloor(false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            RelatedForm = ModelFactory.GetModelRegistrationForm(RelatedFormModelType, PreviousMenu);
            RelatedForm.AssignRelatedForm(this);

            Data04 = RelatedForm.CreateForm(); // start RoomDetail registration form

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                Room = new Room((string)Data01, (string)Data02, (int)Data03, (RoomDetails)Data04);
                return (IModel)Room;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                return (IModel)Room;
            }
        }

        public IModel EditForm(IModel modelToUpdate)
        {
            Room = (IRoom)modelToUpdate;
            IsAnEdit = true;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumsnummer[/]: ");
            Data01 = RoomValidator.ValidateRoomNumber(true, PreviousMenu);
            if (Data01 == null)
                Data01 = Room.Name;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Beskrivning[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data02 == null)
                Data02 = Room.Description;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Våning[/]: ");
            Data03 = RoomValidator.ValidateFloor(true, PreviousMenu);
            if ((int)Data03 == -1)
                Data03 = Room.Floor;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            RelatedForm = ModelFactory.GetModelRegistrationForm(RelatedFormModelType, PreviousMenu);
            RelatedForm.AssignRelatedForm(this);
            Data04 = RelatedForm.CreateForm(); // start RoomDetail registration form

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                Room = new Room((string)Data01, (string)Data02, (int)Data03, (RoomDetails)Data04);
                return (IModel)Room;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                EditForm(modelToUpdate);
                return (IModel)Room;
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
            table.AddRow("Typ", (string)RelatedForm.Data04);

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
            table.AddRow("Pris", entity.Details.Price.ToString());
            AnsiConsole.Write(table);
        }
    }
}
