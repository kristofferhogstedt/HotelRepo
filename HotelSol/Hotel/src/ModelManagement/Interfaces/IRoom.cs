using Hotel.src.ModelManagement.Models;

namespace Hotel.src.ModelManagement.Interfaces
{
    public interface IRoom
    {
        int ID { get; }
        string Name { get; set; }
        string Description { get; set; }
        //int BookingID { get; set; }
        RoomType Type { get; set; }
        string Floor { get; set; }
        ushort NumberOfBeds { get; set; }
    }
}
