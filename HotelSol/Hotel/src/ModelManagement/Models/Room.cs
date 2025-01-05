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
        public List<Booking>? Bookings { get; set; }
        public RoomDetails Details { get; set; }
        //-------------------------------------

        public string Name { get; set; }
        public string? Description { get; set; }
        public int Floor { get; set; }
        public DateTime? CleanedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.Room;

        [NotMapped]
        public string Info => $"Rumsnummer {Name}, Beskrivning: {Description}, Våning: {Floor}";

        //-------------------------------------

        public Room()
        {
            CreatedDate = DateTime.Now;
        }
        public Room(string name, string description, int floor, RoomDetails roomDetails)
        {
            Name = name;
            Description = description; 
            Floor = floor;
            Details = roomDetails;
            CreatedDate = DateTime.Now;
        }
    }
}
