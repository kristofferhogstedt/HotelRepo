using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models
{
    public class RoomType : IRoomType
    {
        public int ID { get; }
        public string TypeName { get; set; }
        public ushort NumberOfBedsDefault { get; set; }
        public ushort NumberOfBedsMax { get; set; }
    }
}
