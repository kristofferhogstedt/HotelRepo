using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Validations;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class RoomBedRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public IMenu MainMenu { get; set; } = MenuFactory.GetMenu<MainMenu>();
        public EModelType ModelType { get; set; } = EModelType.RoomDetails;
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; } = EModelType.Room;
        public IRoomDetails NewEntity { get; set; }
        public IRoomType RoomType { get; set; }
        public IModelController ModelController { get; set; }
        public bool IsAnEdit { get; set; }
        public IRoomDetails ExistingEntity { get; set; }

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
            _instance = InstanceGenerator.GetInstance<RoomBedRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public void CreateForm()
        {
            throw new NotImplementedException();
        }

        public void EditForm(IModel entityToUpdate)
        {
            ExistingEntity = (IRoomDetails)entityToUpdate;
            var _roomType = ExistingEntity.RoomType;
            ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);
            IsAnEdit = true;

            Console.Clear();
            DisplaySummary(ExistingEntity);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Antal sängar[/]: ");
            Data03 = RoomDetailsValidator.ValidateNumberOfBeds(_roomType, ExistingEntity.Size, IsAnEdit, PreviousMenu);
            if (CopyChecker.CheckCopyValue(Data03))
                Data03 = ExistingEntity.NumberOfBeds;

            Console.Clear();
            Console.WriteLine("Tidigare värden: ");
            DisplaySummary(ExistingEntity);
            Console.WriteLine("Nya värden: ");
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                NewEntity = ExistingEntity;
                NewEntity.NumberOfBeds = (int)Data03;
                NewEntity.UpdatedDate = DateTime.Now;

                RoomDetailsService.Update(NewEntity);
                MainMenu.Run();
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);

                PreviousMenu.Run();
            }
        }

        public void InactivateForm(IModel entityToDelete)
        {
            throw new NotImplementedException();
        }
        public IModel CreateAndReturnForm()
        {
            throw new NotImplementedException();
        }

        public IModel EditAndReturnForm(IModel entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void DisplaySummary()
        {
            Console.Clear();
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Antal sängar", (string)Data03);
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="entity"></param>
        public void DisplaySummary(IRoomDetails entity)
        {
            // Visa sammanfattning
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Rumsnummer", entity.Room.Name);
            table.AddRow("Beskrivning", entity.Room.Description);
            table.AddRow("Våning", entity.Room.Floor.ToString());
            table.AddRow("Rumstyp", entity.RoomType.Name);
            table.AddRow("Storlek", entity.Size.ToString());
            table.AddRow("Antal sängar", entity.NumberOfBeds.ToString());
            table.AddRow("Pris", entity.Price.ToString());
            AnsiConsole.Write(table);
        }
    }
}
