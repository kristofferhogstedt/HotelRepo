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
    public class RoomDetailController : IModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety
        public EModelType ModelType { get; set; } = EModelType.RoomDetail;

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

        public void ReadOne()
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

        public IModel GetOne()
        {
            throw new NotImplementedException();
        }

        public void Delete(IModel modelToDelete)
        {
            throw new NotImplementedException();
        }

        //public void CreateRoomType(string name, ushort defaultSize, ushort numberOfBedsDefault, ushort numberOfBedsMax)
        //{
        //    _roomType.Name = name;
        //    _roomType.DefaultSize = defaultSize;
        //    _roomType.NumberOfBedsDefault = numberOfBedsDefault;
        //    _roomType.NumberOfBedsMax = numberOfBedsMax;
        //}



    }
}
