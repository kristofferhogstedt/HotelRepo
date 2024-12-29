using Hotel.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class Room : IRoom
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoomType RoomType { get; set; }
        public string Floor { get; set; }
        public ushort NumberOfBeds { get; set; }

        [NotMapped]
        private ushort _size;
        public ushort Size 
        {
            get
            {
                return _size;
            }
            set
            {
                switch (RoomType.Type)
                {
                    case ERoomType.Single:
                        Size = 20;
                        break;
                    case ERoomType.Double:
                        Size = 35;
                        break;
                    case ERoomType.Family:
                        Size = 50;
                        break;
                    case ERoomType.Suite:
                        Size = 60;
                        break;
                }
            }
        }
        public DateTime CleanedDate { get; set; }

        public Room()
        {

        }
    }
}
