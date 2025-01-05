using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Models;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Validations;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    internal class RoomDetailsRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.RoomDetails;

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
        public IModelRegistrationForm? RelatedForm { get; set; }
        public void AssignRelatedForm(IModelRegistrationForm relatedForm)
        {
            RelatedForm = relatedForm;
        }

        public IRoomDetails RoomDetails { get; set; }
        public IRoomType RoomType { get; set; }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<RoomDetailsRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public IModel CreateForm()
        {
            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumtyp[/]: ");
            Data01 = RoomDetailsValidator.ValidateRoomType(PreviousMenu);
            if (Data01 != null)
                RoomType = Data01 as IRoomType;
            else
            {
                Console.WriteLine("Fel vid val av rumstyp, återgår till föregående meny... Kontakta admin om problemet kvarstår.");
                Thread.Sleep(3000);
                PreviousMenu.Run();
            }

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Storlek[/] (default {RoomType.SizeDefault}): ");
            Data02 = RoomDetailsValidator.ValidateRoomSize(RoomType, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Antal sängar[/] (default {RoomType.NumberOfBedsDefault}): ");
            Data03 = RoomDetailsValidator.ValidateNumberOfBeds(RoomType, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                RoomDetails = new RoomDetails((IRoomType)Data01, (int)Data02, (int)Data03);
                return (IModel)RoomDetails;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                return (IModel)RoomDetails;
            }
        }

        public IModel EditForm(IModel modelToUpdate)
        {
            RoomDetails = (IRoomDetails)modelToUpdate;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Rumtyp[/]: ");
            Data01 = RoomDetailsValidator.ValidateRoomType(PreviousMenu);
            if (Data01 == null)
                Data01 = RoomDetails.RoomType;            
            
            if (Data01 != null)
                RoomType = Data01 as IRoomType;
            else
            {
                Console.WriteLine("Fel vid val av rumstyp, återgår till föregående meny... Kontakta admin om problemet kvarstår.");
                Thread.Sleep(3000);
                PreviousMenu.Run();
            }

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Storlek[/] (default {RoomType.SizeDefault}): ");
            Data02 = RoomDetailsValidator.ValidateRoomSize(RoomType, PreviousMenu);
            if (Data02 == null)
                Data02 = RoomDetails.Size;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine($"\n[yellow]Antal sängar[/] (default {RoomType.NumberOfBedsDefault}): ");
            Data03 = RoomDetailsValidator.ValidateNumberOfBeds(RoomType, PreviousMenu);
            if (Data03 == null)
                Data03 = RoomDetails.NumberOfBeds;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                RoomDetails = new RoomDetails((IRoomType)Data01, (int)Data02, (int)Data03);
                return (IModel)RoomDetails;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                return (IModel)RoomDetails;
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
            table.AddRow("Rumstyp", (string)Data01);
            table.AddRow("Storlek", (string)Data02);
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
            table.AddRow("Rumstyp", entity.RoomType.Name);
            table.AddRow("Storlek", entity.Size.ToString());
            table.AddRow("Antal sängar", entity.NumberOfBeds.ToString());
            AnsiConsole.Write(table);
        }
    }
}
