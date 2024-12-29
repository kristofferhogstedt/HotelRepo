using Hotel.Enums;
using Hotel.src.ModelManagement.Models;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoom
    {
        int ID { get; }
        string Name { get; set; }
        string Description { get; set; }
        ERoomType RoomType { get; set; }
        string Floor { get; set; }
        ushort NumberOfBeds { get; set; }
        ushort Size { get; set; }
        DateTime CleanedDate { get; set; }
    }
}
