using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Models;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class RoomRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.Room;

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
        public IModelRegistrationForm SubForm { get; set; }

        public string _firstName;
        public string _lastName;
        public DateTime _dateOfBirth;
        public string _email;
        public string _phone;
        public IRoom Room { get; set; }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public IModel CreateForm()
        {
            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]förnamn[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]efternamn[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]födelseår[/]: ");
            var _yearOfBirth = UserInputHandlerDateTime.UserInputYear(PreviousMenu);
            LineClearer.ClearLine(1000);

            AnsiConsole.MarkupLine("\n[yellow]födelsemånad[/]: ");
            var _monthOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);
            LineClearer.ClearLine(1000);

            AnsiConsole.MarkupLine("\n[yellow]födelsedag[/]: ");
            var _dayOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);

            Data03 = Convert.ToDateTime($"{_yearOfBirth}-{_monthOfBirth}-{_dayOfBirth}");

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]E-post[/]: ");
            Data04 = UserInputRegexHandler.UserInputRegexEmail(PreviousMenu);

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]telefonnummer[/]: ");
            Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Gatuadress[/]: ");
            Data06 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Postnummer[/]: ");
            Data07 = UserInputRegexHandler.UserInputRegexPostalCode(PreviousMenu);

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Stad[/]: ");
            Data08 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Land[/]: ");
            Data09 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                Room = new Room((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04
                    , (string)Data05, (string)Data06, (string)Data07, (string)Data08, (string)Data09);
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

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]förnamn[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data01.ToString().IsNullOrEmpty())
                Data01 = Room.Name;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]efternamn[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data02.ToString().IsNullOrEmpty())
                Data02 = Room.Description;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]födelseår[/]: ");
            Data03 = UserInputHandlerDateTime.UserInputYear(PreviousMenu);
            if (Data03.ToString().IsNullOrEmpty())
                Data03 = Room.Floor;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]E-post[/]: ");
            Data04 = UserInputRegexHandler.UserInputRegexEmail(PreviousMenu);
            if (Data04.ToString().IsNullOrEmpty())
                Data04 = Room.Email;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]telefonnummer[/]: ");
            Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);
            if (Data05.ToString().IsNullOrEmpty())
                Data05 = Room.Phone;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Gatuadress[/]: ");
            Data06 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data06.ToString().IsNullOrEmpty())
                Data06 = Room.StreetAddress;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Postnummer[/]: ");
            Data07 = UserInputRegexHandler.UserInputRegexPostalCode(PreviousMenu);
            if (Data07.ToString().IsNullOrEmpty())
                Data07 = Room.PostalCode;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Stad[/]: ");
            Data08 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data08.ToString().IsNullOrEmpty())
                Data08 = Room.City;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Land[/]: ");
            Data09 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data09.ToString().IsNullOrEmpty())
                Data09 = Room.Country;

            Console.Clear();
            DisplaySummary(Room);
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                Room = new Customer((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04
                    , (string)Data05, (string)Data06, (string)Data07, (string)Data08, (string)Data09);
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
            // Visa sammanfattning
            Console.Clear();
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Förnamn", (string)Data01);
            table.AddRow("Efternamn", (string)Data02);
            table.AddRow("Födelsedatum", Data03.ToString());
            table.AddRow("E-post", (string)Data04);
            table.AddRow("Telefonnummer", (string)Data05);
            table.AddRow("Gatuadress", (string)Data06);
            table.AddRow("Postnummer", (string)Data07);
            table.AddRow("Stad", (string)Data08);
            table.AddRow("Land", (string)Data09);

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
            table.AddRow("Förnamn", entity.FirstName);
            table.AddRow("Efternamn", entity.LastName);
            table.AddRow("Födelsedatum", entity.DateOfBirth.ToString());
            table.AddRow("E-post", entity.Email);
            table.AddRow("Telefonnummer", entity.Phone);
            table.AddRow("Gatuadress", entity.StreetAddress);
            table.AddRow("Postnummer", entity.PostalCode);
            table.AddRow("Stad", entity.City);
            table.AddRow("Land", entity.Country);
            AnsiConsole.Write(table);
        }
    }
}
