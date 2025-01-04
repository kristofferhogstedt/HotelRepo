using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Utilities.Messagers;

namespace Hotel.src.ModelManagement.Services
{
    public class BookingService
    {
        public static void Create(IBooking modelToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.Bookings.Add((Booking)modelToCreate);
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
        public static IBooking GetOne(string searchString)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsActive == true)
                .First(m => m.CustomerID.ToString().Contains(searchString));

            if (_modelToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _modelToReturn;
        }

        public static IBooking GetOneByID(int searchID)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsActive == true)
                .First(m => m.ID == searchID);

            if (_modelToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _modelToReturn;
        }

        /// <summary>
        /// For fetching all customers
        /// </summary>
        /// <param name="databaseLair"></param>
        /// <returns></returns>
        public static List<IBooking> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsActive == true)
                .ToList<IBooking>();

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return _listToReturn;
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IBooking modelToUpdate)
        {
            DatabaseLair.DatabaseContext.Bookings.Update((Booking)modelToUpdate);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public void Delete(IBooking modelToDelete)
        {
            var _modelToDelete = (Booking)modelToDelete;
            _modelToDelete.IsActive = false;
            _modelToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Bookings.Update(_modelToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }
    }
}
