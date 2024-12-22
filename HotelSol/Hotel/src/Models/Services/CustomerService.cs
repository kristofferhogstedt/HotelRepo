using Hotel.src.Models.Interfaces;
using Hotel.src.Models.Services.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.Models.Services
{
    public class CustomerService : ICustomerService
    {
        public void Create()
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
            string _phoneNumber = UserInputHandler.UserInputString();

            Console.WriteLine("\nAdress: ");
            IAddress _address = AddressService.CreateAddress();
        }

        public ICustomer ReadOne(DatabaseLair dbLair)
        {
            Console.Clear();
            Console.Write("Kund: ");
            return dbLair.DatabaseContext.Customers.First(c => c.CustomerFirstName == UserInputHandler.UserInputString());
        }

        public List<ICustomer> ReadAll(DatabaseLair dbLair)
        {
            List<ICustomer> ListToReturn = (List<ICustomer>)(dbLair.DatabaseContext.Customers.ToList() as ICustomer);

            Console.Clear();
            if (ListToReturn == null)
            {
                Console.WriteLine("Data not found, contact administrator");
                Console.WriteLine("Returning... ");
                return ListToReturn;
            }
            return ListToReturn;
            // Guard clause?
        }

        public void Update(DatabaseLair dbLair)
        {
            Console.Clear();
            dbLair.DatabaseContext.Customers.Displayer.ReadAll(dbLair).ForEach(c => Console.WriteLine(c.DisplayString()));
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
