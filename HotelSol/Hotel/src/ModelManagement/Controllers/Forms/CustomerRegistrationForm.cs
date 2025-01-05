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
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using HotelLibrary.Utilities.UserInputManagement;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class CustomerRegistrationForm : IModelRegistrationForm, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelType { get; set; } = EModelType.Customer;

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
        public EModelType RelatedFormModelType { get; set; }
        public void AssignRelatedForm(IModelRegistrationForm relatedForm)
        {
            throw new NotImplementedException();
        }

        public string _firstName;
        public string _lastName;
        public DateTime _dateOfBirth;
        public string _email;
        public string _phone;
        public ICustomer Customer { get; set; } 

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public IModel CreateForm()
        {
            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]förnamn[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]efternamn[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
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
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]E-post[/]: ");
            Data04 = UserInputRegexHandler.UserInputRegexEmail(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]telefonnummer[/]: ");
            Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Gatuadress[/]: ");
            Data06 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Postnummer[/]: ");
            Data07 = UserInputRegexHandler.UserInputRegexPostalCode(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Stad[/]: ");
            Data08 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
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
                Customer = new Customer((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04
                    , (string)Data05, (string)Data06, (string)Data07, (string)Data08, (string)Data09);
                return (IModel)Customer;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                return (IModel)Customer;
            }
        }

        public IModel EditForm(IModel modelToUpdate)
        {
            Customer = (ICustomer)modelToUpdate;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]förnamn[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data01.ToString().IsNullOrEmpty())
                Data01 = Customer.FirstName;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]efternamn[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data02.ToString().IsNullOrEmpty())
                Data02 = Customer.LastName;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]födelseår[/]: ");
            var _yearOfBirth = UserInputHandlerDateTime.UserInputYear(PreviousMenu);
            if (_yearOfBirth == 0)
                _yearOfBirth = Customer.DateOfBirth.Year;

            AnsiConsole.MarkupLine("\nAnge [yellow]födelsemånad[/]: ");
            var _monthOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);
            if (_monthOfBirth == 0)
                _monthOfBirth = Customer.DateOfBirth.Month;

            AnsiConsole.MarkupLine("\nAnge [yellow]födelsedag[/]: ");
            var _dayOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);
            if (_dayOfBirth == 0)
                _dayOfBirth = Customer.DateOfBirth.Day;

            Data03 = Convert.ToDateTime($"{_yearOfBirth}-{_monthOfBirth}-{_dayOfBirth}");
            if (Data03.ToString().IsNullOrEmpty())
                Data03 = Customer.DateOfBirth;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]E-post[/]: ");
            Data04 = UserInputRegexHandler.UserInputRegexEmail(PreviousMenu);
            if (Data04.ToString().IsNullOrEmpty())
                Data04 = Customer.Email;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]telefonnummer[/]: ");
            Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);
            if (Data05.ToString().IsNullOrEmpty())
                Data05 = Customer.Phone;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Gatuadress[/]: ");
            Data06 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data06.ToString().IsNullOrEmpty())
                Data06 = Customer.StreetAddress;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Postnummer[/]: ");
            Data07 = UserInputRegexHandler.UserInputRegexPostalCode(PreviousMenu);
            if (Data07.ToString().IsNullOrEmpty())
                Data07 = Customer.PostalCode;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Stad[/]: ");
            Data08 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data08.ToString().IsNullOrEmpty())
                Data08 = Customer.City;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Land[/]: ");
            Data09 = UserInputHandler.UserInputString(PreviousMenu);
            if (Data09.ToString().IsNullOrEmpty())
                Data09 = Customer.Country;

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                Customer = new Customer((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04
                    , (string)Data05, (string)Data06, (string)Data07, (string)Data08, (string)Data09);
                return (IModel)Customer;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                EditForm(modelToUpdate);
                return (IModel)Customer;
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
            table.AddRow("Gatuadress", customer.StreetAddress);
            table.AddRow("Postnummer", customer.PostalCode);
            table.AddRow("Stad", customer.City);
            table.AddRow("Land", customer.Country);
            AnsiConsole.Write(table);
        }

    }
}
