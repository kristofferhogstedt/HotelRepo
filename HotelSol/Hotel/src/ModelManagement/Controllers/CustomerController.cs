using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Persistence;
using HotelLibrary.Utilities.UserInputManagement;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Controllers.Checks;
using System.Threading;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.ModelManagement.Controllers.Forms;
using Hotel.src.ModelManagement.Utilities.Displayers;
using Hotel.src.ModelManagement.Utilities.Selectors;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;

namespace Hotel.src.ModelManagement.Controllers
{
    public class CustomerController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public EModelType ModelType { get; set; } = EModelType.Customer;

        public CustomerController()
        {
        }

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            var _customerForm = ModelFactory.GetModelRegistrationForm(ModelType, PreviousMenu);
            ICustomer _customer = (ICustomer)_customerForm.CreateForm();

            if (_customer == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }
            else
                CustomerService.Create(_customer);
        }

        public IModel BrowseOne()
        {
            ICustomer _customerToReturn = CustomerEntitySelector.Select(CustomerService.GetAll(), 0, PreviousMenu);
            return _customerToReturn;
        }

        public void ManageOne()
        {
            var _customer = (ICustomer)BrowseOne();
            Console.Clear();
            CustomerDisplayer.DisplayModel(_customer);
            Console.WriteLine("Vad vill du göra?");

            var _crudMenu = CustomerCRUDMenu.GetInstance(PreviousMenu);
            _crudMenu.Run((IModel)_customer);
        }

        public void ReadAll()
        {
            CustomerDisplayer.DisplayModelTable(CustomerService.GetAll());
        }

        public void Update()
        {
            var _customerToUpdate = BrowseOne();

            var _customerForm = ModelFactory.GetModelRegistrationForm(ModelType, PreviousMenu);
            ICustomer _customer = (ICustomer)_customerForm.EditForm((IModel)_customerToUpdate);

            if (_customer == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }
                CustomerService.Update(_customer);
        }

        public void Update(IModel modelToUpdate)
        {
            var _customerToUpdate = modelToUpdate;

            var _customerForm = ModelFactory.GetModelRegistrationForm(ModelType, PreviousMenu);
            ICustomer _customer = (ICustomer)_customerForm.EditForm((IModel)_customerToUpdate);

            if (_customer == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }
            else
                CustomerService.Update(_customer);
        }

        //public void Update(DatabaseLair dbLair)
        //{
        //    Console.Clear();
        //    dbLair.DatabaseContext.Customers.Displayer.ReadAll(dbLair).ForEach(c => Console.WriteLine(c.DisplayString()));
        //    Console.Write("Välj katt att uppdatera: ");
        //    var _entityToUpdate = dbContext.Students.First(c => c.FirstName + " " + c.LastName == Console.ReadLine());
        //    Console.Clear();
        //    Console.WriteLine($"uppdaterar ålder på: {_entityToUpdate.FirstName} {_entityToUpdate.LastName}");
        //    Console.Write("Ange ny ålder: ");
        //    //_entityToUpdate. = UserInputManager.UserInputInt();

        //    Console.Clear();
        //    Console.WriteLine("Uppdaterad lista: ");
        //    CustomerService.ReadAll(dbContext).ForEach(c => Console.WriteLine(c.DisplayString()));
        //    dbContext.SaveChanges();
        //}
        public void Delete(IModel modelToDelete)
        {
            //while (true)
            //{

            //    Console.Write("Ange kund: ");
            //    string _customerName = UserInputHandler.UserInputString();
            //    ICustomer _customer = CustomerService.ReadOne(_customerName);
            //    CustomerChecks.HasBooking(_customerName);
            //}

        }
        public void DisplaySummary(IModel modelToDisplay)
        {
            var _customer = (ICustomer)modelToDisplay;
            Console.Clear();
            Console.WriteLine($"\nFörnamn: {_customer.FirstName}");
            Console.WriteLine($"\nEfternamn: {_customer.LastName}");
            Console.WriteLine($"\nFödelsedatum: {_customer.DateOfBirth}");
            Console.WriteLine($"\nE-post: {_customer.Email}");
            Console.WriteLine($"\nTelefon: {_customer.Phone}");
            Console.WriteLine($"\nGatuadress: {_customer.StreetAddress}");
            Console.WriteLine($"\nPostnummer: {_customer.PostalCode}");
            Console.WriteLine($"\nStad: {_customer.City}");
            Console.WriteLine($"\nLand: {_customer.Country}");

        }
    }
}
