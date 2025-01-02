using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Controllers.Forms
{
    public class CustomerRegistrationForm : IModelRegistrationForm, IInstantiable
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

        public static IModelRegistrationForm GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerRegistrationForm>(_instance, _lock, previousMenu);
            return (IModelRegistrationForm)_instance;
        }

        public IModel CreateOrEdit(IModel customerToEdit)
        {
            if (customerToEdit == null)
                return CreateForm();
            else
            {
                _customer = (ICustomer)customerToEdit;
                DisplaySummary(_customer);
                return EditForm((IModel)_customer);
            }
        }

        public IModel CreateForm()
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
                    .ValidationErrorMessage("[red]Födelseår måste vara numeriskt.[/]")
                    .Validate(input => ushort.TryParse(input, out _)));

            string _monthOfBirth = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]födelsemånad[/]:")
                    .ValidationErrorMessage("[red]Födelsemånad måste vara numeriskt.[/]")
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

            // Create or edit Address
            var _addressForm = AddressForm.GetInstance(PreviousMenu);

            if (_customer != null)
                _address = (IAddress)_addressForm.EditForm(_customer.Address);
            else
                _address = (IAddress)_addressForm.CreateForm();


            DisplaySummary();

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                _customer = new Customer(_firstName, _lastName, _dateOfBirth, _email, _phone, (Address)_address);
                return (IModel)_customer;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                PreviousMenu.Run();
                return null;
            }
        }


        public IModel EditForm(IModel modelToUpdate)
        {
            ICustomer _customerToUpdate = (ICustomer)modelToUpdate;
            // Välkomstmeddelande
            AnsiConsole.MarkupLine("[bold green]Kundregistrering[/]");
            AnsiConsole.WriteLine();

            // Hämta information från användaren
            _firstName = AnsiConsole.Prompt(
                new TextPrompt<string>("[[Optional]]Ange [yellow]förnamn[/]:")
                    .AllowEmpty()
            .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
            .Validate(input => 
            (!string.IsNullOrWhiteSpace(input))
            || (input == "" && _customerToUpdate.FirstName != null))
            );
            if (_firstName == null)
                _firstName = _customerToUpdate.FirstName;

            _lastName = AnsiConsole.Prompt(
                new TextPrompt<string>("[[Optional]]Ange [yellow]efternamn[/]:")
                    .AllowEmpty()
            .ValidationErrorMessage("[red]Namnet får inte vara tomt.[/]")
            .Validate(input => 
            (!string.IsNullOrWhiteSpace(input))
            || (input == "" && _customerToUpdate.LastName != null))
            );
            if (_lastName == null)
                _lastName = _customerToUpdate.LastName;

            var _yearOfBirth = UserInputHandler.UserInputYear();

            //string _yearOfBirth = AnsiConsole.Prompt(
            //    new TextPrompt<string>("[[Optional]]Ange [yellow]födelseår[/]:")
            //        .AllowEmpty()
            //        .ValidationErrorMessage("[red]Födelseår måste vara numeriskt och måste vara över 18 år.[/]")
            //        .Validate(input => 
            //            (int.TryParse(input, out _)
            //            && Convert.ToDateTime($"{Convert.ToInt32(input)}-{DateTime.Now.Month}-{DateTime.Now.Day}")
            //            <= Convert.ToDateTime($"{DateTime.Now.Year - 18}-{DateTime.Now.Month}-{DateTime.Now.Day}")
            //            )
            //            || (input == "" && _customerToUpdate.DateOfBirth.Year != null))
            //        );
            //if (_yearOfBirth == null)
            //    _yearOfBirth = Convert.ToString(_customerToUpdate.DateOfBirth.Year);

            string _monthOfBirth = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]födelsemånad[/]:")
                    .AllowEmpty()
                    .ValidationErrorMessage("[red]Födelsemånad måste vara numeriskt.[/]")
                    .Validate(input => 
                        (int.TryParse(input, out _)
                            && Convert.ToInt32(input) > 0
                            && Convert.ToInt32(input) <= 12
                        )
                        || (input == "" && _customerToUpdate.DateOfBirth.Month != null)
                        )
                    );
            if (_monthOfBirth == null)
                _monthOfBirth = Convert.ToString(_customerToUpdate.DateOfBirth.Month);

            string _dayOfBirth = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]födelsedag[/]:")
                    .AllowEmpty()
                    .ValidationErrorMessage("[red]Födelsedag måste vara numeriskt.[/]")
                    .Validate(input => 
                        (int.TryParse(input, out _)
                            && Convert.ToInt32(input) > 0
                            && Convert.ToInt32(input) <= DateTime.DaysInMonth(Convert.ToInt32(_yearOfBirth), Convert.ToInt32(_monthOfBirth))
                        )
                        || (input == "" && _customerToUpdate.DateOfBirth.Day != null))
                    );
            if (_dayOfBirth == null)
                _dayOfBirth = Convert.ToString(_customerToUpdate.DateOfBirth.Day);

            _dateOfBirth = UserInputHandler.UserInputDateTime(Convert.ToInt32(_yearOfBirth), Convert.ToInt32(_monthOfBirth), Convert.ToInt32(_dayOfBirth));

            _email = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]e-post[/]:")
                    .AllowEmpty()
                    .ValidationErrorMessage("[red]Ogiltig e-postadress. Måste innehålla \"@\".[/]")
                    .Validate(input => 
                    (input.Contains("@"))
                    || (input == "" && _customerToUpdate.Email != null)
                    )
                    );
            if (_email == null)
                _email = _customerToUpdate.Email;

            _phone = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]telefonnummer[/]:")
                    .AllowEmpty()
                    .ValidationErrorMessage("[red]Telefonnumret måste vara numeriskt![/]")
                    .Validate(input => 
                    (long.TryParse(input, out _))
                    || (input == "" && _customerToUpdate.Phone != null))
                    );
            if (_phone == null)
                _phone = _customerToUpdate.Phone;

            // Create or edit Address
            var _addressForm = AddressForm.GetInstance(PreviousMenu);

            if (_customerToUpdate.Address != null)
                _address = (IAddress)_addressForm.EditForm(_customer.Address);
            else
                _address = (IAddress)_addressForm.CreateForm();


            DisplaySummary();

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
                _customer = new Customer(_firstName, _lastName, _dateOfBirth, _email, _phone, (Address)_address);
                return (IModel)_customer;
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
                Thread.Sleep(2000);
                return (IModel)_customer;
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
            if (customer.Address == null)
                table.AddRow("Adress", "Ej angiven");
            else
                table.AddRow("Adress", $"{customer.Address.StreetAddress} {customer.Address.PostalCode} {customer.Address.City}{customer.Address.Country}");
            AnsiConsole.Write(table);
        }
    }
}
