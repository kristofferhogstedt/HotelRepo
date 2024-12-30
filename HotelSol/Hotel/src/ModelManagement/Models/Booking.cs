using Hotel.src.ModelManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hotel.src.ModelManagement.Models
{
    public class Booking : IBooking
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int EmployeeID { get; set; }
        public bool IsActive { get; set; }
    }
}
