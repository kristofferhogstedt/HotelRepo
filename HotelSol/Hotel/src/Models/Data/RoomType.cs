using Hotel.src.Models.Interfaces;

namespace Hotel.src.Models.Data
{
    public class RoomType : IRoomType
    {
        public int ID { get; }
        public string TypeName { get; set; }
        public ushort NumberOfBedsDefault { get; set; }
        public ushort NumberOfBedsMax { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
