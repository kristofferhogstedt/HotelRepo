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
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public string RoomType { get; set; }
        public string Floor { get; set; }
    }
}
