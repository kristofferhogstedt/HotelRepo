using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Spectre.Console;
using System.Diagnostics.Metrics;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class AddressForm
    {
        string _streetAddress;
        string _postalCode;
        string _city;
        string _country;

        public IAddress CreateForm()
        {
            // Välkomstmeddelande
            AnsiConsole.MarkupLine("[bold green]Adressregistrering[/]");
            AnsiConsole.WriteLine();

            // Hämta information från användaren
            _streetAddress = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]gatuadress[/]:")
                    .ValidationErrorMessage("[red]Adress måste anges.[/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            _postalCode = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]postnummer[/]:")
                    .ValidationErrorMessage("[red]Postnumret får bara innehålla siffror.[/]")
                    .Validate(input => int.TryParse(input, out _)));

            _city = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]stad[/]:")
                    .ValidationErrorMessage("[red]Stad måste anges.[/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            _country = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]stad[/]:")
                    .ValidationErrorMessage("[red]Stad får inte vara tomt.[/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            DisplaySummary();

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Address registrerad framgångsrikt![/]");
                return new Address(_country, _city, _postalCode, _streetAddress);
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
            table.AddRow("Gatuadress", _streetAddress);
            table.AddRow("Postkod", _postalCode);
            table.AddRow("Stad", _city);
            table.AddRow("Land", _country);
            AnsiConsole.Write(table);
        }
    }
}
