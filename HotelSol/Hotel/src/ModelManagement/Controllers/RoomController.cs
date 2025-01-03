using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Selectors;

namespace Hotel.src.ModelManagement.Controllers
{
    public class RoomController : IRoomController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
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

        public IRoom GetOne()
        {
            IRoom _modelToReturn = RoomEntitySelector.Select(RoomService.GetAll(), 0, PreviousMenu);
            return _modelToReturn;
        }
    }
}
