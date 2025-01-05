﻿using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Hotel.src.ModelManagement.Models
{
    public class Booking : IBooking
    {
        [Key]
        public int ID { get; set; }

        //-------------------------------------
        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int RoomID { get; set; }
        public Room Room { get; set; }
        [Required]
        public Invoice Invoice { get; set; }
        //-------------------------------------
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.Booking;
        [NotMapped]
        public string Info => $"ID: {ID}, Fråndatum: {FromDate}, Tilldatum: {ToDate}";
        [NotMapped]
        public int StayLength 
        { 
            get
            {
                return DateTime.Compare(ToDate, FromDate);
            }
        }
        //-------------------------------------

        public Booking()
        {
            CreatedDate = DateTime.Now;
        }

        public Booking(Room room, Customer customer, DateTime fromDate, DateTime toDate, Invoice invoice)
        {
            Room = room;
            Customer = customer;
            FromDate = fromDate;
            ToDate = toDate;
            Invoice = invoice;
            CreatedDate = DateTime.Now;
        }
    }
}
