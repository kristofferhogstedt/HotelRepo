using Hotel.src.FactoryManagement;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services.Interfaces;
using Hotel.src.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Services
{
    public class DataService<T> //: IDataService<T>, IInstantiable where T : class
    {
        //private static IInstantiable _instance;
        //private static readonly object _lock = new object(); // Lock object for thread safety
        //public IMenu PreviousMenu { get; set; }

        //private readonly DatabaseLair _databaseLair;
        //private readonly DbSet<T>? _dbSet;

        ///// <summary>
        ///// Single instance
        ///// </summary>
        ///// <returns></returns>
        //public static IDataService<T> GetInstance(IMenu previousMenu)
        //{
        //    _instance = InstanceGenerator.GetInstance<DataService<T>>(_instance, _lock, previousMenu);
        //    return (IDataService<T>)_instance;
        //}

        //public static void Create(T model)
        //{
        //    var _type = DatabaseLair.DatabaseContext.GetService<DbSet<T>>();

        //    try
        //    {
        //        _type.Add(model);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    finally
        //    {
        //        DatabaseLair.DatabaseContext.SaveChanges();
        //    }
        //}
        //public static List<T> ReadAll()
        //{
        //    var _type = DatabaseLair.DatabaseContext.GetService<DbSet<T>>();

        //    T _customerToReturn = _type
        //        .First(c => c.FirstName.Contains(searchString)
        //        || c.LastName.Contains(searchString));

        //    if (_customerToReturn == null)
        //    {
        //        Console.Clear();
        //        DataNotFoundMessage();
        //        return null;
        //    }

        //    return _customerToReturn;

        //}
        //public static T ReadOne()
        //{

        //}
        //public static void Update(T model)
        //{

        //}
    }
}