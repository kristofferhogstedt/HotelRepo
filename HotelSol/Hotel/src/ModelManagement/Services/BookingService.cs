using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Checkers;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;

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
                Console.WriteLine("Skapande lyckat!");
                Thread.Sleep(1000);
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
        public static IModel GetOne(string searchString, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsInactive == isInactive)
                .First();

            if (getRelatedObjects)
            {
                _entityToReturn = (Booking)GetSubDataRoom(_entityToReturn);
                _entityToReturn = (Booking)GetSubDataCustomer(_entityToReturn);
                _entityToReturn = (Booking)GetSubDataInvoice(_entityToReturn);
            }
            return _entityToReturn;
        }

        public static IModel GetOneByID(int searchID, bool getRelatedObjects, bool isInactive)
        {
            IModel _entityToReturn = null;

            if (DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsInactive == isInactive)
                .Any(m => m.ID == searchID))
            {
                _entityToReturn = DatabaseLair.DatabaseContext.Bookings
                    .Where(m => m.IsInactive == isInactive)
                    .First(m => m.ID == searchID);

                if (getRelatedObjects)
                {
                    _entityToReturn = (Booking)GetSubDataRoom(_entityToReturn);
                    _entityToReturn = (Booking)GetSubDataCustomer(_entityToReturn);
                    _entityToReturn = (Booking)GetSubDataInvoice(_entityToReturn);
                }
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByCustomerID(int searchID, bool getRelatedObjects, bool isInactive)
        {
            IModel _entityToReturn = null;

            if (DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsInactive == isInactive)
                .Any(m => m.CustomerID == searchID))
            {
                _entityToReturn = DatabaseLair.DatabaseContext.Bookings
                    .Where(m => m.IsInactive == isInactive)
                    .First(m => m.CustomerID == searchID);

                if (getRelatedObjects)
                {
                    _entityToReturn = (Booking)GetSubDataRoom(_entityToReturn);
                    _entityToReturn = (Booking)GetSubDataCustomer(_entityToReturn);
                    _entityToReturn = (Booking)GetSubDataInvoice(_entityToReturn);
                }
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        /// <summary>
        /// For seeder functionality to not care about IsInactive
        /// </summary>
        /// <param name="searchID"></param>
        /// <returns></returns>
        public static IModel GetOneByIDSeed(int searchID, bool getRelatedObjects)
        {
            var _entityToReturn = DatabaseLair.DatabaseContext.Bookings
                .First(m => m.ID == searchID);

            if (getRelatedObjects)
            {
                _entityToReturn = (Booking)GetSubDataRoom(_entityToReturn);
                _entityToReturn = (Booking)GetSubDataCustomer(_entityToReturn);
                _entityToReturn = (Booking)GetSubDataInvoice(_entityToReturn);
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        /// <summary>
        /// For fetching all customers
        /// </summary>
        /// <param name="databaseLair"></param>
        /// <returns></returns>
        public static List<IBooking> GetAll(bool getRelatedObjects, bool isInactive)
        {
            List<IBooking> _listToReturn = null;

            if (DatabaseLair.DatabaseContext.Bookings.Any(m => m.IsInactive == isInactive))
            {
                _listToReturn = DatabaseLair.DatabaseContext.Bookings.Where(b => b.IsInactive == isInactive).ToList<IBooking>();

                if (getRelatedObjects)
                {
                    _listToReturn = GetSubDataRoom(_listToReturn);
                    _listToReturn = GetSubDataCustomer(_listToReturn);
                    _listToReturn = GetSubDataInvoice(_listToReturn);
                }
            }
            else
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IBooking entityToUpdate)
        {
            var existingEntity = DatabaseLair.DatabaseContext.Bookings
                .FirstOrDefault(c => c.ID == entityToUpdate.ID);
            entityToUpdate.UpdatedDate = DateTime.Now;

            if (existingEntity != null)
            {
                DatabaseLair.DatabaseContext.Entry(existingEntity).CurrentValues.SetValues(entityToUpdate);

                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Uppdatering lyckad!");
                Thread.Sleep(1000);
            }
            else
            {
                Create(entityToUpdate);
            }
        }

        public static void Delete(IBooking entityToDelete)
        {
            var existingEntity = DatabaseLair.DatabaseContext.Bookings
                .FirstOrDefault(c => c.ID == entityToDelete.ID);
            entityToDelete.IsInactive = true;
            entityToDelete.InactivatedDate = DateTime.Now;

            if (existingEntity != null)
            {
                DatabaseLair.DatabaseContext.Entry(existingEntity).CurrentValues.SetValues(entityToDelete);

                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Inaktivering lyckad!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Inaktivering misslyckad, återgår");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }


        // Getters for subdata
        //----------------------------------------------

        // Room
        public static IModel GetSubDataRoom(IModel entity)
        {
            var _entityToReturn = (IBooking)entity;
            bool _getRelatedObjects = false;
            bool _handleInactive = false;

            //_entityToReturn.Room = (Room)RoomService.GetOneByID(_entityToReturn.RoomID, _getRelatedObjects, _handleInactive);
            if (DataElementChecker.CheckRoomDataExists(_entityToReturn.RoomID)) // Check if data exists
                _entityToReturn.Room = DatabaseLair.DatabaseContext.Rooms.First(e => e.ID == _entityToReturn.RoomID);
            else
                ServiceMessager.SubDataNotFoundMessage();

            return _entityToReturn;
        }

        public static List<IBooking> GetSubDataRoom(List<IBooking> entityList)
        {
            var _listToReturn = new List<IBooking>();
            bool _getRelatedObjects = false;
            bool _handleInactive = false;

            foreach (IBooking entity in entityList)
            {
                if (DataElementChecker.CheckRoomDataExists(entity.RoomID))
                {
                    entity.Room = DatabaseLair.DatabaseContext.Rooms.First(e => e.ID == entity.RoomID);
                    _listToReturn.Add(entity);
                }
                else
                    ServiceMessager.SubDataNotFoundMessage();
            };

            return _listToReturn;
        }

        // Customer
        public static IModel GetSubDataCustomer(IModel entity)
        {
            var _entityToReturn = (IBooking)entity;
            bool _getRelatedObjects = false;
            if (DataElementChecker.CheckCustomerDataExists(_entityToReturn.CustomerID))
                _entityToReturn.Customer = DatabaseLair.DatabaseContext.Customers.First(e => e.ID == _entityToReturn.CustomerID);
            else
                ServiceMessager.SubDataNotFoundMessage();

            return _entityToReturn;
        }
        public static List<IBooking> GetSubDataCustomer(List<IBooking> entityList)
        {
            var _listToReturn = new List<IBooking>();
            bool _getRelatedObjects = false;
            foreach (Booking entity in entityList)
            {
                if (DataElementChecker.CheckCustomerDataExists(entity.CustomerID))
                {
                    entity.Customer = DatabaseLair.DatabaseContext.Customers.First(e => e.ID == entity.CustomerID);
                    _listToReturn.Add(entity);

                }
                else
                    ServiceMessager.SubDataNotFoundMessage();

            };
            return _listToReturn;
        }

        // Invoice
        public static IModel GetSubDataInvoice(IModel entity)
        {
            var _entityToReturn = (IBooking)entity;
            bool _getRelatedObjects = false;
            //_entityToReturn.Invoice = (Invoice)InvoiceService.GetOneByBookingID(_entityToReturn.ID, isInactive);
            if (DataElementChecker.CheckInvoiceDataExistsByBookingID(_entityToReturn.ID))
                _entityToReturn.Invoice = DatabaseLair.DatabaseContext.Invoices.First(e => e.BookingID == _entityToReturn.ID);
            else
                ServiceMessager.SubDataNotFoundMessage();

            return _entityToReturn;
        }

        public static List<IBooking> GetSubDataInvoice(List<IBooking> entityList)
        {
            var _listToReturn = new List<IBooking>();
            bool _getRelatedObjects = false;
            foreach (Booking entity in entityList)
            {
                if (DataElementChecker.CheckInvoiceDataExistsByBookingID(entity.ID))
                {
                    entity.Invoice = DatabaseLair.DatabaseContext.Invoices.First(e => e.BookingID == entity.ID);
                    _listToReturn.Add(entity);
                }
                else
                    ServiceMessager.SubDataNotFoundMessage();
            }

            return _listToReturn;
        }
    }
}
