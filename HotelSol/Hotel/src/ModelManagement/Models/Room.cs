using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class Room : IRoom
    {
        [Key]
        public int ID { get; set; }
        //-------------------------------------
        [ForeignKey("Booking")]
        public List<Booking>? Bookings { get; set; }
        public RoomDetail Detail { get; set; }
        //-------------------------------------

        public string Name { get; set; }
        public string? Description { get; set; }
        public string Floor { get; set; }
        public DateTime? CleanedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelType { get; set; } = EModelType.Room;
        //-------------------------------------

        public Room()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
