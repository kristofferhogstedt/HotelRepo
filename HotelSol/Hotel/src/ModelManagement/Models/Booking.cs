using Hotel.src.ModelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hotel.src.ModelManagement.Models
{
    public class Booking : IBooking
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
