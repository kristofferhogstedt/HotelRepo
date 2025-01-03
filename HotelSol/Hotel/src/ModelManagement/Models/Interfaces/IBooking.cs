using System.ComponentModel.DataAnnotations;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IBooking
    {
        [Key]
        int ID { get; set; }

        [Required]
        int CustomerID { get; set; }
        int RoomID { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        bool IsActive { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        DateTime? InactivatedDate { get; set; }
    }
}
