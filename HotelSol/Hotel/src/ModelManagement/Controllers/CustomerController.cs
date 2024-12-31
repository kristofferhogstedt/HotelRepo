using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Persistence;
using HotelLibrary.Utilities.UserInputManagement;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Controllers.Checks;
using System.Threading;

namespace Hotel.src.ModelManagement.Controllers
{
    public class CustomerController : ICustomerController
    {
        //// Singleton
        //public static ICustomerController _instance;
        //private static readonly object _lock = new object(); // Lock object for thread safety

        //private ICustomer _customer;

        //public CustomerController()
        //{
        //    //_customer = customer;
        //}

        ///// <summary>
        ///// Single instance
        ///// </summary>
        ///// <returns></returns>
        //public static ICustomerController GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        lock (_lock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new CustomerController();
        //            }
        //        }
        //    }
        //    return _instance;
        //}


        public static string GetCustomerInfoString(ICustomer customer)
        {
            Console.WriteLine("Kund: (Namn/ID/E-Post) ");
            //var _customer = CustomerService.GetOne();
            return customer.Info;
        }

        public static ICustomer Create()
        {
            Console.Clear();
            Console.WriteLine("Kundregistrering");
            Console.Write("\nFörNamn: ");
            string _firstName = UserInputHandler.UserInputString();
            Console.Write("\nEfternamn: ");
            string _lastName = UserInputHandler.UserInputString();
            Console.Write("\nE-post: ");
            string _email = UserInputHandler.UserInputString();
            Console.Write("\nTelefon: ");
            string? _phoneNumber = UserInputHandler.UserInputString();

            Console.WriteLine("\nAdress: ");
            IAddress _address = AddressService.CreateAddress();

            return new Customer(_firstName, _lastName, _email, _phoneNumber, (Address)_address);
        }

        public static void ReadOne()
        {
            Console.Clear();
            Console.Write("Kund: ");
            //return App.AppDatabase.Database.Customers.First(c => c.FirstName == UserInputHandler.UserInputString());
            Console.WriteLine();
        }

        public static void ReadAll(DatabaseLair dbLair)
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
