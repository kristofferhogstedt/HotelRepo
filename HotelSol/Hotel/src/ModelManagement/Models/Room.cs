using Hotel.Enums;
using Hotel.src.ModelManagement.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Room : IRoom
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ERoomType RoomType { get; set; }
        public string Floor { get; set; }
        private ushort _numberOfBeds;
        public ushort NumberOfBeds 
        {
            get
            { 
                return _numberOfBeds; 
            } 
            set
            {
                
            }
        }

        private int _size;
        public int Size
        {
            get { return _size; }
            init
            {
                switch (RoomType)
                {
                    case ERoomType.Single:
                        _size = 20;
                        break;
                    case ERoomType.Double:
                        _size = 35;
                        break;
                    case ERoomType.Family:
                        _size = 50;
                        break;
                    case ERoomType.Suite:
                        _size = 60;
                        break;
                }
            }
        }

        public Room()
        {

        }
    }
}
