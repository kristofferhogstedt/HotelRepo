﻿using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class RoomType : IRoomType
    {
        [Key]
        public int ID { get; set; }

        //-------------------------------------
        public List<RoomDetails> RoomDetails { get; set; }
        //-------------------------------------

        public string Name { get; set; }
        private double _priceDefault;
        public double PriceDefault
        {
            get
            {
                return _priceDefault;
            }
            set
            {
                switch (Name)
                {
                    case "Single":
                        _priceDefault = 800;
                        break;
                    case "Double":
                        _priceDefault = 1000;
                        break;
                    case "Family":
                        _priceDefault = 1500;
                        break;
                    case "Suite":
                        _priceDefault = 2500;
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
        private int _sizeMax;
        public int SizeMax
        {
            get
            {
                return _sizeMax;
            }
            set
            {
                switch (Name)
                {
                    case "Single":
                        _sizeMax = 20;
                        break;
                    case "Double":
                        _sizeMax = 25;
                        break;
                    case "Family":
                        _sizeMax = 40;
                        break;
                    case "Suite":
                        _sizeMax = 60;
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
                        _numberOfBedsMax = 1;
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
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.RoomType;
        [NotMapped]
        public string Info => throw new NotImplementedException();

        //-------------------------------------

        public RoomType()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
