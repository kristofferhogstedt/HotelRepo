using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomType : IRoomType
    {
        [Key]
        public ERoomType ID { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                switch (ID)
                {
                    case ERoomType.Single:
                        _name = "Singelrum";
                        break;
                    case ERoomType.Double:
                        _name = "Dubbelrum";
                        break;
                    case ERoomType.Family:
                        _name = "Familjerum";
                        break;
                    case ERoomType.Suite:
                        _name = "Lyxsvit";
                        break;
                }
            }
        }

        private int _sizeDefault;
        public int SizeDefault
        {
            get
            {
                return _sizeDefault;
            }
            set
            {
                switch (ID)
                {
                    case ERoomType.Single:
                        _sizeDefault = 15;
                        break;
                    case ERoomType.Double:
                        _sizeDefault = 25;
                        break;
                    case ERoomType.Family:
                        _sizeDefault = 30;
                        break;
                    case ERoomType.Suite:
                        _sizeDefault = 45;
                        break;
                }
            }
        }

        private int _numberOfBedsDefault;
        public int NumberOfBedsDefault
        {
            get
            {
                return _numberOfBedsDefault;
            }
            set
            {
                switch (ID)
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

        private int _numberOfBedsMax;
        public int NumberOfBedsMax
        {
            get
            {
                return _numberOfBedsMax;
            }
            set
            {
                switch (ID)
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
