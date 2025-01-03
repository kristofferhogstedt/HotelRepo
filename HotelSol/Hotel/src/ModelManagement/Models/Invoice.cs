using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Invoice : IInvoice
    {
        public int ID { get; set; }
        public int BookingID { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        public Invoice()
        {
            //CreatedDate = new DateTime();
            CreatedDate = DateTime.Now;

            //Due/*Date = new DateTime();*/
            DueDate = CreatedDate.AddDays(30);
        }
    }
}
