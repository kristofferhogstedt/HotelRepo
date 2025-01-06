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
    public class RoomController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelTypeEnum { get; set; } = EModelType.Room;

        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        public RoomController()
        {
        }

        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<RoomController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            var _roomForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            //IRoom _room = (IRoom)
            _roomForm.CreateForm();

            //if (_room == null)
            //{
            //    Console.WriteLine("Ingen data att spara, återgår...");
            //    Thread.Sleep(2000);
            //    return;
            //}
            //else
            //    RoomService.Create(_room);
        }
        public void Create(IModel entityToCreate)
        {
            RoomService.Create((IRoom)entityToCreate);
        }

        public IModel BrowseOne()
        {
            List<IRoom> _ListToBrowse = new List<IRoom>();
            foreach (IRoom e in RoomService.GetAll())
                _ListToBrowse.Add(e);
            IRoom _modelToReturn = RoomEntitySelector.Select(_ListToBrowse, 0, PreviousMenu);
            return _modelToReturn;
        }

        public void ManageOne()
        {
            var _room = (IRoom)BrowseOne();
            Console.Clear();
            RoomDisplayer.DisplayModel(_room);
            Console.WriteLine("Vad vill du göra?");

            var _crudMenu = ModelCRUDMenu.GetInstance(PreviousMenu);
            _crudMenu.Run((IModel)_room);
        }

        public void ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(IModel entityToUpdate)
        {
            var _entityToUpdate = entityToUpdate;

            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.EditForm((IModel)_entityToUpdate);
            //IRoom _Entity = (IRoom)_modelForm.EditForm((IModel)_entityToUpdate);

            //if (_Entity == null)
            //{
            //    Console.WriteLine("Ingen data att spara, återgår...");
            //    Thread.Sleep(2000);
            //    return;
            //}
            //else
            //    RoomService.Update(_Entity);
        }

        public void Delete(IModel modelToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
