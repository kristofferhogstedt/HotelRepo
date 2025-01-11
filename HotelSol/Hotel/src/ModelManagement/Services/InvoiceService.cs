using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services.Interfaces;
using Hotel.src.ModelManagement.Utilities.Checkers;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Services
{
    public class InvoiceService //: IDataService<InvoiceService>
    {
        public static void Create(IInvoice modelToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.Invoices.Add((Invoice)modelToCreate);
                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Skapande lyckat!");
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Inaktivering misslyckad, återgår");
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// For fetching one customer
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static IModel GetOne(string searchString, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .First(m => m.BookingID.ToString().Equals(searchString)
                );

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubData(_entityToReturn); // Get subdata
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByID(int searchID, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .First(m => m.ID == searchID);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubData(_entityToReturn); // Get subdata
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByBookingID(int searchID, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .First(m => m.BookingID == searchID);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubData(_entityToReturn); // Get subdata
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByBookingIDSeed(int searchID, bool getRelatedObjects)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .First(m => m.BookingID == searchID);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubData(_entityToReturn); // Get subdata
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
        public static List<IInvoice> GetAll(bool getRelatedObjects, bool isInactive)
        {
            List<IInvoice> _listToReturn = null;
            if (DatabaseLair.DatabaseContext.Invoices.Any(m => m.IsInactive == isInactive))
            {
                _listToReturn = DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .ToList<IInvoice>();

                if (getRelatedObjects)
                {
                    _listToReturn = GetSubData(_listToReturn); // Get subdata
                }
            }
            else
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return _listToReturn;
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IInvoice entityToUpdate)
        {
            var existingEntity = DatabaseLair.DatabaseContext.Invoices
                .FirstOrDefault(c => c.ID == entityToUpdate.ID);
            entityToUpdate.UpdatedDate = DateTime.Now;

            if (existingEntity != null)
            {
                DatabaseLair.DatabaseContext.Entry(existingEntity).CurrentValues.SetValues(entityToUpdate);

                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Uppdatering lyckad!");
            }
            else
            {
                Console.WriteLine("Uppdatering misslyckad, återgår");
                Thread.Sleep(1000);
                return;
            }
        }

        public static void Delete(IInvoice entityToDelete)
        {
            var existingEntity = DatabaseLair.DatabaseContext.Invoices
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
                return;
            }
        }


        // Getters for subdata
        //----------------------------------------------
        
        // Booking
        public static IModel GetSubData(IModel entity)
        {
            var _entityToReturn = (Invoice)entity;
            bool _getRelatedObjects = false;
            if (DataElementChecker.CheckBookingDataExists(_entityToReturn.BookingID))
            {
                _entityToReturn.Booking = (Booking)BookingService.GetOneByIDSeed(_entityToReturn.BookingID, _getRelatedObjects);
                _entityToReturn.Booking.Customer = (Customer)CustomerService.GetOneByIDSeed(_entityToReturn.Booking.CustomerID, _getRelatedObjects);
                _entityToReturn.Booking.Room = (Room)RoomService.GetOneByIDSeed(_entityToReturn.Booking.RoomID, _getRelatedObjects);
            }
            else
                ServiceMessager.SubDataNotFoundMessage();

            return _entityToReturn;
        }

        public static List<IInvoice> GetSubData(List<IInvoice> entityList)
        {
            var _listToReturn = new List<IInvoice>();
            bool _getRelatedObjects = false;
            foreach (Invoice entity in entityList)
            {
                if (DataElementChecker.CheckBookingDataExists(entity.BookingID))
                {
                    entity.Booking = (Booking)BookingService.GetOneByIDSeed(entity.BookingID, _getRelatedObjects);
                    entity.Booking.Customer = (Customer)CustomerService.GetOneByIDSeed(entity.Booking.CustomerID, _getRelatedObjects);
                    entity.Booking.Room = (Room)RoomService.GetOneByIDSeed(entity.Booking.RoomID, _getRelatedObjects);
                    _listToReturn.Add(entity);
                }
                else
                    ServiceMessager.SubDataNotFoundMessage();
            };
            return _listToReturn;
        }
    }
}
