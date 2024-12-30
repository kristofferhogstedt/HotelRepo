using Hotel.Enums;
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
    public class RoomController : IRoomController
    {
        public static IRoomController _instance;
        IRoom _room;

        public RoomController()
        {
        }

        public RoomController(IRoom room)
        {
            _room = room;
        }

        public static IRoomController GetInstance()
        {
            if (_instance == null)
                _instance = new RoomController();
            return _instance;
        }
    }
}
