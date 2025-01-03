using System.ComponentModel.DataAnnotations;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IBooking
    {
        int ID { get; set; }
        [Required]
        Customer CustomerID { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
