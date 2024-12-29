using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Invoice : IInvoice
    {
        public int ID { get; set; }
        public int BookingID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }

        public Invoice()
        {
            CreateDate = new DateTime();
            CreateDate = DateTime.Now;

            DueDate = new DateTime();
            DueDate = DateTime.Now.AddDays(30);
        }
    }
}
