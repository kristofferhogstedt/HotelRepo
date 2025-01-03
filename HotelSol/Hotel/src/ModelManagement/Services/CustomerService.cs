using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Services
{
    public class CustomerService //: ICustomerService
    {
        public static void Create(ICustomer modelToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.Customers.Add((Customer)modelToCreate);
                DatabaseLair.DatabaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// For fetching one customer
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static ICustomer GetOne(string searchString)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Customers
                .Where(m => m.IsActive == true)
                .First(m => m.FirstName.Contains(searchString) 
                || m.LastName.Contains(searchString));

            if (_modelToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return null;
            }

            return _modelToReturn;
        }

        public static ICustomer GetOneByID(int searchID)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Customers
                .Where(m => m.IsActive == true)
                .First(m => m.ID == searchID);

            if (_modelToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return null;
            }

            return _modelToReturn;
        }

        /// <summary>
        /// For fetching list of specific customers based on search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        //public static List<ICustomer> GetSpecific(string searchString)
        //{
        //    List<ICustomer> _listToReturn;
        //    if (searchString == null || searchString == "")
        //        _listToReturn = GetAll();
        //    else
        //        _listToReturn = DatabaseLair.DatabaseContext.Customers
        //        .Where(c => c.FirstName.Contains(searchString)
        //        || c.LastName.Contains(searchString)
        //        || c.Email.Contains(searchString)
        //        ).ToList<ICustomer>();

        //    if (_listToReturn == null)
        //    {
        //        Console.Clear();
        //        DataNotFoundMessage();
        //        return null;
        //    }

        //    return _listToReturn;
        //}

        /// <summary>
        /// For fetching all customers
        /// </summary>
        /// <param name="databaseLair"></param>
        /// <returns></returns>
        public static List<ICustomer> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Customers
                .Where(m => m.IsActive == true)
                .ToList<ICustomer>();

            if (_listToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return _listToReturn;
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(ICustomer modelToUpdate)
        {
            DatabaseLair.DatabaseContext.Customers.Update((Customer)modelToUpdate);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public void Delete(ICustomer modelToDelete)
        {
            var _modelToDelete = (Customer)modelToDelete;
            _modelToDelete.IsActive = false;
            _modelToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Customers.Update(_modelToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public static void DataNotFoundMessage()
        {
            Console.WriteLine("Data not found");
            Console.WriteLine("Returning... ");
        }
    }
}
