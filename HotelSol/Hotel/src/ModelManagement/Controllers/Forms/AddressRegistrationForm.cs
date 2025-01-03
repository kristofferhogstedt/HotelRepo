using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using HotelLibrary.Utilities.UserInputManagement;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;
using System.Diagnostics.Metrics;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class AddressRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public EModelType ModelType { get; set; } = EModelType.Address;

        public object Data01 { get; set; }
        public object Data02 { get; set; }
        public object Data03 { get; set; }
        public object Data04 { get; set; }
        public object Data05 { get; set; }
        public object Data06 { get; set; }
        public object Data07 { get; set; }
        public object Data08 { get; set; }
        public object Data09 { get; set; }
        public object Data10 { get; set; }
        public IModelRegistrationForm SubForm { get; set; }

        string _streetAddress;
        string _postalCode;
        string _city;
        string _country;
        public IAddress Address { get; set; }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<AddressRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public IModel CreateOrEdit(IModel adressToEdit)
        {
            if (adressToEdit == null)
                return CreateForm();
            else
            {
                Address = (IAddress)adressToEdit;
                DisplaySummary(Address);
                return EditForm(Address);
            }
        }

        //public IModel CreateForm()
        //{
        //    // Välkomstmeddelande
        //    AnsiConsole.MarkupLine("[bold green]Adressregistrering[/]");
        //    AnsiConsole.WriteLine();

        //    // Hämta information från användaren
        //    _streetAddress = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]gatuadress[/]:")
        //            .ValidationErrorMessage("[red]Adress måste anges.[/]")
        //            .Validate(input => !string.IsNullOrWhiteSpace(input)));

        //    _postalCode = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]postnummer[/]:")
        //            .ValidationErrorMessage("[red]Postnumret får bara innehålla siffror.[/]")
        //            .Validate(input => int.TryParse(input, out _)));

        //    _city = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]stad[/]:")
        //            .ValidationErrorMessage("[red]Stad måste anges.[/]")
        //            .Validate(input => !string.IsNullOrWhiteSpace(input)));

        //    _country = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]land[/]:")
        //            .ValidationErrorMessage("[red]Land får inte vara tomt.[/]")
        //            .Validate(input => !string.IsNullOrWhiteSpace(input)));

        //    DisplaySummary();

        //    // Bekräfta kunduppgifter
        //    bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

        //    if (confirm)
        //    {
        //        // Meddelande om lyckad registrering
        //        AnsiConsole.MarkupLine("[bold green]Address registrerad framgångsrikt![/]");
        //        return new Address(_country, _city, _postalCode, _streetAddress);
        //    }
        //    else
        //    {
        //        // Meddelande om avbryta
        //        AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
        //        Thread.Sleep(2000);
        //        return null;
        //    }
        //}

        public IModel CreateForm()
        {
            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]gatuadress[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]postadress[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]stad[/]: ");
            Data03 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]land[/]: ");
            Data04 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                this.Address = new Address((string)Data01, (string)Data02, (string)Data03, (string)Data04);
                return (IModel)this.Address;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                return (IModel)this.Address;
            }
        }

        public IModel EditForm(IModel modelToUpdate)
        {
            Address = (IAddress)modelToUpdate;

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]gatuadress[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data01.ToString().IsNullOrEmpty())
                Data01 = Address.StreetAddress;

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]postadress[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data02.ToString().IsNullOrEmpty())
                Data02 = Address.PostalCode;

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]stad[/]: ");
            Data03 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data03.ToString().IsNullOrEmpty())
                Data03 = Address.City;

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]land[/]: ");
            Data04 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data04.ToString().IsNullOrEmpty())
                Data04 = Address.Country;

            Console.Clear();
            DisplaySummary(Address);
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                this.Address = new Address((string)Data01, (string)Data02, (string)Data03, (string)Data04);
                return (IModel)this.Address;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                return (IModel)this.Address;
            }
        }

        public void DisplaySummary()
        {
            // Visa sammanfattning
            Console.Clear();
            FormDisplayer.DisplayFormHeader();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av adress:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Gatuadress", (string)Data01);
            table.AddRow("Postkod", (string)Data02);
            table.AddRow("Stad", (string)Data03);
            table.AddRow("Land", (string)Data04);
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="customer"></param>
        public void DisplaySummary(IAddress address)
        {
            // Visa sammanfattning
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av adress:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Gatuadress", address.StreetAddress);
            table.AddRow("Postadress", address.PostalCode);
            table.AddRow("Stad", address.City);
            table.AddRow("Land", address.Country);
            AnsiConsole.Write(table);
        }
    }
}
