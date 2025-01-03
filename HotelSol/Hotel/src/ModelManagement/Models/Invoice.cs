using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Invoice : IInvoice
    {
        public int ID { get; set; }
        public Booking BookingID { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        public Invoice()
        {
            CreatedDate = new DateTime();
            CreatedDate = DateTime.Now;

            DueDate = new DateTime();
            DueDate = DateTime.Now.AddDays(30);
        }
    }
}
