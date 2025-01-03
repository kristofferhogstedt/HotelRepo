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
        public static RoomDetailController _instance;
        IRoomDetail _roomType;

        public RoomDetailController()
        {
        }

        public static RoomDetailController GetInstance()
        {
            if (_instance == null)
                _instance = new RoomDetailController();
            return _instance;
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
