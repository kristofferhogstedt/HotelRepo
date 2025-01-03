using Hotel.Enums;
using System.Drawing;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomDetail
    {
        int ID { get; set; }
        string TypeID { get; set; }
        int Size { get; set; }
        int NumberOfBeds { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
