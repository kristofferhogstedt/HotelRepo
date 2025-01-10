using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services.Interfaces;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hotel.src.ModelManagement.Services
{
	public class CustomerService //: ICustomerService
	{
		public static void Create(ICustomer entityToCreate)
		{
			try
			{
				DatabaseLair.DatabaseContext.Customers.Add((Customer)entityToCreate);
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
		public static ICustomer GetOne(string searchString, bool getRelatedObjects, bool isInactive)
		{
			var _entityToReturn = DatabaseLair.DatabaseContext.Customers
				.Where(m => m.IsInactive == isInactive)
				.First(m => m.FirstName.Contains(searchString)
				|| m.LastName.Contains(searchString));

			if (_entityToReturn == null)
			{
				Console.Clear();
				ServiceMessager.DataNotFoundMessage();
				return null;
			}

			return _entityToReturn;
		}

		public static ICustomer GetOneByID(int searchID, bool getRelatedObjects, bool isInactive)
		{
			var _entityToReturn = DatabaseLair.DatabaseContext.Customers
				.Where(m => m.IsInactive == isInactive)
				.First(m => m.ID == searchID);

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
		public static ICustomer GetOneByIDSeed(int searchID, bool getRelatedObjects)
		{
			var _entityToReturn = DatabaseLair.DatabaseContext.Customers
				.First(m => m.ID == searchID);

			if (_entityToReturn == null)
			{
				Console.Clear();
				ServiceMessager.DataNotFoundMessage();
				return null;
			}

			return _entityToReturn;
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
		public static List<ICustomer> GetAll(bool getRelatedObjects, bool isInactive)
		{
			List<ICustomer> _listToReturn = null;
			if (DatabaseLair.DatabaseContext.Customers.Any(m => m.IsInactive == isInactive))
			{
				_listToReturn = DatabaseLair.DatabaseContext.Customers
				.Where(m => m.IsInactive == isInactive)
				.ToList<ICustomer>();
			}
			else
			{
				Console.Clear();
				ServiceMessager.DataNotFoundMessage();
				return _listToReturn;
			}
			return _listToReturn;
		}

		public static void Update(ICustomer entityToUpdate)
		{
			var existingEntity = DatabaseLair.DatabaseContext.Customers
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

		public static void Delete(ICustomer entityToDelete)
		{
			var existingEntity = DatabaseLair.DatabaseContext.Customers
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
				Thread.Sleep(2000);
				return;
			}
		}
	}
}
