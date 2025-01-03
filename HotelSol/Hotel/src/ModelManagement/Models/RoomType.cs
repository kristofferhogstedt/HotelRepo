using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomType : IRoomType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        private int _sizeDefault;
        public int SizeDefault
        {
            get
            {
                return _sizeDefault;
            }
            set
            {
                switch (Name)
                {
                    case "Single":
                        _sizeDefault = 15;
                        break;
                    case "Double":
                        _sizeDefault = 20;
                        break;
                    case "Family":
                        _sizeDefault = 30;
                        break;
                    case "Suite":
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
                switch (Name)
                {
                    case "Single":
                        _numberOfBedsDefault = 1;
                        break;
                    case "Double":
                        _numberOfBedsDefault = 2;
                        break;
                    case "Family":
                        _numberOfBedsDefault = 4;
                        break;
                    case "Suite":
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
                switch (Name)
                {
                    case "Single":
                        _numberOfBedsMax = 2;
                        break;
                    case "Double":
                        _numberOfBedsMax = 4;
                        break;
                    case "Family":
                        _numberOfBedsMax = 6;
                        break;
                    case "Suite":
                        _numberOfBedsMax = 6;
                        break;
                }
            }
        }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        public RoomType()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
