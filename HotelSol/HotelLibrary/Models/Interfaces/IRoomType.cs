using HotelLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.Interfaces
{
    public interface IRoomType
    {
        int ID { get; }
        string TypeName { get; set; }
        string Description { get; set; }
        ushort NumberOfBedsDefault { get; set; }
        ushort NumberOfBedsMax { get; set; }
    }
}
