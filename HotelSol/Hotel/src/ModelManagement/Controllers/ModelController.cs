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
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Services;
using System.Reflection.Metadata;

namespace Hotel.src.ModelManagement.Controllers
{
    // NOT IN USE
    public class ModelController<T> : IModelController, IInstantiable where T : IControllableModel
    {
        public IMenu PreviousMenu { get; set; }
        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public EModelType ModelTypeEnum { get; set; }

        Type TypeOfT { get; set; } = typeof(T);
        Type ModelTypeOfT { get; set; } 
        object ServiceTypeOfT { get; set; } 
        //public var InterfaceOfT { get; set; } = typeof(T).GetInterfaces().FirstOrDefault();


        public ModelController()
        {
            ServiceTypeOfT = TypeOfT.GetProperty("ServiceType")?.GetValue(null);
            //ServiceTypeOfT = TypeOfT.GetProperties().Where(t => t.Name == "ServiceType").FirstOrDefault();

        }

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<ModelController<T>>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            IModel _entity = (IModel)_modelForm.CreateForm();

            if (_entity == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }

            //ServiceTypeOfT.Create(_entity);
        }

        public void ManageOne()
        {
            throw new NotImplementedException();
        }

        public void ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Update(IModel modelToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IModel BrowseOne()
        {
            throw new NotImplementedException();
        }

        public void Delete(IModel modelToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
