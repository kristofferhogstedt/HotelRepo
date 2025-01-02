using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.ModelManagement.Controllers.Enums;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;
using System.Numerics;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class CustomerForm : IModelForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }

        string _firstName;
        string _lastName;
        DateTime _dateOfBirth;
        string _email;
        string _phone;
        IAddress _address;
        private ICustomer _customer;

        public static IModelForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerForm>(_instance, _lock, previousMenu);
            return (IModelForm)_instance;
        }

        public void CreateOrEdit(ICustomer customerToEdit)
        { 
            if (customerToEdit == null)
                EditForm();
            else
            {
                _customer = customerToEdit;
                DisplaySummary(_customer);
                EditForm();
            }
        }


        public IModel EditForm()
        {

            // Välkomstmeddelande
            AnsiConsole.MarkupLine("[bold green]Kundregistrering[/]");
            AnsiConsole.WriteLine();

            // Hämta information från användaren
            _firstName = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]förnamn[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));
            _lastName = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]efternamn[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            string _yearOfBirth = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]födelseår[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
                    .Validate(input => ushort.TryParse(input, out _)));

            string _monthOfBirth = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]födelsemånad[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
                    .Validate(input => ushort.TryParse(input, out _)));

            _dateOfBirth = UserInputHandler.UserInputDateTime(Convert.ToUInt16(_yearOfBirth), Convert.ToUInt16(_monthOfBirth));

            _email = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]e-post[/]:")
                    .ValidationErrorMessage("[red]Ogiltig e-postadress. Måste innehålla \"@\".[/]")
                    .Validate(input => input.Contains("@")));

            _phone = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]telefonnummer[/]:")
                    .ValidationErrorMessage("[red]Telefonnumret måste vara numeriskt![/]")
                    .Validate(input => long.TryParse(input, out _)));

            AddressForm _addressForm = new AddressForm();
            _address = (IAddress)_addressForm.EditForm();

            DisplaySummary();

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                _customer = new Customer(_firstName, _lastName, _dateOfBirth, _email, _phone, (Address)_address);
                return _customer;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                return _customer;
            }
        }

        public void DisplaySummary()
        {
            // Visa sammanfattning
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Förnamn", _firstName);
            table.AddRow("Efternamn", _lastName);
            table.AddRow("Födelsedatum", _dateOfBirth.ToString());
            table.AddRow("E-post", _email);
            table.AddRow("Telefonnummer", _phone);
            table.AddRow("Adress", $"{_address.StreetAddress} {_address.PostalCode} {_address.City}{_address.Country}");
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="customer"></param>
        public void DisplaySummary(ICustomer customer)
        {
            // Visa sammanfattning
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Förnamn", customer.FirstName);
            table.AddRow("Efternamn", customer.LastName);
            table.AddRow("Födelsedatum", customer.DateOfBirth.ToString());
            table.AddRow("E-post", customer.Email);
            table.AddRow("Telefonnummer", customer.Phone);
            table.AddRow("Adress", $"{customer.Address.StreetAddress} {customer.Address.PostalCode} {customer.Address.City}{customer.Address.Country}");
            AnsiConsole.Write(table);
        }
    }
}
