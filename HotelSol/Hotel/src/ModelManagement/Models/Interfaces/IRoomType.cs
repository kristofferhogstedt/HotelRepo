using Hotel.Enums;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomType
    {
        int ID { get; }
        string Name { get; set; }
        ERoomType Type { get; set; }
        ushort NumberOfBedsDefault { get; set; }
        ushort NumberOfBedsMax { get; set; }
    }
}
