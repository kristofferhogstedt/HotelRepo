using Hotel.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomDetail : IRoomDetail
    {
        public int ID { get; set; }
        public ERoomType Type { get; set; }

        private string _name;
        public string Name 
        { 
            get
            {
                return _name;
            }
            set
            {
                switch (Type)
                {
                    case ERoomType.Single:
                        _name = "Enkelrum";
                        break;
                    case ERoomType.Double:
                        _name = "Dubbelrum";
                        break;
                    case ERoomType.Family:
                        _name = "Familjerum";
                        break;
                    case ERoomType.Suite:
                        _name = "Lyxsvit'n";
                        break;
                }
            }
        }

        private ushort _defaultSize;
        public ushort DefaultSize
        {
            get
            {
                return _defaultSize;
            }
            set
            {
                switch (Type)
                {
                    case ERoomType.Single:
                        DefaultSize = 20;
                        break;
                    case ERoomType.Double:
                        DefaultSize = 35;
                        break;
                    case ERoomType.Family:
                        DefaultSize = 50;
                        break;
                    case ERoomType.Suite:
                        DefaultSize = 60;
                        break;
                }
            }
        }

        private ushort _numberOfBedsDefault;
        public ushort NumberOfBedsDefault 
        { 
            get
            {
                return _numberOfBedsDefault;
            }
            set
            {
                switch (Type)
                {
                    case ERoomType.Single:
                        _numberOfBedsDefault = 1;
                        break;
                    case ERoomType.Double:
                        _numberOfBedsDefault = 2;
                        break;
                    case ERoomType.Family:
                        _numberOfBedsDefault = 4;
                        break;
                    case ERoomType.Suite:
                        _numberOfBedsDefault = 2;
                        break;
                }
            }
        }

        private ushort _numberOfBedsMax;
        public ushort NumberOfBedsMax
        {
            get
            {
                return _numberOfBedsMax;
            }
            set
            {
                switch (Type)
                {
                    case ERoomType.Single:
                        _numberOfBedsDefault = 2;
                        break;
                    case ERoomType.Double:
                        _numberOfBedsDefault = 4;
                        break;
                    case ERoomType.Family:
                        _numberOfBedsDefault = 6;
                        break;
                    case ERoomType.Suite:
                        _numberOfBedsDefault = 6;
                        break;
                }
            }
        }

        public RoomDetail(ERoomType roomType)
        {
            Type = roomType;
        }
    }
}
