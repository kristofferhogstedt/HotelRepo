using Hotel.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomType : IRoomType
    {
        public int ID { get; set; }
        string Name { get; set; }
        int Size { get; set; }

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
                        _numberOfBedsDefault = 2;
                        break;
                    case "Double":
                        _numberOfBedsDefault = 4;
                        break;
                    case "Family":
                        _numberOfBedsDefault = 6;
                        break;
                    case "Suite":
                        _numberOfBedsDefault = 6;
                        break;
                }
            }
        }
    }
}
