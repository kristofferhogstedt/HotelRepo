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
        public string Info => $"{RoomType.Name}     {Price} sek      {Size} m2          {NumberOfBeds} st";

        //-------------------------------------

        public RoomDetails()
        {
            CreatedDate = DateTime.Now;
        }
        public RoomDetails(IRoomType roomType, int roomTypeID, IRoom room, int roomID, int size, int numberOfBeds, double price)
        {
            RoomType = (RoomType)roomType;
            RoomTypeID = roomTypeID;
            Room = (Room)room;
            RoomID = roomID;
            Size = size;
            NumberOfBeds = numberOfBeds;
            Price = price;
            CreatedDate = DateTime.Now;
		}
		public RoomDetails(IRoomType roomType, int roomTypeID, int size, int numberOfBeds, double price)
		{
			RoomType = (RoomType)roomType;
			RoomTypeID = roomTypeID;
			Size = size;
			NumberOfBeds = numberOfBeds;
			Price = price;
			CreatedDate = DateTime.Now;
		}
	}
}
