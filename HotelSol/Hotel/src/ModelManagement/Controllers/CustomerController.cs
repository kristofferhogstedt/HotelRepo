using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Persistence;
using HotelLibrary.Utilities.UserInputManagement;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Controllers.Checks;
using System.Threading;
using Hotel.src.ModelManagement.Displayers;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.ModelManagement.Controllers.Forms;

namespace Hotel.src.ModelManagement.Controllers
{
    public class CustomerController : IModelController, IInstantiable
    {
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public IMenu PreviousMenu { get; set; }

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


        public string CustomerInfoString(ICustomer customer)
        {
            Console.WriteLine("Kund: (Namn/ID/E-Post) ");
            //var _customer = CustomerService.GetOne();
            return customer.Info;
        }

        public void Create()
        {
            var _customerForm = CustomerForm.GetInstance(PreviousMenu);
            ICustomer _customer = (ICustomer)_customerForm.EditForm();

            if (_customer == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }

            CustomerService.Create(_customer);
        }

        public void DisplayCurrentCustomerInfo(ICustomer customer)
        {
            Console.Clear();
            Console.WriteLine($"\nFörnamn: {customer.FirstName}");
            Console.WriteLine($"\nEfternamn: {customer.LastName}");
            Console.WriteLine($"\nFödelsedatum: {customer.DateOfBirth}");
            Console.WriteLine($"\nE-post: {customer.Email}");
            Console.WriteLine($"\nTelefon: {customer.Phone}");
            Console.WriteLine($"\nAdress: {customer.Address.StreetAddress} {customer.Address.PostalCode} {customer.Address.City} {customer.Address.Country}");
        }

        public void ReadOne()
        {
        }

        public void ReadSpecific()
        {
            Console.Clear();
            Console.Write("Ange söksträng: ");
            var _searchString = UserInputHandler.UserInputString(PreviousMenu);
            var _customerList = CustomerService.GetSpecific(_searchString);
            //return App.AppDatabase.Database.Customers.First(c => c.FirstName == UserInputHandler.UserInputString());

            CustomerDisplayer.DisplayModelTable(_customerList);
        }

        public void ReadAll()
        {
            CustomerDisplayer.DisplayModelTable(CustomerService.GetAll());
        }

        public void Update()
        {
            var _customerToUpdate = CustomerController.GetOne();

            var _customerForm = CustomerForm.GetInstance(PreviousMenu);
            ICustomer _customer = (ICustomer)_customerForm.EditForm(_customerToUpdate);

            if (_customer == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }

            CustomerService.Create(_customer);
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
        public void Delete()
        {
            //while (true)
            //{

            //    Console.Write("Ange kund: ");
            //    string _customerName = UserInputHandler.UserInputString();
            //    ICustomer _customer = CustomerService.ReadOne(_customerName);
            //    CustomerChecks.HasBooking(_customerName);
            //}

        }
    }
}
