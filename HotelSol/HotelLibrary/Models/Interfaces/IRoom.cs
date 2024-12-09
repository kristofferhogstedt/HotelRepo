using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.Interfaces
{
    public interface IRoom
    {
        int RoomId { get; set; }
        string RoomName { get; set; }
        string RoomDescription { get; set; }
        string RoomType { get; set; }
        string Floor { get; set; }
    }
}
