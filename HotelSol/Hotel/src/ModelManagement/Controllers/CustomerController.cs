using Hotel.src.Persistence;
using HotelLibrary.Models.Interfaces;
using HotelLibrary.Services;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Controllers
{
    public class CustomerController
    {
        public static void Create()
        {
            Console.WriteLine("Kundregistrering");
            Console.Write("\nFörNamn: ");
            string _firstName = UserInputHandler.UserInputString();
            Console.Write("\nEfternamn: ");
            string _lastName = UserInputHandler.UserInputString();
            Console.Write("\nE-post: ");
            string _email = UserInputHandler.UserInputString();
            Console.Write("\nTelefon: ");
            string _phoneNumber = UserInputHandler.UserInputString();

            Console.WriteLine("\nAdress: ");
            IAddress _address = AddressService.CreateAddress();
        }

        public static ICustomer ReadOne(DatabaseLair dbLair)
        {
            Console.Write("Kund: ");
            return dbLair.Customers.First(c => c.FirstName == Console.ReadLine());
        }

        public static List<ICustomer> ReadAll(DatabaseLair dbLair)
        {
            return dbContext.Students.ToList();
        }

        public static void Update(DatabaseLair dbLair)
        {
            Console.Clear();
            dbLair.ReadAll(dbContext).ForEach(c => Console.WriteLine(c.DisplayString()));
            Console.Write("Välj katt att uppdatera: ");
            var _entityToUpdate = dbContext.Students.First(c => c.FirstName + " " + c.LastName == Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"uppdaterar ålder på: {_entityToUpdate.FirstName} {_entityToUpdate.LastName}");
            Console.Write("Ange ny ålder: ");
            //_entityToUpdate. = UserInputManager.UserInputInt();

            Console.Clear();
            Console.WriteLine("Uppdaterad lista: ");
            CustomerService.ReadAll(dbContext).ForEach(c => Console.WriteLine(c.DisplayString()));
            dbContext.SaveChanges();
        }
        public void Delete()
        {

        }
    }
}
