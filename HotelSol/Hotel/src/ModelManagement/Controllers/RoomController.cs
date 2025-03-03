﻿using Hotel.src.FactoryManagement;
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
    public class RoomController : IModelController, IInstantiable, IRoomController
    {
        public IMenu PreviousMenu { get; set; }
        public EModelType ModelTypeEnum { get; set; } = EModelType.Room;

        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public bool GetRelatedObjects { get; set; } = true;

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
            _roomForm.CreateForm();
        }
        public void Create(IModel entityToCreate)
        {
            RoomService.Create((IRoom)entityToCreate);
        }

        public IModel BrowseOne(bool isInactive)
        {
            List<IRoom> _ListToBrowse = new List<IRoom>();
            foreach (IRoom e in RoomService.GetAll(GetRelatedObjects, isInactive))
                _ListToBrowse.Add(e);
            IRoom _modelToReturn = RoomEntitySelector.Select(_ListToBrowse, 0, PreviousMenu);
            return _modelToReturn;
        }

        public void ManageOne(bool isInactive)
        {
            var _room = (IRoom)BrowseOne(isInactive);
            Console.Clear();
            RoomDisplayer.DisplayModel(_room);
            Console.WriteLine("Vad vill du göra?");

            var _crudMenu = ModelCRUDMenu.GetInstance(PreviousMenu);
            _crudMenu.Run((IModel)_room);
        }

        public void ReadAll(bool IsInactive)
        {
            throw new NotImplementedException();
        }

        public void Update(IModel entityToUpdate)
        {
            var _entityToUpdate = entityToUpdate;

            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.EditForm((IModel)_entityToUpdate);
        }

        public void UpdateBeds(IModel entityToUpdate)
        {
            var _entityToUpdate = entityToUpdate;
            var _roomBedModelTypeEnum = EModelType.RoomBed;

            var _modelForm = ModelFactory.GetModelRegistrationForm(_roomBedModelTypeEnum, PreviousMenu);
            _modelForm.EditForm((IModel)_entityToUpdate);
        }

        public void Delete(IModel entityToDelete)
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            _modelForm.InactivateForm((IModel)entityToDelete);
        }
        public void Reactivate(IModel entityToReactivate)
        {
            var _modelForm = ModelFactory.GetModelRegistrationForm(ModelTypeEnum, PreviousMenu);
            if (DatabaseLair.DatabaseContext.Rooms.Any(b => b.IsInactive == true))
                _modelForm.ReactivateForm((IModel)entityToReactivate);
            else
            {
                Console.WriteLine("Inga inaktiva finns");
                Thread.Sleep(2000);
            }
        }
    }
}
