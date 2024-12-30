using Hotel.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class Room : IRoom
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        //public RoomDetail RoomDetails { get; set; }
        public ERoomType Type { get; set; }
        public string Floor { get; set; }
        public ushort NumberOfBeds { get; set; }
        public bool IsActive { get; set; }
        public ushort Size { get; set; }
        public DateTime CleanedDate { get; set; }

        public Room()
        { 
        }

        public Room(ERoomType roomType)
        {
            Type = roomType;
        }
    }
}
