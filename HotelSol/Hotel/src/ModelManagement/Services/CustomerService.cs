using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Services
{
    public class CustomerService //: ICustomerService
    {
        //    public void Create()
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Kundregistrering");
        //        Console.Write("\nFörNamn: ");
        //        string _firstName = UserInputHandler.UserInputString();
        //        Console.Write("\nEfternamn: ");
        //        string _lastName = UserInputHandler.UserInputString();
        //        Console.Write("\nE-post: ");
        //        string _email = UserInputHandler.UserInputString();
        //        Console.Write("\nTelefon: ");
        //        string _phoneNumber = UserInputHandler.UserInputString();

        //        Console.WriteLine("\nAdress: ");
        //        IAddress _address = AddressService.CreateAddress();
        //    }

        /// <summary>
        /// For fetching one customer
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static ICustomer GetOne(string searchString)
        {
            ICustomer _customerToReturn = DatabaseLair.DatabaseContext.Customers
                .First(c => c.FirstName.Contains(searchString));

            if (_customerToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return null;
            }

            return _customerToReturn;
        }

        /// <summary>
        /// For fetching list of specific customers based on search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static List<ICustomer> GetSpecific(string searchString)
        {
            List<ICustomer> _listToReturn = DatabaseLair.DatabaseContext.Customers
                .Where(c => c.FirstName.Contains(searchString)).ToList<ICustomer>();

            if (_listToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return null;
            }

            return _listToReturn;
        }

        /// <summary>
        /// For fetching all customers
        /// </summary>
        /// <param name="databaseLair"></param>
        /// <returns></returns>
        public static List<ICustomer> GetAll()
        {
            List<ICustomer> _listToReturn = DatabaseLair.DatabaseContext.Customers.ToList<ICustomer>();

            if (_listToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return _listToReturn;
            }
            return _listToReturn;
            // Guard clause?
        }

        //    public void Update(DatabaseLair dbLair)
        //    {
        //        Console.Clear();
        //        dbLair.DatabaseContext.Customers.Displayer.ReadAll(dbLair).ForEach(c => Console.WriteLine(c.DisplayString()));
        //        Console.Write("Välj katt att uppdatera: ");
        //        var _entityToUpdate = dbContext.Students.First(c => c.FirstName + " " + c.LastName == Console.ReadLine());
        //        Console.Clear();
        //        Console.WriteLine($"uppdaterar ålder på: {_entityToUpdate.FirstName} {_entityToUpdate.LastName}");
        //        Console.Write("Ange ny ålder: ");
        //        //_entityToUpdate. = UserInputManager.UserInputInt();

        //        Console.Clear();
        //        Console.WriteLine("Uppdaterad lista: ");
        //        CustomerService.ReadAll(dbContext).ForEach(c => Console.WriteLine(c.DisplayString()));
        //        dbContext.SaveChanges();
        //    }
        //    public void Delete()
        //    {

        //    }

        public static void DataNotFoundMessage()
        {
            Console.WriteLine("Data not found");
            Console.WriteLine("Returning... ");
        }
    }
}
