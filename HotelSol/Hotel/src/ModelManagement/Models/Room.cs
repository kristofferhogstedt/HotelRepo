using Hotel.src.ModelManagement.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Room : IRoom
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
