using Hotel.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomDetail : IRoomDetail
    {
        public int ID { get; set; }
        public string Type { get; set; }
        int Size { get; set; }
        int NumberOfBeds { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        public RoomDetail(ERoomType roomType)
        {
            Type = roomType;
        }
    }
}
