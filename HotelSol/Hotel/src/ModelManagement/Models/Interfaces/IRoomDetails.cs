using Hotel.src.ModelManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomDetails : IModel
    {
        [Key]
        int ID { get; set; }

        //-------------------------------------
        [ForeignKey("Room")]
        [Required]
        public int RoomID { get; set; }
        [Required]
        public Room Room { get; set; }

        [ForeignKey("RoomType")]
        [Required]
        public int RoomTypeID { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        //-------------------------------------

        int Size { get; set; }
        int NumberOfBeds { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
