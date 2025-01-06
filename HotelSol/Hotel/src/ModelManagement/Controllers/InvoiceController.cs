using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Displayers;
using Hotel.src.ModelManagement.Utilities.Selectors;

namespace Hotel.src.ModelManagement.Controllers
{
    public class InvoiceController : IModelController, IInvoiceController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelTypeEnum { get; set; } = EModelType.Invoice;

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

        public void Create(IModel entityToCreate)
        {
            InvoiceService.Create((IInvoice)entityToCreate);
        }

        public IModel BrowseOne(bool isInactive)
        {
            List<IInvoice> _ListToBrowse = new List<IInvoice>();
            foreach (IInvoice e in InvoiceService.GetAll(isInactive))
                _ListToBrowse.Add(e);
            IInvoice _modelToReturn = InvoiceEntitySelector.Select(_ListToBrowse, 0, PreviousMenu);
            return _modelToReturn;
        }

        public void ManageOne(bool isInactive)
        {
            var _invoice = (IInvoice)BrowseOne(isInactive);
            Console.Clear();
            InvoiceDisplayer.DisplayModel(_invoice);
            Console.WriteLine("Vad vill du göra?");

            var _crudMenu = ModelCRUDMenu.GetInstance(PreviousMenu);
            _crudMenu.Run((IModel)_invoice);
        }

        public void ReadAll(bool isInactive)
        {
            InvoiceDisplayer.DisplayModelTable(InvoiceService.GetAll(isInactive));
        }

        public void Update(IModel entityToUpdate)
        {
            var _entityToUpdate = entityToUpdate;

            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.EditForm((IModel)_entityToUpdate);
            //IInvoice _Entity = (IInvoice)_modelForm.EditForm((IModel)_entityToUpdate);

            //if (_Entity == null)
            //{
            //    Console.WriteLine("Ingen data att spara, återgår...");
            //    Thread.Sleep(2000);
            //    return;
            //}
            //else
            //    InvoiceService.Update(_Entity);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }


        public void Delete(IModel entityToDelete)
        {
            InvoiceService.Delete((IInvoice)entityToDelete);
        }
    }
}
