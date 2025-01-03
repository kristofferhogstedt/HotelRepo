using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Services
{
    public class AddressService //: IDataService<Address>
    {
        public static void Create(IAddress modelToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.Addresses.Add((Address)modelToCreate);
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
        public static IAddress GetOne(string searchString)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Addresses
                .Where(m => m.IsActive == true)
                .First(m => m.StreetAddress.Contains(searchString)
                || m.PostalCode.Contains(searchString)
                || m.City.Contains(searchString)
                || m.Country.Contains(searchString)
                );

            if (_modelToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return null;
            }

            return _modelToReturn;
        }

        public static IAddress GetOneByID(int searchID)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Addresses
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
        /// For fetching all customers
        /// </summary>
        /// <param name="databaseLair"></param>
        /// <returns></returns>
        public static List<IAddress> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Addresses
                .Where(m => m.IsActive == true)
                .ToList<IAddress>();

            if (_listToReturn == null)
            {
                Console.Clear();
                DataNotFoundMessage();
                return _listToReturn;
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IAddress modelToUpdate)
        {
            DatabaseLair.DatabaseContext.Addresses.Update((Address)modelToUpdate);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public void Delete(IAddress modelToDelete)
        {
            var _modelToDelete = (Address)modelToDelete;
            _modelToDelete.IsActive = false;
            _modelToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Addresses.Update(_modelToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public static void DataNotFoundMessage()
        {
            Console.WriteLine("Data not found");
            Console.WriteLine("Returning... ");
        }
    }
}
