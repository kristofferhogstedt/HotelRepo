using Hotel.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Room : IRoom
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ERoomType RoomType { get; set; }
        public string Floor { get; set; }
        public ushort NumberOfBeds { get; set; }
        public ushort Size { get; set; }
        public DateTime CleanedDate { get; set; }

        public Room()
        {

        }
    }
}
