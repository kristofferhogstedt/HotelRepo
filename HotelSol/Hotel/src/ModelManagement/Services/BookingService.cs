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
        public static IModel GetOne(string searchString, bool isInactive)
        {
            var _entityToReturn = DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsInactive == isInactive)
                .First();

            _entityToReturn = (Booking)GetSubDataRoom(_entityToReturn, isInactive);
            _entityToReturn = (Booking)GetSubDataCustomer(_entityToReturn, isInactive);

            return _entityToReturn;
        }

        public static IModel GetOneByID(int searchID, bool isInactive)
        {
            IModel _entityToReturn = null;

            if (DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsInactive == isInactive)
                .Any(m => m.ID == searchID))
            {
                _entityToReturn = DatabaseLair.DatabaseContext.Bookings
                    .Where(m => m.IsInactive == false)
                    .First(m => m.ID == searchID);

                _entityToReturn = (Booking)GetSubDataRoom(_entityToReturn, isInactive);
                _entityToReturn = (Booking)GetSubDataCustomer(_entityToReturn, isInactive);
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
        public static IModel GetOneByIDSeed(int searchID)
        {
            var _entityToReturn = DatabaseLair.DatabaseContext.Bookings
                .First(m => m.ID == searchID);

            _entityToReturn = (Booking)GetSubDataRoomSeed(_entityToReturn);
            _entityToReturn = (Booking)GetSubDataCustomerSeed(_entityToReturn);

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
        public static List<IBooking> GetAll(bool isInactive)
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Bookings
                .Where(m => m.IsInactive == isInactive)
                .ToList<IBooking>();

            _listToReturn = GetSubDataRoom(_listToReturn, isInactive);
            _listToReturn = GetSubDataCustomer(_listToReturn, isInactive);

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return _listToReturn;
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

        public void Delete(IBooking entityToDelete)
        {
            var _entityToDelete = (Booking)entityToDelete;
            _entityToDelete.IsInactive = true;
            _entityToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Bookings.Update(_entityToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }


        // Getters for subdata
        //----------------------------------------------

        // Room
        public static IModel GetSubDataRoom(IModel entity, bool isInactive)
        {
            var _entityToReturn = (IBooking)entity;
            _entityToReturn.Room = (Room)RoomService.GetOneByID(_entityToReturn.RoomID, isInactive);
            return _entityToReturn;
        }
        public static IModel GetSubDataRoomSeed(IModel entity)
        {
            var _entityToReturn = (IBooking)entity;
            _entityToReturn.Room = (Room)RoomService.GetOneByIDSeed(_entityToReturn.RoomID);
            return _entityToReturn;
        }

        public static List<IBooking> GetSubDataRoom(List<IBooking> entityList, bool isInactive)
        {
            var _listToReturn = new List<IBooking>();
            foreach (IBooking entity in entityList)
            {
                entity.Room = (Room)RoomService.GetOneByID(entity.RoomID, isInactive);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }

        // Customer
        public static IModel GetSubDataCustomer(IModel entity, bool isInactive)
        {
            var _entityToReturn = (IBooking)entity;
            _entityToReturn.Customer = (Customer)CustomerService.GetOneByID(_entityToReturn.CustomerID, isInactive);
            return _entityToReturn;
        }
        public static IModel GetSubDataCustomerSeed(IModel entity)
        {
            var _entityToReturn = (IBooking)entity;
            _entityToReturn.Customer = (Customer)CustomerService.GetOneByIDSeed(_entityToReturn.CustomerID);
            return _entityToReturn;
        }

        public static List<IBooking> GetSubDataCustomer(List<IBooking> entityList, bool isInactive)
        {
            var _listToReturn = new List<IBooking>();
            foreach (Booking entity in entityList)
            {
                entity.Customer = (Customer)CustomerService.GetOneByID(entity.CustomerID, isInactive);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }
        public static List<IBooking> GetSubDataCustomerSeed(List<IBooking> entityList)
        {
            var _listToReturn = new List<IBooking>();
            foreach (Booking entity in entityList)
            {
                entity.Customer = (Customer)CustomerService.GetOneByIDSeed(entity.CustomerID);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }

        // Invoice

        public static IModel GetSubDataInvoice(IModel entity, bool isInactive)
        {
            var _entityToReturn = (IBooking)entity;
            _entityToReturn.Invoice = (Invoice)InvoiceService.GetOneByBookingID(_entityToReturn.ID, isInactive);
            return _entityToReturn;
        }
        public static IModel GetSubDataInvoiceSeed(IModel entity)
        {
            var _entityToReturn = (IBooking)entity;
            _entityToReturn.Invoice = (Invoice)InvoiceService.GetOneByBookingIDSeed(_entityToReturn.ID);
            return _entityToReturn;
        }
    }
}
