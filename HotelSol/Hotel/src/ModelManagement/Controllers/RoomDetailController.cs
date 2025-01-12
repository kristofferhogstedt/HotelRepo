using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;

namespace Hotel.src.ModelManagement.Controllers
{
    public class RoomDetailController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public EModelType ModelTypeEnum { get; set; } = EModelType.RoomDetails;

        public RoomDetailController()
        {
        }

        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<RoomDetailController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Create(IModel entityToCreate)
        {
            RoomDetailsService.Create((IRoomDetails)entityToCreate);
        }

        public void ManageOne(bool IsInactive)
        {
            throw new NotImplementedException();
        }

        public void ReadAll(bool IsInactive)
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

        public IModel BrowseOne(bool IsInactive)
        {
            throw new NotImplementedException();
        }

        public void Delete(IModel entityToDelete)
        {
            RoomDetailsService.Delete((IRoomDetails)entityToDelete);
        }

        public void Reactivate(IModel modelToReactivate)
        {
            throw new NotImplementedException();
        }
    }
}
