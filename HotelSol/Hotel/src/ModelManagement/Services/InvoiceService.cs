using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services.Interfaces;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;

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
        public static IModel GetOne(string searchString)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == false)
                .First(m => m.BookingID.ToString().Equals(searchString)
                );

            _entityToReturn = GetSubData(_entityToReturn); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByID(int searchID)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == false)
                .First(m => m.ID == searchID);

            _entityToReturn = GetSubData(_entityToReturn); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IModel GetOneByBookingID(int searchID)
        {
            var _entityToReturn = (IModel)DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == false)
                .First(m => m.BookingID == searchID);
            
            _entityToReturn = GetSubData(_entityToReturn); // Get subdata

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
        public static List<IInvoice> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsInactive == false)
                .ToList<IInvoice>();

            _listToReturn = GetSubData(_listToReturn); // Get subdata

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

            if (existingEntity != null)
            {
                DatabaseLair.DatabaseContext.Entry(existingEntity).CurrentValues.SetValues(entityToUpdate);
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
        public static IModel GetSubData(IModel entity)
        {
            var _entityToReturn = (Invoice)entity;
            _entityToReturn.Booking = (Booking)BookingService.GetOneByID(_entityToReturn.BookingID);
            return _entityToReturn;
        }

        public static List<IInvoice> GetSubData(List<IInvoice> entityList)
        {
            var _listToReturn = new List<IInvoice>();
            foreach (Invoice entity in entityList)
            {
                entity.Booking = (Booking)BookingService.GetOneByID(entity.BookingID);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }
    }
}
