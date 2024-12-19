using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models
{
    internal class Room : IRoom
    {
        public int RoomId { get; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public IRoomType RoomType { get; set; }
        public string Floor { get; set; }
        public Room()
        {

        }
    }
}
