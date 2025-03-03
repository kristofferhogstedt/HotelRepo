﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IBooking : IModel
    {
        [Key]
        int ID { get; set; }

        //-------------------------------------
        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        public Room Room { get; set; }
        [Required]
        public Invoice Invoice { get; set; }
        //-------------------------------------

        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public string Info { get; }
        [NotMapped]
        int StayLength { get; }
    }
}
