using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.MenuManagement.Menus.Interfaces;

namespace Hotel.src.ModelManagement.Services
{
    public class AddressService_DELETE //: IAddressService
    {
        //public static void Create(IAddress modelToCreate, IMenu previousMenu)
        //{
        //    try
        //    {
        //        DatabaseLair.DatabaseContext.Addresses.Add((Address)modelToCreate);
        //        DatabaseLair.DatabaseContext.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        previousMenu.Run();
        //    }
        //}

        ///// <summary>
        ///// For fetching one customer
        ///// </summary>
        ///// <param name="searchString"></param>
        ///// <returns></returns>
        //public static IAddress GetOne(string searchString, IMenu previousMenu)
        //{
        //    var _modelToReturn = DatabaseLair.DatabaseContext.Addresses
        //        .Where(m => m.IsActive == true)
        //        .First(m => m.StreetAddress.Contains(searchString)
        //        || m.PostalCode.Contains(searchString)
        //        || m.City.Contains(searchString)
        //        || m.Country.Contains(searchString)
        //        );

        //    if (_modelToReturn == null)
        //    {
        //        Console.Clear();
        //        ServiceMessager.DataNotFoundMessage();
        //        previousMenu.Run();
        //    }

        //    return _modelToReturn;
        //}

        //public static IAddress GetOneByID(int searchID, IMenu previousMenu)
        //{
        //    var _modelToReturn = DatabaseLair.DatabaseContext.Addresses
        //        .Where(m => m.IsActive == true)
        //        .First(m => m.ID == searchID);

        //    if (_modelToReturn == null)
        //    {
        //        Console.Clear();
        //        ServiceMessager.DataNotFoundMessage();
        //        previousMenu.Run();
        //    }

        //    return _modelToReturn;
        //}

        //public static IAddress GetOneByCustomerID(int searchID, IMenu previousMenu)
        //{
        //    // Get customer by ID
        //    var _customerID = DatabaseLair.DatabaseContext.Customers
        //        .Where(m => m.IsActive == true)
        //        .First(m => m.ID == searchID).ID;

        //    // Get address by customer ID
        //    var _modelToReturn = DatabaseLair.DatabaseContext.Addresses
        //        .Where(m => m.IsActive == true)
        //        .First(m => m.ID == _customerID);

        //    if (_modelToReturn == null)
        //    {
        //        Console.Clear();
        //        ServiceMessager.DataNotFoundMessage();
        //        previousMenu.Run();
        //    }

        //    return _modelToReturn;
        //}

        ///// <summary>
        ///// For fetching all customers
        ///// </summary>
        ///// <param name="databaseLair"></param>
        ///// <returns></returns>
        //public static List<IAddress> GetAll(IMenu previousMenu)
        //{
        //    var _listToReturn = DatabaseLair.DatabaseContext.Addresses
        //        .Where(m => m.IsActive == true)
        //        .ToList<IAddress>();

        //    if (_listToReturn == null)
        //    {
        //        Console.Clear();
        //        ServiceMessager.DataNotFoundMessage();
        //        previousMenu.Run();
        //    }
        //    return _listToReturn;
        //}

        //public static void Update(IAddress modelToUpdate)
        //{
        //    DatabaseLair.DatabaseContext.Addresses.Update((Address)modelToUpdate);
        //    DatabaseLair.DatabaseContext.SaveChanges();
        //}

        //public static void Delete(IAddress modelToDelete)
        //{
        //    var _modelToDelete = (Address)modelToDelete;
        //    _modelToDelete.IsActive = false;
        //    _modelToDelete.InactivatedDate = DateTime.Now;
        //    DatabaseLair.DatabaseContext.Addresses.Update(_modelToDelete);
        //    DatabaseLair.DatabaseContext.SaveChanges();
        //}

    }
}
