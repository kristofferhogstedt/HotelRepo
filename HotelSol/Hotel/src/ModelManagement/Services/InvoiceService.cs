using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services.Interfaces;
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
        public static IModel GetOne(string searchString, bool isInactive)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .First(m => m.BookingID.ToString().Equals(searchString)
                );

            _entityToReturn = GetSubData(_entityToReturn, isInactive); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByID(int searchID, bool isInactive)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .First(m => m.ID == searchID);

            _entityToReturn = GetSubData(_entityToReturn, isInactive); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByBookingID(int searchID, bool isInactive)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .First(m => m.BookingID == searchID);
            
            _entityToReturn = GetSubData(_entityToReturn, isInactive); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByBookingIDSeed(int searchID)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .First(m => m.BookingID == searchID);

            _entityToReturn = GetSubDataSeed(_entityToReturn); // Get subdata

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
        public static List<IInvoice> GetAll(bool isInactive)
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == isInactive)
                .ToList<IInvoice>();

            _listToReturn = GetSubData(_listToReturn, isInactive); // Get subdata

            if (_listToReturn == null)
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
                Create(entityToUpdate);
            }
        }

        public static void Delete(IInvoice entityToDelete)
        {
            var _entityToDelete = (Invoice)entityToDelete;
            _entityToDelete.IsInactive = true;
            _entityToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Invoices.Update(_entityToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }


        // Getters for subdata
        //----------------------------------------------
        
        // Booking
        public static IModel GetSubData(IModel entity, bool isInactive)
        {
            var _entityToReturn = (Invoice)entity;
            _entityToReturn.Booking = (Booking)BookingService.GetOneByID(_entityToReturn.BookingID, isInactive);
            return _entityToReturn;
        }
        public static IModel GetSubDataSeed(IModel entity)
        {
            var _entityToReturn = (Invoice)entity;
            _entityToReturn.Booking = (Booking)BookingService.GetOneByIDSeed(_entityToReturn.BookingID);
            return _entityToReturn;
        }

        public static List<IInvoice> GetSubData(List<IInvoice> entityList, bool isInactive)
        {
            var _listToReturn = new List<IInvoice>();
            foreach (Invoice entity in entityList)
            {
                entity.Booking = (Booking)BookingService.GetOneByID(entity.BookingID, isInactive);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }
    }
}
