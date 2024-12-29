using Hotel.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomType : IRoomType
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
                        _name = "Single";
                        break;
                    case ERoomType.Double:
                        _name = "Double";
                        break;
                    case ERoomType.Family:
                        _name = "Familj";
                        break;
                    case ERoomType.Suite:
                        _name = "Lyxsvit'n";
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
    }
}
