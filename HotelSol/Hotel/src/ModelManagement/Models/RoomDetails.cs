using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomDetails : IRoomDetails
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

        public double Price { get; set; }
        public int Size { get; set; }
        public int NumberOfBeds { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.RoomDetails;

        [NotMapped]
        public string Info => throw new NotImplementedException();

        //-------------------------------------

        public RoomDetails()
        {
            CreatedDate = DateTime.Now;
        }
        public RoomDetails(IRoomType roomType, int size, int numberOfBeds)
        {
            RoomType = (RoomType)roomType;
            Size = size;
            NumberOfBeds = numberOfBeds;
            CreatedDate = DateTime.Now;
        }
    }
}
