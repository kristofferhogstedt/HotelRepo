using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Utilities;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Rules;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using Hotel.src.Utilities.UserInputManagement.RegexManagement;
using HotelLibrary.Utilities.UserInputManagement;
using HotelLibrary.Utilities.Validation;
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
        public IModelRegistrationForm? RelatedForm { get; set; }
        public EModelType RelatedFormModelType { get; set; }
        public IModelController ModelController { get; set; }

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
            throw new NotImplementedException();
        }

        //public string _firstName;
        //public string _lastName;
        //public DateTime _dateOfBirth;
        //public string _email;
        //public string _phone;
        public ICustomer Customer { get; set; } 
        public bool IsAnEdit { get; set; }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public void CreateForm()
        {
            ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);
            IsAnEdit = false;

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]förnamn[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]efternamn[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
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
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]E-post[/]: ");
            Data04 = CustomerValidator.ValidateEmail(false, PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]telefonnummer[/]: ");
            Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Gatuadress[/]: ");
            Data06 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Postnummer[/]: ");
            Data07 = UserInputRegexHandler.UserInputRegexPostalCode(PreviousMenu);

            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Stad[/]: ");
            Data08 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
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
                
                ModelController.Create((IModel)Customer);
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                PreviousMenu.Run();
            }
        }

        public void EditForm(IModel modelToUpdate)
        {
            var ExistingCustomer = (ICustomer)modelToUpdate;
            ModelController = ModelFactory.GetModelController(ModelType, PreviousMenu);
            IsAnEdit = true;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]förnamn[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);
            if (CopyValue(Data01))
                Data01 = ExistingCustomer.FirstName;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]efternamn[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);
            if (CopyValue(Data02))
                Data02 = ExistingCustomer.LastName;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]födelseår[/]: ");
            var _yearOfBirth = UserInputHandlerDateTime.UserInputYear(PreviousMenu);
            if (CopyValue(_yearOfBirth))
                _yearOfBirth = ExistingCustomer.DateOfBirth.Year;

            AnsiConsole.MarkupLine("\nAnge [yellow]födelsemånad[/]: ");
            var _monthOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);
            if (CopyValue(_monthOfBirth))
                _monthOfBirth = ExistingCustomer.DateOfBirth.Month;

            AnsiConsole.MarkupLine("\nAnge [yellow]födelsedag[/]: ");
            var _dayOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);
            if (CopyValue(_dayOfBirth))
                _dayOfBirth = ExistingCustomer.DateOfBirth.Day;

            Data03 = Convert.ToDateTime($"{_yearOfBirth}-{_monthOfBirth}-{_dayOfBirth}");
            if (CopyValue(Data03))
                Data03 = ExistingCustomer.DateOfBirth;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]E-post[/]: ");
            Data04 = CustomerValidator.ValidateEmail(false, PreviousMenu);
            if (CopyValue(Data04))
                Data04 = ExistingCustomer.Email;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]telefonnummer[/]: ");
            Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);
            if (CopyValue(Data05))
                Data05 = ExistingCustomer.Phone;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Gatuadress[/]: ");
            Data06 = UserInputHandler.UserInputString(PreviousMenu);
            if (CopyValue(Data06))
                Data06 = ExistingCustomer.StreetAddress;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Postnummer[/]: ");
            Data07 = UserInputRegexHandler.UserInputRegexPostalCode(PreviousMenu);
            if (CopyValue(Data07))
                Data07 = ExistingCustomer.PostalCode;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Stad[/]: ");
            Data08 = UserInputHandler.UserInputString(PreviousMenu);
            if (CopyValue(Data08))
                Data08 = ExistingCustomer.City;

            Console.Clear();
            DisplaySummary(ExistingCustomer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\n[yellow]Land[/]: ");
            Data09 = UserInputHandler.UserInputString(PreviousMenu);
            if (CopyValue(Data09))
                Data09 = ExistingCustomer.Country;

            Console.Clear();
            Console.WriteLine("Tidigare värden: ");
            DisplaySummary(ExistingCustomer);
            Console.WriteLine("Nya värden: ");
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");

                Customer = new Customer((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04
                    , (string)Data05, (string)Data06, (string)Data07, (string)Data08, (string)Data09)
                { ID = ExistingCustomer.ID };
                
                CustomerService.Update(Customer);
                PreviousMenu.Run();
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                PreviousMenu.Run();
            }
        }

        public IModel CreateAndReturnForm()
        {
            throw new NotImplementedException();
        }
        public IModel EditAndReturnForm(IModel modelToUpdate)
        {
            throw new NotImplementedException();
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

        public bool CopyValue(object value)
        {
            return value.ToString() == "-1";
        }
    }
}
