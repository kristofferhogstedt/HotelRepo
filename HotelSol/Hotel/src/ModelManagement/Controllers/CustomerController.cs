using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Persistence;
using HotelLibrary.Utilities.UserInputManagement;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Controllers.Checks;
using System.Threading;
using Hotel.src.ModelManagement.Displayers;

namespace Hotel.src.ModelManagement.Controllers
{
    public class CustomerController : IModelController
    {
        public static IModelController _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        //private ICustomer _customer;

        //public CustomerController()
        //{
        //    //_customer = customer;
        //}

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static IModelController GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CustomerController();
                    }
                }
            }
            return _instance;
        }


        public string CustomerInfoString(ICustomer customer)
        {
            Console.WriteLine("Kund: (Namn/ID/E-Post) ");
            //var _customer = CustomerService.GetOne();
            return customer.Info;
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Kundregistrering");
            Console.Write("\nFörnamn: ");
            string _firstName = UserInputHandler.UserInputString();
            Console.Write("\nEfternamn: ");
            string _lastName = UserInputHandler.UserInputString();
            Console.WriteLine("Födelseår: ");
            ushort _yearOfBirth = UserInputHandler.UserInputUshort();
            DateTime _dateOfBirth = UserInputHandler.UserInputDateTime(_yearOfBirth);
            Console.Write("\nE-post: ");
            string _email = UserInputHandler.UserInputStringEmail();
            Console.Write("\nTelefon: ");
            string? _phoneNumber = UserInputHandler.UserInputStringPhone();

            Console.WriteLine("\nAdress: ");
            var _addressController = AddressController.GetInstance();
            var _address = _addressController.Create() as IAddress;

            ICustomer _customer = new Customer(_firstName, _lastName, _dateOfBirth, _email, _phoneNumber, (Address)_address);
            CustomerService.Create(_customer);
        }

        public void ReadOne()
        {
        }

        public void ReadSpecific()
        {
            Console.Clear();
            Console.Write("Ange söksträng: ");
            var _searchString = UserInputHandler.UserInputString();
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
