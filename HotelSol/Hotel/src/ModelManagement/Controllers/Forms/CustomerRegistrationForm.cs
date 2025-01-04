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

        public string _firstName;
        public string _lastName;
        public DateTime _dateOfBirth;
        public string _email;
        public string _phone;
        IAddress _address;
        public ICustomer Customer { get; set; }

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        //public IModel CreateOrEdit(IModel customerToEdit)
        //{
        //    if (customerToEdit == null)
        //        return CreateForm();
        //    else
        //    {
        //        Customer = (ICustomer)customerToEdit;
        //        DisplaySummary(Customer);
        //        return EditForm((IModel)Customer);
        //    }
        //}

        //public IModel CreateForm()
        //{

        //    // Välkomstmeddelande
        //    AnsiConsole.MarkupLine("[bold green]Kundregistrering[/]");
        //    AnsiConsole.WriteLine();

        //    // Hämta information från användaren
        //    _firstName = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]förnamn[/]:")
        //            .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
        //            .Validate(input => !string.IsNullOrWhiteSpace(input)));
        //    _lastName = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]efternamn[/]:")
        //            .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
        //            .Validate(input => !string.IsNullOrWhiteSpace(input)));

        //    string _yearOfBirth = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]födelseår[/]:")
        //            .ValidationErrorMessage("[red]Födelseår måste vara numeriskt.[/]")
        //            .Validate(input => ushort.TryParse(input, out _)));

        //    string _monthOfBirth = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]födelsemånad[/]:")
        //            .ValidationErrorMessage("[red]Födelsemånad måste vara numeriskt.[/]")
        //            .Validate(input => ushort.TryParse(input, out _)));

        //    _dateOfBirth = UserInputHandlerDateTime.UserInputDateTime(Convert.ToUInt16(_yearOfBirth), Convert.ToUInt16(_monthOfBirth));

        //    _email = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]e-post[/]:")
        //            .ValidationErrorMessage("[red]Ogiltig e-postadress. Måste innehålla \"@\".[/]")
        //            .Validate(input => input.Contains("@")));

        //    _phone = AnsiConsole.Prompt(
        //        new TextPrompt<string>("Ange [yellow]telefonnummer[/]:")
        //            .ValidationErrorMessage("[red]Telefonnumret måste vara numeriskt![/]")
        //            .Validate(input => long.TryParse(input, out _)));

        //    // Create or edit Address
        //    var _addressForm = AddressForm.GetInstance(PreviousMenu);

        //    if (Customer != null)
        //        _address = (IAddress)_addressForm.EditForm(Customer.Address);
        //    else
        //        _address = (IAddress)_addressForm.CreateForm();


        //    DisplaySummary();

        //    // Bekräfta kunduppgifter
        //    bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

        //    if (confirm)
        //    {
        //        // Meddelande om lyckad registrering
        //        AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
        //        Customer = new Customer(_firstName, _lastName, _dateOfBirth, _email, _phone, (Address)_address);
        //        return (IModel)Customer;
        //    }
        //    else
        //    {
        //        // Meddelande om avbryta
        //        AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
        //        Thread.Sleep(2000);
        //        PreviousMenu.Run();
        //        return null;
        //    }
        //}


        public IModel CreateForm()
        {
            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]förnamn[/]: ");
            Data01 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]efternamn[/]: ");
            Data02 = UserInputHandler.UserInputString(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]födelseår[/]: ");
            var _yearOfBirth = UserInputHandlerDateTime.UserInputYear(PreviousMenu);

            AnsiConsole.MarkupLine("\nAnge [yellow]födelsemånad[/]: ");
            var _monthOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);

            AnsiConsole.MarkupLine("\nAnge [yellow]födelsedag[/]: ");
            var _dayOfBirth = UserInputHandlerDateTime.UserInputMonth(PreviousMenu);

            Data03 = Convert.ToDateTime($"{_yearOfBirth}-{_monthOfBirth}-{_dayOfBirth}");

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]E-post[/]: ");
            Data04 = UserInputRegexHandler.UserInputRegexEmail(PreviousMenu);

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);
            AnsiConsole.MarkupLine("\nAnge [yellow]telefonnummer[/]: ");
            Data05 = UserInputRegexHandler.UserInputRegexPhone(PreviousMenu);


            var _addressController = (ISupportModelController)ModelFactory.GetModelController(EModelType.Address, PreviousMenu);
            // Address registration form
            //var _addressForm = AddressRegistrationForm.GetInstance(PreviousMenu);
            var _addressID = _addressController.CreateAndReturnID();
            Data06 = _addressID;
            Console.Clear();
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                this.Customer = new Customer((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04, (string)Data05, (int)Data06);
                return (IModel)this.Customer;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                CreateForm();
                return (IModel)this.Customer;
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

            var _addressController = ModelFactory.GetModelController(EModelType.Address, PreviousMenu);

            _addressController.DisplayCurrentModelInfo(Customer.Address);
            AnsiConsole.MarkupLine("Uppdatera [yellow]adress[/]?");
            if (UserInputHandler.UserInputBool(PreviousMenu))
            {
                // Address registration form
                var _addressForm = AddressRegistrationForm.GetInstance(PreviousMenu);
                _addressForm.Customer = Customer;

                // If customer exists, and an address, edit it. If not, create a new one.
                if (Customer != null)
                {
                    if (Customer.Address != null)
                        Data06 = (IAddress)_addressForm.EditForm(this.Customer.Address);
                    else
                        Data06 = (IAddress)_addressForm.CreateForm();
                }
                else
                    Data06 = (IAddress)_addressForm.CreateForm();
            }

            Console.Clear();
            DisplaySummary(Customer);
            FormDisplayer.DisplayCurrentFormValues(this);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                this.Customer = new Customer((string)Data01, (string)Data02, (DateTime)Data03, (string)Data04, (string)Data05, (Address)Data06);
                return (IModel)this.Customer;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                EditForm(modelToUpdate);
                return (IModel)this.Customer;
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
            table.AddRow("E-post", (string)Data05);
            table.AddRow("Telefonnummer", (string)Data05);
            if (SubForm == null)
                table.AddRow("Adress", "Ej angiven");
            else
            {
                table.AddRow("Adress", $"{(IAddress)SubForm.Data01}");
                table.AddRow("Adress", $"{(IAddress)SubForm.Data02}");
                table.AddRow("Adress", $"{(IAddress)SubForm.Data03}");
                table.AddRow("Adress", $"{(IAddress)SubForm.Data04}");
            }
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Summary of existing customer information
        /// </summary>
        /// <param name="customer"></param>
        public void DisplaySummary(ICustomer customer)
        {
            var _address = AddressService.GetOneByCustomerID(customer.ID, PreviousMenu);

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
            if (_address == null)
                table.AddRow("Adress", "Ej angiven");
            else
                table.AddRow("Adress", $"{_address.StreetAddress}, {_address.PostalCode} {_address.City}, {_address.Country}");
            AnsiConsole.Write(table);
        }
    }
}
