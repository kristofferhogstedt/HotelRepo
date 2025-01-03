using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.FactoryManagement;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Controllers
{
    //public class ModelController<T> : IModelController, IInstantiable where T : new()
    //{
    //    public IMenu PreviousMenu { get; set; }
    //    public static IInstantiable _instance;
    //    private static readonly object _lock = new object(); // Lock object for thread safety

    //    public ModelController()
    //    {
    //    }

    //    /// <summary>
    //    /// Single instance
    //    /// </summary>
    //    /// <returns></returns>
    //    public static IModelController GetInstance(IMenu previousMenu)
    //    {
    //        _instance = InstanceGenerator.GetInstance<ModelController<T>>(_instance, _lock, previousMenu);
    //        return (IModelController)_instance;
    //    }

    //    public void Create()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ReadOne()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ReadAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(IModel modelToUpdate)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
