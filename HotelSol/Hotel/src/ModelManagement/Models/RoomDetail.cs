using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomDetail : IRoomDetail
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("RoomID")]
        public int RoomID { get; set; }

        [ForeignKey("RoomType")]
        public ERoomType TypeID { get; set; }

        public int Size { get; set; }
        public int NumberOfBeds { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        public RoomDetail()
        {
            //TypeID = roomType;
        }
    }
}
