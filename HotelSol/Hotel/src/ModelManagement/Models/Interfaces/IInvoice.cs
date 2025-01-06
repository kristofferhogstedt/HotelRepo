using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IInvoice : IModel
    {
        int ID { get; set; }
        int BookingID { get; set; }
        Booking Booking { get; set; }
        double Amount { get; set; }
        DateTime DueDate { get; set; }
        bool IsPaid { get; set; }
        DateTime? PaidDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public string Info { get; }
    }
}
