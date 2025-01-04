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
        public EModelType ModelType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            var _roomForm = ModelFactory.GetModelRegistrationForm(ModelType, PreviousMenu);
            IRoom _room = (IRoom)_roomForm.CreateForm();

            if (_room == null)
            {
                Console.WriteLine("Ingen data att spara, återgår...");
                Thread.Sleep(2000);
                return;
            }
            else
                RoomService.Create(_room);
        }

        public IModel BrowseOne()
        {
            IRoom _modelToReturn = RoomEntitySelector.Select(RoomService.GetAll(), 0, PreviousMenu);
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

        public void Update(IModel modelToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IModel modelToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
