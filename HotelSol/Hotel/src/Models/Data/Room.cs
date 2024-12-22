using Hotel.src.Models.Interfaces;

namespace Hotel.src.Models.Data
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
