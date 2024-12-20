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
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoomType Type { get; set; }
        public string Floor { get; set; }
        public ushort NumberOfBeds { get; set; }

        public Room()
        {

        }
    }
}
