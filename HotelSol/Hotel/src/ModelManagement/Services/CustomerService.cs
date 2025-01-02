using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Services
{
    public class CustomerService //: ICustomerService
    {
        public static void Create(ICustomer customer)
        {
            try
            {
                DatabaseLair.DatabaseContext.Customers.Add((Customer)customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                DatabaseLair.DatabaseContext.SaveChanges();
            }
        }

        /// <summary>
        /// For fetching one customer
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static ICustomer GetOne(string searchString)
        {
            ICustomer _customerToReturn = DatabaseLair.DatabaseContext.Customers
                .First(c => c.FirstName.Contains(searchString) 
                || c.LastName.Contains(searchString));

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

        public static void Update(ICustomer customerToUpdate)
        {
            DatabaseLair.DatabaseContext.Customers.Update((Customer)customerToUpdate);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public void Delete()
        {

        }

        public static void DataNotFoundMessage()
        {
            Console.WriteLine("Data not found");
            Console.WriteLine("Returning... ");
        }
    }
}
