using Bogus.DataSets;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class CustomerForm
    {
        string _firstName;
        string _lastName;
        DateTime _dateOfBirth;
        string _email;
        string _phone;
        IAddress _address;
        public ICustomer CreateForm()
        {
            // Välkomstmeddelande
            AnsiConsole.MarkupLine("[bold green]Välkommen till kundregistrering![/]");
            AnsiConsole.WriteLine();

            // Hämta information från användaren
            _firstName = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]förnamn[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));
            _lastName = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]efternamn[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            string _yearOfBirth = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]födelseår[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt![/]")
                    .Validate(input => ushort.TryParse(input, out _)));


            string _monthOfBirth = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]födelsemånad[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt![/]")
                    .Validate(input => ushort.TryParse(input, out _)));

            _dateOfBirth = UserInputHandler.UserInputDateTime(Convert.ToUInt16(_yearOfBirth), Convert.ToUInt16(_monthOfBirth));

            _email = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]e-post[/]:")
                    .ValidationErrorMessage("[red]Ogiltig e-postadress![/]")
                    .Validate(input => input.Contains("@")));

            _phone = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]telefonnummer[/]:")
                    .ValidationErrorMessage("[red]Telefonnumret måste vara numeriskt![/]")
                    .Validate(input => long.TryParse(input, out _)));

            AddressForm _addressForm = new AddressForm();
            _address = _addressForm.CreateForm();
            
            DisplaySummary();

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                return new Customer(_firstName, _lastName, _dateOfBirth, _email, _address, phone);
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                return null;
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
            table.AddRow("Namn", name);
            table.AddRow("E-post", email);
            table.AddRow("Adress", address);
            table.AddRow("Postnummer", postcode);
            table.AddRow("Stad", city);
            table.AddRow("Telefonnummer", phone);
            AnsiConsole.Write(table);

        }
    }
}
