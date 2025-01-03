using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers
{
    public class RoomDetailController
    {
        public IMenu PreviousMenu { get; set; }
        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        public RoomDetailController()
        {
        }

        public static IModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<CustomerController>(_instance, _lock, previousMenu);
            return (IModelController)_instance;
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
