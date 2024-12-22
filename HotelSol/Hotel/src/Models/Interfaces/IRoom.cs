using Hotel.src.Models.Data;

namespace Hotel.src.Models.Interfaces
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
