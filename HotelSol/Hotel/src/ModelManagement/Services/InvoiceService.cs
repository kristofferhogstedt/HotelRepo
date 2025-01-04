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
        public static IInvoice GetOne(string searchString)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsActive == true)
                .First(m => m.BookingID.ToString().Equals(searchString)
                );

            if (_modelToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _modelToReturn;
        }

        public static IInvoice GetOneByID(int searchID)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Invoices
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
        public static List<IInvoice> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Invoices
                .Where(m => m.IsActive == true)
                .ToList<IInvoice>();

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return _listToReturn;
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IInvoice modelToUpdate)
        {
            DatabaseLair.DatabaseContext.Invoices.Update((Invoice)modelToUpdate);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public void Delete(IInvoice modelToDelete)
        {
            var _modelToDelete = (Invoice)modelToDelete;
            _modelToDelete.IsActive = false;
            _modelToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Invoices.Update(_modelToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }
    }
}
