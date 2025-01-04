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

        //-------------------------------------
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }

        [ForeignKey("RoomType")]
        [Required]
        public int RoomTypeID { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        //-------------------------------------

        public int Size { get; set; }
        public int NumberOfBeds { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.RoomDetail;

        [NotMapped]
        public string Info => throw new NotImplementedException();

        //-------------------------------------

        public RoomDetail()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
