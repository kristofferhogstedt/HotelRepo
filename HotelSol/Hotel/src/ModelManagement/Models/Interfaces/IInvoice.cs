namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IInvoice
    {
        int ID { get; set; }
        Booking BookingID { get; set; }
        double Amount { get; set; }
        DateTime DueDate { get; set; }
        bool IsPaid { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
