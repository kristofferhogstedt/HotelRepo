using Hotel.Enums;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomDetail
    {
        int ID { get; set; }
        string Name { get; set; }
        ERoomType Type { get; set; }
        ushort DefaultSize { get; set; }
        ushort NumberOfBedsDefault { get; set; }
        ushort NumberOfBedsMax { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
