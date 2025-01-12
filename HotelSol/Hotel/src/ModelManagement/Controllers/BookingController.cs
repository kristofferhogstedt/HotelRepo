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
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Controllers
{
    public class BookingController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object(); 
        public EModelType ModelTypeEnum { get; set; } = EModelType.Booking;
        public bool GetRelatedObjects { get; set; } = true;

        public BookingController()
        {
        }

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<BookingController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.CreateForm();
        }

        public void Create(IModel entityToCreate)
        {
            BookingService.Create((IBooking)entityToCreate);
        }

        public IModel BrowseOne(bool isInactive)
        {
            List<IBooking> _listToBrowse = new List<IBooking>();
            foreach (IBooking e in BookingService.GetAll(GetRelatedObjects, isInactive))
                _listToBrowse.Add(e);

            var _modelToReturn = BookingEntitySelector.Select(_listToBrowse, 0, PreviousMenu);
            return _modelToReturn;
        }

        public void ManageOne(bool isInactive)
        {
            var _model = BrowseOne(isInactive);
            Console.Clear();
            BookingDisplayer.DisplayModel(_model);
            Console.WriteLine("Vad vill du göra?");

            var _crudMenu = ModelCRUDMenu.GetInstance(PreviousMenu);
            _crudMenu.Run((IModel)_model);
        }

        public void ReadAll(bool isInactive)
        {
            List<IBooking> _listToDisplay = new List<IBooking>();
            foreach (IBooking e in BookingService.GetAll(GetRelatedObjects, isInactive))
            {
                _listToDisplay.Add(e);
            }
            BookingDisplayer.DisplayModelTable(_listToDisplay);
        }

        public void Update(bool isInactive)
        {
            var _modelToUpdate = BrowseOne(isInactive);

            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.EditForm((IModel)_modelToUpdate);
        }

        public void Update(IModel entityToUpdate)
        {
            var _modelToUpdate = entityToUpdate;

            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.EditForm((IModel)_modelToUpdate);
        }

        public void Delete(IModel entityToDelete)
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.InactivateForm((IModel)entityToDelete);
        }

        public void Reactivate(IModel entityToReactivate)
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            if (DatabaseLair.DatabaseContext.Bookings.Any(b => b.IsInactive == true))
                _modelForm.ReactivateForm((IModel)entityToReactivate);
            else
            {
                Console.WriteLine("Inga inaktiva finns");
                Thread.Sleep(2000);
            }
        }
    }
}
