using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers
{
    public class InvoiceController : IModelController, IInvoiceController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelTypeEnum { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        public InvoiceController() 
        {
        }

        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<InvoiceController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            throw new NotImplementedException();
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
